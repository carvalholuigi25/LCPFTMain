using LCPFavThingsLib.Models;
using LCPFavThings.Helpers;
using Microsoft.Data.SqlClient;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using SQLite;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Net.Http.Headers;

namespace LCPFavThings.Data.SQL
{
    public class AllDataService : IAllDataService
    {
        private readonly string apiUrl = HTTPHelper.GetMyBaseAddress();
        
        #if DEBUG
            private readonly static HttpClientHandler insecureHandler = HTTPHelper.GetInsecureHandler(0);
            private readonly HttpClient httpClient = new(insecureHandler);
        #else
            private readonly HttpClient httpClient = new HttpClient();
        #endif

        public AllDataService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<T>> Get<T>(string apiname)
        {
            return await httpClient.GetFromJsonAsync<List<T>>($@"{apiUrl}/api/{apiname}");
        }

        public async Task<List<T>> GetById<T>(string apiname, int id)
        {
            return await httpClient.GetFromJsonAsync<List<T>>($@"{apiUrl}/api/{apiname}/{id}");
        }

        public async Task<List<T>> ReadById<T>(string apiname, Expression<Func<T, bool>> predicate)
        {
            var resp = await httpClient.GetFromJsonAsync<List<T>>($@"{apiUrl}/api/{apiname}");
            return resp.AsQueryable().Where(predicate).ToList();
        }

        public async Task<T> Insert<T>(string apiname, T body)
        {
            var resp = await httpClient.PostAsJsonAsync($@"{apiUrl}/api/{apiname}", body);
            return await resp.Content.ReadFromJsonAsync<T>();
        }

        public async Task<List<T>> InsertAndGet<T>(string apiname, T body)
        {
            var resp = await httpClient.PostAsJsonAsync($@"{apiUrl}/api/{apiname}", body);
            var json = await resp.Content.ReadFromJsonAsync<T>();
            var mylist = new List<T>();
            mylist.Add(json);
            return mylist.Count > 0 ? mylist : default;
        }

        public async Task<T> Update<T>(string apiname, int id, T body)
        {
            var resp = await httpClient.PutAsJsonAsync($@"{apiUrl}/api/{apiname}/{id}", body);
            var json = await resp.Content.ReadAsStringAsync();
            return !string.IsNullOrEmpty(json) ? JsonConvert.DeserializeObject<T>(json) : default;
        }

        public async Task<List<T>> Delete<T>(string apiname, int id)
        {
            await httpClient.DeleteAsync($@"{apiUrl}/api/{apiname}/{id}");
            return await Get<T>(apiname);
        }

        public async Task<dynamic> QueryIt<T>(string qry = "SELECT * FROM Movies", string dbmt = "sqlite") where T : new()
        {
            dynamic res = "";
            var dbmode = MyExtensions.GetDBModeEnv(dbmt);
            var pthfile = MyExtensions.GetFileDB(dbmode);

            if (dbmode == "sqlite")
            {
                pthfile = !pthfile.Contains("Data Source=", StringComparison.OrdinalIgnoreCase) ? "Data Source=" + pthfile : pthfile;
                SQLiteAsyncConnection connection = new(pthfile);
                res = await connection.QueryAsync<T>(qry);
                await connection.CloseAsync();
            }
            else if(dbmode == "sqlserver")
            {
                var values = new List<Dictionary<string, object>>();

                using SqlConnection conn = new(pthfile);
                using SqlCommand comm = new(qry, conn);
                try
                {
                    conn.Open();
                    using SqlDataReader dr = comm.ExecuteReader();
                    if (dr.HasRows)
                    {
                        do
                        {
                            while (await dr.ReadAsync())
                            {
                                var fieldValues = new Dictionary<string, object>();

                                for (int i = 0; i < dr.FieldCount; i++)
                                {
                                    fieldValues.Add(dr.GetName(i), dr[i]);
                                }

                                values.Add(fieldValues);
                            }

                            res = JsonConvert.SerializeObject(values);
                        } while (await dr.NextResultAsync());
                    }
                }
                catch (Exception e)
                {
                    res = JsonConvert.SerializeObject(e.Message);
                }

                if (conn.State == System.Data.ConnectionState.Open) conn.Close();
            }
            else if(dbmode == "mysql")
            {
                var values = new List<Dictionary<string, object>>();
                MySqlConnection myconn = new(pthfile);
                MySqlCommand mycmd = new(qry, myconn);
                MySqlDataReader myreader;

                try
                {
                    myconn.Open();
                    myreader = mycmd.ExecuteReader();

                    if (myreader.HasRows)
                    {
                        do
                        {
                            while (await myreader.ReadAsync())
                            {
                                var fieldValues = new Dictionary<string, object>();

                                for (int i = 0; i < myreader.FieldCount; i++)
                                {
                                    fieldValues.Add(myreader.GetName(i), myreader[i]);
                                }

                                values.Add(fieldValues);
                            }

                            res = JsonConvert.SerializeObject(values);
                        } while (await myreader.NextResultAsync());
                    }
                } 
                catch(Exception e)
                {
                    res = JsonConvert.SerializeObject(e.Message);
                }

                myconn.Close();
            }
            else
            {
                res = $"This {dbmode} is not supported and not implemented on this webapp!";
            }

            return res;
        }
    }
}

