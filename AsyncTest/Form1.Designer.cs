namespace AsyncTest
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
            this.btnSync = new System.Windows.Forms.Button();
            this.rchTextBox = new System.Windows.Forms.RichTextBox();
            this.btnAsync = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(67, 348);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(205, 58);
            this.btnSync.TabIndex = 0;
            this.btnSync.Text = "Synchronous call";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // rchTextBox
            // 
            this.rchTextBox.Location = new System.Drawing.Point(67, 34);
            this.rchTextBox.Name = "rchTextBox";
            this.rchTextBox.Size = new System.Drawing.Size(566, 254);
            this.rchTextBox.TabIndex = 1;
            this.rchTextBox.Text = "";
            // 
            // btnAsync
            // 
            this.btnAsync.Location = new System.Drawing.Point(434, 348);
            this.btnAsync.Name = "btnAsync";
            this.btnAsync.Size = new System.Drawing.Size(199, 58);
            this.btnAsync.TabIndex = 2;
            this.btnAsync.Text = "Asynchronous call";
            this.btnAsync.UseVisualStyleBackColor = true;
            this.btnAsync.Click += new System.EventHandler(this.btnAsync_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(296, 348);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(111, 58);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 480);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAsync);
            this.Controls.Add(this.rchTextBox);
            this.Controls.Add(this.btnSync);
            this.Name = "Form1";
            this.Text = "Async Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.RichTextBox rchTextBox;
        private System.Windows.Forms.Button btnAsync;
        private System.Windows.Forms.Button btnClear;
    }
}

