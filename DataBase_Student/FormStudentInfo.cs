using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace DataBase_Student
{
    public partial class FormStudentInfo : Form
    {
        FormStudent form;
        public FormStudentInfo()
        {
            InitializeComponent();
            form = new FormStudent(this); // New form
            //dataGridView.KeyDown += KeyDown_DataGrid;
        }
        public void Display()
        {
            DbStudent.DisplayAndSearch("SELECT Id, Name, Data, Payment, Contact FROM Table_STD ORDER BY Data ASC, Name ASC", dataGridView);
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void FormStudentInfo_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) //Find out the record
        {
            DbStudent.DisplayAndSearch("SELECT Id, Name, Data, Payment, Contact FROM Table_STD WHERE Name LIKE '%" + txtSearch.Text + "%'", dataGridView);
        }
        /*
        private void KeyDown_DataGrid(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridView.SelectedRows[0].Index;
                    dataGridView_CellClick(sender, new DataGridViewCellEventArgs(0, rowIndex));
                }
            }
            else if (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2)
            {
                if (dataGridView.SelectedRows.Count > 0)
                {
                    int rowIndex = dataGridView.SelectedRows[0].Index;
                    dataGridView_CellClick(sender, new DataGridViewCellEventArgs(1, rowIndex));
                }
            }
        }
        */
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e) //Edit Delete
        {
            if (dataGridView.Columns[e.ColumnIndex].Name == "Edit")
            {
                try
                {
                    form.Clear();
                    form.id = dataGridView.Rows[e.RowIndex].Cells["Column1"].Value.ToString();
                    form.name = dataGridView.Rows[e.RowIndex].Cells["Column2"].Value.ToString();
                    if (DateTime.TryParse(dataGridView.Rows[e.RowIndex].Cells["Column3"].Value.ToString(), out DateTime result))
                    {
                        form.data = result;
                    }
                    form.payment = dataGridView.Rows[e.RowIndex].Cells["Column4"].Value.ToString();
                    form.contact = dataGridView.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
                    form.UpdateInfo();
                    form.ShowDialog();
                    return;
                }
                catch
                {
                    MessageBox.Show("Don't click on the top of the table", "Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (dataGridView.Columns[e.ColumnIndex].Name == "Delete")
            {
                if (MessageBox.Show("Are you sure you want to delete this student record?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DbStudent.DeleteStudent(dataGridView.Rows[e.RowIndex].Cells["Column1"].Value.ToString());
                    Display(); // wyświetl zaktualizowane dane w dataGridView
                }
                return;
            }
        }

        private void SearchPayment_Click(object sender, EventArgs e)
        {
            PaymentSearch paymentSearch = new PaymentSearch();
            paymentSearch.Show();
        }

        private void DeleteAll_Click(object sender, EventArgs e)
        {
            string password = "@Student123";
            if (MessageBox.Show("Are you sure you want to delete all records?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                var inputForm = new Form();
                var passwordBox = new TextBox();
                var okButton = new Button();

                inputForm.Text = "Enter password";
                passwordBox.PasswordChar = '*';
                okButton.Text = "OK";
                okButton.DialogResult = DialogResult.OK;

                inputForm.Controls.Add(passwordBox);
                inputForm.Controls.Add(okButton);

                passwordBox.Location = new Point(20, 20);
                okButton.Location = new Point(20, 50);

                inputForm.AcceptButton = okButton;

                if (inputForm.ShowDialog() == DialogResult.OK)
                {
                    if (passwordBox.Text == password)
                    {
                        DbStudent.DeleteAllRecords();
                        Display();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect password!");
                    }
                }
            }
        }
        private void BuckUp_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Baza danych (*.mdf)|*.mdf";
            saveFileDialog.Title = "Keep a backup database";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.FileName != "")
            {
                string backupPath = saveFileDialog.FileName;
                // Tworzenie kopi zapasowej bazy danych
                DbStudent.BackupDatabase(backupPath);
                MessageBox.Show("The backup was created successfully.");
            }
        }
    }
}
