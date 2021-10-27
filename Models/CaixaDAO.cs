using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_Sistelie.Interfaces;
using DS_Sistelie.Database;
using MySql.Data.MySqlClient;
using DS_Sistelie.Helpers;

namespace DS_Sistelie.Models
{
    class CaixaDAO : IDAO<Caixa>
    {
        private static Conexao conn;

        public CaixaDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Caixa t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Caixa WHERE cod_caixa = @id";

                query.Parameters.AddWithValue("@id", t.IdCaixa);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O Caixa não foi excluído corretamente, por favor tente novamente!");
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public Caixa GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM Caixa WHERE cod_caixa = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var caixa = new Caixa();

                while (reader.Read())
                {
                    caixa.IdCaixa = reader.GetInt32("cod_caixa");
                    caixa.SaldoInicial= reader.GetDouble("saldo_inicial_caixa");
                    caixa.EntradaCaixa = reader.GetDouble("entrada_caixa");
                    caixa.SaidaCaixa = reader.GetDouble("saida_caixa");
                    caixa.SaldoFinal = reader.GetDouble("saldo_final");
                    caixa.MesCaixa = reader.GetString("mes_caixa");
                    caixa.AnoCaixa = reader.GetString("ano_caixa");
                }

                return caixa;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Query();
            }
        }

        public void Insert(Caixa t)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "INSERT INTO Caixa (saldo_inicial_caixa, entrada_caixa, saida_caixa, " +
                    "saldo_final, mes_caixa, ano_caixa) " +
                    "VALUES (@saldoIni, @entrada, @saida, @saldoFin, @mes, @ano)";
                

                query.Parameters.AddWithValue("@saldoIni", t.SaldoInicial);
                query.Parameters.AddWithValue("@entrada", t.EntradaCaixa);
                query.Parameters.AddWithValue("@saida", t.SaidaCaixa);
                query.Parameters.AddWithValue("@saldoFin", t.SaldoFinal);
                query.Parameters.AddWithValue("@mes", t.MesCaixa);
                query.Parameters.AddWithValue("@ano", t.AnoCaixa);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                   throw new Exception("O registro não foi inserido. Verifique e tente novamente");


                /*MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetName(0).Equals("Alerta"))
                    {
                        throw new Exception(reader.GetString("Alerta"));
                    }
                }*/
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public List<Caixa> List()
        {
            try
            {
                List<Caixa> list = new List<Caixa>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Caixa";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Caixa()
                    {
                        IdCaixa = reader.GetInt32("cod_caixa"),
                        SaldoInicial = reader.GetDouble("saldo_inicial_caixa"),
                        EntradaCaixa = reader.GetDouble("entrada_caixa"),
                        SaidaCaixa = reader.GetDouble("saida_caixa"),
                        SaldoFinal = reader.GetDouble("saldo_final"),
                        AnoCaixa = reader.GetString("ano_caixa"),
                        MesCaixa = reader.GetString("mes_caixa")
                    });
                }

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Caixa t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE Caixa SET saldo_inicial_caixa = @saldoInicial, entrada_caixa = @entrada, saida_caixa = @saida, " +
                    "saldo_final = @saldoFinal, mes_caixa = @mes, ano_caixa = @ano " +
                    "WHERE cod_caixa = @id";

                query.Parameters.AddWithValue("@saldoInicial", t.SaldoInicial);
                query.Parameters.AddWithValue("@entrada", t.EntradaCaixa);
                query.Parameters.AddWithValue("@saida", t.SaidaCaixa);
                query.Parameters.AddWithValue("@saldoFinal", t.SaldoFinal);
                query.Parameters.AddWithValue("@mes", t.MesCaixa);
                query.Parameters.AddWithValue("@ano", t.AnoCaixa);
                query.Parameters.AddWithValue("@id", t.IdCaixa);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                    throw new Exception("Atualização do registro não foi realizada.");

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
