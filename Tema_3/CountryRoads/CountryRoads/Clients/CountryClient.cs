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

        public MostVisited Get(int id)
        {
            try
            {

                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constants.CONNECTION_STRING;
                    conn.Open();

                    MySqlCommand mySqlCommand = conn.CreateCommand();
                    mySqlCommand.CommandText = $"SELECT name,visitas FROM {Constants.TABLE_NAME_COUNTRY} WHERE id=@id";
                    mySqlCommand.Parameters.AddWithValue("@id", id);
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();

                    reader.Read();
                    return new MostVisited
                    {
                        Name = reader.GetString(0),
                        Visitas = reader.IsDBNull(1) ? 0 : reader.GetInt32(1)
                    };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return new MostVisited();
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
                    mySqlCommand.CommandText = $"SELECT id, name,visitas FROM {Constants.TABLE_NAME_COUNTRY}";
                    MySqlDataReader reader = mySqlCommand.ExecuteReader();
        
                    while (reader.Read())
                    {
                        MostVisited enemigo = new MostVisited
                        {
                            Id= reader.GetInt32(0),
                            Name= reader.GetString(1),
                            Visitas= reader.IsDBNull(2) ? 0 : reader.GetInt32(1)
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

        public bool Upsert(MostVisited data)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constants.CONNECTION_STRING;
                    conn.Open();
                    MySqlCommand mySqlCommand = conn.CreateCommand();

                    if (data.Id ==0)
                    {
                        mySqlCommand.CommandText = $"insert into {Constants.TABLE_NAME_COUNTRY} (name,visitas) " +
                            "values (@name, @visitas)";

                        mySqlCommand.Parameters.AddWithValue("@name", data.Name);
                        mySqlCommand.Parameters.AddWithValue("@visitas", data.Visitas); 
                        return mySqlCommand.ExecuteNonQuery() > 0;
                    }

                    data.Visitas++;
                    mySqlCommand.CommandText = $"update from {Constants.TABLE_NAME_COUNTRY} set visitas=@visitas  WHERE id=@id";
                    mySqlCommand.Parameters.AddWithValue("@name", data.Name);
                    mySqlCommand.Parameters.AddWithValue("@visitas", data.Visitas);
                    return mySqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }
    }
}
