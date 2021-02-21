using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using System.Linq;
using Newtonsoft.Json;
using MongoDB.Bson.IO;
using System.Web;
using static BBALL.LIB.Helpers.ParameterHelper;
using System.Collections.Specialized;

namespace BBALL.LIB.Helpers
{
    public static class DatabaseHelper
    {
        public static BsonDocument UpdateDatabase(string collection, JArray parameters)
        {
            try
            {
                var url = StatsHelper.BaseURL + collection + "/";

                return UpdateDatabase(url, collection, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(collection + " failed. Check log.");
                ErrorDocument(ex, "UpdateDatabase", "", collection, parameters);
                return null;
            }
        }

        /// <summary>
        /// Create a collection if it does not exist. Insert or replace a document to the collection.
        /// </summary>
        /// <param name="url">The stats API url</param>
        /// <param name="collection">The name of the collection</param>
        public static BsonDocument UpdateDatabase(string url, string collection, JArray parameters = null, bool parse = true, int timeout = 15)
        {
            try
            {
                if(parameters == null)
                {
                    var queryString = HttpUtility.ParseQueryString(url);

                    foreach (var item in queryString.AllKeys)
                    {
                        parameters.Add(CreateParameterObject(item, queryString[item]));
                    }
                }
                else
                {
                    url = StatsHelper.GenerateUrl(url, parameters);
                }

                //get the data from stats.nba.com
                JObject response = JObject.Parse(StatsHelper.API(url, timeout).Result);

                JObject statDocument = new JObject();
                foreach (JObject parameter in parameters)
                {
                    var val = parameter["Value"].ToString();
                    statDocument.Add(parameter["Key"].ToString(), val == "" ? null : val);
                }

                //JObject statDocument = response["parameters"].ToObject<JObject>();

                if (parse)
                {
                    JArray statResultSets = response["resultSets"].ToObject<JArray>();
                    
                    //create data object
                    JArray results = new JArray();
                    for (int resultIndex = 0; resultIndex < statResultSets.Count; resultIndex++)
                    {
                        JObject resultObject = new JObject();
                        var resultSet = statResultSets[resultIndex];
                        var name = resultSet["name"].ToString();
                        var headers = resultSet["headers"].ToObject<JArray>();
                        var rowSet = resultSet["rowSet"].ToObject<JArray>();

                        JArray dataArray = new JArray();
                        for (int rowIndex = 0; rowIndex < rowSet.Count; rowIndex++)
                        {
                            JObject dataObject = new JObject();
                            var row = rowSet[rowIndex];

                            for (int headerIndex = 0; headerIndex < headers.Count; headerIndex++)
                            {
                                var header = headers[headerIndex];

                                dataObject.Add(header.ToString(), row[headerIndex]);
                            }

                            dataArray.Add(dataObject);
                        }

                        resultObject.Add("name", name);
                        resultObject.Add("data", dataArray);
                        results.Add(resultObject);
                    }
                    //add the results to the new document
                    statDocument.Add("resultSets", results);
                }
                else
                {
                    JObject statResultSets = response["resultSets"].ToObject<JObject>();

                    statDocument.Add("resultSets", statResultSets);
                }

                //convert the stat document to bson
                var document = BsonSerializer.Deserialize<BsonDocument>(statDocument.ToString());

                AddUpdateDocument(collection, document, parameters);

                return document;
            }
            catch (Exception ex)
            {
                Console.WriteLine(url + " failed. Check log.");
                ErrorDocument(ex, "UpdateDatabase", url, collection, parameters);
                return null;
            }
        }

        /// <summary>
        /// Generate an error document to be logged for issues
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <param name="url">The queried url.</param>
        /// <param name="collection">The database collection.</param>
        /// <param name="parameters">The query parameters.</param>
        public static void ErrorDocument(Exception exception, string method, string url, string collection, JArray parameters = null)
        {
            try
            {
                BsonDocument errorDocument = new BsonDocument();
                errorDocument.Add(new BsonElement("Method", method));
                errorDocument.Add(new BsonElement("URL", url));
                errorDocument.Add(new BsonElement("Collection", collection));
                errorDocument.Add(new BsonElement("Message", exception.Message));
                errorDocument.Add(new BsonElement("StackTrace", exception.StackTrace));
                errorDocument.Add(new BsonElement("Source", exception.Source));
                errorDocument.Add(new BsonElement("Timestamp", String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now)));

                AddUpdateDocument("errorlog", errorDocument, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void AddUpdateDocument(string collection, BsonDocument document, JArray parameters)
        {
            try
            {
                //create a filter to be used later
                FilterDefinition<BsonDocument> filter = CreateFilterDefinition(parameters);

                //connect to the database
                var dbClient = new MongoClient("mongodb://127.0.0.1:27017");
                IMongoDatabase db = dbClient.GetDatabase("bball");

                //check if the collection exists
                if (!CollectionExists(db, collection))
                {
                    //create the collection if it does not exist
                    db.CreateCollection(collection);
                }

                //get the database collection
                var dbCollection = db.GetCollection<BsonDocument>(collection);

                //find the existing document
                var exisintgDocument = dbCollection.Find(filter).FirstOrDefault();

                if(document == null)
                {
                    Console.WriteLine("Document empty.");
                }
                else
                {
                    if (exisintgDocument == null)
                    {
                        //insert a new document if it does not exist
                        dbCollection.InsertOne(document);
                        Console.WriteLine(collection + " inserted.");
                    }
                    else
                    {
                        //replace the document if it does exist
                        dbCollection.ReplaceOne(filter, document);
                        Console.WriteLine(collection + " replaced.");
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Get document as a JObject
        /// </summary>
        /// <param name="collection">The collection name</param>
        /// <returns>The document as an object</returns>
        public static JObject GetJSONDocument(string collection, JArray parameters)
        {
            try
            {
                var dbClient = new MongoClient("mongodb://127.0.0.1:27017");
                //connect to the database
                IMongoDatabase db = dbClient.GetDatabase("bball");

                //get the database collection
                var dbCollection = db.GetCollection<BsonDocument>(collection);

                //find the document
                FilterDefinition<BsonDocument> filter = CreateFilterDefinition(parameters);
                var dbDocument = dbCollection.Find(filter).FirstOrDefault();

                //convert bson document to json
                var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                JObject json = JObject.Parse(dbDocument.ToJson(jsonWriterSettings));

                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(collection + " failed. Check log.");
                ErrorDocument(ex, "GetJSONDocument", "", collection, parameters);
                return null;
            }
        }

        /// <summary>
        /// Get document as a JObject
        /// </summary>
        /// <param name="collection">The collection name</param>
        /// <returns>The document as an object</returns>
        public static BsonDocument GetDocument(string collection, JArray parameters)
        {
            try
            {
                var dbClient = new MongoClient("mongodb://127.0.0.1:27017");
                //connect to the database
                IMongoDatabase db = dbClient.GetDatabase("bball");

                //get the database collection
                var dbCollection = db.GetCollection<BsonDocument>(collection);

                //find the document
                FilterDefinition<BsonDocument> filter = CreateFilterDefinition(parameters);
                var dbDocument = dbCollection.Find(filter).FirstOrDefault();

                return dbDocument;
            }
            catch (Exception ex)
            {
                Console.WriteLine(collection + " failed. Check log.");
                ErrorDocument(ex, "GetDocument", null, collection, parameters);
                return null;
            }
        }

        /// <summary>
        /// Get all documents from a collection.
        /// </summary>
        /// <param name="collection">The collection name</param>
        /// <returns>An array of documents</returns>
        public static List<BsonDocument> GetAllDocuments(string collection, JArray parameters = null)
        {
            try
            {
                var dbClient = new MongoClient("mongodb://127.0.0.1:27017");
                //connect to the database
                IMongoDatabase db = dbClient.GetDatabase("bball");

                //get the database collection
                var dbCollection = db.GetCollection<BsonDocument>(collection);
                List<BsonDocument> dbDocuments = new List<BsonDocument>();
                if(parameters == null)
                {
                    dbDocuments = dbCollection.Find(_ => true).ToList();
                }
                else
                {
                    //find the document
                    FilterDefinition<BsonDocument> filter = CreateFilterDefinition(parameters);
                    dbDocuments = dbCollection.Find(filter).ToList();
                }

                return dbDocuments;
            }
            catch (Exception ex)
            {
                Console.WriteLine(collection + " failed. Check log.");
                ErrorDocument(ex, "GetAllDocuments", "", collection, parameters);
                return null;
            }
        }

        /// <summary>
        /// Create a filter definition
        /// </summary>
        /// <param name="parameters">The filter parameters</param>
        /// <returns>A filter definition</returns>
        private static FilterDefinition<BsonDocument> CreateFilterDefinition(JArray parameters)
        {
            try
            {
                //create a filter to be used later
                var builder = Builders<BsonDocument>.Filter;
                FilterDefinition<BsonDocument> filter = new BsonDocument();

                if (parameters != null)
                {
                    //add query parameters to url
                    foreach (var item in parameters)
                    {
                        switch (item["Type"].ToString())
                        {
                            case "int":
                                filter &= builder.Eq(item["Key"].ToString(), item["Value"].ToObject<int>());
                                break;
                            case "bool":
                                filter &= builder.Eq(item["Key"].ToString(), item["Value"].ToObject<bool>());
                                break;
                            default:
                                var val = item["Value"].ToString();
                                filter &= builder.Eq(item["Key"].ToString(), val == "" ? null : val);
                                break;
                        }
                    }
                }

                return filter;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Check to see if the collection exists
        /// </summary>
        /// <param name="db">The database object</param>
        /// <param name="collection">The name of the collection</param>
        /// <returns>true/false</returns>
        private static bool CollectionExists(IMongoDatabase db, string collection)
        {
            try
            {
                var filter = new BsonDocument("name", collection);
                var options = new ListCollectionNamesOptions { Filter = filter };

                return db.ListCollectionNames(options).Any();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
