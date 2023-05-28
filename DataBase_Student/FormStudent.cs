using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase_Student
{
    public partial class FormStudent : Form
    {
        private readonly FormStudentInfo _parent;
        public string id, name, payment, contact;
        public System.DateTime data;
        public FormStudent(FormStudentInfo parent)
        {
            InitializeComponent();
            _parent = parent;
            this.KeyPreview = true; // Ustawienie KeyPreview na true jest ważne, aby obsługa klawiszy działała na całym formularzu.
            this.KeyDown += new KeyEventHandler(formCloseTwo);
        }
        private void formCloseTwo(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        public void UpdateInfo() // Change the button text and label in form
        {
            lbltext.Text = "Update Student";
            btnSave.Text = "Update";

            txtName.Text = name;
            txtData.Value = data;
            txtPayment.Text = payment;
            txtContact.Text = contact;
        }

        public void SaveInfo()
        {
            lbltext.Text = "Add Student";
            btnSave.Text = "Save";
        }
        public void Clear()
        {
            txtData.Text = txtName.Text = txtPayment.Text = txtContact.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.AcceptButton = btnSave; //Enter
            if(txtName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Student name is Empty.");
                return;
            }
            if (txtData.Text.Trim().Length < 1)
            {
                MessageBox.Show("Date is Empty.");
                return;
            }
            if (txtPayment.Text.Trim().Length < 1)
            {
                MessageBox.Show("Payment is Empty.");
                return;
            }
            if(txtContact.Text.Trim().Length < 1)
            {
                MessageBox.Show("Contact is Empty.");
                return;
            }
            if(btnSave.Text == "Save")
            {
                Student std = new Student(0, txtName.Text.Trim(), txtData.Text.Trim(), txtPayment.Text.Trim(), txtContact.Text.Trim());
                DbStudent.addStudent(std);
                Clear();
            }
            if(btnSave.Text == "Update")
            {
                Student std = new Student(0, txtName.Text.Trim(), txtData.Text.Trim(), txtPayment.Text.Trim(), txtContact.Text.Trim());
                DbStudent.UpdateStudent(std, id);
            }
            _parent.Display();
        }
    }
}
