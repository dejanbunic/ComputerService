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
    public partial class ComponentForm : Form
    {
        account account;
        public ComponentForm(account account)
        {
            InitializeComponent();
            this.account = account;
        }
       // List<Control> textBoxes;
        List<Control> buttons;
        List<Control> labels;
        void Initialize_Add()
        {
           // textBoxes = new List<Control>();
            buttons = new List<Control>();
            labels = new List<Control>();

           // textBoxes.Add(usernameTextBox);
           // textBoxes.Add(passwordTextBox);

            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
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
        private void ComponentForm_Load(object sender, EventArgs e)
        {
            Initialize_Add();
            if (account.skin.Equals("dark"))
                ApplayTheme(zcolor(70, 70, 70), Color.White, zcolor(70, 70, 70), zcolor(70, 70, 70));
            if (account.skin.Equals("light"))
                ApplayTheme(zcolor(232, 232, 232), Color.Black, zcolor(191, 191, 191), Color.White);
            if (account.skin.Equals("blue"))
                ApplayTheme(zcolor(163, 197, 255), Color.Black, zcolor(84, 147, 255), Color.White);
            populateComponentGridView();
        }
        public void populateComponentGridView()
        {
            componentGridView.Rows.Clear();
            componentGridView.Refresh();
            using (ComputerServiceModel ctx = new ComputerServiceModel())
            {
                var allComponents = (from c in ctx.components where c.delete == 0 select c).ToList();
                foreach (var c in allComponents)
                {
                    componentGridView.Rows.Add(c.idcomponent, c.type, c.manufacturer, c.seria, c.price);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;

           // DialogResult result = MessageBox.Show("Do you want to delete selected component", "Delete component", buttons);
            DialogResult result = new DialogResult();
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                result = MessageBox.Show("Do you want to delete selected component?", "Delete component", buttons, MessageBoxIcon.Question);
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                result = MessageBox.Show("Da li želite da obrišete izabranu komponentu?", "Obriši komponentu", buttons, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
                try
                {
                    using (ComputerServiceModel ctx = new ComputerServiceModel())
                    {
                        int rowIndex = componentGridView.CurrentCell.RowIndex;
                        DataGridViewRow dataGridViewRow = componentGridView.CurrentRow;
                        int id = Int32.Parse(dataGridViewRow.Cells[0].Value.ToString());
                        var component = (from c in ctx.components where c.idcomponent == id select c).FirstOrDefault();

                        if (component != null)
                        {
                            component.delete = 1;
                            ctx.SaveChanges();

                        }
                        populateComponentGridView();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  ComponentForm component = new ComponentForm();
            DataGridViewRow dataGridViewRow = componentGridView.CurrentRow;
           var addComponent = new AddComponent(this,"insert",dataGridViewRow,account);
           addComponent.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  ComponentForm component = new ComponentForm();
            DataGridViewRow dataGridViewRow = componentGridView.CurrentRow;
            var addComponent = new AddComponent(this, "update", dataGridViewRow,account);
            addComponent.Show();
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
            var serviceSheet = new ServiceSheetForm(account);
            this.Hide();
            serviceSheet.Closed += (s, args) => this.Close();
            serviceSheet.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var login = new Login();
            this.Hide();
            login.Closed += (s, args) => this.Close();
            login.Show();
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
                account.skin = "blue";
                ApplayTheme(zcolor(163, 197, 255), Color.Black, zcolor(84, 147, 255), Color.White);
            }
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            this.Controls.Clear();
            InitializeComponent();
            ComponentForm_Load(sender,e);
        }

        private void serbianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr-Latn");
            this.Controls.Clear();
            InitializeComponent();
            ComponentForm_Load(sender, e);
        }
    }
}