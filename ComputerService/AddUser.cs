using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerService
{
    public partial class AddUser : Form
    {
        List<Control> textBoxes;
        List<Control> buttons;
        List<Control> labels;
        ErrorProvider errorProvider = new ErrorProvider();
        void Initialize_Add()
        {
            textBoxes = new List<Control>();
            buttons = new List<Control>();
            labels = new List<Control>();

            textBoxes.Add(usernameBox);
            textBoxes.Add(passwordBox);
            textBoxes.Add(confirmPasswordBox);

            buttons.Add(okButton);
            buttons.Add(cancelButton);
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
       
        }
        void ApplayTheme(Color background, Color label, Color button, Color textBoxe)
        {
            this.BackColor = background;
            foreach (var l in labels)
            {
                l.ForeColor = label;
            }
            foreach (var b in buttons)
            {
                b.BackColor = button;
                b.ForeColor = label;
            }
            foreach (var t in textBoxes)
            {
                t.BackColor = textBoxe;
                t.ForeColor = label;
            }
            accountTypeComboBox.BackColor = background;
            accountTypeComboBox.ForeColor = label;
        }
        Color zcolor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }
        AdminMain adminMain;
        String updateOrInsert;
        account account;
        
        DataGridViewRow dataGridViewRow;
        
        public AddUser(AdminMain aM, String updateOrInsert, DataGridViewRow dataGridViewRow,account accountSkin)
        {
            InitializeComponent();
            this.adminMain = aM;
            passwordBox.PasswordChar = '*';
            confirmPasswordBox.PasswordChar = '*';
            this.updateOrInsert = updateOrInsert;
           // this.accountSkin = accountSkin;
              this.account = accountSkin;
           // this.account.skin = accountSkin.skin;
            this.dataGridViewRow = dataGridViewRow;
            if (updateOrInsert.Equals("update"))
            {
                
                usernameBox.Text = dataGridViewRow.Cells[1].Value.ToString();
               // passwordBox.Text = dataGridViewRow.Cells[2].Value.ToString();
               // confirmPasswordBox.Text = dataGridViewRow.Cells[2].Value.ToString();
                accountTypeComboBox.Text = dataGridViewRow.Cells[3].Value.ToString();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateChildren(ValidationConstraints.Enabled))
                {
                   // if (!usernameBox.Text.Equals("") && !passwordBox.Text.Equals("") && !confirmPasswordBox.Text.Equals(""))
                    //{
                        if (passwordBox.Text.Equals(confirmPasswordBox.Text))
                        {                                                                            
                            using (ComputerServiceModel ctx = new ComputerServiceModel())
                            {
                                if (updateOrInsert.Equals("insert") && !string.IsNullOrEmpty(usernameBox.Text) && !string.IsNullOrEmpty(passwordBox.Text) && !string.IsNullOrEmpty(confirmPasswordBox.Text))
                                {
                                    //fdsa
                                   
                                var account = new account()
                                    {
                                        username = usernameBox.Text,
                                        password = ComputeSha256Hash(passwordBox.Text),
                                        skin = "light",
                                    };
                                    ctx.accounts.Add(account);
                                    ctx.SaveChanges();
                                    ctx.Entry(account).GetDatabaseValues();
                                    int id = account.idaccount;
                                    if (accountTypeComboBox.Text.Equals("Administrator"))
                                    {
                                        var administrator = new administrator()
                                        {
                                            account_idaccount = id
                                        };
                                        //   MessageBox.Show("id je" + id);
                                        ctx.administrators.Add(administrator);
                                        ctx.SaveChanges();
                                    }
                                    else
                                    {
                                        var user = new user()
                                        {
                                            account_idaccount = id
                                        };
                                        ctx.users.Add(user);
                                        ctx.SaveChanges();
                                    }
                                this.Close();
                                }
                                else if (updateOrInsert.Equals("update") && !string.IsNullOrEmpty(usernameBox.Text))
                                {
                                    int id = Int32.Parse(dataGridViewRow.Cells[0].Value.ToString());
                                    var accountChange = (from c in ctx.accounts where c.idaccount == id select c).FirstOrDefault();
                                    if (accountChange != null)
                                    {
                                        accountChange.username = usernameBox.Text.ToString();
                                        if(!string.IsNullOrEmpty(passwordBox.Text))
                                            accountChange.password = ComputeSha256Hash(passwordBox.Text);
                                        ctx.SaveChanges();
                                        // MessageBox.Show("update password"+accountChange.password);
                                    }
                                    var administrator = (from c in ctx.administrators where c.account_idaccount == id select c).FirstOrDefault();
                                    var user = (from c in ctx.users where c.account_idaccount == id select c).FirstOrDefault();
                                    if (administrator != null)
                                    {
                                        if (!accountTypeComboBox.Text.Equals("Administrator"))
                                        {

                                            var user1 = new user()
                                            {
                                                account_idaccount = id
                                            };
                                            ctx.users.Add(user1);
                                            ctx.administrators.Remove(administrator);
                                        }
                                    }
                                    if (user != null)
                                    {
                                        if (!accountTypeComboBox.Text.Equals("User") && !accountTypeComboBox.Text.Equals("Korisnik"))
                                        {
                                            var admin1 = new administrator()
                                            {
                                                account_idaccount = id
                                            };
                                            ctx.administrators.Add(admin1);
                                            ctx.users.Remove(user);
                                        }
                                    }
                                    ctx.SaveChanges();
                                    this.Close();
                            } else
                                    {
                                  //  if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                                   //     MessageBox.Show("Fill all fields");
                                   // if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                                   //     MessageBox.Show("Popuni sva polja");
                                    validateMessage(usernameBox,5, 256, okButton,"notEmpty");
                                    validateMessage(passwordBox, 5, 256, okButton, "notEmpty");

                                     }
                            }
                            
                            adminMain.populateUserGridView();

                        }
                        else
                        {
                        // if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                        //    MessageBox.Show("Fields Password and Confirm password don't have same value");
                        // if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                        //  MessageBox.Show("Lozinka i ponovo lozinka nemaju istu vrijednost");
                        if (!passwordBox.Text.Equals(confirmPasswordBox.Text))
                        {
                            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                            {
                                okButton.Enabled = false;
                                errorProvider.SetError(confirmPasswordBox, "Polja Lozinka i Ponovi lozinku nisu ista");
                            }
                            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                            {
                                okButton.Enabled = false;
                                errorProvider.SetError(confirmPasswordBox, "Fields Password and Confirm password are not the same");
                            }
                        }
                        else
                        {
                            okButton.Enabled = true;
                            errorProvider.SetError(confirmPasswordBox, null); ;
                        }

                    }
                    //}
                    /*else
                    {
                        if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                            MessageBox.Show("Fill all fields");
                        if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr - Latn"))
                            MessageBox.Show("Popuni sva polja");
                    }*/
                }

            }catch(Exception ex)
            {
                String s = ex.StackTrace;
               // MessageBox.Show("Exception");
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                    MessageBox.Show("User with this username exists");
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                    MessageBox.Show("Korisnik sa ovim korisničkim imenom već postoji");
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void AddUser_Load(object sender, EventArgs e)
        {
            Initialize_Add();
            //MessageBox.Show(account.skin + "to je skin");
            if (account.skin.Equals("dark"))
                ApplayTheme(zcolor(70, 70, 70), Color.White, zcolor(70, 70, 70), zcolor(70, 70, 70));
            if (account.skin.Equals("light"))
                ApplayTheme(zcolor(232, 232, 232), Color.Black, zcolor(191, 191, 191), Color.White);
            if (account.skin.Equals("blue"))
                ApplayTheme(zcolor(163, 197, 255), Color.Black, zcolor(84, 147, 255), Color.White);
        }

        private void usernameBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(usernameBox,5, 256, okButton,"notEmpty");
        }

        private void passwordBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage( passwordBox, 5, 256, okButton,"Empty");
        }

        private void confirmPasswordBox_Validating(object sender, CancelEventArgs e)
        {
            // validateMessage(sender, e, usernameBox, 5, 256, okButton);
            if (!passwordBox.Text.Equals(confirmPasswordBox.Text))
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                {
                    okButton.Enabled = false;
                    errorProvider.SetError(confirmPasswordBox, "Polja Lozinka i Ponovi lozinku nisu ista");
                }
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                {
                    okButton.Enabled = false;
                    errorProvider.SetError(confirmPasswordBox, "Fields Password and Confirm password are not the same");
                }
            }
            else
            {
                okButton.Enabled = true;
                errorProvider.SetError(confirmPasswordBox, null); ;
            }
        }
        private void validateMessage(TextBox textBox, int minLength, int maxLength, Button button, String notEmpty)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
            {
                button.Enabled = false;
                if (string.IsNullOrEmpty(textBox.Text))
                {

                    if (notEmpty.Equals("notEmpty"))
                    {
                        button.Enabled = false;
                        textBox.Focus();
                        errorProvider.SetError(textBox, "Polje je prazno");
                    }
                }
                else
                {
                    if (textBox.Text.Length > maxLength)
                    {
                        
                        button.Enabled = false;
                        textBox.Focus();
                        errorProvider.SetError(textBox, "Maksimalna dužina je " + maxLength+" karaktera");
                    }
                    else if (textBox.Text.Length < minLength)
                    {
                        
                        button.Enabled = false;
                        textBox.Focus();
                        errorProvider.SetError(textBox, "Minimalna dužina je " + minLength+" karaktera");
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
               // button.Enabled = true;
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    if (notEmpty.Equals("notEmpty"))
                    {
                        button.Enabled = false;
                        textBox.Focus();
                        errorProvider.SetError(textBox, "Field is empty");
                    }
                }
                else
                {
                    if (textBox.Text.Length > maxLength)
                    {
                        button.Enabled = false;
                        textBox.Focus();
                        errorProvider.SetError(textBox, "Maximum length is " + maxLength + " characters");
                    }
                    else if (textBox.Text.Length < minLength)
                    {
                        button.Enabled = false;
                        // e.Cancel = true;
                        textBox.Focus();
                        errorProvider.SetError(textBox, "Minimum length is " + minLength + " characters");
                    }
                    else
                    {
                        button.Enabled = true;
                        errorProvider.SetError(textBox, null); ;
                    }

                }
            }
        }

        private void usernameBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(usernameBox, 5, 256, okButton, "notEmpty");
        }

        private void passwordBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(passwordBox, 5, 256, okButton, "Empty");
        }

        private void confirmPasswordBox_TextChanged(object sender, EventArgs e)
        {
            if (!passwordBox.Text.Equals(confirmPasswordBox.Text))
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                {
                    okButton.Enabled = false;
                    errorProvider.SetError(confirmPasswordBox, "Lozinke nisu iste");
                }
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                {
                    okButton.Enabled = false;
                    errorProvider.SetError(confirmPasswordBox, "Passwords don't match");
                }
            }
            else
            {
                okButton.Enabled = true;
                errorProvider.SetError(confirmPasswordBox, null); ;
            }
        }
    }
}
