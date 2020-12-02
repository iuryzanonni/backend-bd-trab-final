using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_trab_final_BD.Model
{
    public class Localizacao
    {
        public decimal id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string estado { get; set; }
    }
    public class LocalizacaoManager
    {
        public LocalizacaoManager() { }

        public List<Localizacao> GetList()
        {
            List<Localizacao> model = new List<Localizacao>();
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM LOCALIZACAO";
                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Localizacao localizacao = new Localizacao();
                        localizacao.id = (decimal)reader["ID"];
                        localizacao.nome = reader["NOME"].ToString();
                        localizacao.cidade = reader["CIDADE"].ToString();
                        localizacao.estado = reader["ESTADO"].ToString();
                        model.Add(localizacao);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
                return model;
        }

        public void InsertLocalizacao(int id, string nome, string cidade, string estado)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO LOCALIZACAO VALUES(" + id + ",'" + nome + "','" + cidade + "','" + estado + "')";
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                }catch(Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        public void UpdateLocalizacao(int id, string nome, string cidade, string estado)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE LOCALIZACAO SET NOME='" + nome +
                    "', CIDADE ='" + cidade +
                    "', ESTADO = '" + estado +
                    "' WHERE ID = " + id;
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

        public void DeleteLocalizacao(int id)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM LOCALIZACAO WHERE ID=" + id;
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
