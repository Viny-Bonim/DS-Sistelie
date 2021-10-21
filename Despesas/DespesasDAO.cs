using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_Sistelie.Interfaces;
using DS_Sistelie.Database;
using MySql.Data.MySqlClient;
using DS_Sistelie.Helpers;

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
                query.CommandText = "SELECT * FROM Despesa WHERE cod_desp  = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var despesas = new Despesas();

                while (reader.Read())
                {
                    despesas.IdDespesa = reader.GetInt32("cod_desp");
                    despesas.ValorDespesa = reader.GetDouble("valor_desp");
                    despesas.dataDespesa = reader.GetDateTime("data_desp");
                    despesas.DescricaoDespesa = reader.GetString("descricao_desp");
                    despesas.GrupoDespesa = reader.GetString("grupo_desp");
                    despesas.Fkcaixa = reader.GetInt32("cod_caixa_fk");
                    despesas.Fkfuncionario = reader.GetInt32("cod_func_fk");
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
                query.CommandText = "INSERT INTO Despesa (valor_desp, data_desp, descricao_desp, grupo_desp, cod_caixa_fk, cod_func_fk) " +
                    "VALUES (@valor, @data, @descricao, @grupo, @Fkcaixa, @Fkfuncionario)";

                query.Parameters.AddWithValue("@valor", t.ValorDespesa);
                query.Parameters.AddWithValue("@data", t.dataDespesa?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@descricao", t.DescricaoDespesa);
                query.Parameters.AddWithValue("@grupo", t.GrupoDespesa);
                query.Parameters.AddWithValue("@Fkcaixa", t.Fkcaixa);
                query.Parameters.AddWithValue("@Fkfuncionario", t.Fkfuncionario);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O fornecedor não foi cadastrado, por favor tente novamente!");
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
                query.CommandText = "SELECT * FROM Despesa";

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
                        Fkcaixa = reader.GetInt32("cod_caixa_fk"),
                        Fkfuncionario = reader.GetInt32("cod_func_fk")
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
                query.CommandText = "UPDATE Despesa SET valor_desp = @valor, data_desp = @data, descricao_desp = @descricao, grupo_desp = @grupo " +
                   "WHERE cod_desp = @id";
                
                query.Parameters.AddWithValue("@valor", t.ValorDespesa);
                query.Parameters.AddWithValue("@data", t.dataDespesa);
                query.Parameters.AddWithValue("@descricao", t.DescricaoDespesa);
                query.Parameters.AddWithValue("@grupo", t.GrupoDespesa);
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
