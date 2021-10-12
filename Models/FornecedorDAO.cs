using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_Sistelie.Interfaces;
using DS_Sistelie.Database;

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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(Fornecedor t)
        {
            throw new NotImplementedException();
        }
    }
}
