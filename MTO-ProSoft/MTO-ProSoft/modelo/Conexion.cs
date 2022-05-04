using MySql.Data.MySqlClient;

namespace MTO_ProSoft.modelo
{
    class Conexion
    {
        public static MySqlConnection getConexion()
        {
            string servidor = "localhost";
            string puerto = "3306";
            string usuario = "root";
            string password = "";
            string bd = "usuarios";
            string cadenaConexion = "Server= "+servidor+"; port="+puerto+"; user id="+usuario+
                                    "; password="+password+"; database="+bd+";";

            MySqlConnection conexion = new MySqlConnection(cadenaConexion);
            return conexion;
        }
    }
}
