using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BBALL.CON.Helpers
{
    public class StatsHelper
    {
        public string LeagueID = "00";
        public string BaseURL = "https://stats.nba.com/stats/";

        public async Task<string> API(string url)
        {
            HttpClient client = new HttpClient();
            try
            {
                client.Timeout = TimeSpan.FromSeconds(15);
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Add("Accept", "*/*");
                client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
                client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
                client.DefaultRequestHeaders.Add("Connection", "keep-alive");
                client.DefaultRequestHeaders.Add("Host", "stats.nba.com");
                client.DefaultRequestHeaders.Add("Origin", "https://stats.nba.com");
                client.DefaultRequestHeaders.Add("Pragma", "no-cache");
                client.DefaultRequestHeaders.Add("Referer", "https://stats.nba.com");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors");
                client.DefaultRequestHeaders.Add("x-nba-stats-origin", "stats");
                client.DefaultRequestHeaders.Add("x-nba-stats-token", "true");
                var bytes = await client.GetByteArrayAsync(url);
                var json = new StreamReader(new GZipStream(new MemoryStream(bytes), CompressionMode.Decompress)).ReadToEnd();

                return json;
            }
            catch (Exception ex)
            {
                var error = ex;
                throw;
            }
            finally
            {
                client.Dispose();
            }
        }
    }
}
