namespace PresentationTracker
{
    partial class EnterPINForm
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
            this.bSavePIN = new System.Windows.Forms.Button();
            this.tTwitterPIN = new System.Windows.Forms.TextBox();
            this.lTwitterPIN = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bSavePIN
            // 
            this.bSavePIN.Location = new System.Drawing.Point(15, 51);
            this.bSavePIN.Name = "bSavePIN";
            this.bSavePIN.Size = new System.Drawing.Size(75, 23);
            this.bSavePIN.TabIndex = 0;
            this.bSavePIN.Text = "Save PIN";
            this.bSavePIN.UseVisualStyleBackColor = true;
            this.bSavePIN.Click += new System.EventHandler(this.bSavePIN_Click);
            // 
            // tTwitterPIN
            // 
            this.tTwitterPIN.Location = new System.Drawing.Point(15, 25);
            this.tTwitterPIN.Name = "tTwitterPIN";
            this.tTwitterPIN.Size = new System.Drawing.Size(214, 20);
            this.tTwitterPIN.TabIndex = 1;
            // 
            // lTwitterPIN
            // 
            this.lTwitterPIN.AutoSize = true;
            this.lTwitterPIN.Location = new System.Drawing.Point(12, 9);
            this.lTwitterPIN.Name = "lTwitterPIN";
            this.lTwitterPIN.Size = new System.Drawing.Size(60, 13);
            this.lTwitterPIN.TabIndex = 2;
            this.lTwitterPIN.Text = "Twitter PIN";
            // 
            // EnterPINForm
            // 
            this.AcceptButton = this.bSavePIN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(241, 89);
            this.Controls.Add(this.lTwitterPIN);
            this.Controls.Add(this.tTwitterPIN);
            this.Controls.Add(this.bSavePIN);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterPINForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EnterPIN for Presentation Tracker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSavePIN;
        private System.Windows.Forms.TextBox tTwitterPIN;
        private System.Windows.Forms.Label lTwitterPIN;
    }
}