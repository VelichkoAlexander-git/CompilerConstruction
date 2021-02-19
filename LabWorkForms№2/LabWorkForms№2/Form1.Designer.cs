
namespace LabWorkForms_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.CodeTxt = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.StartTsbtn = new System.Windows.Forms.ToolStripButton();
            this.FileTsddb = new System.Windows.Forms.ToolStripDropDownButton();
            this.OpenTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveTsmi = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CodeTxt
            // 
            this.CodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeTxt.Location = new System.Drawing.Point(12, 27);
            this.CodeTxt.Multiline = true;
            this.CodeTxt.Name = "CodeTxt";
            this.CodeTxt.Size = new System.Drawing.Size(360, 422);
            this.CodeTxt.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileTsddb,
            this.StartTsbtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(384, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // StartTsbtn
            // 
            this.StartTsbtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StartTsbtn.Image = ((System.Drawing.Image)(resources.GetObject("StartTsbtn.Image")));
            this.StartTsbtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.StartTsbtn.Name = "StartTsbtn";
            this.StartTsbtn.Size = new System.Drawing.Size(35, 22);
            this.StartTsbtn.Text = "Start";
            this.StartTsbtn.Click += new System.EventHandler(this.StartTsbtn_Click);
            // 
            // FileTsddb
            // 
            this.FileTsddb.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.FileTsddb.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenTsmi,
            this.SaveTsmi});
            this.FileTsddb.Image = ((System.Drawing.Image)(resources.GetObject("FileTsddb.Image")));
            this.FileTsddb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FileTsddb.Name = "FileTsddb";
            this.FileTsddb.Size = new System.Drawing.Size(38, 22);
            this.FileTsddb.Text = "File";
            // 
            // OpenTsmi
            // 
            this.OpenTsmi.Name = "OpenTsmi";
            this.OpenTsmi.Size = new System.Drawing.Size(180, 22);
            this.OpenTsmi.Text = "Open";
            this.OpenTsmi.Click += new System.EventHandler(this.OpenTsmi_Click);
            // 
            // SaveTsmi
            // 
            this.SaveTsmi.Name = "SaveTsmi";
            this.SaveTsmi.Size = new System.Drawing.Size(180, 22);
            this.SaveTsmi.Text = "Save";
            this.SaveTsmi.Click += new System.EventHandler(this.SaveTsmi_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 461);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.CodeTxt);
            this.MinimumSize = new System.Drawing.Size(400, 500);
            this.Name = "Form1";
            this.Text = "Form1";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox CodeTxt;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton StartTsbtn;
        private System.Windows.Forms.ToolStripDropDownButton FileTsddb;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem OpenTsmi;
        private System.Windows.Forms.ToolStripMenuItem SaveTsmi;
    }
}

