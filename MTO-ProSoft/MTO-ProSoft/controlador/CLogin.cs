using MTO_ProSoft.modelo;

namespace MTO_ProSoft.controlador
{
    class CLogin
    {
        public string ctrlLogin(string user, string password)
        {
            MUsuario mUsuario = new MUsuario();
            string respuesta = "";
            Usuario datosUsuario = null;

            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                respuesta = "Debe llenar todos los campos :c";
            }
            else
            {
                datosUsuario = mUsuario.existeUsuario(user);
                if (datosUsuario == null)
                {
                    respuesta = "El usuario no existe";
                }
                else
                {
                    if (datosUsuario.Password != Functions.generarSHA1(password))
                    {
                        respuesta = "El usuario y/o contraseña no coinciden";
                    }
                }
            }
            return respuesta;
        }
    }
}
