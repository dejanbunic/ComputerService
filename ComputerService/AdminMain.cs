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
    public partial class AdminMain : Form
    {
        List<Control> textBoxes;
        List<Control> buttons;
        List<Control> labels;
        void Initialize_Add()
        {
            textBoxes = new List<Control>();
            buttons = new List<Control>();
            labels = new List<Control>();

            //textBoxes.Add(user);
           // textBoxes.Add(passwordTextBox);

            buttons.Add(addUserButton);
            buttons.Add(updateUserButton);
            buttons.Add(deleteUserButton);
            labels.Add(label1);
            //labels.Add(label2);
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
        public AdminMain(account account)
        {
            InitializeComponent();
            this.account=account;
        }

        public DataGridView getGridView()
        {
            return usersGridView;
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
           // var account = new account();
            DataGridViewRow dataGridViewRow = usersGridView.CurrentRow;
            var addUser = new AddUser(this,"insert",  dataGridViewRow,account);
            addUser.Show();

        }
        public void populateUserGridView()
        {
            try
            {
                usersGridView.Rows.Clear();
                usersGridView.Refresh();
                using (ComputerServiceModel ctx = new ComputerServiceModel())
                {
                    var allUsers = (from c in ctx.accounts select c).ToList();
                    var allArministrators = (from a in ctx.administrators select a).ToList();
                    foreach (var c in allUsers)
                    {
                        
                        int i = 0;
                        foreach (var a in allArministrators)
                        {
                            if (a.account_idaccount == c.idaccount)
                            {
                                i = 1;
                            }
                        }
                        if (c.delete == 0)
                        {
                            if (i == 1)
                                usersGridView.Rows.Add(c.idaccount, c.username, c.password, "Administrator");
                            else
                                usersGridView.Rows.Add(c.idaccount, c.username, c.password, "User");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace);
            }
        }

        private void AdminMain_Load(object sender, EventArgs e)
        {
            Initialize_Add();
           
            if (account.skin.Equals("dark"))
                ApplayTheme(zcolor(70, 70, 70), Color.White, zcolor(70, 70, 70), zcolor(70, 70, 70));
            if (account.skin.Equals("light"))
                ApplayTheme(zcolor(232, 232, 232), Color.Black, zcolor(191, 191, 191), Color.White);
            if (account.skin.Equals("blue"))
                ApplayTheme(zcolor(163, 197, 255), Color.Black, zcolor(84, 147, 255), Color.White);
            populateUserGridView();

        }
        
        private void deleteUserButton_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            //MessageBoxButtons.Ca
            //MessageBox.Show(buttons.GetHashCode()+"Hes kod"+buttons.ToString);
            DialogResult result=new DialogResult();
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                result = MessageBox.Show("Do you want to delete selected user?", "Delete user", buttons, MessageBoxIcon.Question);
            if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                result = MessageBox.Show("Da li želite da obrišete izabranog korisnika?", "Obriši korisnika", buttons,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    using (ComputerServiceModel ctx = new ComputerServiceModel())
                    {
                        int rowIndex = usersGridView.CurrentCell.RowIndex;
                        //usersGridView.CurrentRow.Cells.
                        DataGridViewRow dataGridViewRow = usersGridView.CurrentRow;
                       
                      //  MessageBox.Show("id je prije" + dataGridViewRow.Cells[0].ToString());
                        int id = Int32.Parse(dataGridViewRow.Cells[0].Value.ToString());
                       // MessageBox.Show("id je " + id);
                        var user = (from c in ctx.accounts where c.idaccount == id select c).FirstOrDefault();
                        
                        if (user != null)
                        {
                            user.delete = 1;
                            ctx.SaveChanges();
                            
                        }
                        populateUserGridView();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }

        private void updateUserButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = usersGridView.CurrentRow;
            var addUser = new AddUser(this, "update", dataGridViewRow, account);
            addUser.Show();
          //  DataGridViewRow dataGridViewRow = usersGridView.CurrentRow;
          /*  var account = new account()
            {
                idaccount = Int32.Parse(dataGridViewRow.Cells[0].Value.ToString()),
                username = dataGridViewRow.Cells[1].Value.ToString(),
                password = dataGridViewRow.Cells[2].Value.ToString()
            };*/
          //  var addUser = new AddUser(this,"update",dataGridViewRow,account);
           // addUser.Show();
           
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var login = new Login();
            this.Hide();
            login.Closed += (s, args) => this.Close();
            login.Show();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            this.Controls.Clear();
            InitializeComponent();
            AdminMain_Load(sender, e);
        }

        private void serbianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("sr-Latn");
            this.Controls.Clear();
            InitializeComponent();
            AdminMain_Load(sender, e);
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
    }
}