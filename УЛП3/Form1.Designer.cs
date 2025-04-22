namespace SeriesCalculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.scrollBarN = new System.Windows.Forms.HScrollBar();
            this.lblN = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCycleResult = new System.Windows.Forms.TextBox();
            this.txtFormulaResult = new System.Windows.Forms.TextBox();
            this.lblVerification = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // scrollBarN
            // 
            this.scrollBarN.Location = new System.Drawing.Point(50, 30);
            this.scrollBarN.Name = "scrollBarN";
            this.scrollBarN.Size = new System.Drawing.Size(300, 30);
            this.scrollBarN.TabIndex = 0;
            this.scrollBarN.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrollBarN_Scroll);
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblN.Location = new System.Drawing.Point(360, 30);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(51, 20);
            this.lblN.TabIndex = 1;
            this.lblN.Text = "n = 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(50, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Вычисление в цикле";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(50, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вычисление по формуле";
            // 
            // txtCycleResult
            // 
            this.txtCycleResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCycleResult.Location = new System.Drawing.Point(220, 80);
            this.txtCycleResult.Name = "txtCycleResult";
            this.txtCycleResult.ReadOnly = true;
            this.txtCycleResult.Size = new System.Drawing.Size(200, 23);
            this.txtCycleResult.TabIndex = 4;
            // 
            // txtFormulaResult
            // 
            this.txtFormulaResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtFormulaResult.Location = new System.Drawing.Point(220, 120);
            this.txtFormulaResult.Name = "txtFormulaResult";
            this.txtFormulaResult.ReadOnly = true;
            this.txtFormulaResult.Size = new System.Drawing.Size(200, 23);
            this.txtFormulaResult.TabIndex = 5;
            // 
            // lblVerification
            // 
            this.lblVerification.AutoSize = true;
            this.lblVerification.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblVerification.Location = new System.Drawing.Point(220, 160);
            this.lblVerification.Name = "lblVerification";
            this.lblVerification.Size = new System.Drawing.Size(146, 17);
            this.lblVerification.TabIndex = 6;
            this.lblVerification.Text = "Результаты совпадают";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(50, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Измените значение n (1-50)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(50, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Проверка совпадения:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 211);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblVerification);
            this.Controls.Add(this.txtFormulaResult);
            this.Controls.Add(this.txtCycleResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblN);
            this.Controls.Add(this.scrollBarN);
            this.Name = "Form1";
            this.Text = "Вычисление суммы ряда 1^5 - 2^5 + 3^5 - ... + (-1)^(n-1)*n^5";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.HScrollBar scrollBarN;
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCycleResult;
        private System.Windows.Forms.TextBox txtFormulaResult;
        private System.Windows.Forms.Label lblVerification;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}