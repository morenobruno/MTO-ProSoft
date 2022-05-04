using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace MTO_ProSoft
{
    class Functions
    {
        public static void mostrarFondoDeVentanaOscuro(Form parent, Form ventana)
        {
            // take a screenshot of the form and darken it:
            Bitmap bmp = new Bitmap(parent.ClientRectangle.Width, parent.ClientRectangle.Height);
            using (Graphics G = Graphics.FromImage(bmp))
            {
                G.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
                G.CopyFromScreen(parent.PointToScreen(new Point(0, 0)), new Point(0, 0), parent.ClientRectangle.Size);
                double percent = 0.80;
                Color darken = Color.FromArgb((int)(255 * percent), Color.Black);
                using (Brush brsh = new SolidBrush(darken))
                {
                    G.FillRectangle(brsh, parent.ClientRectangle);
                }
            }

            // put the darkened screenshot into a Panel and bring it to the front:
            using (Panel p = new Panel())
            {
                setDoubleBuffer(p, true);
                p.Location = new Point(0, 0);
                p.Size = parent.ClientRectangle.Size;
                p.BackgroundImage = bmp;
                parent.Controls.Add(p);
                p.BringToFront();

                // display your dialog somehow:
                ventana.StartPosition = FormStartPosition.CenterParent;
                //ventana.Location = parent.Location;
                //ventana.Height = parent.Height;
                ventana.ShowInTaskbar = false;
                ventana.ShowDialog(parent);
            }
        }

        public static void setDoubleBuffer(Control ctl, bool DoubleBuffered)
        {
            try
            {
                typeof(Control).InvokeMember("DoubleBuffered",
                BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                null, ctl, new object[] { DoubleBuffered });
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }

        public static string generarSHA1(string cadena)
        {
            UTF8Encoding enc = new UTF8Encoding();
            byte[] data = enc.GetBytes(cadena);
            byte[] result;

            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();

            result = sha.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i] < 16)
                {
                    sb.Append("0");
                }
                sb.Append(result[i].ToString("x"));
            }
            return sb.ToString();
        }
    }
}
