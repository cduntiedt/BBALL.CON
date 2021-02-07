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
        /// <summary>
        /// Connect to the StatsService
        /// </summary>
        private static StatsHelper stats = new StatsHelper();

        public static BsonDocument UpdateDatabase(string collection, JArray parameters)
        {
            try
            {
                var url = stats.BaseURL + collection + "/";

                return UpdateDatabase(url, collection, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        /// <summary>
        /// Create a collection if it does not exist. Insert or replace a document to the collection.
        /// </summary>
        /// <param name="url">The stats API url</param>
        /// <param name="collection">The name of the collection</param>
        public static BsonDocument UpdateDatabase(string url, string collection, JArray parameters = null)
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
                    //add query parameters to url
                    url += "?";
                    foreach (var item in parameters)
                    {
                        if (item != parameters.FirstOrDefault())
                        {
                            url += "&";
                        }
                        url += item["Key"].ToString() + "=" + item["Value"].ToString();
                    }
                }

                //get the data from stats.nba.com
                JObject response = JObject.Parse(stats.API(url).Result);

                //get the full list of filter parameters
                JObject statParameters = response["parameters"].ToObject<JObject>();
               
                //create a new document to be inserted or replaced
                JObject statDocument = response["parameters"].ToObject<JObject>();
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

                //convert the stat document to bson
                var document = BsonSerializer.Deserialize<BsonDocument>(statDocument.ToString());

                AddUpdateDocument(collection, document, parameters, url);

                return document;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

        public static void AddUpdateDocument(string collection, BsonDocument document, JArray parameters, string item)
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
                if (exisintgDocument == null)
                {
                    //insert a new document if it does not exist
                    dbCollection.InsertOne(document);
                    Console.WriteLine(item + " inserted.");
                }
                else
                {
                    //replace the document if it does exist
                    dbCollection.ReplaceOne(filter, document);
                    Console.WriteLine(item + " replaced.");
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
                Console.WriteLine(ex);
                throw;
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
                Console.WriteLine(ex);
                throw;
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
                Console.WriteLine(ex);
                throw;
            }
        }

        /// <summary>
        /// Create a filter definition
        /// </summary>
        /// <param name="parameters">The filter parameters</param>
        /// <returns>A filter definition</returns>
        private static FilterDefinition<BsonDocument> CreateFilterDefinition(JArray parameters)
        {
            //create a filter to be used later
            var builder = Builders<BsonDocument>.Filter;
            FilterDefinition<BsonDocument> filter = new BsonDocument();

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
                        filter &= builder.Eq(item["Key"].ToString(), item["Value"].ToString());
                        break;
                }
            }

            return filter;
        }

        /// <summary>
        /// Check to see if the collection exists
        /// </summary>
        /// <param name="db">The database object</param>
        /// <param name="collection">The name of the collection</param>
        /// <returns>true/false</returns>
        private static bool CollectionExists(IMongoDatabase db, string collection)
        {
            var filter = new BsonDocument("name", collection);
            var options = new ListCollectionNamesOptions { Filter = filter };

            return db.ListCollectionNames(options).Any();
        }
    }
}
