using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EquipmentControl.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using MySql.Data.EntityFrameworkCore.Extensions;
using MySql.Data.MySqlClient;

namespace EquipmentControl.Data
{
    public class LastochkaContext
    {
        public string ConnectionString { get; set; }
        public LastochkaContext(string connectionstring)
        {
            this.ConnectionString = connectionstring;
        }
        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Lastochka> GetAllLastochkas()
        {
            List<Lastochka> list = new List<Lastochka>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from LastochkaList where id < 10", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Lastochka()
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            TrainNumber = reader["TrainNumber"].ToString(),
                            MarIP = reader["MarIP"].ToString(),
                        });
                    }
                }
            }
            return list;
        }
    }
}
