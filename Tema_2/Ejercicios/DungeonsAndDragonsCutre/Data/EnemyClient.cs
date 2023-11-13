using DungeonsAndDragonsCutre.Models;
using DungeonsAndDragonsCutre.Utils;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragonsCutre.Data
{
    public  class EnemyClient : IData<Enemigo>
    {
        private static EnemyClient _instance;

        private EnemyClient()
        {

        }

        public static EnemyClient Instance{ 
            get 
            {
                _instance ??= new EnemyClient();
                return _instance;
            } 
        }

        public  bool Delete(Enemigo data)
        {
            return false;
        }

        public List<Enemigo> GetAll()
        {
            List<Enemigo> result = new List<Enemigo>();
            try
            {

                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constants.CONNECTION_STRING;
                    conn.Open();

                    MySqlCommand mySqlCommand = conn.CreateCommand();
                    mySqlCommand.CommandText = "SELECT * FROM Enemy";
                    MySqlDataReader reader =mySqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        Enemigo enemigo = new Enemigo
                        {
                            Nombre = reader.GetString(nameof(Enemigo.Nombre)),
                            Vida = reader.GetInt32(nameof(Enemigo.Vida)),
                            Fuerza = reader.GetInt32(nameof(Enemigo.Fuerza)),
                            Path = reader.GetString(nameof(Enemigo.Path))
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

        public bool Insert(Enemigo data)
        {
            return false;
        }

        public bool Update(Enemigo data)
        {
            return false;
        }
    }
}
