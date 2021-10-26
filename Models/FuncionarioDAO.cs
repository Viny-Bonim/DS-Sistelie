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
            throw new NotImplementedException();
        }

        public Funcionario GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Funcionario t)
        {
            throw new NotImplementedException();
        }

        public List<Funcionario> List()
        {
            try
            {
                List<Funcionario> list = new List<Funcionario>();

                var query = conn.Query();
                query.CommandText = "SELECT * FROM Funcionario ";
                    
                    
                    
                                                    /* +
                                                "LEFT JOIN endereco ON cod_endereco = cod_endereco_fk " +
                                                "LEFT JOIN Tarefa ON cod_tare = cod_tare_fk " +
                                                "WHERE cod_func = @id";*/

                MySqlDataReader reader = query.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Funcionario()
                    {
                        IdFunc = reader.GetInt32("cod_func"),
                        Nome = reader.GetString("nome")




                        /*
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
                        },

                        Tarefa = DAOHelper.IsNull(reader, "cod_tare_fk") ? null : new Tarefa()
                        {
                            IdTarefa = reader.GetInt32("cod_endereco"),
                            TipoTarefa = reader.GetString("tipo_tare"),
                            ResponsavelTarefa = reader.GetString("responsavel_tare"),
                            DataInicio = reader.GetDateTime("datainicio_tare"),
                            DataTermino = reader.GetDateTime("datatermi_tare"),
                            DescricaoTarefa = reader.GetString("descricao_tare")
                        }*/





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
            throw new NotImplementedException();
        }
    }
}
