
namespace ReadCsvFileSaveTxt
{
    partial class Form1
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
            this.FileDialogCSV = new System.Windows.Forms.OpenFileDialog();
            this.btnFilePath = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRegisterPath = new System.Windows.Forms.Button();
            this.btnTemplateUpload = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPlaceHolders = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FileDialogRegister = new System.Windows.Forms.OpenFileDialog();
            this.FileDialogTemplate = new System.Windows.Forms.OpenFileDialog();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.lblRegisterPath = new System.Windows.Forms.Label();
            this.lblTemplatePath = new System.Windows.Forms.Label();
            this.btnCreateFiles = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblNeededPlaceholders = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FileDialogCSV
            // 
            this.FileDialogCSV.FileName = "FileDialogCSV";
            // 
            // btnFilePath
            // 
            this.btnFilePath.Location = new System.Drawing.Point(37, 119);
            this.btnFilePath.Name = "btnFilePath";
            this.btnFilePath.Size = new System.Drawing.Size(151, 49);
            this.btnFilePath.TabIndex = 1;
            this.btnFilePath.Text = "Dosya Yükle";
            this.btnFilePath.UseVisualStyleBackColor = true;
            this.btnFilePath.Click += new System.EventHandler(this.btnFilePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 179);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Dosya Yolu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kayıt Yolu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "TemplateYolu:";
            // 
            // btnRegisterPath
            // 
            this.btnRegisterPath.Location = new System.Drawing.Point(210, 119);
            this.btnRegisterPath.Name = "btnRegisterPath";
            this.btnRegisterPath.Size = new System.Drawing.Size(151, 49);
            this.btnRegisterPath.TabIndex = 2;
            this.btnRegisterPath.Text = "Kayıt Yolu";
            this.btnRegisterPath.UseVisualStyleBackColor = true;
            this.btnRegisterPath.Click += new System.EventHandler(this.btnRegisterPath_Click);
            // 
            // btnTemplateUpload
            // 
            this.btnTemplateUpload.Location = new System.Drawing.Point(387, 119);
            this.btnTemplateUpload.Name = "btnTemplateUpload";
            this.btnTemplateUpload.Size = new System.Drawing.Size(151, 49);
            this.btnTemplateUpload.TabIndex = 3;
            this.btnTemplateUpload.Text = "Template Yükle";
            this.btnTemplateUpload.UseVisualStyleBackColor = true;
            this.btnTemplateUpload.Click += new System.EventHandler(this.btnTemplateUpload_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Alanları Giriniz:";
            // 
            // txtPlaceHolders
            // 
            this.txtPlaceHolders.Location = new System.Drawing.Point(143, 35);
            this.txtPlaceHolders.Name = "txtPlaceHolders";
            this.txtPlaceHolders.Size = new System.Drawing.Size(395, 22);
            this.txtPlaceHolders.TabIndex = 0;
            this.txtPlaceHolders.Leave += new System.EventHandler(this.txtPlaceHolders_Leave);
            this.txtPlaceHolders.MouseLeave += new System.EventHandler(this.txtPlaceHolders_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(73, 76);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(456, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "*Dökümandaki kayıt sırasına göre aralarına noktalı virgül koyarak giriniz";
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(134, 179);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(0, 17);
            this.lblFilePath.TabIndex = 5;
            // 
            // lblRegisterPath
            // 
            this.lblRegisterPath.AutoSize = true;
            this.lblRegisterPath.Location = new System.Drawing.Point(134, 202);
            this.lblRegisterPath.Name = "lblRegisterPath";
            this.lblRegisterPath.Size = new System.Drawing.Size(0, 17);
            this.lblRegisterPath.TabIndex = 5;
            // 
            // lblTemplatePath
            // 
            this.lblTemplatePath.AutoSize = true;
            this.lblTemplatePath.Location = new System.Drawing.Point(134, 224);
            this.lblTemplatePath.Name = "lblTemplatePath";
            this.lblTemplatePath.Size = new System.Drawing.Size(0, 17);
            this.lblTemplatePath.TabIndex = 5;
            // 
            // btnCreateFiles
            // 
            this.btnCreateFiles.Location = new System.Drawing.Point(37, 254);
            this.btnCreateFiles.Name = "btnCreateFiles";
            this.btnCreateFiles.Size = new System.Drawing.Size(501, 67);
            this.btnCreateFiles.TabIndex = 6;
            this.btnCreateFiles.Text = "ÇÖZÜMLE";
            this.btnCreateFiles.UseVisualStyleBackColor = true;
            this.btnCreateFiles.Click += new System.EventHandler(this.btnCreateFiles_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label6.Location = new System.Drawing.Point(140, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(191, 17);
            this.label6.TabIndex = 7;
            this.label6.Text = "Example: AD;SOYAD;TUTAR";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(73, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(465, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "*Boş geçilirse varsayılan değer FATURANO;AD;SOYAD;TUTAR olacaktır";
            // 
            // lblNeededPlaceholders
            // 
            this.lblNeededPlaceholders.AutoSize = true;
            this.lblNeededPlaceholders.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblNeededPlaceholders.ForeColor = System.Drawing.Color.Maroon;
            this.lblNeededPlaceholders.Location = new System.Drawing.Point(34, 99);
            this.lblNeededPlaceholders.Name = "lblNeededPlaceholders";
            this.lblNeededPlaceholders.Size = new System.Drawing.Size(0, 17);
            this.lblNeededPlaceholders.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 335);
            this.Controls.Add(this.lblNeededPlaceholders);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCreateFiles);
            this.Controls.Add(this.lblTemplatePath);
            this.Controls.Add(this.lblRegisterPath);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPlaceHolders);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnTemplateUpload);
            this.Controls.Add(this.btnRegisterPath);
            this.Controls.Add(this.btnFilePath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog FileDialogCSV;
        private System.Windows.Forms.Button btnFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegisterPath;
        private System.Windows.Forms.Button btnTemplateUpload;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPlaceHolders;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.OpenFileDialog FileDialogRegister;
        private System.Windows.Forms.OpenFileDialog FileDialogTemplate;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.Label lblRegisterPath;
        private System.Windows.Forms.Label lblTemplatePath;
        private System.Windows.Forms.Button btnCreateFiles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblNeededPlaceholders;
    }
}

