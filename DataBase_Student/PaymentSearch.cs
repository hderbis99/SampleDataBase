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
    public partial class PaymentSearch : Form
    {
        public PaymentSearch()
        {
            InitializeComponent();
            this.KeyPreview = true; // Ustawienie KeyPreview na true jest ważne, aby obsługa klawiszy działała na całym formularzu.
            this.KeyDown += new KeyEventHandler(formClose);
        }
        private void formClose(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
        private void btnSearchTwo_Click(object sender, EventArgs e)
        {
            this.AcceptButton = btnSearchTwo; // Enter
            DateTime startDate = dateTimePickerFrom.Value;
            DateTime endDate = dateTimePickerTo.Value;

            // Tworzenie obiektu klasy DbStudent
            DbStudent db = new DbStudent();

            // Obliczenie sumy płatności dla danego okresu czasowego
            double totalPayment = db.GetTotalPaymentsForPeriod(startDate, endDate);

            // Wyświetlenie sumy płatności w polu tekstowym
            PaymentTwo.Text = totalPayment.ToString();
        }
    }
}
