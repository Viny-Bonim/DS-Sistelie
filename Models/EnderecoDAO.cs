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
    class EnderecoDAO : IDAO<Endereco>
    {
        private static Conexao conn;

        public EnderecoDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Endereco t)
        {
            throw new NotImplementedException();
        }

        public Endereco GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Endereco t)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "CALL InserirEndereco(@cep, @bairro, @logradouro, @numero, @uf, @cidade)";

                query.Parameters.AddWithValue("@cep", t.Cep);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@logradouro", t.Logradouro);
                query.Parameters.AddWithValue("@numero", t.Numero);
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

        public List<Endereco> List()
        {
            try
            {
                List<Endereco> list = new List<Endereco>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Endereco";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Endereco()
                    {
                        IdEnd = reader.GetInt32("cod_endereco"),
                        Cep = reader.GetString("cep"),
                        Bairro = reader.GetString("bairro"),
                        Logradouro = reader.GetString("logradouro"),
                        Numero = reader.GetString("numero"),
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

        public void Update(Endereco t)
        {
            throw new NotImplementedException();
        }
    }
}
