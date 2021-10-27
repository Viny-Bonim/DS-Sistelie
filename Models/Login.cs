using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Sistelie.Models
{
    class Login
    {
        public int Id { get; set; }

        public string NomeLogin { get; set; }

        public string SenhaLogin { private get; set; }

        public Funcionario Funcionario { get; set; }

        private static Login _instance;

        private Login() { }

        public static Login GetInstance()
        {
            if (_instance == null)
                _instance = new Login();

            return _instance;
        }

        public static bool LoginUsuario(string usuario, string senha)
        {
            var user = new LoginDAO().GetByUsuario(usuario, senha);

            if (user != null)
                return true;

            return false;
        }
    }
}
