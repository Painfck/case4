namespace MindSoft
{
    partial class Presenter
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
            this.pbdiaview = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbdiaview)).BeginInit();
            this.SuspendLayout();
            // 
            // pbdiaview
            // 
            this.pbdiaview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbdiaview.Location = new System.Drawing.Point(0, 0);
            this.pbdiaview.Name = "pbdiaview";
            this.pbdiaview.Size = new System.Drawing.Size(1254, 687);
            this.pbdiaview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbdiaview.TabIndex = 0;
            this.pbdiaview.TabStop = false;
            this.pbdiaview.Click += new System.EventHandler(this.pbdiaview_Click);
            // 
            // Presenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 687);
            this.Controls.Add(this.pbdiaview);
            this.Name = "Presenter";
            this.Text = "Presenter";
            ((System.ComponentModel.ISupportInitialize)(this.pbdiaview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbdiaview;
    }
}