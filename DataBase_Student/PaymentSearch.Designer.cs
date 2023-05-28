
namespace DataBase_Student
{
    partial class PaymentSearch
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltext = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearchTwo = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PaymentTwo = new System.Windows.Forms.TextBox();
            this.dateTimePickerTo = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.lbltext);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 155);
            this.panel1.TabIndex = 1;
            // 
            // lbltext
            // 
            this.lbltext.AutoSize = true;
            this.lbltext.BackColor = System.Drawing.Color.Black;
            this.lbltext.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbltext.ForeColor = System.Drawing.Color.White;
            this.lbltext.Location = new System.Drawing.Point(21, 46);
            this.lbltext.Name = "lbltext";
            this.lbltext.Size = new System.Drawing.Size(98, 30);
            this.lbltext.TabIndex = 0;
            this.lbltext.Text = "Payment";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnSearchTwo);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.PaymentTwo);
            this.panel2.Controls.Add(this.dateTimePickerTo);
            this.panel2.Controls.Add(this.dateTimePickerFrom);
            this.panel2.Location = new System.Drawing.Point(68, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(339, 290);
            this.panel2.TabIndex = 2;
            // 
            // btnSearchTwo
            // 
            this.btnSearchTwo.BackColor = System.Drawing.Color.Black;
            this.btnSearchTwo.FlatAppearance.BorderSize = 0;
            this.btnSearchTwo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSearchTwo.ForeColor = System.Drawing.Color.White;
            this.btnSearchTwo.Location = new System.Drawing.Point(111, 215);
            this.btnSearchTwo.Name = "btnSearchTwo";
            this.btnSearchTwo.Size = new System.Drawing.Size(106, 48);
            this.btnSearchTwo.TabIndex = 19;
            this.btnSearchTwo.Text = "Search";
            this.btnSearchTwo.UseVisualStyleBackColor = false;
            this.btnSearchTwo.Click += new System.EventHandler(this.btnSearchTwo_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(14, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 18;
            this.label6.Text = "Payment:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(14, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 21);
            this.label4.TabIndex = 16;
            this.label4.Text = "To:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(14, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 21);
            this.label3.TabIndex = 15;
            this.label3.Text = "From:";
            // 
            // PaymentTwo
            // 
            this.PaymentTwo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PaymentTwo.Location = new System.Drawing.Point(18, 168);
            this.PaymentTwo.Name = "PaymentTwo";
            this.PaymentTwo.ReadOnly = true;
            this.PaymentTwo.Size = new System.Drawing.Size(299, 29);
            this.PaymentTwo.TabIndex = 14;
            // 
            // dateTimePickerTo
            // 
            this.dateTimePickerTo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerTo.Location = new System.Drawing.Point(18, 86);
            this.dateTimePickerTo.Name = "dateTimePickerTo";
            this.dateTimePickerTo.Size = new System.Drawing.Size(299, 29);
            this.dateTimePickerTo.TabIndex = 12;
            // 
            // dateTimePickerFrom
            // 
            this.dateTimePickerFrom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dateTimePickerFrom.Location = new System.Drawing.Point(18, 30);
            this.dateTimePickerFrom.Name = "dateTimePickerFrom";
            this.dateTimePickerFrom.Size = new System.Drawing.Size(299, 29);
            this.dateTimePickerFrom.TabIndex = 11;
            // 
            // PaymentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 551);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PaymentSearch";
            this.Text = "PaymentSearch";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.formClose);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltext;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PaymentTwo;
        private System.Windows.Forms.DateTimePicker dateTimePickerTo;
        private System.Windows.Forms.DateTimePicker dateTimePickerFrom;
        private System.Windows.Forms.Button btnSearchTwo;
    }
}