using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS_Sistelie.Interfaces;
using DS_Sistelie.Database;
using MySql.Data.MySqlClient;

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
            throw new NotImplementedException();
        }

        public Despesas GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Despesas t)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "INSERT INTO Despesa (valor_desp, data_desp, descricao_desp, grupo_desp, cod_caixa_fk, cod_func_fk) " +
                    "VALUES (@valor, @data, @descricao, @grupo, @Fkcaixa, @Fkfuncionario)";

                query.Parameters.AddWithValue("@valor", t.ValorDespesa);
                query.Parameters.AddWithValue("@data", t.dataDespesa.ToString("yyyy-MM-dd"));
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
            throw new NotImplementedException();
        }

        public void Update(Despesas t)
        {
            throw new NotImplementedException();
        }
    }
}
