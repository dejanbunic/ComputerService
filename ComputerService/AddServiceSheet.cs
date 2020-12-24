//using iTextSharp.text;
//using iTextSharp.text.pdf;
using iText.IO.Font;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComputerService
{
    public partial class AddServiceSheet : Form
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

            textBoxes.Add(nameTextBox);
            textBoxes.Add(phoneNumberTextBox);
            textBoxes.Add(emailTextBox);
            textBoxes.Add(productNumberTextBox);
            textBoxes.Add(typeTextBox);
            textBoxes.Add(manufacturerTextBox);
            textBoxes.Add(seriaTextBox);
            textBoxes.Add(descriptionTextBox);
            textBoxes.Add(statusTextBox);

            buttons.Add(button1);
            buttons.Add(button2);
            buttons.Add(button3);
            buttons.Add(button4);
            buttons.Add(button5);
            buttons.Add(button6);
            labels.Add(label1);
            labels.Add(label2);
            labels.Add(label3);
            labels.Add(label4);
            labels.Add(label5);
            labels.Add(label6);
            labels.Add(label7);
            labels.Add(label8);
            labels.Add(label9);
            labels.Add(label10);
            labels.Add(label11);
            labels.Add(label12);
            //labels.Add(label13);
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
        account account;
        string insertOrUpdate;
        DataGridViewRow dataGridViewRow;
        ServiceSheetForm serviceSheetForm;
        public AddServiceSheet(account account, String insertOrUpdate, DataGridViewRow dataGridViewRow,ServiceSheetForm serviceSheetForm)
        {
            InitializeComponent();
            this.serviceSheetForm = serviceSheetForm;
            this.account = account;
            this.insertOrUpdate = insertOrUpdate;
            this.dataGridViewRow = dataGridViewRow;
            populateUserGridView();
            populateServicesGridView();
            if (insertOrUpdate.Equals("update"))
            {
                this.dataGridViewRow = dataGridViewRow;
                int id = (int)dataGridViewRow.Cells[0].Value;
                nameTextBox.Text = dataGridViewRow.Cells[1].Value.ToString();
                phoneNumberTextBox.Text = dataGridViewRow.Cells[2].Value.ToString();
                emailTextBox.Text = dataGridViewRow.Cells[3].Value.ToString();
                productNumberTextBox.Text = dataGridViewRow.Cells[4].Value.ToString();
                typeTextBox.Text = dataGridViewRow.Cells[5].Value.ToString();
                manufacturerTextBox.Text = dataGridViewRow.Cells[6].Value.ToString();
                seriaTextBox.Text = dataGridViewRow.Cells[7].Value.ToString();
                //dat des status price
                descriptionTextBox.Text = dataGridViewRow.Cells[9].Value.ToString();
                statusTextBox.Text = dataGridViewRow.Cells[10].Value.ToString();

                //priceText
                //MessageBox.Show("nekakok to ne ide");
                using (ComputerServiceModel ctx = new ComputerServiceModel())
                {
                    var serviceSheet = (from c in ctx.service_sheet where c.idservice_sheet == id select c).FirstOrDefault();
                //    var allComponents = serviceSheet.components;
                    foreach (DataGridViewRow r in componentsGridView.Rows) 
                    { 
                        foreach (var a in serviceSheet.components)
                        {
                           // MessageBox.Show("id komponente je" + a.idcomponent);
                            if(a.idcomponent == (int)r.Cells[0].Value)
                            {
                               // MessageBox.Show("id komponente je" + a.idcomponent);
                                r.Cells[5].Value = "Yes";
                            }
                        }
                    }

                    foreach (DataGridViewRow r in servicesGridView.Rows)
                    {
                        foreach (var a in serviceSheet.services)
                        {
                            // MessageBox.Show("id komponente je" + a.idcomponent);
                            if (a.idservice == (int)r.Cells[0].Value)
                            {
                               // MessageBox.Show("id servisa je" + a.idservice);
                                r.Cells[4].Value = "Yes";
                            }
                        }
                    }

                }

            }
        }
        public void populateUserGridView()
        {
            componentsGridView.Rows.Clear();
            componentsGridView.Refresh();
            using (ComputerServiceModel ctx = new ComputerServiceModel())
            {
                var allComponents = (from c in ctx.components where c.delete==0 select c).ToList();
                foreach(var c in allComponents)
                {
                    componentsGridView.Rows.Add(c.idcomponent,c.type,c.manufacturer,c.seria,c.price,"No");
                }
            }
        }
        public void populateServicesGridView()
        {
            servicesGridView.Rows.Clear();
            servicesGridView.Refresh();
            using(ComputerServiceModel ctx = new ComputerServiceModel())
            {
                var allServices =(from c in ctx.services where c.delete == 0  select c).ToList();
                foreach(var c in allServices)
                {
                    servicesGridView.Rows.Add(c.idservice, c.name, c.type, c.price, "No");
                }
            }
        }
        private void AddServiceSheet_Load(object sender, EventArgs e)
        {
            Initialize_Add();
            if (account.skin.Equals("dark"))
                ApplayTheme(zcolor(70, 70, 70), Color.White, zcolor(70, 70, 70), zcolor(70, 70, 70));
            if (account.skin.Equals("light"))
                ApplayTheme(zcolor(232, 232, 232), Color.Black, zcolor(191, 191, 191), Color.White);
            if (account.skin.Equals("blue"))
                ApplayTheme(zcolor(163, 197, 255), Color.Black, zcolor(84, 147, 255), Color.White);
            nameTextBox.Height = 40;
            nameTextBox.Width = 100;
          //  populateUserGridView();
           // populateServicesGridView();
        }
        Color zcolor(int r, int g, int b)
        {
            return Color.FromArgb(r, g, b);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int rowIndex = componentsGridView.CurrentCell.RowIndex;
            //usersGridView.CurrentRow.Cells.
            DataGridViewRow dataGridViewRow = componentsGridView.CurrentRow;
            dataGridViewRow.Cells[5].Value = "Yes";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = componentsGridView.CurrentCell.RowIndex;
            //usersGridView.CurrentRow.Cells.
            DataGridViewRow dataGridViewRow = componentsGridView.CurrentRow;
            dataGridViewRow.Cells[5].Value = "No";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //int i = 0;
            foreach (DataGridViewRow d in componentsGridView.Rows)
            {
                if (!searchComponentsTextBox.Text.Equals("")) 
                { 
                    if (d.Cells[0].Value.ToString().Contains(searchComponentsTextBox.Text) || d.Cells[1].Value.ToString().Contains(searchComponentsTextBox.Text) || d.Cells[2].Value.ToString().Contains(searchComponentsTextBox.Text) ||
                        d.Cells[3].Value.ToString().Contains(searchComponentsTextBox.Text) || d.Cells[4].Value.ToString().Contains(searchComponentsTextBox.Text) || d.Cells[5].Value.ToString().Contains(searchComponentsTextBox.Text))
                    {
                        d.Visible = true;

                    }
                    else
                    {
                        d.Visible = false;
                    }
                }
                else
                {
                    
                        d.Visible = true;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //add
            int rowIndex = servicesGridView.CurrentCell.RowIndex;
            //usersGridView.CurrentRow.Cells.
            DataGridViewRow dataGridViewRow = servicesGridView.CurrentRow;
            dataGridViewRow.Cells[4].Value = "Yes";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //delete 
            int rowIndex = servicesGridView.CurrentCell.RowIndex;
            //usersGridView.CurrentRow.Cells.
            DataGridViewRow dataGridViewRow = servicesGridView.CurrentRow;
            dataGridViewRow.Cells[4].Value = "No";
        }

        private void textBox10_TextChanged_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow a in servicesGridView.Rows)
            {
                //int i = 0;
                if (!searchServicesTextBox.Text.Equals("") && a.Cells[0].Value != null)
                {
                    //MessageBox.Show(a.Cells[0].Value.ToString());
                    if (a.Cells[0].Value.ToString().Contains(searchServicesTextBox.Text) || a.Cells[1].Value.ToString().Contains(searchServicesTextBox.Text) || a.Cells[2].Value.ToString().Contains(searchServicesTextBox.Text) ||
                        a.Cells[3].Value.ToString().Contains(searchServicesTextBox.Text) || a.Cells[4].Value.ToString().Contains(searchServicesTextBox.Text))
                   //if(a.Cells[0].Value.ToString().Contains(searchServicesTextBox.Text))
                    {
                        a.Visible = true;

                    }
                    else
                    {
                        a.Visible = false;
                    }
                }
                else
                {

                    a.Visible = true;
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //add
           // MessageBox.Show("cirkus");
            try
            {
                validateMessage(nameTextBox, 0, 120, button5, "notEmpty");
                validateMessage(typeTextBox, 0, 120, button5, "notEmpty");
                validateMessage(descriptionTextBox, 0, 512, button5, "notEmpty");
                validateMessage(statusTextBox, 0, 40, button5, "notEmpty");
                using (ComputerServiceModel ctx = new ComputerServiceModel())
                {

                    if (insertOrUpdate.Equals("insert") && !string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(typeTextBox.Text) && !string.IsNullOrEmpty(descriptionTextBox.Text) && !string.IsNullOrEmpty(statusTextBox.Text))
                    {
                        var person = new person()
                        {
                            name = nameTextBox.Text,
                            e_mail = emailTextBox.Text,
                            phone_number = phoneNumberTextBox.Text

                        };

                        ctx.people.Add(person);
                        ctx.SaveChanges();
                        ctx.Entry(person).GetDatabaseValues();
                        int idPerson = person.idperson;
                        //MessageBox.Show("id osobe je" + idPerson);
                        var product = new product()
                        {
                            type = typeTextBox.Text,
                            manufacturer = manufacturerTextBox.Text,
                            seria = seriaTextBox.Text,
                            product_number = productNumberTextBox.Text
                        };
                        ctx.products.Add(product);
                        ctx.SaveChanges();
                        ctx.Entry(product).GetDatabaseValues();
                        int idProduct = product.idproduct;
                        //MessageBox.Show("id proizvoda je" + idProduct);
                        //decimal d = 3;
                        var serviceSheet = new service_sheet()
                        {
                            person_idperson = idPerson,
                            product_idproduct = idProduct,
                            description = descriptionTextBox.Text,
                            status = statusTextBox.Text,
                            date = DateTime.Now,
                            price = 0
                        };


                        foreach (DataGridViewRow com in componentsGridView.Rows)
                        {
                            if (com.Cells[5].Value.ToString().Equals("Yes"))
                            {
                                int id = (int)com.Cells[0].Value;
                                var component = ctx.components.FirstOrDefault(s => s.idcomponent == id);
                                serviceSheet.components.Add(component);
                                // decimal temp;
                                // decimal.TryParse(component.price, out temp);
                                serviceSheet.price += component.price;
                            }
                        }
                        foreach (DataGridViewRow ser in servicesGridView.Rows)
                        {
                            if (ser.Cells[4].Value.ToString().Equals("Yes"))
                            {
                                int id = (int)ser.Cells[0].Value;
                                var service = ctx.services.FirstOrDefault(s => s.idservice == id);
                                serviceSheet.services.Add(service);
                                serviceSheet.price += service.price;
                            }
                        }

                        ctx.service_sheet.Add(serviceSheet);
                        ctx.SaveChanges();
                        ctx.Entry(serviceSheet).GetDatabaseValues();
                        int idServiceSheet = serviceSheet.idservice_sheet;
                        createPdf(idServiceSheet);
                        this.Close();
                    }
                    if (insertOrUpdate.Equals("update") && !string.IsNullOrEmpty(nameTextBox.Text) && !string.IsNullOrEmpty(typeTextBox.Text) && !string.IsNullOrEmpty(descriptionTextBox.Text) && !string.IsNullOrEmpty(statusTextBox.Text))
                    {
                        int idServiceSheet = (int)dataGridViewRow.Cells[0].Value;
                       // createPdf(idServiceSheet);
                        var serviceSheet = (from s in ctx.service_sheet where s.idservice_sheet == idServiceSheet select s).FirstOrDefault();
                        var person = (from p in ctx.people where p.idperson == serviceSheet.person_idperson select p).FirstOrDefault();
                        var product = (from p in ctx.products where p.idproduct == serviceSheet.product_idproduct select p).FirstOrDefault();
                        serviceSheet.price = 0;
                        serviceSheet.components.Clear();
                        serviceSheet.services.Clear();
                        if (serviceSheet != null)
                        {
                            serviceSheet.status = statusTextBox.Text;
                            serviceSheet.description = descriptionTextBox.Text;
                            ctx.SaveChanges();
                        }
                        if (person != null)
                        {
                            person.name = nameTextBox.Text;
                            person.phone_number = phoneNumberTextBox.Text;
                            person.e_mail = emailTextBox.Text;
                            ctx.SaveChanges();

                        }
                        if (product != null)
                        {
                            product.type = typeTextBox.Text;
                            product.manufacturer = manufacturerTextBox.Text;
                            product.product_number = productNumberTextBox.Text;
                            product.seria = seriaTextBox.Text;
                            ctx.SaveChanges();
                        }

                        foreach (DataGridViewRow com in componentsGridView.Rows)
                        {
                            if (com.Cells[5].Value.ToString().Equals("Yes"))
                            {
                                int id = (int)com.Cells[0].Value;
                                var component = ctx.components.FirstOrDefault(s => s.idcomponent == id);
                                serviceSheet.components.Add(component);
                                serviceSheet.price += component.price;
                            }
                        }

                        foreach (DataGridViewRow ser in servicesGridView.Rows)
                        {
                            if (ser.Cells[4].Value.ToString().Equals("Yes"))
                            {
                                int id = (int)ser.Cells[0].Value;
                                var service = ctx.services.FirstOrDefault(s => s.idservice == id);
                                serviceSheet.services.Add(service);
                                serviceSheet.price += service.price;
                            }
                        }
                        ctx.SaveChanges();
                        createPdf(idServiceSheet);
                        this.Close();
                    }
                }
                serviceSheetForm.populateServiceSheetGridView();

            }
            catch (Exception)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en"))
                    MessageBox.Show("Close pdf");
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                    MessageBox.Show("Zatvori pdf");
            } 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            createPdf(4);
            this.Close();
        }
        private void createPdf(int id) 
        {
            using (ComputerServiceModel ctx = new ComputerServiceModel())
            {
               // String FONT = ".."+Path.DirectorySeparatorChar+".."+Path.DirectorySeparatorChar+"Resources" + Path.DirectorySeparatorChar + "Arimo-Regular.ttf";
                PdfFont normalFont = PdfFontFactory.CreateFont(FontConstants.HELVETICA, "Cp1250");
                var serviceSheet = (from s in ctx.service_sheet where id == s.idservice_sheet select s).FirstOrDefault();
               // PdfFont font = PdfFontFactory.CreateFont(FONT, PdfEncodings.IDENTITY_H, true);
                // MessageBox.Show("user path"+Environment.GetFolderPath(Environment.SpecialFolder.UserProfile));
                String computerServicePath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + Path.DirectorySeparatorChar + "ComputerService";
                //MessageBox.Show("computer service path" + computerServicePath);
                if (!Directory.Exists(computerServicePath))
                {
                    DirectoryInfo di = Directory.CreateDirectory(computerServicePath);
                }
                String path = computerServicePath + Path.DirectorySeparatorChar + "PDF";
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }

                    PdfWriter writer;
                    writer = new PdfWriter(path + Path.DirectorySeparatorChar + "ServiceSheet" + id + ".pdf");
                
                
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);
                document.SetFont(normalFont);
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("en") )
                { 
                    Paragraph header = new Paragraph("Service sheet")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(20);

                    document.Add(header);

                    LineSeparator ls = new LineSeparator(new iText.Kernel.Pdf.Canvas.Draw.SolidLine());
                    Paragraph person = new Paragraph("Person information")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(15);
                    document.Add(person);
                    document.Add(new Paragraph("Name: " + nameTextBox.Text));
                    document.Add(new Paragraph("Phone: " + phoneNumberTextBox.Text));
                    document.Add(new Paragraph("E-mail: " + emailTextBox.Text));
                    document.Add(ls);
                    Paragraph device = new Paragraph("Device information")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(15);
                    document.Add(device);
                    document.Add(new Paragraph("Type: " + typeTextBox.Text));
                    document.Add(new Paragraph("Product number: " + productNumberTextBox.Text));
                    document.Add(new Paragraph("Manufacturer: " + manufacturerTextBox.Text));
                    document.Add(new Paragraph("Seria: " + seriaTextBox.Text));
                    document.Add(ls);

                    if (serviceSheet.components.Count > 0)
                    {
                        Paragraph components = new Paragraph("Components")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(15);
                        document.Add(components);
                        foreach (var component in serviceSheet.components)
                        {
                            document.Add(new Paragraph("Type: " + component.type));
                            document.Add(new Paragraph("Manufacturer: " + component.manufacturer));
                            document.Add(new Paragraph("Seria: " + component.seria));
                            document.Add(new Paragraph("Price: " + component.price));
                        }
                        document.Add(ls);
                    }


                    if (serviceSheet.services.Count > 0)
                    {
                        Paragraph services = new Paragraph("Services")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(15);
                        document.Add(services);
                        foreach (var service in serviceSheet.services)
                        {
                            //document.Add(Chunk.TABBING);
                            document.Add(new Paragraph("    Name: " + service.name));
                            document.Add(new Paragraph("    Type: " + service.type));
                            document.Add(new Paragraph("    Price: " + service.price));
                        }
                        document.Add(ls);
                    }

                    document.Add(new Paragraph("Description: " + descriptionTextBox.Text));
                    document.Add(new Paragraph("Status: " + statusTextBox.Text));
                    document.Add(new Paragraph("Date: " + serviceSheet.date.ToString("dd-MM-yyyy HH:mm:ss")));
                    document.Add(new Paragraph("Total Price: " + serviceSheet.price));
                    document.Close();
                }
                if (Thread.CurrentThread.CurrentUICulture.Name.Equals("sr-Latn"))
                {
                    Paragraph header = new Paragraph("Servisni list")
                   .SetTextAlignment(TextAlignment.CENTER)
                   .SetFontSize(20);
                    document.Add(header);
                    LineSeparator ls = new LineSeparator(new iText.Kernel.Pdf.Canvas.Draw.SolidLine());
                    Paragraph person = new Paragraph("Informacije osobe")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(15);
                    document.Add(person);
                    document.Add(new Paragraph("Ime: " + nameTextBox.Text));
                    document.Add(new Paragraph("Telefon: " + phoneNumberTextBox.Text));
                    document.Add(new Paragraph("E-mail: " + emailTextBox.Text));
                    document.Add(ls);
                    Paragraph device = new Paragraph("Informacije o uređaju")
                       .SetTextAlignment(TextAlignment.CENTER)
                       .SetFontSize(15);
                    document.Add(device);
                    document.Add(new Paragraph("Tip ure\u0111aja: " + typeTextBox.Text));
                    document.Add(new Paragraph("Broj proizvoda: " + productNumberTextBox.Text));
                    document.Add(new Paragraph("Proizvo\u0111a\u010D: " + manufacturerTextBox.Text));
                    document.Add(new Paragraph("Serija: " + seriaTextBox.Text));
                    document.Add(ls);
                    if (serviceSheet.components.Count > 0)
                    {
                        Paragraph components = new Paragraph("Komponente")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(15);
                        document.Add(components);
                        foreach (var component in serviceSheet.components)
                        {
                            document.Add(new Paragraph("Tip koponente: " + component.type));
                            document.Add(new Paragraph("Proizvo\u0111a\u010D: " + component.manufacturer));
                            document.Add(new Paragraph("Serija: " + component.seria));
                            document.Add(new Paragraph("Cijena: " + component.price));
                        }
                        document.Add(ls);
                    }
                    if (serviceSheet.services.Count > 0)
                    {
                        Paragraph services = new Paragraph("Servisi")
                        .SetTextAlignment(TextAlignment.CENTER)
                        .SetFontSize(15);
                        document.Add(services);
                        foreach (var service in serviceSheet.services)
                        {
                            //document.Add(Chunk.TABBING);
                            document.Add(new Paragraph("Naziv: " + service.name));
                            document.Add(new Paragraph("Tip: " + service.type));
                            document.Add(new Paragraph("Cijena: " + service.price));
                        }
                        document.Add(ls);
                    }
                    document.Add(new Paragraph("Opis: " + descriptionTextBox.Text));
                    document.Add(new Paragraph("Status: " + statusTextBox.Text));
                    document.Add(new Paragraph("Datum: " + serviceSheet.date.ToString("dd-MM-yyyy HH:mm:ss")));
                    document.Add(new Paragraph("Ukupna cijena: " + serviceSheet.price));
                    document.Close();

                }
                
            }
        }
        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void nameTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(nameTextBox, 0, 120, button5, "notEmpty");
        }

        private void phoneNumberTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(phoneNumberTextBox, 0, 40, button5, "Empty");
        }

        private void emailTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(emailTextBox, 0, 40, button5, "Empty");
        }

        private void productNumberTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(productNumberTextBox, 0, 120, button5, "Empty");
        }

        private void manufacturerTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(manufacturerTextBox, 0, 120, button5, "Empty");
        }

        private void seriaTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(seriaTextBox, 0, 120, button5, "Empty");
        }
        private void typeTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(typeTextBox, 0, 120, button5, "notEmpty");
        }
        private void descriptionTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(descriptionTextBox, 0, 512, button5, "notEmpty");
        }

        private void statusTextBox_Validating(object sender, CancelEventArgs e)
        {
            validateMessage(statusTextBox, 0, 40, button5, "notEmpty");
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
            validateMessage(nameTextBox, 0, 120, button5, "notEmpty");
        }

        private void phoneNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(phoneNumberTextBox, 0, 40, button5, "Empty");
        }

        private void emailTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(emailTextBox, 0, 40, button5, "Empty");
        }

        private void productNumberTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(productNumberTextBox, 0, 120, button5, "Empty");
        }

        private void typeTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(typeTextBox, 0, 120, button5, "notEmpty");
        }

        private void manufacturerTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(manufacturerTextBox, 0, 120, button5, "Empty");
        }

        private void seriaTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(seriaTextBox, 0, 120, button5, "Empty");
        }

        private void descriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(descriptionTextBox, 0, 512, button5, "notEmpty");
        }

        private void statusTextBox_TextChanged(object sender, EventArgs e)
        {
            validateMessage(statusTextBox, 0, 40, button5, "notEmpty");
        }
    }

}
