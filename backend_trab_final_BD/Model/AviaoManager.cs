using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_trab_final_BD.Model
{
    public class Aviao
    {
        public decimal id { get; set; }
        public string modelo { get; set; }
        public string dataFabricacao { get; set; }
        public string dataUltimaManutencao { get; set; }
        public decimal capacidade { get; set; }
    }
    public class AviaoManager
    {
        public AviaoManager() { }
        public List<Aviao> getListAviao()
        {
            List<Aviao> model = new List<Aviao>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM AVIAO";
                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Aviao aviao = new Aviao();
                        aviao.id = (decimal)reader["ID"];
                        aviao.modelo = reader["MODELO"].ToString();
                        DateTime date = (DateTime)reader["DATAFABRICACAO"];
                        aviao.dataFabricacao = date.ToString("dd/MM/yyyy");
                        DateTime date_2 = (DateTime)reader["DATAULTIMAMANUTENCAO"];
                        aviao.dataUltimaManutencao = date_2.ToString("dd/MM/yyyy");
                        aviao.capacidade = (decimal)reader["CAPACIDADE"];

                        model.Add(aviao);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return model;
        }
        public void InsertAviao(int id, string modelo, string dataFabricacao, string dataUltimaManutencao, int capacidade) {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO AVIAO VALUES ("+ id +",'" + modelo + "',TO_DATE('" + dataFabricacao + "', 'DD/MM/YYYY'),TO_DATE('" +
                   dataUltimaManutencao + "', 'DD/MM/YYYY')," + capacidade + ")";

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
        public void UpdateAviao(int id, string modelo, string dataFabricacao, string dataUltimaManutencao, int capacidade)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE AVIAO SET" +
                    " MODELO = '" + modelo +
                    "', DATAFABRICACAO = TO_DATE('" + dataFabricacao + "', 'DD/MM/YYYY')" +
                    ", DATAULTIMAMANUTENCAO = TO_DATE('" + dataUltimaManutencao + "', 'DD/MM/YYYY')" +
                    ", CAPACIDADE = " + capacidade +
                    " WHERE ID = " + id;

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
        public void DeleteAviao(int id)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM AVIAO WHERE ID=" + id;
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
