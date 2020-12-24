using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerService
{
    public partial class UserMain : Form
    {
        account account;
        public UserMain(account account)
        {
            InitializeComponent();
            this.account = account;
        }
        List<Control> buttons;
        List<Control> labels;
        void Initialize_Add()
        {
            
            buttons = new List<Control>();
            labels = new List<Control>();
            buttons.Add(componentsButton);
            buttons.Add(servicesButton);
            buttons.Add(serviceSheetButton);
            labels.Add(label1);

        }
        void ApplayTheme(Color background, Color label, Color button)
        {
            this.BackColor = background;
            
            foreach (var b in buttons)
            {
                b.BackColor = button;
                b.ForeColor = label;
            }
            foreach (var b in labels)
            {
                
                b.ForeColor = label;
            }

        }
        private void componentsButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var component = new ComponentForm(account);
            component.Closed += (s, args) => this.Close();
            this.Hide();
            component.Show();
            
        }

        private void servicesButton_Click(object sender, EventArgs e)
        {
            var services = new ServiceForm(account);
            services.Closed += (s, args) => this.Close();
            this.Hide();
            services.Show();
        }

        private void serviceSheetButton_Click(object sender, EventArgs e)
        {
            var serviceSheet = new ServiceSheetForm(account);
            serviceSheet.Closed += (s, args) => this.Close();
            this.Hide();
            serviceSheet.Show();
        }

        private void UserMain_Load(object sender, EventArgs e)
        {
            Initialize_Add();
            if(account.skin.Equals("dark"))
               ApplayTheme(zcolor(70, 70, 70), Color.White, zcolor(70, 70, 70));
            if (account.skin.Equals("light"))
                ApplayTheme(zcolor(232, 232, 232), Color.Black, zcolor(191, 191, 191));
            if (account.skin.Equals("blue"))
                ApplayTheme(zcolor(163, 197, 255), Color.Black, zcolor(84, 147, 255));

        }
        Color zcolor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }
    }
}
