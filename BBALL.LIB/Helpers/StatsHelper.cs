using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using static BBALL.LIB.Helpers.ParameterHelper;
using System.Web;
using BBALL.LIB.Models;

namespace BBALL.LIB.Helpers
{
    public static class StatsHelper
    {
        public static string LeagueID = "00";
        public static string BaseURL = "https://stats.nba.com/stats/";

        public static async Task<string> API(string url, string collection, BsonArray parameters, bool parse = true, int timeout = 15, string resultSets = "resultSets")
        {
            var query = new StatQuery(url, collection, parameters, parse, timeout, resultSets);
            return await API(query);
        }

        public static async Task<string> API(StatQuery query)
        {
            HttpClient client = new HttpClient();
            string startTime = "";
            string endTime = "";
            string elapsedTime = "";

            try
            {
                await Log(query);

                await TimeoutHelper.Count();

                //start a stopwatch to take the length of the process
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();
                startTime = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);

                Console.WriteLine($"GET: {query.Url}");

                client.Timeout = TimeSpan.FromSeconds(query.Timeout);
                client.BaseAddress = new Uri(query.Url);
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                //client.DefaultRequestHeaders.Add("Accept", "application/json, text/plain, */*");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                client.DefaultRequestHeaders.Add("Host", "stats.nba.com");
                client.DefaultRequestHeaders.Add("Origin", "https://stats.nba.com");
                client.DefaultRequestHeaders.Add("Pragma", "no-cache");
                client.DefaultRequestHeaders.Add("Referer", "https://stats.nba.com");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("x-nba-stats-origin", "stats");
                client.DefaultRequestHeaders.Add("x-nba-stats-token", "true");

                var bytes = await client.GetByteArrayAsync(query.Url);
                var json = new StreamReader(new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress)).ReadToEnd();

                stopWatch.Stop();
                endTime = String.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now);

                // Get the elapsed time as a TimeSpan value.
                TimeSpan ts = stopWatch.Elapsed;

                // Format and display the TimeSpan value.
                elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                    ts.Hours, ts.Minutes, ts.Seconds,
                    ts.Milliseconds / 10);

                return json;
            }
            catch (Exception ex)
            {
                await DatabaseHelper.ErrorDocumentAsync(ex, "API", query.Url, "");
                throw;
            }
            finally
            {
                client.Dispose();

                await Log(query, startTime, endTime, elapsedTime);
            }
        }

        private static async Task Log(StatQuery query, string startTime = "", string endTime = "", string elapsedTime = "")
        {
            BsonArray filterParameters = new BsonArray()
            {
                CreateParameterObject("url", query.Url)
            };

            await DatabaseHelper.AddUpdateDocumentAsync(
                    "logapi",
                    new BsonDocument {
                        { "url", query.Url },
                        { "collection", query.Collection },
                        { "parameters", query.Parameters },
                        { "parse", query.Parse },
                        { "resultSet", query.ResultSet },
                        { "date", DailyHelper.GetDate(0) },
                        { "startTime", startTime },
                        { "endTime", endTime },
                        { "elapsedTime", elapsedTime },
                        { "failed", startTime != "" && endTime == "" ? true : false },
                        { "completed", elapsedTime != "" ? true : false }
                    },
                    filterParameters);
        }

        public static string GenerateUrl(string url, BsonArray parameters)
        {
            try
            {
                //add query parameters to url
                if(parameters == null)
                {
                    return url;
                }

                url += "?";
                foreach (var item in parameters)
                {
                    if (item != parameters.FirstOrDefault())
                    {
                        url += "&";
                    }
                    url += item["Key"].ToString() + "=" + item["Value"].ToString();
                }

                return url;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
