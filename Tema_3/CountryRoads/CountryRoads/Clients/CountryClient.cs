using CountryRoads.Data;
using CountryRoads.Model;
using CountryRoads.Utils;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryRoads.Clients
{
    public class CountryClient : IData<MostVisited>
    {
        private static CountryClient _instance;

        private CountryClient()
        {

        }
        public static CountryClient Instance
        {
            get
            {
                _instance ??= new CountryClient();
                return _instance;
            }
        }

        public bool Delete(MostVisited data)
        {
            throw new NotImplementedException();
        }

        public List<MostVisited> GetAll()
        {
            List<MostVisited> result = new List<MostVisited>();
            try
            {

                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constants.CONNECTION_STRING;
                    conn.Open();

                    MySqlCommand mySqlCommand = conn.CreateCommand();
                    mySqlCommand.CommandText = $"SELECT name FROM {Constants.TABLE_NAME_COUNTRY}";
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        MostVisited enemigo = new MostVisited
                        {
                            Name= reader.GetString(0),
                        };
                        result.Add(enemigo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return result;
        }

        public bool Insert(MostVisited data)
        {
            throw new NotImplementedException();
        }

        public bool Update(MostVisited data)
        {
            throw new NotImplementedException();
        }
    }
}
