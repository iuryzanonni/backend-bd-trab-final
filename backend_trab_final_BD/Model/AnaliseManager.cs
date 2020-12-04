using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend_trab_final_BD.Model
{
    public class AnalisePassageiro
    {
        public string cpf { get; set; }
        public string nome { get; set; }
        public decimal poltrona { get; set; }
        public string origem { get; set; }
        public string destino { get; set; }
        public decimal tempoViagem { get; set; }
        public decimal quant { get; set; }
        public string idade { get; set; }
    }

    public class AnaliseFuncionario
    {
        public string cpf { get; set; }
        public string nome { get; set; }
        public string cargo { get; set; }
        public decimal hrVoo { get; set; }
        public string idTripulacao { get; set; }        
    }
    public class AnaliseManager
    {
        public AnaliseManager() { }

        public List<AnalisePassageiro> ListaPassageiros()
        {
            List<AnalisePassageiro> model = new List<AnalisePassageiro>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = "SELECT PASSAGEIRO.CPF" +
                    "	, PASSAGEIRO.NOME" +
                    "	, PASSAGEM.POLTRONA" +
                    "	, L1.CIDADE AS \"ORIGEM\"" +
                    "	, L2.CIDADE AS \"DESTINO\"" +
                    "	, VIAGEM.HORASVOO AS \"TEMPO DE VIAGEM\" " +
                    "FROM PASSAGEIRO " +
                    "INNER JOIN PASSAGEM " +
                    "ON PASSAGEIRO.CPF = PASSAGEM.PASSAGEIROCPF " +
                    "INNER JOIN VIAGEM " +
                    "ON VIAGEM.ID = PASSAGEM.VIAGEMID " +
                    "INNER JOIN LOCALIZACAO L1 " +
                    "ON VIAGEM.ORIGEMID = L1.ID " +
                    "INNER JOIN LOCALIZACAO L2 " +
                    "ON VIAGEM.DESTINOID = L2.ID";
                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AnalisePassageiro analise = new AnalisePassageiro();
                        analise.cpf = reader["CPF"].ToString();
                        analise.nome = reader["NOME"].ToString();
                        analise.poltrona = (decimal)reader["POLTRONA"];
                        analise.origem = reader["ORIGEM"].ToString();
                        analise.destino = reader["DESTINO"].ToString();
                        analise.tempoViagem = (decimal)reader["TEMPO DE VIAGEM"];
                        model.Add(analise);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }

                return model;
        }

        public List<AnaliseFuncionario> FuncionarioTrip()
        {
            List<AnaliseFuncionario> model = new List<AnaliseFuncionario>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = " SELECT F.CPF" +
                    " 	, F.NOME " +
                    " 	, F.CARGO " +
                    " 	, F.HORASVOO " +
                    " 	, T.ID " +
                    " FROM FUNCIONARIO F" +
                    " LEFT JOIN TRIPULACAO T" +
                    " ON F.CPF = T.PILOTOCPF " +
                    " OR F.CPF = T.COPILOTOCPF " +
                    " OR F.CPF  = T.COMISSARIO1CPF" +
                    " OR F.CPF  = T.COMISSARIO2CPF" +
                    //" WHERE T.ID IS NULL" +
                    " ORDER BY T.ID";
                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AnaliseFuncionario analise = new AnaliseFuncionario();
                        analise.cpf = reader["cpf"].ToString();
                        analise.nome = reader["nome"].ToString();
                        analise.cargo = reader["cargo"].ToString();
                        analise.hrVoo = (decimal)reader["horasvoo"];
                        if(Convert.IsDBNull(reader["id"]))
                        {
                            analise.idTripulacao = "Sem tripulação";
                        }
                        else
                        {
                            analise.idTripulacao = reader["id"].ToString();
                        }
                        model.Add(analise);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return model;
        }

        public List<AnalisePassageiro> QuantViagens()
        {
            List<AnalisePassageiro> model = new List<AnalisePassageiro>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = " SELECT PASSAGEIRO.CPF " +
                    " 	 , PASSAGEIRO.NOME" +
                    " 	 , L2.CIDADE" +
                    " 	, COUNT(L2.CIDADE) \"QUANT\"" +
                    " FROM PASSAGEIRO" +
                    " INNER JOIN PASSAGEM" +
                    " ON PASSAGEIRO.CPF = PASSAGEM.PASSAGEIROCPF" +
                    " INNER JOIN VIAGEM" +
                    " ON VIAGEM.ID = PASSAGEM.VIAGEMID" +
                    " INNER JOIN LOCALIZACAO L1" +
                    " ON VIAGEM.ORIGEMID = L1.ID " +
                    " INNER JOIN LOCALIZACAO L2" +
                    " ON VIAGEM.DESTINOID = L2.ID" +
                    " GROUP BY L2.CIDADE, PASSAGEIRO.CPF, PASSAGEIRO.NOME";

                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AnalisePassageiro analise = new AnalisePassageiro();
                        analise.cpf = reader["CPF"].ToString();
                        analise.nome = reader["NOME"].ToString();
                        analise.destino = reader["CIDADE"].ToString();
                        analise.quant = (decimal)reader["QUANT"];
                        model.Add(analise);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

                return model;
        }

        public List<AnalisePassageiro> MultViagens()
        {
            List<AnalisePassageiro> model = new List<AnalisePassageiro>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = " SELECT PASSAGEIRO.CPF " +
                    " 	 , PASSAGEIRO.NOME" +
                    " 	 , L2.CIDADE" +
                    " 	, COUNT(L2.CIDADE) AS \"NUMVEZES\"" +
                    " FROM PASSAGEIRO" +
                    " INNER JOIN PASSAGEM" +
                    " ON PASSAGEIRO.CPF = PASSAGEM.PASSAGEIROCPF" +
                    " INNER JOIN VIAGEM" +
                    " ON VIAGEM.ID = PASSAGEM.VIAGEMID" +
                    " INNER JOIN LOCALIZACAO L1" +
                    " ON VIAGEM.ORIGEMID = L1.ID " +
                    " INNER JOIN LOCALIZACAO L2" +
                    " ON VIAGEM.DESTINOID = L2.ID" +
                    " HAVING  COUNT(L2.CIDADE) >1" +
                    " GROUP BY L2.CIDADE, PASSAGEIRO.CPF, PASSAGEIRO.NOME";

                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AnalisePassageiro analise = new AnalisePassageiro();
                        analise.cpf = reader["CPF"].ToString();
                        analise.nome = reader["NOME"].ToString();
                        analise.destino = reader["CIDADE"].ToString();
                        analise.quant = (decimal)reader["NUMVEZES"];
                        model.Add(analise);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return model;
        }

        public List<AnalisePassageiro> IdadePassageiros()
        {
            List<AnalisePassageiro> model = new List<AnalisePassageiro>();

            using (OracleConnection connection = ConnectionBD.Connection())
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = " SELECT PASSAGEIRO.CPF " +
                    " 	 , PASSAGEIRO.NOME" +
                    " 	 , L2.CIDADE" +
                    " 	, COUNT(L2.CIDADE) \"QUANT\"" +
                    " ,FLOOR((sysdate-PASSAGEIRO.DATANASCIMENTO)/ 365) \"IDADE\"" +
                    " FROM PASSAGEIRO" +
                    " INNER JOIN PASSAGEM" +
                    " ON PASSAGEIRO.CPF = PASSAGEM.PASSAGEIROCPF" +
                    " INNER JOIN VIAGEM" +
                    " ON VIAGEM.ID = PASSAGEM.VIAGEMID" +
                    " INNER JOIN LOCALIZACAO L1" +
                    " ON VIAGEM.ORIGEMID = L1.ID " +
                    " INNER JOIN LOCALIZACAO L2" +
                    " ON VIAGEM.DESTINOID = L2.ID" +
                    " WHERE PASSAGEIRO.CPF IN (SELECT p.CPF FROM PASSAGEIRO p WHERE FLOOR((sysdate-p.DATANASCIMENTO)/365) >= 65) " +
                    " GROUP BY L2.CIDADE, PASSAGEIRO.CPF, PASSAGEIRO.NOME, FLOOR((sysdate-PASSAGEIRO.DATANASCIMENTO)/ 365)";

                try
                {
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AnalisePassageiro analise = new AnalisePassageiro();
                        analise.cpf = reader["CPF"].ToString();
                        analise.nome = reader["NOME"].ToString();
                        analise.destino = reader["CIDADE"].ToString();
                        analise.quant = (decimal)reader["QUANT"];
                        analise.idade = reader["IDADE"].ToString();
                        model.Add(analise);
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }

            return model;
        }
    }
}
