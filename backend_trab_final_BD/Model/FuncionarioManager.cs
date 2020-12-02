using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;

namespace backend_trab_final_BD.Model
{
    public class Funcionario
    {
        public string cpf { get; set; }
        public string nome { get; set; }
        public string cargo { get; set; }
        public string dataContratacao { get; set; }
        public decimal hrVoo { get; set; }
    }
    public class FuncionarioManager
    {
        public FuncionarioManager(){}

        public List<Funcionario> GetList()
        {
            List<Funcionario> model = new List<Funcionario>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM FUNCIONARIO";

                try {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Funcionario funcionario = new Funcionario();
                        funcionario.cpf = reader["CPF"].ToString();
                        funcionario.nome = reader["NOME"].ToString();
                        funcionario.cargo = reader["CARGO"].ToString();
                        DateTime date = (DateTime)reader["DATACONTRATACAO"];
                        funcionario.dataContratacao = date.ToString("dd/MM/yyyy");
                        funcionario.hrVoo = (decimal)reader["HORASVOO"];

                        model.Add(funcionario);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }

            return model;

        }
        public void InsertFuncionario(string cpf, string nome, string cargo, string dataContratacao, decimal hrVoo)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "INSERT INTO FUNCIONARIO VALUES ('" + cpf + "','" + nome + "','" + cargo + "',TO_DATE('" + dataContratacao + 
                    "','DD/MM/YYYY')," + hrVoo + ")";
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
        public void DeleteFuncionario(string cpf)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "DELETE FROM FUNCIONARIO WHERE CPF='" + cpf + "'";
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
        public void UpdateFuncionario(string cpf, string nome, string cargo, string dataContratacao, decimal hrVoo)
        {
            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "UPDATE FUNCIONARIO SET " +
                    "NOME='" + nome +
                    "', CARGO='" + cargo +
                    "', DATACONTRATACAO=TO_DATE('" + dataContratacao + "', 'DD/MM/YYYY')" +
                    ", HORASVOO=" + hrVoo +
                    " WHERE CPF='" + cpf + "'";
                OracleCommand command_test = connection.CreateCommand();
                command_test.CommandText = "SELECT * FROM FUNCIONARIO WHERE CPF='" + cpf + "'";
                try
                {
                    connection.Open();
                    OracleDataReader reader = command_test.ExecuteReader();
                    if (reader.HasRows)
                    {
                        command.ExecuteNonQuery();
                    }
                    else
                    {
                        throw new Exception("Id não existe");
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }
    }
}
