using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_Sistelie.Interfaces;
using DS_Sistelie.Database;
using MySql.Data.MySqlClient;

namespace DS_Sistelie.Models
{
    class FornecedorDAO : IDAO<Fornecedor>
    {
        private static Conexao conn;

        public FornecedorDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Fornecedor t)
        {
            throw new NotImplementedException();
        }

        public Fornecedor GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT* FROM Fornecedor WHERE cod_forn = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                var fornecedor = new Fornecedor();

                while (reader.Read())
                {
                    fornecedor.CodigoFornecedor = reader.GetInt32("cod_forn");
                    fornecedor.Email = reader.GetString("email_forn");
                    fornecedor.TipoFornecedor = reader.GetString("tipo_forn");
                    fornecedor.DataCadastroFornecedor = reader.GetDateTime("data_cadastro_forn");
                    fornecedor.RgIe = reader.GetString("rg_ie_forn");
                    fornecedor.Cpf = reader.GetString("cpf_forn");
                    fornecedor.Cnpj = reader.GetString("cnpj_forn");
                    fornecedor.NomeFantasia = reader.GetString("nome_fantasia_forn");
                    fornecedor.RazaoSocial = reader.GetString("razao_social_forn");
                    fornecedor.Telefone = reader.GetString("telefone_forn");
                }

                return fornecedor;
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

        public void Insert(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Fornecedor (email_forn, tipo_forn, data_cadastro_forn, rg_ie_forn, cpf_forn, cnpj_forn, nome_fantasia_forn, razao_social_forn, telefone_forn, cod_endereco_fk) " +
                    "VALUES (@email, @tipo, @datacad, @rgie, @cpf, @cnpj, @nomefantasia, @razaosocial, @telefone, @FkEndereco)";

                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@tipo", t.TipoFornecedor);
                query.Parameters.AddWithValue("@datacad", t.DataCadastroFornecedor.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@rgie", t.RgIe);
                query.Parameters.AddWithValue("@cpf", t.Cpf);
                query.Parameters.AddWithValue("@cnpj", t.Cnpj);
                query.Parameters.AddWithValue("@nomefantasia", t.NomeFantasia);
                query.Parameters.AddWithValue("@razaosocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@FkEndereco", t.FkEndereco);

                var result = query.ExecuteNonQuery();

                if(result == 0)
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

        public List<Fornecedor> List()
        {
            try
            {
                List<Fornecedor> listForn = new List<Fornecedor>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Fornecedor";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listForn.Add(new Fornecedor()
                    {
                        CodigoFornecedor = reader.GetInt32("cod_forn"),
                        Email = reader.GetString("email_forn"),
                        TipoFornecedor = reader.GetString("tipo_forn"),
                        DataCadastroFornecedor = reader.GetDateTime("data_cadastro_forn"),
                        RgIe = reader.GetString("rg_ie_forn"),
                        Cpf = reader.GetString("cpf_forn"),
                        Cnpj = reader.GetString("cnpj_forn"),
                        NomeFantasia = reader.GetString("nome_fantasia_forn"),
                        RazaoSocial = reader.GetString("razao_social_forn"),
                        Telefone = reader.GetString("telefone_forn"),
                    });
                }

                return listForn;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "UPDATE Fornecedor SET email_forn = @email, tipo_forn = @tipo, data_cadastro_forn = @datacad, rg_ie_forn = @rgie, cpf_forn = @cpf, cnpj_forn = @cnpj, nome_fantasia_forn = @nomefantasia, razao_social_forn = @razaosocial, telefone_forn = @telefone, cod_endereco_fk = @FkEndereco " +
                   "WHERE cod_forn = @id";

                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@tipo", t.TipoFornecedor);
                query.Parameters.AddWithValue("@datacad", t.DataCadastroFornecedor.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@rgie", t.RgIe);
                query.Parameters.AddWithValue("@cpf", t.Cpf);
                query.Parameters.AddWithValue("@cnpj", t.Cnpj);
                query.Parameters.AddWithValue("@nomefantasia", t.NomeFantasia);
                query.Parameters.AddWithValue("@razaosocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@FkEndereco", t.FkEndereco);
                query.Parameters.AddWithValue("@id", t.CodigoFornecedor);

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
