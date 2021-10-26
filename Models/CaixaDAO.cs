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
    class CaixaDAO : IDAO<Caixa>
    {
        private static Conexao conn;

        public CaixaDAO()
        {
            conn = new Conexao();
        }

        public void Delete(Caixa t)
        {
            throw new NotImplementedException();
        }

        public Caixa GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Caixa t)
        {
            throw new NotImplementedException();
        }

        public List<Caixa> List()
        {
            try
            {
                List<Caixa> list = new List<Caixa>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Caixa";

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Caixa()
                    {
                        IdCaixa = reader.GetInt32("cod_caixa"),
                        AnoCaixa = reader.GetString("ano_caixa"),
                        MesCaixa = reader.GetString("mes_caixa")
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

        public void Update(Caixa t)
        {
            throw new NotImplementedException();
        }
    }
}
