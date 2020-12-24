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
    public partial class ServiceSheetForm : Form
    {
        List<Control> buttons;
        List<Control> labels;
        account account;
        public ServiceSheetForm(account account)
        {
            InitializeComponent();
            this.account = account;
        }
        void Initialize_Add()
        {
            // textBoxes = new List<Control>();
            buttons = new List<Control>();
            labels = new List<Control>();

            // textBoxes.Add(usernameTextBox);
            // textBoxes.Add(passwordTextBox);

            buttons.Add(addServiceSheetButton);
            buttons.Add(deleteServiceSheet);
            buttons.Add(updateServiceSheetButton);
            labels.Add(label1);

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
            menuStrip1.BackColor = background;
            menuStrip1.ForeColor = label;
            // componentGridView.BackgroundColor = background;

        }
        Color zcolor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }
        private void addServiceSheetButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = serviceSheetGridView.CurrentRow;
            var addServiceSheet = new AddServiceSheet(account, "insert",dataGridViewRow,this);
            addServiceSheet.Show();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var userMain = new UserMain(account);
            this.Hide();
            userMain.Closed += (s, args) => this.Close();
            userMain.Show();

        }

        private void componentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var component = new ComponentForm(account);
            this.Hide();
            component.Closed += (s, args) => this.Close();
            component.Show();
        }

        private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var service = new ServiceForm(account);
            this.Hide();
            service.Closed += (s, args) => this.Close();
            service.Show();
        }

        private void serviceSheetToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var login = new Login();
            this.Hide();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void ServiceSheet_Load(object sender, EventArgs e)
        {
            Initialize_Add();
            if (account.skin.Equals("dark"))
                ApplayTheme(zcolor(70, 70, 70), Color.White, zcolor(70, 70, 70), zcolor(70, 70, 70));
            if (account.skin.Equals("light"))
                ApplayTheme(zcolor(232, 232, 232), Color.Black, zcolor(191, 191, 191), Color.White);
            if (account.skin.Equals("blue"))
                ApplayTheme(zcolor(163, 197, 255), Color.Black, zcolor(84, 147, 255), Color.White);
            populateServiceSheetGridView();
        }
        public void populateServiceSheetGridView()
        {
            serviceSheetGridView.Rows.Clear();
            serviceSheetGridView.Refresh();
            using (ComputerServiceModel ctx = new ComputerServiceModel())
            {
                var allServiceSheet = (from c in ctx.service_sheet select c).ToList();
                foreach (var c in allServiceSheet)
                {
                    if (c.delete == 0) 
                    { 
                        var person = (from per in ctx.people where c.person_idperson == per.idperson select per).FirstOrDefault();
                        var product = (from pro in ctx.products where c.product_idproduct == pro.idproduct select pro).FirstOrDefault();
                        serviceSheetGridView.Rows.Add(c.idservice_sheet, person.name, person.phone_number, person.e_mail,
                        product.product_number, product.type, product.manufacturer, product.seria, c.date, c.description, c.status, c.price);
                     }
                }
            }
        }

        private void deleteServiceSheet_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show("Do you want to delete selected user", "Delete user", buttons);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (ComputerServiceModel ctx = new ComputerServiceModel())
                    {
                        int rowIndex = serviceSheetGridView.CurrentCell.RowIndex;
                        //usersGridView.CurrentRow.Cells.
                        DataGridViewRow dataGridViewRow = serviceSheetGridView.CurrentRow;

                        //  MessageBox.Show("id je prije" + dataGridViewRow.Cells[0].ToString());
                        int id = Int32.Parse(dataGridViewRow.Cells[0].Value.ToString());
                        // MessageBox.Show("id je " + id);
                        var service_sheet = (from c in ctx.service_sheet where c.idservice_sheet == id select c).FirstOrDefault();

                        if (service_sheet != null)
                        {
                            service_sheet.delete = 1;
                            ctx.SaveChanges();

                        }
                        populateServiceSheetGridView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
        private void darkThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ComputerServiceModel ctx = new ComputerServiceModel())
            {
                var pom = (from c in ctx.accounts where c.idaccount == account.idaccount select c).FirstOrDefault();
                if (pom != null)
                {
                    pom.skin = "dark";
                    ctx.SaveChanges();
                    
                }
                account.skin = "dark";
                ApplayTheme(zcolor(70, 70, 70), Color.White, zcolor(70, 70, 70), zcolor(70, 70, 70));
            }
        }
        private void lightThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ComputerServiceModel ctx = new ComputerServiceModel())
            {
                var pom = (from c in ctx.accounts where c.idaccount == account.idaccount select c).FirstOrDefault();
                if (pom != null)
                {
                    pom.skin = "light";
                    ctx.SaveChanges();

                }
                account.skin = "light";
                ApplayTheme(zcolor(232, 232, 232), Color.Black, zcolor(191, 191, 191), Color.White);
            }
        }

        private void blueThemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ComputerServiceModel ctx = new ComputerServiceModel())
            {
                var pom = (from c in ctx.accounts where c.idaccount == account.idaccount select c).FirstOrDefault();
                if (pom != null)
                {
                    pom.skin = "blue";
                    ctx.SaveChanges();

                }
                account.skin= "blue";
                ApplayTheme(zcolor(163, 197, 255), Color.Black, zcolor(84, 147, 255), Color.White);
            }
        }

        private void updateServiceSheetButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = serviceSheetGridView.CurrentRow;
            var addServiceSheet = new AddServiceSheet(account,"update",dataGridViewRow,this);
            addServiceSheet.Show();
        }

        private void englishToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            this.Controls.Clear();
            InitializeComponent();
            ServiceSheet_Load(sender, e);
        }

        private void serbianToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr-Latn");
            this.Controls.Clear();
            InitializeComponent();
            ServiceSheet_Load(sender, e);
        }
    }
}
