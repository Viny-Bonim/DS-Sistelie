using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_Sistelie.Interfaces;
using DS_Sistelie.Database;
using MySql.Data.MySqlClient;
using DS_Sistelie.Helpers;
using DS_Sistelie.Models;

namespace DS_Sistelie.Despesas
{
    class DespesasDAO : IDAO<Despesas>
    {
        private static Conexao conn;

        public DespesasDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Despesas t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Despesa WHERE cod_desp = @id";

                query.Parameters.AddWithValue("@id", t.IdDespesa);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("A Despesa não foi excluída corretamente, por favor tente novamente!");
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

        public Despesas GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM Despesa " +
                                                "LEFT JOIN Caixa ON cod_caixa = cod_caixa_fk " +
                                                "LEFT JOIN Funcionario ON cod_func = cod_func_fk " +
                                                "WHERE cod_desp = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var despesas = new Despesas();

                while (reader.Read())
                {
                    despesas.IdDespesa = reader.GetInt32("cod_desp");
                    despesas.ValorDespesa = DAOHelper.GetDouble(reader, "valor_desp");
                    despesas.dataDespesa = DAOHelper.GetDateTime(reader, "data_desp");
                    despesas.DescricaoDespesa = DAOHelper.GetString(reader, "descricao_desp");
                    despesas.GrupoDespesa = DAOHelper.GetString(reader, "grupo_desp");


                    //pegando dados do caixa
                    if (!DAOHelper.IsNull(reader, "cod_caixa_fk"))
                        despesas.Caixa = new Caixa()
                        {
                            IdCaixa = reader.GetInt32("cod_caixa"),
                            MesCaixa = reader.GetString("mes_caixa"),
                            AnoCaixa = reader.GetString("ano_caixa")
                        };


                    //pegando dados do funcionário
                    if (!DAOHelper.IsNull(reader, "cod_func_fk"))
                        despesas.Funcionario = new Funcionario()
                        {
                            IdFunc = reader.GetInt32("cod_func"),
                            Nome = reader.GetString("nome")
                        };
                }
                return despesas;
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

        public void Insert(Despesas t)
        {
            try
            {
                var query = conn.Query();

                //query.CommandText = "INSERT INTO Despesa (valor_desp, data_desp, descricao_desp, grupo_desp, cod_caixa_fk, cod_func_fk) " +
                //  "VALUES (@valor, @data, @descricao, @grupo, @Fkcaixa, @Fkfuncionario)";

                query.CommandText = "CALL InserirDespesa(@valor, @data, @descricao, @grupo, @Fkcaixa, @Fkfuncionario)";

                query.Parameters.AddWithValue("@valor", t.ValorDespesa);
                query.Parameters.AddWithValue("@data", t.dataDespesa?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@descricao", t.DescricaoDespesa);
                query.Parameters.AddWithValue("@grupo", t.GrupoDespesa);
                query.Parameters.AddWithValue("@Fkcaixa", t.Caixa.IdCaixa);
                query.Parameters.AddWithValue("@Fkfuncionario", t.Funcionario.IdFunc);

                //var result = query.ExecuteNonQuery();
                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetName(0).Equals("Alerta"))
                    {
                        throw new Exception(reader.GetString("Alerta"));
                    }
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

        public List<Despesas> List()
        {
            try
            {
                List<Despesas> listDesp = new List<Despesas>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Despesa LEFT JOIN Caixa ON cod_caixa = cod_caixa_fk LEFT JOIN Funcionario ON cod_func = cod_func_fk WHERE cod_desp = @id";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listDesp.Add(new Despesas()
                    {
                        IdDespesa = reader.GetInt32("cod_desp"),
                        ValorDespesa = DAOHelper.GetDouble(reader, "valor_desp"),
                        dataDespesa = DAOHelper.GetDateTime(reader, "data_desp"),
                        DescricaoDespesa = DAOHelper.GetString(reader, "descricao_desp"),
                        GrupoDespesa = DAOHelper.GetString(reader, "grupo_desp"),

                        Caixa = DAOHelper.IsNull(reader, "cod_caixa_fk") ? null : new Caixa()
                        {
                            IdCaixa = reader.GetInt32("cod_caixa"),
                            MesCaixa = reader.GetString("mes_caixa"),
                            AnoCaixa = reader.GetString("ano_caixa")
                        },

                        Funcionario = DAOHelper.IsNull(reader, "cod_func_fk") ? null : new Funcionario()
                        {
                            IdFunc = reader.GetInt32("cod_func"),
                            Nome = reader.GetString("nome")
                        }
                    });
                }              

                return listDesp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Despesas t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE Despesa SET valor_desp = @valor, data_desp = @data, descricao_desp = @descricao, grupo_desp = @grupo, " +
                    "cod_caixa_fk = @caixa, cod_func_fk = @funcionario " +
                   "WHERE cod_desp = @id";
                
                query.Parameters.AddWithValue("@valor", t.ValorDespesa);
                query.Parameters.AddWithValue("@data", t.dataDespesa);
                query.Parameters.AddWithValue("@descricao", t.DescricaoDespesa);
                query.Parameters.AddWithValue("@grupo", t.GrupoDespesa);
                query.Parameters.AddWithValue("@caixa", t.Caixa.IdCaixa);
                query.Parameters.AddWithValue("@funcionario", t.Funcionario.IdFunc);
                query.Parameters.AddWithValue("@id", t.IdDespesa);

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
