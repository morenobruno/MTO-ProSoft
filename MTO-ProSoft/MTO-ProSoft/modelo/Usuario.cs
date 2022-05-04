using System;

namespace MTO_ProSoft.modelo
{
    class Usuario
    {
        private string userName;
        private string password;
        private string confPassword;
        private int id;
        private int id_tipo;

        public Usuario()
        {
        }

        public Usuario(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public Usuario(string userName, string password, int id, int id_tipo) : this(userName, password)
        {
            this.id = id;
            this.id_tipo = id_tipo;
        }

        public Usuario(string userName, string password,string confPassword, int id, int id_tipo)
        {
            this.userName = userName;
            this.password = password;
            this.confPassword = confPassword;
            this.id = id;
            this.id_tipo = id_tipo;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string ConfPassword { get => confPassword; set => confPassword = value; }
        public int Id { get => id; set => id = value; }
        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
    }
}
