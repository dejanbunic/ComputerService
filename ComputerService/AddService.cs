using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerService
{
    public partial class AddService : Form
    {
        List<Control> textBoxes;
        List<Control> buttons;
        List<Control> labels;
        DataGridViewRow dataGridViewRow;
        String insertOrUpdate;
        ServiceForm service;
        ErrorProvider errorProvider = new ErrorProvider();
        void Initialize_Add()
        {
            textBoxes = new List<Control>();
            buttons = new List<Control>();
            labels = new List<Control>();

            textBoxes.Add(nameTextBox);
            textBoxes.Add(typeTextBox);
            textBoxes.Add(priceTextBox);

            buttons.Add(okButton);
            buttons.Add(cancelButton);
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
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
        }
        Color zcolor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }
        account account;
        public AddService(ServiceForm service,String insertOrUpdate, DataGridViewRow dataGridViewRow,account account)
        {
            InitializeComponent();
            this.service = service;
            this.insertOrUpdate = insertOrUpdate;
            this.dataGridViewRow = dataGridViewRow;
            this.account = account;
            if (insertOrUpdate.Equals("update"))
            {
                nameTextBox.Text = dataGridViewRow.Cells[1].Value.ToString();
                typeTextBox.Text = dataGridViewRow.Cells[2].Value.ToString();
                priceTextBox.Text = dataGridViewRow.Cells[3].Value.ToString();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                if(ValidateChildren(ValidationConstraints.Enabled))
                {
                    decimal temp;
                    //  decimal.TryParse(priceTextBox.Text, out temp);
                    if (decimal.TryParse(priceTextBox.Text, out temp))
                    {
                        using (ComputerServiceModel ctx = new ComputerServiceModel())
                        {
                            if (insertOrUpdate.Equals("insert"))
                            { 
                                var service = new service()
                                {
                                    name = nameTextBox.Text,
                                    type = typeTextBox.Text,
                                    price = temp
                                };
                                ctx.services.Add(service);
                                ctx.SaveChanges();

                            }
                            if (insertOrUpdate.Equals("update"))
                            {
                                int id = Int32.Parse(dataGridViewRow.Cells[0].Value.ToString());
                                var services = (from s in ctx.services where s.idservice==id select s).FirstOrDefault();
                                if (services != null)
                                {
                                    services.name = nameTextBox.Text.ToString();
                                    services.type = typeTextBox.Text.ToString();
                                    services.price = temp;
                                    ctx.SaveChanges();
                                }
                            }
                            this.Close();
                        }
                    }
                    else
                    {
                       // MessageBox.Show("Price field is not decimal");
                    }
                    // populateComponentGridView();
                    service.populateServiceGridView();
                    
                }
                else
                {
                   // MessageBox.Show("Fill all fields");
                }
            }
            catch (Exception)
            {

            }                    
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void AddService_Load(object sender, EventArgs e)
        {
            Initialize_Add();
            if (account.skin.Equals("dark"))
                ApplayTheme(zcolor(70, 70, 70), Color.White, zcolor(70, 70, 70), zcolor(70, 70, 70));
            if (account.skin.Equals("light"))
                ApplayTheme(zcolor(232, 232, 232), Color.Black, zcolor(191, 191, 191), Color.White);
            if (account.skin.Equals("blue"))
                ApplayTheme(zcolor(163, 197, 255), Color.Black, zcolor(84, 147, 255), Color.White);
        }

        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(nameTextBox, 0, 44, okButton, "notEmpty");
        }

        private void typeTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(typeTextBox, 0, 120, okButton, "notEmpty");
        }

        private void priceTextBox_Validating(object sender, CancelEventArgs e)
        {
            decimal temp;
            decimal.TryParse(priceTextBox.Text, out temp);
            okButton.Enabled = true;
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
            {
                if (string.IsNullOrEmpty(priceTextBox.Text))
                {

                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Polje je prazno");
                }
                else if (temp < 0)
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Cijena ne moze biti negativna");
                }
                else if(!decimal.TryParse(priceTextBox.Text, out temp))
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Cijena nije broj");
                }
                else
                {
                    okButton.Enabled = true;
                    errorProvider.SetError(priceTextBox, null); ;
                }
            }
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
            {
                if (string.IsNullOrEmpty(priceTextBox.Text))
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Field is empty");
                }
                else if (temp < 0)
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Must be positive number");
                }
               else if (!decimal.TryParse(priceTextBox.Text, out temp))
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Must be number");
                }
                else
                {
                   okButton.Enabled = true;
                    errorProvider.SetError(priceTextBox, null);
                }
            }
        }
        private void validateMessage(TextBox textBox, int minLength, int maxLength, Button button, String emptyOrNot)
        {
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
            {
                button.Enabled = true;
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    if (emptyOrNot.Equals("notEmpty"))
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
                        errorProvider.SetError(textBox, "Maksimalna dužina je " + maxLength + " karaktera");
                    }
                    else if (textBox.Text.Length < minLength)
                    {
                        button.Enabled = false;
                        textBox.Focus();
                        errorProvider.SetError(textBox, "Minimalna dužina je " + minLength + " karaktera");
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
                    if (emptyOrNot.Equals("notEmpty"))
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

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(nameTextBox, 0, 44, okButton, "notEmpty");
        }

        private void typeTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(typeTextBox, 0, 120, okButton, "notEmpty");
        }

        private void priceTextBox_TextChanged(object sender, EventArgs e)
        {
            decimal temp;
            decimal.TryParse(priceTextBox.Text, out temp);
            okButton.Enabled = true;
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
            {
                if (string.IsNullOrEmpty(priceTextBox.Text))
                {

                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Polje je prazno");
                }
                else if (temp < 0)
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Cijena ne moze biti negativna");
                }
                else if (!decimal.TryParse(priceTextBox.Text, out temp))
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Cijena nije broj");
                }
                else
                {
                    okButton.Enabled = true;
                    errorProvider.SetError(priceTextBox, null); ;
                }
            }
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
            {
                if (string.IsNullOrEmpty(priceTextBox.Text))
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Field is empty");
                }
                else if (temp < 0)
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Must be positive number");
                }
                else if (!decimal.TryParse(priceTextBox.Text, out temp))
                {
                    okButton.Enabled = false;
                    priceTextBox.Focus();
                    errorProvider.SetError(priceTextBox, "Must be number");
                }
                else
                {
                    okButton.Enabled = true;
                    errorProvider.SetError(priceTextBox, null); ;
                }
            }
        }
    }
}
