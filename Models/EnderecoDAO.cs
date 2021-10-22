using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using DS_Sistelie.Database;
using DS_Sistelie.Interfaces;

namespace DS_Sistelie.Models
{
    class EnderecoDAO : IDAO<Endereço>
    {
        private static Conexao conn;

        public EnderecoDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Endereço t)
        {
            throw new NotImplementedException();
        }

        public Endereço GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Endereço t)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "CALL InserirEndereco(@cep, @bairro, @logradouro, @numero, @pais, @uf, @cidade)";

                query.Parameters.AddWithValue("@cep", t.Cep);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@logradouro", t.Logradouro);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@pais", t.Pais);
                query.Parameters.AddWithValue("@uf", t.Uf);
                query.Parameters.AddWithValue("@cidade", t.Cidade);

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

        public List<Endereço> List()
        {
            try
            {
                List<Endereço> list = new List<Endereço>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Endereco";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Endereço()
                    {
                        IdEnd = reader.GetInt32("cod_endereco"),
                        Cep = reader.GetString("cep"),
                        Bairro = reader.GetString("bairro"),
                        Logradouro = reader.GetString("logradouro"),
                        Numero = reader.GetString("numero"),
                        Pais = reader.GetString("pais"),
                        Uf = reader.GetString("uf"),
                        Cidade = reader.GetString("cidade"),
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

        public void Update(Endereço t)
        {
            throw new NotImplementedException();
        }
    }
}
