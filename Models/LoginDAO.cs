using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DS_Sistelie.Models
{
    class LoginDAO : AbstractDAO<Login>
    {
        public Login GetByUsuario(string usuarioNome, string senha)
        {
            try
            {
                var query = conn.Query();
                query.CommandText = "SELECT * FROM Login LEFT JOIN Funcionario ON cod_func = cod_func_fk " +
                    "WHERE nome_login = @usuario AND senha_login = @senha";

                query.Parameters.AddWithValue("@usuario", usuarioNome);
                query.Parameters.AddWithValue("@senha", senha);

                MySqlDataReader reader = query.ExecuteReader();

                Login usuario = null;

                while (reader.Read())
                {
                    usuario = Login.GetInstance();
                    usuario.Id = reader.GetInt32("cod_log");
                    usuario.NomeLogin = reader.GetString("nome_login");
                    usuario.Funcionario = new Funcionario() { IdFunc = reader.GetInt32("cod_func"), Nome = reader.GetString("nome") };
                }

                return usuario;
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
