using MTO_ProSoft.controlador;
using System;
using System.Windows.Forms;

namespace MTO_ProSoft
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void gabtn_Login_Click(object sender, EventArgs e)
        {
            string usuario = ctxtbox_Usuario.Text.Trim();
            string password = ctxtbox_Contrasenia.Text;

            try
            {
                CLogin cLogin = new CLogin();
                string respuesta = cLogin.ctrlLogin(usuario,password);
                if (respuesta.Length > 0)
                {
                    MessageBox.Show(respuesta);
                }
                else
                {
                    //vista de ingreso
                    MessageBox.Show("c:");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
