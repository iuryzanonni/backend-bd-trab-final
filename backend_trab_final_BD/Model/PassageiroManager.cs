using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_trab_final_BD.Model
{
    public class Passageiro
    {
        public string nome { get; set; }
        public string cpf { get; set; }
        public string dataNascimento { get; set; }
    }
    public class PassageiroManager
    {
        public PassageiroManager() { }

        public List<Passageiro> getListPassageiro()
        {
            List<Passageiro> model = new List<Passageiro>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM PASSAGEIRO";
                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Passageiro passageiro = new Passageiro();
                        passageiro.cpf = reader["CPF"].ToString();
                        passageiro.nome = reader["NOME"].ToString();
                        DateTime date = (DateTime)reader["DATANASCIMENTO"];
                        passageiro.dataNascimento = date.ToString("dd/MM/yyyy");
                        model.Add(passageiro);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return model;
        }

        public void InsertPassageiro(string cpf, string nome, string dataNascimento)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO passageiro VALUES ('" + cpf + "', '" + nome + "',TO_DATE('" + dataNascimento + "', 'DD/MM/YYYY'))";
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

        public void UpdatePassageiro(string cpf, string nome, string dataNascimento)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE PASSAGEIRO SET NOME = '" + nome + "'" +
                    ", DATANASCIMENTO = '" + dataNascimento + "' WHERE CPF ='" + cpf + "'";
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

        public void DeletePassageiro(string cpf, string nome, string dataNascimento)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM PASSAGEIRO WHERE CPF = '" + cpf + "'";
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
