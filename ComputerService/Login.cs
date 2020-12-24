using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerService
{
    public partial class Login : Form
    {
        List<Control> textBoxes;
        List<Control> buttons;
        List<Control> labels;
        void Initialize_Add()
        {
            textBoxes = new List<Control>();
            buttons = new List<Control>();
            labels = new List<Control>();

            textBoxes.Add(usernameTextBox);
            textBoxes.Add(passwordTextBox);

            buttons.Add(loginButton);
            labels.Add(label1);
            labels.Add(label2);
        }
        void ApplayTheme(Color background, Color label, Color button, Color textBoxe)
        {
            this.BackColor = background;
            foreach(var l in labels)
            {
                l.ForeColor = label;
            }
            foreach(var b in buttons)
            {
                b.BackColor = button;
                b.ForeColor = label;
            }
            foreach(var t in textBoxes)
            {
                t.BackColor = textBoxe;
                t.ForeColor = label;
            }
        }
        public Login()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            InitializeComponent();
        }

       
        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private void loginButton_Click(object sender, EventArgs e)
        {
            validateMessage(usernameTextBox, 0, 256, loginButton);
            validateMessage(passwordTextBox, 0, 256, loginButton);

            if (ValidateChildren(ValidationConstraints.Enabled) && !string.IsNullOrEmpty(usernameTextBox.Text) && !string.IsNullOrEmpty(passwordTextBox.Text))
            {
                try
                {
                    using (ComputerServiceModel ctx = new ComputerServiceModel())
                    {
                        string hash = ComputeSha256Hash(passwordTextBox.Text);
                        var user = (from c in ctx.accounts where (c.username.Equals(usernameTextBox.Text) && c.password.Equals(hash)) select c).FirstOrDefault();
                        if (user != null)
                        {
                            var typeAcconut = (from c in ctx.administrators where c.account_idaccount == user.idaccount select c).FirstOrDefault();
                            if (typeAcconut != null)
                            {

                                this.Hide();
                                var adminMain = new AdminMain(user);
                                adminMain.Closed += (s, args) => this.Close();
                                adminMain.Show();
                            }
                            else
                            {
                                this.Hide();
                                var userMain = new UserMain(user);
                                userMain.Closed += (s, args) => this.Close();
                                userMain.Show();

                            }
                        }
                        else
                        {
                            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                                MessageBox.Show("Invalid username or password");
                            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr - Latn"))
                                MessageBox.Show("Pogrešno korisničko ime ili lozinka");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void Login_Load_1(object sender, EventArgs e)
        {
            //void ApplayTheme(Color background, Color label, Color button, Color textBoxe)
            Initialize_Add();
           // ApplayTheme(zcolor(70,70,70),Color.White, zcolor(70, 70, 70), zcolor(70, 70, 70));
        }
        Color zcolor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }
        ErrorProvider errorProvider = new ErrorProvider();
        private void usernameTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(usernameTextBox,0,256,loginButton);
        }
        private void validateMessage(TextBox textBox,int minLength, int maxLength, Button button)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latin"))
            {
                button.Enabled = true;
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    button.Enabled = false;
                    errorProvider.SetError(textBox, "Polje je prazno");
                }
                else
                {
                    if (textBox.Text.Length > maxLength)
                    {
                        button.Enabled = false;
                        errorProvider.SetError(textBox, "Maksimalna dužina je " + maxLength);
                    }
                    else if (textBox.Text.Length < minLength)
                    {
                        button.Enabled = false;
                        errorProvider.SetError(textBox, "Minimalna dužina je " + minLength);
                    }
                    else
                    {
                        button.Enabled = true;
                        errorProvider.SetError(textBox, null); ;
                    }

                }
            }
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
            {
                button.Enabled = true;
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    button.Enabled = false;
                    errorProvider.SetError(textBox, "Field is empty");
                }
                else
                {
                    if (textBox.Text.Length > maxLength)
                    {
                        button.Enabled = false;
                        errorProvider.SetError(textBox, "Maximum length is "+maxLength);
                    }
                    else if (textBox.Text.Length < minLength)
                    {
                        button.Enabled = false;
                        errorProvider.SetError(textBox, "Minimum length is " + minLength);
                    }
                    else
                    {
                        button.Enabled = true;
                        errorProvider.SetError(textBox, null); ;
                    }

                }
            }
        }
        private void passwordTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage( passwordTextBox,0,256,loginButton);
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(usernameTextBox, 0, 256, loginButton);
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(passwordTextBox, 0, 256, loginButton);
        }
    }
}
