namespace PresentationTracker
{
    partial class EnterSubjectForm
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
            this.bSaveSubject = new System.Windows.Forms.Button();
            this.lPresentationSubject = new System.Windows.Forms.Label();
            this.tPresentationSubject = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // bSaveSubject
            // 
            this.bSaveSubject.Location = new System.Drawing.Point(12, 51);
            this.bSaveSubject.Name = "bSaveSubject";
            this.bSaveSubject.Size = new System.Drawing.Size(121, 23);
            this.bSaveSubject.TabIndex = 0;
            this.bSaveSubject.Text = "Save Subject";
            this.bSaveSubject.UseVisualStyleBackColor = true;
            this.bSaveSubject.Click += new System.EventHandler(this.bSaveSubject_Click);
            // 
            // lPresentationSubject
            // 
            this.lPresentationSubject.AutoSize = true;
            this.lPresentationSubject.Location = new System.Drawing.Point(12, 9);
            this.lPresentationSubject.Name = "lPresentationSubject";
            this.lPresentationSubject.Size = new System.Drawing.Size(105, 13);
            this.lPresentationSubject.TabIndex = 1;
            this.lPresentationSubject.Text = "Presentation Subject";
            // 
            // tPresentationSubject
            // 
            this.tPresentationSubject.Location = new System.Drawing.Point(12, 25);
            this.tPresentationSubject.Name = "tPresentationSubject";
            this.tPresentationSubject.Size = new System.Drawing.Size(199, 20);
            this.tPresentationSubject.TabIndex = 2;
            // 
            // EnterSubjectForm
            // 
            this.AcceptButton = this.bSaveSubject;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 83);
            this.Controls.Add(this.tPresentationSubject);
            this.Controls.Add(this.lPresentationSubject);
            this.Controls.Add(this.bSaveSubject);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnterSubjectForm";
            this.Text = "Enter Presentation Subject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bSaveSubject;
        private System.Windows.Forms.Label lPresentationSubject;
        private System.Windows.Forms.TextBox tPresentationSubject;
    }
}