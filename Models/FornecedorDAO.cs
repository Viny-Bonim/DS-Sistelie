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
    class FornecedorDAO : IDAO<Fornecedor>
    {
        private static Conexao conn;

        public FornecedorDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Fornecedor t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Fornecedor WHERE cod_forn = @id";

                query.Parameters.AddWithValue("@id", t.CodigoFornecedor);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("O fornecedor não foi excluído corretamente, por favor tente novamente!");
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

        public Fornecedor GetById(int id)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM Fornecedor " +
                                                "LEFT JOIN endereco ON cod_endereco = cod_endereco_fk " +
                                                "WHERE cod_forn = @id";

                query.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = query.ExecuteReader();

                if (!reader.HasRows)
                    throw new Exception("Nenhum registro foi encontrado!");

                var fornecedor = new Fornecedor();

                while (reader.Read())
                {
                    fornecedor.CodigoFornecedor = DAOHelper.GetInt(reader, "cod_forn");
                    fornecedor.Email = DAOHelper.GetString(reader, "email_forn");
                    fornecedor.TipoFornecedor = DAOHelper.GetString(reader, "tipo_forn");
                    fornecedor.DataCadastroFornecedor = DAOHelper.GetDateTime(reader, "data_cadastro_forn");
                    fornecedor.RgIe = DAOHelper.GetString(reader, "rg_ie_forn");
                    fornecedor.Cpf = DAOHelper.GetString(reader, "cpf_forn");
                    fornecedor.Cnpj = DAOHelper.GetString(reader, "cnpj_forn");
                    fornecedor.NomeFantasia = DAOHelper.GetString(reader, "nome_fantasia_forn");
                    fornecedor.RazaoSocial = DAOHelper.GetString(reader, "razao_social_forn");
                    fornecedor.Telefone = DAOHelper.GetString(reader, "telefone_forn");

                    if (!DAOHelper.IsNull(reader, "cod_endereco_fk"))
                        fornecedor.Endereco = new Endereco()
                        {
                            IdEnd = DAOHelper.GetInt(reader, "cod_endereco"),
                            Cep = DAOHelper.GetString(reader, "cep"),
                            Bairro = DAOHelper.GetString(reader, "bairro"),
                            Logradouro = DAOHelper.GetString(reader, "logradouro"),
                            Numero = DAOHelper.GetInt(reader, "numero"),
                            Uf = DAOHelper.GetString(reader, "uf"),
                            Cidade = DAOHelper.GetString(reader, "cidade")
                        };
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
                // Inserindo o endereço do Fornecedor
                var enderecoId = new EnderecoDAO().Insert(t.Endereco);

                var query = conn.Query();

                //query.CommandText = "INSERT INTO Fornecedor (email_forn, tipo_forn, data_cadastro_forn, rg_ie_forn, cpf_forn, cnpj_forn, nome_fantasia_forn, razao_social_forn, telefone_forn, cod_endereco_fk) " +
                //    "VALUES (@email, @tipo, @datacad, @rgie, @cpf, @cnpj, @nomefantasia, @razaosocial, @telefone, @enderecoId)";


                query.CommandText = "CALL InserirFornecedor(@email, @tipo, @datacad, @rgie, @cpf, @cnpj, @nomefantasia, @razaosocial, @telefone, @enderecoId)";

                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@tipo", t.TipoFornecedor);
                query.Parameters.AddWithValue("@datacad", t.DataCadastroFornecedor?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@rgie", t.RgIe);
                query.Parameters.AddWithValue("@cpf", t.Cpf);
                query.Parameters.AddWithValue("@cnpj", t.Cnpj);
                query.Parameters.AddWithValue("@nomefantasia", t.NomeFantasia);
                query.Parameters.AddWithValue("@razaosocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@enderecoId", enderecoId);

                //var result = query.ExecuteNonQuery();

                //if (result == 0)
                //   throw new Exception("O registro não foi inserido. Verifique e tente novamente");

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

        public List<Fornecedor> List()
        {
            try
            {
                List<Fornecedor> listForn = new List<Fornecedor>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Fornecedor LEFT JOIN Endereco ON cod_endereco = cod_endereco_fk";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    listForn.Add(new Fornecedor()
                    {
                        CodigoFornecedor = DAOHelper.GetInt(reader, "cod_forn"),
                        Email = DAOHelper.GetString(reader, "email_forn"),
                        TipoFornecedor = DAOHelper.GetString(reader, "tipo_forn"),
                        DataCadastroFornecedor = DAOHelper.GetDateTime(reader, "data_cadastro_forn"),
                        RgIe = DAOHelper.GetString(reader, "rg_ie_forn"),
                        Cpf = DAOHelper.GetString(reader, "cpf_forn"),
                        Cnpj = DAOHelper.GetString(reader, "cnpj_forn"),
                        NomeFantasia = DAOHelper.GetString(reader, "nome_fantasia_forn"),
                        RazaoSocial = DAOHelper.GetString(reader, "razao_social_forn"),
                        Telefone = DAOHelper.GetString(reader, "telefone_forn"),

                        Endereco = DAOHelper.IsNull(reader, "cod_endereco_fk") ? null : new Endereco() 
                        { 
                            IdEnd = DAOHelper.GetInt(reader, "cod_endereco"),
                            Cep = DAOHelper.GetString(reader, "cep"),
                            Bairro = DAOHelper.GetString(reader, "bairro"),
                            Logradouro = DAOHelper.GetString(reader, "logradouro"),
                            Numero = DAOHelper.GetInt(reader, "numero"),
                            Uf = DAOHelper.GetString(reader, "uf"),
                            Cidade = DAOHelper.GetString(reader, "cidade") 
                        }
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
                long enderecoId = t.Endereco.IdEnd;
                var endDao = new EnderecoDAO();

                if (enderecoId > 0)
                    endDao.Update(t.Endereco);
                else
                    enderecoId = endDao.Insert(t.Endereco);

                var query = conn.Query();
                query.CommandText = "UPDATE Fornecedor SET email_forn = @email, tipo_forn = @tipo, data_cadastro_forn = @datacad, " +
                    "rg_ie_forn = @rgie, cpf_forn = @cpf, cnpj_forn = @cnpj, nome_fantasia_forn = @nomefantasia, " +
                    "razao_social_forn = @razaosocial, telefone_forn = @telefone, cod_endereco_fk = @enderecoId " +
                    "WHERE cod_forn = @id";

                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@tipo", t.TipoFornecedor);
                query.Parameters.AddWithValue("@datacad", t.DataCadastroFornecedor?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@rgie", t.RgIe);
                query.Parameters.AddWithValue("@cpf", t.Cpf);
                query.Parameters.AddWithValue("@cnpj", t.Cnpj);
                query.Parameters.AddWithValue("@nomefantasia", t.NomeFantasia);
                query.Parameters.AddWithValue("@razaosocial", t.RazaoSocial);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@enderecoId", enderecoId);
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
