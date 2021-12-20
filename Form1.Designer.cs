
namespace image_pdf_Test
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lblfilename = new System.Windows.Forms.Label();
            this.txtfname = new System.Windows.Forms.TextBox();
            this.grdFiles = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(194, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(143, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = " Upload File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lblfilename
            // 
            this.lblfilename.AutoSize = true;
            this.lblfilename.Location = new System.Drawing.Point(72, 22);
            this.lblfilename.Name = "lblfilename";
            this.lblfilename.Size = new System.Drawing.Size(61, 20);
            this.lblfilename.TabIndex = 3;
            this.lblfilename.Text = "Caption";
            // 
            // txtfname
            // 
            this.txtfname.Location = new System.Drawing.Point(166, 22);
            this.txtfname.Name = "txtfname";
            this.txtfname.Size = new System.Drawing.Size(160, 27);
            this.txtfname.TabIndex = 4;
            // 
            // grdFiles
            // 
            this.grdFiles.AllowUserToAddRows = false;
            this.grdFiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFiles.Location = new System.Drawing.Point(183, 226);
            this.grdFiles.Name = "grdFiles";
            this.grdFiles.RowHeadersWidth = 51;
            this.grdFiles.RowTemplate.Height = 29;
            this.grdFiles.Size = new System.Drawing.Size(704, 188);
            this.grdFiles.TabIndex = 5;
            this.grdFiles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdFiles_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 529);
            this.Controls.Add(this.grdFiles);
            this.Controls.Add(this.txtfname);
            this.Controls.Add(this.lblfilename);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.grdFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lblfilename;
        private System.Windows.Forms.TextBox txtfname;
        private System.Windows.Forms.DataGridView grdFiles;
    }
}

