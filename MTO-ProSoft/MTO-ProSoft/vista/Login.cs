using MTO_ProSoft.controlador;
using MTO_ProSoft.Properties;
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

        private void Login_Load(object sender, EventArgs e)
        {
            recordarUsuario();
        }

        private void gabtn_Login_Click(object sender, EventArgs e)
        {
            string usuario = ctxtbox_Usuario.Text;
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

        private void ctxtbox_Usuario_TextChanged(object sender, EventArgs e)
        {
            Settings.Default["Usuario"] = ctxtbox_Usuario.Text;
            Settings.Default.Save();
        }

        private void gcbox_RecordarUsuario_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default["RecordarUsuario"] = gcbox_RecordarUsuario.Checked;
            Settings.Default.Save();
        }
        private void recordarUsuario()
        {
            gcbox_RecordarUsuario.Checked = (bool)Settings.Default["RecordarUsuario"];
            if (gcbox_RecordarUsuario.Checked)
            {
                ctxtbox_Usuario.Text = (string)Settings.Default["Usuario"];
            }
        }
    }
}
