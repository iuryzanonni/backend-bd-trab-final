using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_trab_final_BD.Model
{
    public class Tripulacao
    {
        public decimal id { get; set; }
        public string pilotoCPF { get; set; }
        public string copilotoCPF { get; set; }
        public string comissario1CPF { get; set; }
        public string comissario2CPF { get; set; }
    }
    public class TripulacaoManager
    {
        public TripulacaoManager() { }

        public List<Tripulacao> GetList()
        {
            List<Tripulacao> model = new List<Tripulacao>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM TRIPULACAO";
                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Tripulacao trip = new Tripulacao();
                        trip.id = (decimal)reader["ID"];
                        trip.pilotoCPF = reader["PILOTOCPF"].ToString();
                        trip.copilotoCPF = reader["COPILOTOCPF"].ToString();
                        trip.comissario1CPF = reader["COMISSARIO1CPF"].ToString();
                        trip.comissario2CPF = reader["COMISSARIO2CPF"].ToString();
                        model.Add(trip);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
            return model;
        }

        public void InsereTripulacao(int id, string pilotoCPF, string copilotoCPF, string comissario1CPF, string comissario2CPF)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO TRIPULACAO VALUES (" + id + ",'" + pilotoCPF + "','" + copilotoCPF + "','" + comissario1CPF + "','" +
                    comissario2CPF + "')";
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

        public void UpdateTripulacao(int id, string pilotoCPF, string copilotoCPF, string comissario1CPF, string comissario2CPF)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE TRIPULACAO SET PILOTOCPF='" + pilotoCPF +
                    "', COPILOTOCPF='" + copilotoCPF +
                    "', COMISSARIO1CPF='" + comissario1CPF +
                    "', COMISSARIO2CPF='" + comissario2CPF + "'" +
                    "WHERE ID = " + id;
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

        public void DeleteTripulacao(int id)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM TRIPULACAO " +
                    "WHERE ID = " + id;
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
