using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BBALL.LIB.Models;
using BBALL.LIB.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using MongoDB.Bson.IO;

namespace BBALL.LIB.Services
{
    public static class StatService
    {
        public static async Task<JObject> Query(StatQuery query)
        {
            try
            {
                await TimeoutHelper.APICount(query.CallCount);
                var updateParameters = new JArray();
                foreach (JObject item in query.Parameters)
                {
                    var key = item["Key"].ToString();
                    var value = item["Value"].ToString();
                        updateParameters.Add(ParameterHelper.CreateParameterObject(key, value));
                }

                //skip querying on the upload date
                if (!query.SkipDate)
                {
                    updateParameters.Add(ParameterHelper.CreateParameterObject("DateUpdated", DailyHelper.GetDate(0)));
                }
                
                //see if document exists and has been updated to the current date
                var document = DatabaseHelper.GetJSONDocument(query.Collection, updateParameters);

                //if it doesn't exist or isn't up to date
                if (document == null)
                {
                    //load the document
                    string url = StatsHelper.BaseURL + query.Collection;
                    var dbDocument = await DatabaseHelper.UpdateDatabaseAsync(url, query.Collection, query.Parameters, query.Parse, query.Timeout);

                    if(dbDocument == null)
                    {
                        throw new Exception("No data");
                    }
                    else
                    {
                        //convert bson document to json
                        var jsonWriterSettings = new JsonWriterSettings { OutputMode = JsonOutputMode.Strict };
                        document = JObject.Parse(dbDocument.ToJson(jsonWriterSettings));
                    }
                }

                //var document = new BsonDocument();

                return document;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
