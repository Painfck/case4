namespace MindSoft
{
    partial class EditKnoop
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabtext = new System.Windows.Forms.TabPage();
            this.btconfirm = new System.Windows.Forms.Button();
            this.btadd = new System.Windows.Forms.Button();
            this.cbtextitems = new System.Windows.Forms.ComboBox();
            this.tbtextinhoud = new System.Windows.Forms.TextBox();
            this.tabimage = new System.Windows.Forms.TabPage();
            this.btbrowse = new System.Windows.Forms.Button();
            this.btconfirmplaatje = new System.Windows.Forms.Button();
            this.pbplaatje = new System.Windows.Forms.PictureBox();
            this.tbplaatjepad = new System.Windows.Forms.TextBox();
            this.cbplaatjeslist = new System.Windows.Forms.ComboBox();
            this.tabHyperlink = new System.Windows.Forms.TabPage();
            this.btconfirmhyperlink = new System.Windows.Forms.Button();
            this.wbhyperlinkcontent = new System.Windows.Forms.WebBrowser();
            this.tbhyperlink = new System.Windows.Forms.TextBox();
            this.cbhyperlinklist = new System.Windows.Forms.ComboBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabtext.SuspendLayout();
            this.tabimage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbplaatje)).BeginInit();
            this.tabHyperlink.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabtext);
            this.tabControl1.Controls.Add(this.tabimage);
            this.tabControl1.Controls.Add(this.tabHyperlink);
            this.tabControl1.Location = new System.Drawing.Point(6, 7);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(365, 243);
            this.tabControl1.TabIndex = 0;
            // 
            // tabtext
            // 
            this.tabtext.Controls.Add(this.btconfirm);
            this.tabtext.Controls.Add(this.btadd);
            this.tabtext.Controls.Add(this.cbtextitems);
            this.tabtext.Controls.Add(this.tbtextinhoud);
            this.tabtext.Location = new System.Drawing.Point(4, 22);
            this.tabtext.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabtext.Name = "tabtext";
            this.tabtext.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabtext.Size = new System.Drawing.Size(357, 217);
            this.tabtext.TabIndex = 0;
            this.tabtext.Text = "Text Inhoud";
            this.tabtext.UseVisualStyleBackColor = true;
            // 
            // btconfirm
            // 
            this.btconfirm.Location = new System.Drawing.Point(295, 181);
            this.btconfirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btconfirm.Name = "btconfirm";
            this.btconfirm.Size = new System.Drawing.Size(50, 20);
            this.btconfirm.TabIndex = 4;
            this.btconfirm.Text = "Confirm";
            this.btconfirm.UseVisualStyleBackColor = true;
            this.btconfirm.Visible = false;
            this.btconfirm.Click += new System.EventHandler(this.btconfirm_Click);
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(309, 14);
            this.btadd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(22, 21);
            this.btadd.TabIndex = 3;
            this.btadd.Text = "+";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // cbtextitems
            // 
            this.cbtextitems.FormattingEnabled = true;
            this.cbtextitems.Location = new System.Drawing.Point(9, 14);
            this.cbtextitems.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbtextitems.Name = "cbtextitems";
            this.cbtextitems.Size = new System.Drawing.Size(282, 21);
            this.cbtextitems.TabIndex = 1;
            // 
            // tbtextinhoud
            // 
            this.tbtextinhoud.Location = new System.Drawing.Point(9, 50);
            this.tbtextinhoud.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbtextinhoud.Multiline = true;
            this.tbtextinhoud.Name = "tbtextinhoud";
            this.tbtextinhoud.Size = new System.Drawing.Size(282, 151);
            this.tbtextinhoud.TabIndex = 0;
            // 
            // tabimage
            // 
            this.tabimage.Controls.Add(this.btbrowse);
            this.tabimage.Controls.Add(this.btconfirmplaatje);
            this.tabimage.Controls.Add(this.pbplaatje);
            this.tabimage.Controls.Add(this.tbplaatjepad);
            this.tabimage.Controls.Add(this.cbplaatjeslist);
            this.tabimage.Location = new System.Drawing.Point(4, 22);
            this.tabimage.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabimage.Name = "tabimage";
            this.tabimage.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabimage.Size = new System.Drawing.Size(357, 217);
            this.tabimage.TabIndex = 1;
            this.tabimage.Text = "Plaatje inhoud";
            this.tabimage.UseVisualStyleBackColor = true;
            // 
            // btbrowse
            // 
            this.btbrowse.Location = new System.Drawing.Point(285, 34);
            this.btbrowse.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btbrowse.Name = "btbrowse";
            this.btbrowse.Size = new System.Drawing.Size(64, 20);
            this.btbrowse.TabIndex = 6;
            this.btbrowse.Text = "Browse...";
            this.btbrowse.UseVisualStyleBackColor = true;
            // 
            // btconfirmplaatje
            // 
            this.btconfirmplaatje.Location = new System.Drawing.Point(148, 15);
            this.btconfirmplaatje.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btconfirmplaatje.Name = "btconfirmplaatje";
            this.btconfirmplaatje.Size = new System.Drawing.Size(24, 17);
            this.btconfirmplaatje.TabIndex = 5;
            this.btconfirmplaatje.Text = ">";
            this.btconfirmplaatje.UseVisualStyleBackColor = true;
            this.btconfirmplaatje.Click += new System.EventHandler(this.btconfirmplaatje_Click);
            // 
            // pbplaatje
            // 
            this.pbplaatje.Location = new System.Drawing.Point(10, 57);
            this.pbplaatje.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pbplaatje.Name = "pbplaatje";
            this.pbplaatje.Size = new System.Drawing.Size(340, 153);
            this.pbplaatje.TabIndex = 4;
            this.pbplaatje.TabStop = false;
            // 
            // tbplaatjepad
            // 
            this.tbplaatjepad.Location = new System.Drawing.Point(175, 15);
            this.tbplaatjepad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbplaatjepad.Name = "tbplaatjepad";
            this.tbplaatjepad.Size = new System.Drawing.Size(176, 20);
            this.tbplaatjepad.TabIndex = 3;
            // 
            // cbplaatjeslist
            // 
            this.cbplaatjeslist.FormattingEnabled = true;
            this.cbplaatjeslist.Location = new System.Drawing.Point(10, 14);
            this.cbplaatjeslist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbplaatjeslist.Name = "cbplaatjeslist";
            this.cbplaatjeslist.Size = new System.Drawing.Size(136, 21);
            this.cbplaatjeslist.TabIndex = 2;
            // 
            // tabHyperlink
            // 
            this.tabHyperlink.Controls.Add(this.btconfirmhyperlink);
            this.tabHyperlink.Controls.Add(this.wbhyperlinkcontent);
            this.tabHyperlink.Controls.Add(this.tbhyperlink);
            this.tabHyperlink.Controls.Add(this.cbhyperlinklist);
            this.tabHyperlink.Location = new System.Drawing.Point(4, 22);
            this.tabHyperlink.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabHyperlink.Name = "tabHyperlink";
            this.tabHyperlink.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tabHyperlink.Size = new System.Drawing.Size(357, 217);
            this.tabHyperlink.TabIndex = 2;
            this.tabHyperlink.Text = "Hyperlink inhoud";
            this.tabHyperlink.UseVisualStyleBackColor = true;
            // 
            // btconfirmhyperlink
            // 
            this.btconfirmhyperlink.Location = new System.Drawing.Point(146, 11);
            this.btconfirmhyperlink.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btconfirmhyperlink.Name = "btconfirmhyperlink";
            this.btconfirmhyperlink.Size = new System.Drawing.Size(24, 17);
            this.btconfirmhyperlink.TabIndex = 7;
            this.btconfirmhyperlink.Text = ">";
            this.btconfirmhyperlink.UseVisualStyleBackColor = true;
            this.btconfirmhyperlink.Click += new System.EventHandler(this.btconfirmhyperlink_Click);
            // 
            // wbhyperlinkcontent
            // 
            this.wbhyperlinkcontent.Location = new System.Drawing.Point(8, 37);
            this.wbhyperlinkcontent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.wbhyperlinkcontent.MinimumSize = new System.Drawing.Size(10, 10);
            this.wbhyperlinkcontent.Name = "wbhyperlinkcontent";
            this.wbhyperlinkcontent.Size = new System.Drawing.Size(340, 173);
            this.wbhyperlinkcontent.TabIndex = 6;
            // 
            // tbhyperlink
            // 
            this.tbhyperlink.Location = new System.Drawing.Point(174, 12);
            this.tbhyperlink.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbhyperlink.Name = "tbhyperlink";
            this.tbhyperlink.Size = new System.Drawing.Size(175, 20);
            this.tbhyperlink.TabIndex = 5;
            // 
            // cbhyperlinklist
            // 
            this.cbhyperlinklist.FormattingEnabled = true;
            this.cbhyperlinklist.Location = new System.Drawing.Point(8, 12);
            this.cbhyperlinklist.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbhyperlinklist.Name = "cbhyperlinklist";
            this.cbhyperlinklist.Size = new System.Drawing.Size(136, 21);
            this.cbhyperlinklist.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // EditKnoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 259);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "EditKnoop";
            this.Text = "EditKnoop";
            this.Load += new System.EventHandler(this.EditKnoop_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabtext.ResumeLayout(false);
            this.tabtext.PerformLayout();
            this.tabimage.ResumeLayout(false);
            this.tabimage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbplaatje)).EndInit();
            this.tabHyperlink.ResumeLayout(false);
            this.tabHyperlink.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabtext;
        private System.Windows.Forms.ComboBox cbtextitems;
        private System.Windows.Forms.TextBox tbtextinhoud;
        private System.Windows.Forms.TabPage tabimage;
        private System.Windows.Forms.Button btconfirmplaatje;
        private System.Windows.Forms.PictureBox pbplaatje;
        private System.Windows.Forms.TextBox tbplaatjepad;
        private System.Windows.Forms.ComboBox cbplaatjeslist;
        private System.Windows.Forms.TabPage tabHyperlink;
        private System.Windows.Forms.Button btconfirmhyperlink;
        private System.Windows.Forms.WebBrowser wbhyperlinkcontent;
        private System.Windows.Forms.TextBox tbhyperlink;
        private System.Windows.Forms.ComboBox cbhyperlinklist;
        private System.Windows.Forms.Button btbrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.Button btconfirm;
    }
}