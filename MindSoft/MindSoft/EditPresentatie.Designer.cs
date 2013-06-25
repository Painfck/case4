namespace MindSoft
{
    partial class EditPresentatie
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
            this.pbdiapreview = new System.Windows.Forms.PictureBox();
            this.tbnotitietekst = new System.Windows.Forms.TextBox();
            this.lbdialist = new System.Windows.Forms.ListBox();
            this.generateBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.btomhoog = new System.Windows.Forms.Button();
            this.btomlaag = new System.Windows.Forms.Button();
            this.btnoteconfirm = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbdiapreview)).BeginInit();
            this.SuspendLayout();
            // 
            // pbdiapreview
            // 
            this.pbdiapreview.Location = new System.Drawing.Point(364, 23);
            this.pbdiapreview.Margin = new System.Windows.Forms.Padding(6);
            this.pbdiapreview.Name = "pbdiapreview";
            this.pbdiapreview.Size = new System.Drawing.Size(274, 279);
            this.pbdiapreview.TabIndex = 0;
            this.pbdiapreview.TabStop = false;
            // 
            // tbnotitietekst
            // 
            this.tbnotitietekst.Location = new System.Drawing.Point(288, 313);
            this.tbnotitietekst.Margin = new System.Windows.Forms.Padding(6);
            this.tbnotitietekst.Multiline = true;
            this.tbnotitietekst.Name = "tbnotitietekst";
            this.tbnotitietekst.Size = new System.Drawing.Size(346, 112);
            this.tbnotitietekst.TabIndex = 1;
            // 
            // lbdialist
            // 
            this.lbdialist.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbdialist.FormattingEnabled = true;
            this.lbdialist.ItemHeight = 25;
            this.lbdialist.Items.AddRange(new object[] {
            "Dia 1",
            "Dia 2",
            "Dia 3"});
            this.lbdialist.Location = new System.Drawing.Point(24, 17);
            this.lbdialist.Margin = new System.Windows.Forms.Padding(6);
            this.lbdialist.Name = "lbdialist";
            this.lbdialist.Size = new System.Drawing.Size(236, 529);
            this.lbdialist.TabIndex = 2;
            this.lbdialist.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lbdialist_MouseClick);
            // 
            // generateBtn
            // 
            this.generateBtn.Location = new System.Drawing.Point(276, 506);
            this.generateBtn.Margin = new System.Windows.Forms.Padding(6);
            this.generateBtn.Name = "generateBtn";
            this.generateBtn.Size = new System.Drawing.Size(150, 44);
            this.generateBtn.TabIndex = 3;
            this.generateBtn.Text = "Generate";
            this.generateBtn.UseVisualStyleBackColor = true;
            this.generateBtn.Click += new System.EventHandler(this.generateBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(488, 506);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(6);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(150, 44);
            this.cancelBtn.TabIndex = 4;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // btomhoog
            // 
            this.btomhoog.Location = new System.Drawing.Point(269, 23);
            this.btomhoog.Name = "btomhoog";
            this.btomhoog.Size = new System.Drawing.Size(75, 39);
            this.btomhoog.TabIndex = 5;
            this.btomhoog.Text = "+";
            this.btomhoog.UseVisualStyleBackColor = true;
            this.btomhoog.Click += new System.EventHandler(this.btomhoog_Click);
            // 
            // btomlaag
            // 
            this.btomlaag.Location = new System.Drawing.Point(269, 68);
            this.btomlaag.Name = "btomlaag";
            this.btomlaag.Size = new System.Drawing.Size(75, 39);
            this.btomlaag.TabIndex = 6;
            this.btomlaag.Text = "-";
            this.btomlaag.UseVisualStyleBackColor = true;
            this.btomlaag.Click += new System.EventHandler(this.btomlaag_Click);
            // 
            // btnoteconfirm
            // 
            this.btnoteconfirm.Location = new System.Drawing.Point(288, 435);
            this.btnoteconfirm.Name = "btnoteconfirm";
            this.btnoteconfirm.Size = new System.Drawing.Size(346, 39);
            this.btnoteconfirm.TabIndex = 7;
            this.btnoteconfirm.Text = "Confirm Note";
            this.btnoteconfirm.UseVisualStyleBackColor = true;
            this.btnoteconfirm.Click += new System.EventHandler(this.btnoteconfirm_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 579);
            this.Controls.Add(this.btnoteconfirm);
            this.Controls.Add(this.btomlaag);
            this.Controls.Add(this.btomhoog);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.generateBtn);
            this.Controls.Add(this.lbdialist);
            this.Controls.Add(this.tbnotitietekst);
            this.Controls.Add(this.pbdiapreview);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Settings";
            this.Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)(this.pbdiapreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbdiapreview;
        private System.Windows.Forms.TextBox tbnotitietekst;
        private System.Windows.Forms.ListBox lbdialist;
        private System.Windows.Forms.Button generateBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button btomhoog;
        private System.Windows.Forms.Button btomlaag;
        private System.Windows.Forms.Button btnoteconfirm;
    }
}