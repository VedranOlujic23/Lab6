using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Lab6
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private bool UserIsValid()
        {

            XElement korisnici = XElement.Load("korisnici.xml");
            //return false;
            var users = from user in korisnici.Elements()
                        select new
                        {
                            username = (string)user.Element("korisnickoIme"),
                            password = (string)user.Element("lozinka")
                        };
            foreach (var user in users)
            {
                if (string.Compare(user.username, TextBoxUsername.Text, true) == 0
                && user.password == TextBoxPassword.Text)
                    return true;
            }
            return false;
        }
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (UserIsValid())
            {
                Close();
            }
            MessageBox.Show(this, "Invalid Username or Password!", "User Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
