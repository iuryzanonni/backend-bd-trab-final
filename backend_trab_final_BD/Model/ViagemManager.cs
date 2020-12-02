using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_trab_final_BD.Model
{
    public class Viagem
    {
        public decimal id { get; set; }
        public decimal numeroPassagens { get; set; }
        public decimal preco { get; set; }
        public string data { get; set; }
        public decimal origemId { get; set; }
        public decimal destinoId { get; set; }
        public decimal tripulacaoId { get; set; }
        public decimal aviaoId { get; set; }
        public decimal hrVoo { get; set; }
    }
    public class ViagemManager
    {
        public ViagemManager() { }

        public List<Viagem> GetViagens()
        {
            List<Viagem> model = new List<Viagem>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM VIAGEM";
                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Viagem viagem = new Viagem();
                        viagem.id = (decimal)reader["ID"];
                        viagem.numeroPassagens = (decimal)reader["NUMEROPASSAGENS"];
                        viagem.preco = (decimal)reader["PRECO"];
                        DateTime date = (DateTime)reader["DATA"];
                        viagem.data = date.ToString("dd/MM/yyyy");
                        viagem.origemId = (decimal)reader["ORIGEMID"];
                        viagem.destinoId = (decimal)reader["DESTINOID"];
                        viagem.tripulacaoId = (decimal)reader["TRIPULACAOID"];
                        viagem.aviaoId = (decimal)reader["AVIAOID"];
                        viagem.hrVoo = (decimal)reader["HORASVOO"];
                        model.Add(viagem);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return model;
        }

        public void InsereViagem(int id, int numeroPassagens, double preco, string data, int origemId, int destinoId, int tripulacaoId, int aviaoId, decimal hrVoo)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO VIAGEM VALUES (" + id + "," + numeroPassagens + "," + preco + ",'" + data + "'," + origemId +
                    "," + destinoId + "," + tripulacaoId + "," + aviaoId + ","+ hrVoo + ")";
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

        public void UpdateViagem(int id, int numeroPassagens, double preco, string data, int origemId, int destinoId, int tripulacaoId, int aviaoId, decimal hrVoo)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE VIAGEM SET NUMEROPASSAGENS=" + numeroPassagens +
                    ", PRECO = " + preco +
                    ", DATA = '" + data +
                    "', ORIGEMID = " + origemId +
                    ", DESTINOID = " + destinoId +
                    ", TRIPULACAOID = " + tripulacaoId +
                    ", AVIAOID = " + aviaoId +
                    ", HORASVOO = " + hrVoo +
                    " WHERE ID=" + id;
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

        public void DeleteViagem(int id)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM VIAGEM WHERE ID=" + id;
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
