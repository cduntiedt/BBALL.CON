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
using System.Threading.Tasks;

namespace BBALL.LIB.Helpers
{
    public static class DatabaseHelper
    {
        private static string _connection { get; set; } = "mongodb://127.0.0.1:27017";
        private static string _database { get; set; } = "basketball";

        public static List<BsonDocument> UpdateDatabase(string collection, JArray parameters)
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

        public static List<BsonDocument> GenerateDocuments(string url, JArray parameters, bool parse = true, int timeout = 15, string resultSets = "resultSets")
        {
            try
            {
                List<BsonDocument> documents = new List<BsonDocument>();

                if (parameters == null)
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

                JObject parameterObj = new JObject();
                foreach (JObject parameter in parameters)
                {
                    var val = parameter["Value"].ToString();
                    parameterObj.Add(parameter["Key"].ToString(), val == "" ? null : val);
                }
                
                if (parse)
                {
                    //if there are multiple result sets
                    if (resultSets == "resultSets")
                    {
                        JArray statResultSets = response[resultSets].ToObject<JArray>();

                        //create data object
                        for (int resultIndex = 0; resultIndex < statResultSets.Count; resultIndex++)
                        {
                            JObject resultSet = statResultSets[resultIndex].ToObject<JObject>();
                            JObject resultObject = CreateResultObject(resultSet);

                            resultObject.Add("PARAMETERS", parameterObj);
                            resultObject.Add("DATE_UPDATED", DailyHelper.GetDate(0));

                            documents.Add(resultObject.ToBsonDocument());
                        }
                    }
                    else
                    {
                        //if there is only one result set
                        JObject statResultsSet = response[resultSets].ToObject<JObject>();
                        JObject resultObject = CreateResultObject(statResultsSet);

                        resultObject.Add("PARAMETERS", parameterObj);
                        resultObject.Add("DATE_UPDATED", DailyHelper.GetDate(0));

                        documents.Add(resultObject.ToBsonDocument());
                    }
                }
                else
                {
                    JObject statResultSets = response[resultSets].ToObject<JObject>();

                    statResultSets.Add("PARAMETERS", parameterObj);
                    statResultSets.Add("DATE_UPDATED", DailyHelper.GetDate(0));

                    documents.Add(statResultSets.ToBsonDocument());
                }

                return documents;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Create a collection if it does not exist. Insert or replace a document to the collection.
        /// </summary>
        /// <param name="url">The stats API url</param>
        /// <param name="collection">The name of the collection</param>
        public static List<BsonDocument> UpdateDatabase(string url, string collection, JArray parameters = null, bool parse = true, int timeout = 15, string resultSets = "resultSets")
        {
            try
            {
                //convert the stat document to bson
                var documents = GenerateDocuments(url, parameters, parse, timeout, resultSets);

                AddUpdateDocuments(collection, documents, parameters);

                return documents;
            }
            catch (Exception ex)
            {
                Console.WriteLine(url + " failed. Check log.");
                ErrorDocument(ex, "UpdateDatabase", url, collection, parameters);
                return null;
            }
        }

        public static async Task<List<BsonDocument>> UpdateDatabaseAsync(string url, string collection, JArray parameters = null, bool parse = true, int timeout = 15, string resultSets = "resultSets")
        {
            try
            {
                var documents = GenerateDocuments(url, parameters, parse, timeout, resultSets);

                AddUpdateDocuments(collection, documents, parameters);

                await Task.CompletedTask;

                return documents;
            }
            catch (Exception ex)
            {
                Console.WriteLine(url + " failed. Check log.");
                ErrorDocument(ex, "UpdateDatabase", url, collection, parameters);
                return null;
            }
        }

        public static BsonDocument UpdateShotLocations(string url, string collection, JArray parameters = null, bool parse = true, int timeout = 15, string resultSets = "resultSets") 
        {
            try
            {
                //get the data from stats.nba.com
                JObject response = JObject.Parse(StatsHelper.API(url, timeout).Result);

                JObject statDocument = new JObject();
                foreach (JObject parameter in parameters)
                {
                    var val = parameter["Value"].ToString();
                    statDocument.Add(parameter["Key"].ToString(), val == "" ? null : val);
                }

                JObject resultSet = response[resultSets].ToObject<JObject>();
                var name = resultSet["name"].ToString();
                var categories = resultSet["headers"][0]["columnNames"].ToObject<JArray>();
                var columns = resultSet["headers"][1]["columnNames"].ToObject<JArray>();
                var rowSet = resultSet["rowSet"].ToObject<JArray>();

                JObject resultObject = new JObject();

                JArray dataArray = new JArray();
                for (int rowIndex = 0; rowIndex < rowSet.Count; rowIndex++)
                {
                    JObject dataObject = new JObject();
                    var row = rowSet[rowIndex];
                    var columnsToSkip = 5;
                    var categoryIndex = 0;
                    for (int columnIndex = 0; columnIndex < columns.Count; columnIndex++)
                    {
                        var column = columns[columnIndex];
                        var columnName = column.ToString();

                        columnsToSkip -= 1;
                        if (columnsToSkip == 0)
                        {
                            columnName += " " + categories[categoryIndex];
                        }

                        dataObject.Add(columnName, row[columnIndex]);
                    }

                    columnsToSkip = 5;

                    dataArray.Add(dataObject);
                }

                resultObject.Add("name", name);
                resultObject.Add("data", dataArray);

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

        private static JObject CreateResultObject(JObject resultSet)
        {
            var name = resultSet["name"].ToString();
            var headers = resultSet["headers"].ToObject<JArray>();
            var rowSet = resultSet["rowSet"].ToObject<JArray>();
            JObject resultObject = new JObject();

            JArray dataArray = new JArray();
            for (int rowIndex = 0; rowIndex < rowSet.Count; rowIndex++)
            {
                JObject dataObject = new JObject();
                dataObject.Add("name", name);

                var row = rowSet[rowIndex];

                for (int headerIndex = 0; headerIndex < headers.Count; headerIndex++)
                {
                    var header = headers[headerIndex];

                    dataObject.Add(header.ToString(), row[headerIndex]);
                }

                dataArray.Add(dataObject);
            }

            return resultObject;
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
                string date = String.Format("{0:yyyyMMdd}", DateTime.Now);
                errorDocument.Add(new BsonElement("Date", date));
                errorDocument.Add(new BsonElement("Timestamp", String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now)));

                BsonArray array = new BsonArray();
                if(parameters != null)
                {
                    BsonDocument parametersDoc = new BsonDocument();
                    foreach (var parameter in parameters)
                    {
                        parametersDoc.Add(new BsonElement(parameter["Key"].ToString(), parameter["Value"].ToString()));
                    }
                   
                    errorDocument.Add(new BsonElement("Parameters", parametersDoc));
                }

                AddUpdateDocument("errorlog", errorDocument, parameters);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static void AddUpdateDocuments(string collection, List<BsonDocument> documents, JArray parameters = null)
        {
            try
            {
                //create a filter to be used later
                FilterDefinition<BsonDocument> filter = CreateFilterDefinition(parameters);

                //connect to the database
                var dbClient = new MongoClient(_connection);
                IMongoDatabase db = dbClient.GetDatabase(_database);

                //check if the collection exists
                if (!CollectionExists(db, collection))
                {
                    //create the collection if it does not exist
                    db.CreateCollection(collection);
                }

                //get the database collection
                var dbCollection = db.GetCollection<BsonDocument>(collection);

                if (documents == null)
                {
                    Console.WriteLine("No documents to upload.");
                }
                else
                {
                    //if there are any existing documents, delete em
                    if(dbCollection.Find(x => x["PARAMETERS"] == documents.FirstOrDefault()["PARAMETERS"]).Any())
                    {
                        dbCollection.DeleteMany(x => x["PARAMETERS"] == documents.FirstOrDefault()["PARAMETERS"]);
                    }

                    dbCollection.InsertMany(documents);
                    Console.WriteLine(collection + " inserted.");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void AddUpdateDocument(string collection, BsonDocument document, JArray parameters = null)
        {
            try
            {
                //create a filter to be used later
                FilterDefinition<BsonDocument> filter = CreateFilterDefinition(parameters);

                //connect to the database
                var dbClient = new MongoClient(_connection);
                IMongoDatabase db = dbClient.GetDatabase(_database);

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
        /// add a new document to the collection
        /// </summary>
        /// <param name="collection">The collection name.</param>
        /// <param name="document">The document to insert</param>
        public static void AddDocument(string collection, BsonDocument document)
        {
            try
            {
                //connect to the database
                var dbClient = new MongoClient(_connection);
                IMongoDatabase db = dbClient.GetDatabase(_database);

                //check if the collection exists
                if (!CollectionExists(db, collection))
                {
                    //create the collection if it does not exist
                    db.CreateCollection(collection);
                }

                //get the database collection
                var dbCollection = db.GetCollection<BsonDocument>(collection);

                //insert a new document
                dbCollection.InsertOne(document);
                Console.WriteLine(collection + " inserted.");
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
        /// <param name="parameters">The parameters</param>
        /// <returns>The document as an object</returns>
        public static JObject GetJSONDocument(string collection, JArray parameters)
        {
            try
            {
                var dbClient = new MongoClient(_connection);
                //connect to the database
                IMongoDatabase db = dbClient.GetDatabase(_database);

                //get the database collection
                var dbCollection = db.GetCollection<BsonDocument>(collection);

                //find the document
                FilterDefinition<BsonDocument> filter = CreateFilterDefinition(parameters);
                var dbDocument = dbCollection.Find(filter).FirstOrDefault();

                if(dbDocument == null)
                {
                    return null;
                }
                else
                {
                    //convert bson document to json
                    var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                    JObject json = JObject.Parse(dbDocument.ToJson(jsonWriterSettings));

                    return json;
                }
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
                var dbClient = new MongoClient(_connection);
                //connect to the database
                IMongoDatabase db = dbClient.GetDatabase(_database);

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
                var dbClient = new MongoClient(_connection);
                //connect to the database
                IMongoDatabase db = dbClient.GetDatabase(_database);

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
                        if (item["Type"] == null) { 
                            var val = item["Value"].ToString();
                            filter &= builder.Eq(item["Key"].ToString(), val == "" ? null : val);
                        }
                        else
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

        /// <summary>
        /// Load static filters.
        /// </summary>
        /// <param name="filter">The filter name.</param>
        /// <param name="list">The list of filter items</param>
        public static void AddFilterCollection(string filter, BsonArray list)
        {
            BsonDocument doc = new BsonDocument {
                {
                    "filter", filter
                },
                {
                    "list",
                    list
                }
            };

            JArray param = new JArray(CreateParameterObject("filter", filter));

            AddUpdateDocument("filters", doc, param);
        }
    }
}
