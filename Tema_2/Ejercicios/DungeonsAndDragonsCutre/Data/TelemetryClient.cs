using DungeonsAndDragonsCutre.Models;
using DungeonsAndDragonsCutre.Utils;
using Microsoft.VisualBasic.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsAndDragonsCutre.Data
{
    public  class TelemetryClient : IData<Telemetry>
    {
        private  static  TelemetryClient _instance;

        private TelemetryClient()
        {

        }

        public static TelemetryClient Instance
        {
            get
            {
                _instance ??= new TelemetryClient();
                return _instance;
            }
        }
        public bool Delete(Telemetry data)
        {
            throw new NotImplementedException();
        }

        public List<Telemetry> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Telemetry data)
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection())
                {
                    conn.ConnectionString = Constants.CONNECTION_STRING;
                    conn.Open();

                    MySqlCommand mySqlCommand = conn.CreateCommand();
                    mySqlCommand.CommandText = "insert into Telemetry (tiempoJugado,max_Dealt_Damage," +
                        "min_Dealt_Damage,Max_Recieved_Damage,Min_Recieved_Damage) " +
                        "values (@fecha, @max_Dealt_Damage," +
                        "@min_Dealt_Damage,@max_Recieved_Damage,@min_Recieved_Damage)";

                    mySqlCommand.Parameters.AddWithValue("@fecha", data.TiempoJugado);
                    mySqlCommand.Parameters.AddWithValue("@max_Dealt_Damage", data.Max_Dealt_Damage); ;
                    mySqlCommand.Parameters.AddWithValue("@min_Dealt_Damage", data.Min_Dealt_Damage);
                    mySqlCommand.Parameters.AddWithValue("@max_Recieved_Damage", data.Min_Recieved_Damage);
                    mySqlCommand.Parameters.AddWithValue("@min_Recieved_Damage", data.Max_Recieved_Damage);
                    return mySqlCommand.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return false;
        }

        public bool Update(Telemetry data)
        {
            throw new NotImplementedException();
        }
    }
}
