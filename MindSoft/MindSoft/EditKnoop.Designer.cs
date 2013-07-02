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
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(766, 498);
            this.tabControl1.TabIndex = 0;
            // 
            // tabtext
            // 
            this.tabtext.Controls.Add(this.btconfirm);
            this.tabtext.Controls.Add(this.tbtextinhoud);
            this.tabtext.Location = new System.Drawing.Point(4, 34);
            this.tabtext.Margin = new System.Windows.Forms.Padding(4);
            this.tabtext.Name = "tabtext";
            this.tabtext.Padding = new System.Windows.Forms.Padding(4);
            this.tabtext.Size = new System.Drawing.Size(722, 429);
            this.tabtext.TabIndex = 0;
            this.tabtext.Text = "Text Inhoud";
            this.tabtext.UseVisualStyleBackColor = true;
            // 
            // btconfirm
            // 
            this.btconfirm.Location = new System.Drawing.Point(585, 23);
            this.btconfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btconfirm.Name = "btconfirm";
            this.btconfirm.Size = new System.Drawing.Size(100, 38);
            this.btconfirm.TabIndex = 4;
            this.btconfirm.Text = "Bewerk";
            this.btconfirm.UseVisualStyleBackColor = true;
            this.btconfirm.Click += new System.EventHandler(this.btconfirm_Click);
            // 
            // tbtextinhoud
            // 
            this.tbtextinhoud.Location = new System.Drawing.Point(17, 27);
            this.tbtextinhoud.Margin = new System.Windows.Forms.Padding(4);
            this.tbtextinhoud.Multiline = true;
            this.tbtextinhoud.Name = "tbtextinhoud";
            this.tbtextinhoud.Size = new System.Drawing.Size(560, 356);
            this.tbtextinhoud.TabIndex = 0;
            // 
            // tabimage
            // 
            this.tabimage.Controls.Add(this.btbrowse);
            this.tabimage.Controls.Add(this.btconfirmplaatje);
            this.tabimage.Controls.Add(this.pbplaatje);
            this.tabimage.Controls.Add(this.tbplaatjepad);
            this.tabimage.Controls.Add(this.cbplaatjeslist);
            this.tabimage.Location = new System.Drawing.Point(4, 34);
            this.tabimage.Margin = new System.Windows.Forms.Padding(4);
            this.tabimage.Name = "tabimage";
            this.tabimage.Padding = new System.Windows.Forms.Padding(4);
            this.tabimage.Size = new System.Drawing.Size(758, 460);
            this.tabimage.TabIndex = 1;
            this.tabimage.Text = "Plaatje inhoud";
            this.tabimage.UseVisualStyleBackColor = true;
            // 
            // btbrowse
            // 
            this.btbrowse.Location = new System.Drawing.Point(570, 65);
            this.btbrowse.Margin = new System.Windows.Forms.Padding(4);
            this.btbrowse.Name = "btbrowse";
            this.btbrowse.Size = new System.Drawing.Size(128, 38);
            this.btbrowse.TabIndex = 6;
            this.btbrowse.Text = "Browse...";
            this.btbrowse.UseVisualStyleBackColor = true;
            // 
            // btconfirmplaatje
            // 
            this.btconfirmplaatje.Location = new System.Drawing.Point(296, 29);
            this.btconfirmplaatje.Margin = new System.Windows.Forms.Padding(4);
            this.btconfirmplaatje.Name = "btconfirmplaatje";
            this.btconfirmplaatje.Size = new System.Drawing.Size(48, 33);
            this.btconfirmplaatje.TabIndex = 5;
            this.btconfirmplaatje.Text = ">";
            this.btconfirmplaatje.UseVisualStyleBackColor = true;
            // 
            // pbplaatje
            // 
            this.pbplaatje.Location = new System.Drawing.Point(20, 110);
            this.pbplaatje.Margin = new System.Windows.Forms.Padding(4);
            this.pbplaatje.Name = "pbplaatje";
            this.pbplaatje.Size = new System.Drawing.Size(680, 294);
            this.pbplaatje.TabIndex = 4;
            this.pbplaatje.TabStop = false;
            // 
            // tbplaatjepad
            // 
            this.tbplaatjepad.Location = new System.Drawing.Point(350, 29);
            this.tbplaatjepad.Margin = new System.Windows.Forms.Padding(4);
            this.tbplaatjepad.Name = "tbplaatjepad";
            this.tbplaatjepad.Size = new System.Drawing.Size(348, 31);
            this.tbplaatjepad.TabIndex = 3;
            // 
            // cbplaatjeslist
            // 
            this.cbplaatjeslist.FormattingEnabled = true;
            this.cbplaatjeslist.Location = new System.Drawing.Point(20, 27);
            this.cbplaatjeslist.Margin = new System.Windows.Forms.Padding(4);
            this.cbplaatjeslist.Name = "cbplaatjeslist";
            this.cbplaatjeslist.Size = new System.Drawing.Size(268, 33);
            this.cbplaatjeslist.TabIndex = 2;
            // 
            // tabHyperlink
            // 
            this.tabHyperlink.Controls.Add(this.btconfirmhyperlink);
            this.tabHyperlink.Controls.Add(this.wbhyperlinkcontent);
            this.tabHyperlink.Controls.Add(this.tbhyperlink);
            this.tabHyperlink.Controls.Add(this.cbhyperlinklist);
            this.tabHyperlink.Location = new System.Drawing.Point(4, 34);
            this.tabHyperlink.Margin = new System.Windows.Forms.Padding(4);
            this.tabHyperlink.Name = "tabHyperlink";
            this.tabHyperlink.Padding = new System.Windows.Forms.Padding(4);
            this.tabHyperlink.Size = new System.Drawing.Size(722, 429);
            this.tabHyperlink.TabIndex = 2;
            this.tabHyperlink.Text = "Hyperlink inhoud";
            this.tabHyperlink.UseVisualStyleBackColor = true;
            // 
            // btconfirmhyperlink
            // 
            this.btconfirmhyperlink.Location = new System.Drawing.Point(292, 21);
            this.btconfirmhyperlink.Margin = new System.Windows.Forms.Padding(4);
            this.btconfirmhyperlink.Name = "btconfirmhyperlink";
            this.btconfirmhyperlink.Size = new System.Drawing.Size(48, 33);
            this.btconfirmhyperlink.TabIndex = 7;
            this.btconfirmhyperlink.Text = ">";
            this.btconfirmhyperlink.UseVisualStyleBackColor = true;
            // 
            // wbhyperlinkcontent
            // 
            this.wbhyperlinkcontent.Location = new System.Drawing.Point(16, 71);
            this.wbhyperlinkcontent.Margin = new System.Windows.Forms.Padding(4);
            this.wbhyperlinkcontent.MinimumSize = new System.Drawing.Size(20, 19);
            this.wbhyperlinkcontent.Name = "wbhyperlinkcontent";
            this.wbhyperlinkcontent.Size = new System.Drawing.Size(680, 333);
            this.wbhyperlinkcontent.TabIndex = 6;
            // 
            // tbhyperlink
            // 
            this.tbhyperlink.Location = new System.Drawing.Point(348, 23);
            this.tbhyperlink.Margin = new System.Windows.Forms.Padding(4);
            this.tbhyperlink.Name = "tbhyperlink";
            this.tbhyperlink.Size = new System.Drawing.Size(346, 31);
            this.tbhyperlink.TabIndex = 5;
            // 
            // cbhyperlinklist
            // 
            this.cbhyperlinklist.FormattingEnabled = true;
            this.cbhyperlinklist.Location = new System.Drawing.Point(16, 23);
            this.cbhyperlinklist.Margin = new System.Windows.Forms.Padding(4);
            this.cbhyperlinklist.Name = "cbhyperlinklist";
            this.cbhyperlinklist.Size = new System.Drawing.Size(268, 33);
            this.cbhyperlinklist.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // EditKnoop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 498);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "EditKnoop";
            this.Text = "EditKnoop";
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
        private System.Windows.Forms.Button btconfirm;
    }
}