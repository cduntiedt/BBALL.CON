using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BBALL.LIB.Models;
using BBALL.LIB.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BBALL.LIB.Services
{
    public static class StatService
    {
        public static async Task<BsonDocument> Query(StatQuery query)
        {
            try
            {
                var document = DatabaseHelper.GetDocument(query.Collection, query.Parameters);

                if(document == null)
                {
                    string url = StatsHelper.BaseURL + query.Collection;
                    document = await DatabaseHelper.UpdateDatabaseAsync(url, query.Collection, query.Parameters);
                }

                return document;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
