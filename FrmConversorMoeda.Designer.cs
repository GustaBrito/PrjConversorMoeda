
namespace PrjConversorMoeda
{
    partial class FrmConversorMoeda
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConversorMoeda));
            this.lblWelcome = new System.Windows.Forms.Label();
            this.cbPais1 = new System.Windows.Forms.ComboBox();
            this.cbPais2 = new System.Windows.Forms.ComboBox();
            this.mskMoeda1 = new System.Windows.Forms.MaskedTextBox();
            this.mskMoeda2 = new System.Windows.Forms.MaskedTextBox();
            this.pbPais1 = new System.Windows.Forms.PictureBox();
            this.pbPais2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblInfo1 = new System.Windows.Forms.Label();
            this.lblInfo2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbPais1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPais2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblWelcome.Location = new System.Drawing.Point(1, 9);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(485, 45);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "CONVERSOR DE MOEDAS";
            this.lblWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbPais1
            // 
            this.cbPais1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPais1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPais1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPais1.FormattingEnabled = true;
            this.cbPais1.Location = new System.Drawing.Point(166, 122);
            this.cbPais1.Name = "cbPais1";
            this.cbPais1.Size = new System.Drawing.Size(293, 39);
            this.cbPais1.TabIndex = 1;
            // 
            // cbPais2
            // 
            this.cbPais2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbPais2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPais2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbPais2.FormattingEnabled = true;
            this.cbPais2.Location = new System.Drawing.Point(166, 364);
            this.cbPais2.Name = "cbPais2";
            this.cbPais2.Size = new System.Drawing.Size(293, 39);
            this.cbPais2.TabIndex = 2;
            // 
            // mskMoeda1
            // 
            this.mskMoeda1.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mskMoeda1.Location = new System.Drawing.Point(166, 189);
            this.mskMoeda1.Name = "mskMoeda1";
            this.mskMoeda1.Size = new System.Drawing.Size(293, 38);
            this.mskMoeda1.TabIndex = 3;
            // 
            // mskMoeda2
            // 
            this.mskMoeda2.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.mskMoeda2.Location = new System.Drawing.Point(166, 431);
            this.mskMoeda2.Name = "mskMoeda2";
            this.mskMoeda2.Size = new System.Drawing.Size(293, 38);
            this.mskMoeda2.TabIndex = 4;
            // 
            // pbPais1
            // 
            this.pbPais1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPais1.Location = new System.Drawing.Point(30, 97);
            this.pbPais1.Name = "pbPais1";
            this.pbPais1.Size = new System.Drawing.Size(130, 130);
            this.pbPais1.TabIndex = 5;
            this.pbPais1.TabStop = false;
            // 
            // pbPais2
            // 
            this.pbPais2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbPais2.Location = new System.Drawing.Point(30, 339);
            this.pbPais2.Name = "pbPais2";
            this.pbPais2.Size = new System.Drawing.Size(130, 130);
            this.pbPais2.TabIndex = 6;
            this.pbPais2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(222, 276);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "==";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(166, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(282, 25);
            this.label2.TabIndex = 8;
            this.label2.Text = "Moeda de Qual país você deseja ?";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(166, 336);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(282, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Moeda de Qual país você deseja ?";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(166, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Qual o valor ?";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(166, 406);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(145, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "Valor Convertido";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo1
            // 
            this.lblInfo1.AutoSize = true;
            this.lblInfo1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo1.Location = new System.Drawing.Point(166, 230);
            this.lblInfo1.Name = "lblInfo1";
            this.lblInfo1.Size = new System.Drawing.Size(47, 25);
            this.lblInfo1.TabIndex = 12;
            this.lblInfo1.Text = "-----";
            this.lblInfo1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo2
            // 
            this.lblInfo2.AutoSize = true;
            this.lblInfo2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblInfo2.Location = new System.Drawing.Point(166, 472);
            this.lblInfo2.Name = "lblInfo2";
            this.lblInfo2.Size = new System.Drawing.Size(47, 25);
            this.lblInfo2.TabIndex = 13;
            this.lblInfo2.Text = "-----";
            this.lblInfo2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(1, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(485, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "Aguarde um momento para carregar todas as moedas";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmConversorMoeda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 528);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblInfo2);
            this.Controls.Add(this.lblInfo1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbPais2);
            this.Controls.Add(this.pbPais1);
            this.Controls.Add(this.mskMoeda2);
            this.Controls.Add(this.mskMoeda1);
            this.Controls.Add(this.cbPais2);
            this.Controls.Add(this.cbPais1);
            this.Controls.Add(this.lblWelcome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConversorMoeda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Conversor de Moedas ";
            this.Load += new System.EventHandler(this.FrmConversorMoeda_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbPais1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPais2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.ComboBox cbPais1;
        private System.Windows.Forms.ComboBox cbPais2;
        private System.Windows.Forms.MaskedTextBox mskMoeda1;
        private System.Windows.Forms.MaskedTextBox mskMoeda2;
        private System.Windows.Forms.PictureBox pbPais1;
        private System.Windows.Forms.PictureBox pbPais2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblInfo1;
        private System.Windows.Forms.Label lblInfo2;
        private System.Windows.Forms.Label label6;
    }
}

