using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_Sistelie.Database;
using DS_Sistelie.Interfaces;

namespace DS_Sistelie.Models
{
    class EnderecoDAO
    {
        private static Conexao conn = new Conexao();

        public long Insert(Endereco t)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "INSERT INTO Endereco (cep, bairro, logradouro, numero, uf, cidade) " +
                    "VALUES (@cep, @bairro, @logradouro, @numero, @uf, @cidade)";

                query.Parameters.AddWithValue("@cep", t.Cep);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@logradouro", t.Logradouro);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@uf", t.Uf);
                query.Parameters.AddWithValue("@cidade", t.Cidade);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Erro ao salvar informações do endereço. Revise e tente novamente.");
                }

                return query.LastInsertedId;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Update(Endereco t)
        {
            try
            {
                var query = conn.Query();

                query.CommandText = "UPDATE Endereco SET cep = @cep, bairro = @bairro, logradouro = @logradouro, numero = @numero, uf = @uf, cidade = @cidade " +
                    "WHERE cod_endereco = @id";

                query.Parameters.AddWithValue("@cep", t.Cep);
                query.Parameters.AddWithValue("@bairro", t.Bairro);
                query.Parameters.AddWithValue("@logradouro", t.Logradouro);
                query.Parameters.AddWithValue("@numero", t.Numero);
                query.Parameters.AddWithValue("@uf", t.Uf);
                query.Parameters.AddWithValue("@cidade", t.Cidade);
                query.Parameters.AddWithValue("@id", t.IdEnd);

                var result = query.ExecuteNonQuery();

                if (result == 0)
                {
                    throw new Exception("Erro ao atualizar informações do endereço. Revise e tente novamente.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
