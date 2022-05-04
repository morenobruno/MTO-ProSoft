using MySql.Data.MySqlClient;

namespace MTO_ProSoft.modelo
{
    class MUsuario
    {
        public int registro(Usuario usuario)
        {
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "CONSULTA PARA INSERTAR UN USUARIO";

            MySqlCommand sqlCommand = new MySqlCommand(sql,conexion);

            sqlCommand.Parameters.AddWithValue("",usuario.UserName);
            sqlCommand.Parameters.AddWithValue("", usuario.Password);
            sqlCommand.Parameters.AddWithValue("", usuario.Id_tipo);

            int resultado = sqlCommand.ExecuteNonQuery();

            return resultado;
        }

        public Usuario existeUsuario(string userName)
        {
            MySqlDataReader sqlDataReader;

            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT id,Nombre,Password FROM usuario WHERE Nombre LIKE @usuario";

            MySqlCommand sqlCommand = new MySqlCommand(sql, conexion);

            sqlCommand.Parameters.AddWithValue("@usuario", userName);

            sqlDataReader = sqlCommand.ExecuteReader();

            Usuario oUsuario = null;

            while (sqlDataReader.Read())
            {
                oUsuario = new Usuario();
                oUsuario.Id = int.Parse(sqlDataReader["id"].ToString());
                oUsuario.UserName = sqlDataReader["Nombre"].ToString();
                oUsuario.Password = sqlDataReader["Password"].ToString();
            }
            return oUsuario;
        }

        public bool yaExisteUsuario(string userName)
        {
            MySqlDataReader sqlDataReader;

            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT id FROM (nombre de tabla) WHERE (nombre de columna) LIKE @usuario";

            MySqlCommand sqlCommand = new MySqlCommand(sql, conexion);

            sqlCommand.Parameters.AddWithValue("@usuario", userName);

            sqlDataReader = sqlCommand.ExecuteReader();

            if (sqlDataReader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
