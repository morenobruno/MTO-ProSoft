using MTO_ProSoft.modelo;

namespace MTO_ProSoft.controlador
{
    class CRegistroUsuario
    {
        public string ctrlRegistro(Usuario usuario)
        {
            MUsuario mUsuario = new MUsuario();
            string respuesta = "";

            if (string.IsNullOrEmpty(usuario.UserName.Trim()) 
                || string.IsNullOrEmpty(usuario.Password.Trim()))
            {
                respuesta = "Debe llenar todos los campos de texto :c";
            }
            else
            {
                if (usuario.Password.Equals(usuario.ConfPassword))
                {
                    if (mUsuario.yaExisteUsuario(usuario.UserName))
                    {
                        respuesta = "Ese nombre de usuario ya existe :c";
                    }
                    else
                    {
                        usuario.Password = Functions.generarSHA1(usuario.Password);
                        mUsuario.registro(usuario);
                    }
                }
                else
                {
                    respuesta = "Las contraseñas no coinciden";
                }
            }
            return respuesta;
        }
    }
}
