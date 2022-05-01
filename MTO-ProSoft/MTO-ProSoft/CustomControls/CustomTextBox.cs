using System;
using System.Drawing;

namespace MTO_ProSoft.CustomControls
{
    class CustomTextBox : Guna.UI.WinForms.GunaTextBox
    {
        private String placeHolder = "";
        private bool passwordMode = false;
        public CustomTextBox()
        {
            this.ForeColor = Color.FromArgb(152, 156, 146);
            this.Font = new Font("Inter SemiBold", 14, FontStyle.Bold);
            this.BaseColor = Color.FromArgb(237, 237, 237);
            this.BorderColor = Color.FromArgb(237, 237, 237);
            this.FocusedBaseColor = Color.White;
            this.FocusedBorderColor = Color.Black;
            this.FocusedForeColor = Color.Black;
            this.Width = 270;
            this.Height = 50;
            this.Radius = 5;
            this.TextOffsetX = 10;
            this.Enter += new System.EventHandler(this._Enter);
            this.Leave += new System.EventHandler(this._Leave);

        }

        public string PlaceHolder
        {
            get => placeHolder;
            set
            {
                placeHolder = value;
                this.Text = placeHolder;
            }
        }

        public bool PasswordMode { get => passwordMode; set => passwordMode = value; }

        private void _Enter(object sender, EventArgs e)
        {
            if (this.Text == placeHolder && !PasswordMode)
            {
                this.Text = "";
            }
            else if (this.Text == placeHolder && PasswordMode)
            {
                this.Text = "";
                this.PasswordChar = '●';
            }
        }

        private void _Leave(object sender, EventArgs e)
        {
            if (this.Text.Trim() == "" && !PasswordMode)
            {
                this.Text = placeHolder;
            }
            else if (this.Text.Trim() == "" && PasswordMode)
            {
                this.Text = placeHolder;
                this.PasswordChar = '\0';
            }
        }
    }
}

