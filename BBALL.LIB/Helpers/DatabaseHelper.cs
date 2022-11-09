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
using System.Xml.Linq;

namespace BBALL.LIB.Helpers
{
    public static class DatabaseHelper
    {
        private static string _connection { get; set; } = "mongodb://127.0.0.1:27017";
        private static string _database { get; set; } = "basketball";

        public static async Task<List<BsonDocument>> GenerateDocumentsAsync(string url, JArray parameters, bool parse = true, int timeout = 15, string resultSets = "resultSets")
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
                BsonDocument response = BsonDocument.Parse(await StatsHelper.API(url, timeout));

                BsonDocument parameterObj = new BsonDocument();
                foreach (JObject parameter in parameters)
                {
                    var val = parameter["Value"].ToString();
                    if(val == "")
                    {
                        parameterObj.Add(parameter["Key"].ToString(), BsonNull.Value);
                    }
                    else
                    {
                        parameterObj.Add(parameter["Key"].ToString(), val);
                    }
                }
                
                if (parse)
                {
                    //if there are multiple result sets
                    if (resultSets == "resultSets")
                    {
                        BsonArray statResultSets = response[resultSets].AsBsonArray;

                        //create data object
                        for (int resultIndex = 0; resultIndex < statResultSets.Count; resultIndex++)
                        {
                            BsonDocument resultSet = statResultSets[resultIndex].AsBsonDocument;
                            var resultObject = CreateResultObject(resultSet, parameterObj);

                            documents.AddRange(resultObject);
                        }
                    }
                    else
                    {
                        //if there is only one result set
                        BsonDocument statResultsSet = response[resultSets].AsBsonDocument;
                        var resultObject = CreateResultObject(statResultsSet, parameterObj);

                        documents.AddRange(resultObject);
                    }
                }
                else
                {
                    BsonDocument statResultSets = response[resultSets].AsBsonDocument;

                    if (url.Contains("videodetailsasset"))
                    {
                        var videos = statResultSets["Meta"]["videoUrls"].AsBsonArray;
                        for (int i = 0; i < videos.Count; i++)
                        {
                            //the videos
                            var video = videos[i].AsBsonDocument;
                            //event information
                            var ev = statResultSets["playlist"][i].AsBsonDocument;

                            video.Merge(ev);

                            video.Add("PARAMETERS", parameterObj);
                            video.Add("DATE_UPDATED", DailyHelper.GetDate(0));

                            documents.Add(video);
                        }
                    }
                    else
                    {
                        statResultSets.Add("PARAMETERS", parameterObj);
                        statResultSets.Add("DATE_UPDATED", DailyHelper.GetDate(0));

                        documents.Add(statResultSets);
                    }
                }

                return documents;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task<List<BsonDocument>> UpdateDatabaseAsync(string url, string collection, JArray parameters = null, bool parse = true, int timeout = 15, string resultSets = "resultSets")
        {
            try
            {
                var documents = await GenerateDocumentsAsync(url, parameters, parse, timeout, resultSets);

                await AddUpdateDocumentsAsync(collection, documents, parameters);

                ErrorHelper.Reset();

                return documents;
            }
            catch (Exception ex)
            {
                Console.WriteLine(url + " failed. Check log.");
                WriteParametersToConsole(parameters);
                await ErrorDocumentAsync(ex, "UpdateDatabaseAsync", url, collection, parameters);
                return null;
            }
        }

        private static List<BsonDocument> CreateResultObject(BsonDocument resultSet, BsonDocument parameters)
        {
            var docs = new List<BsonDocument>();

            var name = resultSet["name"].ToString();
            var headers = resultSet["headers"].AsBsonArray;
            var rowSet = resultSet["rowSet"].AsBsonArray;

            for (int rowIndex = 0; rowIndex < rowSet.Count; rowIndex++)
            {
                BsonDocument dataObject = new BsonDocument();
                dataObject.Add("RESULT_NAME", name);
                dataObject.Add("DATE_UPDATED", DailyHelper.GetDate(0));
                dataObject.Add("PARAMETERS", parameters);

                var row = rowSet[rowIndex];

                for (int headerIndex = 0; headerIndex < headers.Count; headerIndex++)
                {
                    var header = headers[headerIndex];
                    dataObject.Add(header.ToString(), row[headerIndex]);
                }

                docs.Add(dataObject);
            }

            return docs;
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
                BsonDocument errorDocument = new BsonDocument
                {
                    { "Method", method},
                    { "URL", StatsHelper.GenerateUrl(url, parameters) },
                    { "Collection", collection },
                    { "Message", exception.Message },
                    { "StackTrace", exception.StackTrace },
                    { "Source", exception.Source },
                    { "Date", DailyHelper.GetDate() },
                    { "Timestamp", String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now) }
                };
            
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

                ErrorHelper.Increment();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task ErrorDocumentAsync(Exception exception, string method, string url, string collection, JArray parameters = null)
        {
            try
            {
                await Task.Run(() => { ErrorDocument(exception, method, url, collection, parameters); });
            }
            catch (Exception)
            {
                throw;
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
                    Console.WriteLine($"{collection} inserted.");

                    WriteParametersToConsole(parameters);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task AddUpdateDocumentsAsync(string collection, List<BsonDocument> documents, JArray parameters = null)
        {
            try
            {
                await Task.Run(() => { AddUpdateDocuments(collection, documents, parameters); });
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void WriteParametersToConsole(JArray parameters = null)
        {
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    var dataItem = parameter.ToObject<JObject>().ToObject<KeyValuePair<string, JToken>>();
                    Console.WriteLine($"\t {dataItem.Key}: {dataItem.Value}");
                }
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

        public static async Task AddDocumentAsync(string collection, BsonDocument document)
        {
            try
            {
                await Task.Run(() => { AddDocument(collection, document); });
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
                if (parameters == null)
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

        public static async Task EmptyDatabase()
        {
            try
            {
                var dbClient = new MongoClient(_connection);
                //connect to the database
                IMongoDatabase db = dbClient.GetDatabase(_database);

                var collections = await db.ListCollectionNamesAsync();
                var names = collections.ToList().Where(x => x != "filters").ToList();

                for (int i = 0; i < names.Count; i++)
                {
                    var name = names[i];
                    await db.DropCollectionAsync(name);
                    Console.WriteLine($"{name} collections has been dropped.");
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public static async Task DropCollectionAsync(string collection)
        {
            try
            {
                var dbClient = new MongoClient(_connection);
                //connect to the database
                IMongoDatabase db = dbClient.GetDatabase(_database);
                
                await db.DropCollectionAsync(collection);
            }
            catch (Exception)
            {
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
