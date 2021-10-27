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
    class FuncionarioDAO : IDAO<Funcionario>
    {
        private static Conexao conn;

        public FuncionarioDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Funcionario t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "DELETE FROM Funcionario WHERE cod_func = @id";

                query.Parameters.AddWithValue("@id", t.IdFunc);

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

        public Funcionario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Funcionario t)
        {
            try
            {
                var id_end = new EnderecoDAO().Insert(t.Endereco);

                var query = conn.Query();
                query.CommandText = "INSERT INTO funcionario (nome, cpf, rg, data_nasc_func, sexo, telefone, email, cod_endereco_fk) " +
                                    "VALUES (@nome, @cpf, @rg, @nacimento, @sexo, @telefone, @email, @id_end)";

                query.Parameters.AddWithValue("@nome", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@nacimento", t.data_nas?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@sexo", t.Sexo);
                query.Parameters.AddWithValue("@telefone", t.Telefone);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@id_end", id_end);

                var result = query.ExecuteNonQuery();

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

        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Funcionario " +
                                                "LEFT JOIN endereco ON cod_endereco = cod_endereco_fk " +
                                                "WHERE cod_func = @id";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario()
                    {
                        IdFunc = reader.GetInt32("cod_func"),
                        Nome = reader.GetString("nome"),
                        CPF = reader.GetString("cpf"),
                        RG = reader.GetString("rg"),
                        data_nas = reader.GetDateTime("data_nasc_func"),
                        Sexo = reader.GetString("sexo"),
                        Telefone = reader.GetString("telefone"),
                        Email = reader.GetString("email"),
                        Endereco = DAOHelper.IsNull(reader, "cod_endereco_fk") ? null : new Endereco()
                        {
                            IdEnd = reader.GetInt32("cod_endereco"),
                            Cep = reader.GetString("cep"),
                            Bairro = reader.GetString("bairro"),
                            Logradouro = reader.GetString("logradouro"),
                            Numero = reader.GetInt32("numero"),
                            Uf = reader.GetString("uf"),
                            Cidade = reader.GetString("cidade")
                        }
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

        public void Update(Funcionario t)
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
                query.CommandText = "UPDATE Funcionario SET nome = @nomeFunc, cpf = @cpfFunc, rg = @rgFunc, " +
                    "data_nasc_func = @dataNascFunc, sexo = @sexoFunc, telefone = @telefoneFunc, email = @emailFunc, " +
                    "cod_endereco_fk = @enderecoId " +
                    "WHERE cod_func = @id";


                query.Parameters.AddWithValue("@nomeFunc", t.Nome);
                query.Parameters.AddWithValue("@cpf", t.CPF);
                query.Parameters.AddWithValue("@rg", t.RG);
                query.Parameters.AddWithValue("@dataNascFunc", t.data_nas?.ToString("yyyy-MM-dd"));
                query.Parameters.AddWithValue("@sexoFunc", t.Sexo);
                query.Parameters.AddWithValue("@telefoneFunc", t.Telefone);
                query.Parameters.AddWithValue("@email", t.Email);
                query.Parameters.AddWithValue("@enderecoId", enderecoId);
                query.Parameters.AddWithValue("@id", t.IdFunc);

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
