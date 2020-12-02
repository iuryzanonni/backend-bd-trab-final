using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_trab_final_BD.Model
{
    public class Passagem
    {
        public string passageiroCPF { get; set; }
        public decimal viagemId { get; set; }
        public decimal poltrona { get; set; }
    }
    public class PassagemManager
    {
        public PassagemManager() { }

        public List<Passagem> GetPassagem()
        {
            List<Passagem> model = new List<Passagem>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM PASSAGEM";
                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Passagem pass = new Passagem();
                        pass.passageiroCPF = reader["PASSAGEIROCPF"].ToString();
                        pass.viagemId = (decimal)reader["VIAGEMID"];
                        pass.poltrona = (decimal)reader["POLTRONA"];
                        model.Add(pass);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return model;
        }

        public void InserePassagem(string passageiroCPF, int viagemId, int poltrona)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO PASSAGEM VALUES ('" + passageiroCPF + "'," + viagemId + "," + poltrona + ")";
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public void UpdatePassagem(string passageiroCPF, int viagemId, int poltrona)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE PASSAGEM SET POLTRONA = " + poltrona + "WHERE PASSAGEIROCPF='" + passageiroCPF + "' AND VIAGEMID = " + viagemId;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public void DeletePassagem(string passageiroCPF, int viagemId)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM PASSAGEM WHERE PASSAGEIROCPF='" + passageiroCPF + "' AND VIAGEMID = " + viagemId;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}

