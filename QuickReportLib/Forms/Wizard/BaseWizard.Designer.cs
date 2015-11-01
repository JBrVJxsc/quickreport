namespace QuickReportLib.Forms.Wizard
{
    partial class BaseWizard
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseWizard));
            this.pnlBottom = new QuickReportLib.Controls.Plus.PanelWithLine();
            this.msBottom = new System.Windows.Forms.MenuStrip();
            this.msShortCutKey = new System.Windows.Forms.ToolStripMenuItem();
            this.msBottomShortCutKeyLast = new System.Windows.Forms.ToolStripMenuItem();
            this.msBottomShortCutKeyNext = new System.Windows.Forms.ToolStripMenuItem();
            this.msBottomShortCutKeyFinish = new System.Windows.Forms.ToolStripMenuItem();
            this.btLast = new System.Windows.Forms.Button();
            this.btNext = new System.Windows.Forms.Button();
            this.pnlTop = new QuickReportLib.Controls.Plus.PanelWithColor();
            this.imgWizard = new System.Windows.Forms.PictureBox();
            this.lbWizardSummary = new System.Windows.Forms.Label();
            this.lbWizardTitle = new System.Windows.Forms.Label();
            this.pnlCenter = new System.Windows.Forms.Panel();
            this.pnlBottom.SuspendLayout();
            this.msBottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgWizard)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            this.pnlBottom.Controls.Add(this.msBottom);
            this.pnlBottom.Controls.Add(this.btLast);
            this.pnlBottom.Controls.Add(this.btNext);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 387);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(593, 61);
            this.pnlBottom.TabIndex = 0;
            // 
            // msBottom
            // 
            this.msBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msShortCutKey});
            this.msBottom.Location = new System.Drawing.Point(0, 0);
            this.msBottom.Name = "msBottom";
            this.msBottom.Size = new System.Drawing.Size(593, 25);
            this.msBottom.TabIndex = 2;
            this.msBottom.Text = "menuStrip1";
            this.msBottom.Visible = false;
            // 
            // msShortCutKey
            // 
            this.msShortCutKey.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msBottomShortCutKeyLast,
            this.msBottomShortCutKeyNext,
            this.msBottomShortCutKeyFinish});
            this.msShortCutKey.Name = "msShortCutKey";
            this.msShortCutKey.Size = new System.Drawing.Size(80, 21);
            this.msShortCutKey.Text = "快捷键支持";
            // 
            // msBottomShortCutKeyLast
            // 
            this.msBottomShortCutKeyLast.Name = "msBottomShortCutKeyLast";
            this.msBottomShortCutKeyLast.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.B)));
            this.msBottomShortCutKeyLast.Size = new System.Drawing.Size(154, 22);
            this.msBottomShortCutKeyLast.Text = "上一步";
            this.msBottomShortCutKeyLast.Click += new System.EventHandler(this.msBottomShortCutKeyLast_Click);
            // 
            // msBottomShortCutKeyNext
            // 
            this.msBottomShortCutKeyNext.Name = "msBottomShortCutKeyNext";
            this.msBottomShortCutKeyNext.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
            this.msBottomShortCutKeyNext.Size = new System.Drawing.Size(154, 22);
            this.msBottomShortCutKeyNext.Text = "下一步";
            this.msBottomShortCutKeyNext.Click += new System.EventHandler(this.msBottomShortCutKeyNext_Click);
            // 
            // msBottomShortCutKeyFinish
            // 
            this.msBottomShortCutKeyFinish.Name = "msBottomShortCutKeyFinish";
            this.msBottomShortCutKeyFinish.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F)));
            this.msBottomShortCutKeyFinish.Size = new System.Drawing.Size(154, 22);
            this.msBottomShortCutKeyFinish.Text = "完成";
            this.msBottomShortCutKeyFinish.Click += new System.EventHandler(this.msBottomShortCutKeyFinish_Click);
            // 
            // btLast
            // 
            this.btLast.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btLast.Location = new System.Drawing.Point(390, 15);
            this.btLast.Name = "btLast";
            this.btLast.Size = new System.Drawing.Size(85, 29);
            this.btLast.TabIndex = 1;
            this.btLast.Text = "上一步(&B)";
            this.btLast.UseVisualStyleBackColor = true;
            this.btLast.Click += new System.EventHandler(this.btLast_Click);
            // 
            // btNext
            // 
            this.btNext.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btNext.Location = new System.Drawing.Point(491, 15);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(85, 29);
            this.btNext.TabIndex = 0;
            this.btNext.Text = "下一步(&N)";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.White;
            this.pnlTop.Controls.Add(this.imgWizard);
            this.pnlTop.Controls.Add(this.lbWizardSummary);
            this.pnlTop.Controls.Add(this.lbWizardTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.EndColor = System.Drawing.Color.Gray;
            this.pnlTop.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Horizontal;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(593, 64);
            this.pnlTop.StartColor = System.Drawing.Color.White;
            this.pnlTop.TabIndex = 1;
            // 
            // imgWizard
            // 
            this.imgWizard.Dock = System.Windows.Forms.DockStyle.Right;
            this.imgWizard.Location = new System.Drawing.Point(529, 0);
            this.imgWizard.Name = "imgWizard";
            this.imgWizard.Size = new System.Drawing.Size(64, 64);
            this.imgWizard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgWizard.TabIndex = 2;
            this.imgWizard.TabStop = false;
            this.imgWizard.Visible = false;
            // 
            // lbWizardSummary
            // 
            this.lbWizardSummary.AutoSize = true;
            this.lbWizardSummary.BackColor = System.Drawing.Color.Transparent;
            this.lbWizardSummary.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWizardSummary.Location = new System.Drawing.Point(26, 40);
            this.lbWizardSummary.Name = "lbWizardSummary";
            this.lbWizardSummary.Size = new System.Drawing.Size(0, 17);
            this.lbWizardSummary.TabIndex = 1;
            // 
            // lbWizardTitle
            // 
            this.lbWizardTitle.AutoSize = true;
            this.lbWizardTitle.BackColor = System.Drawing.Color.Transparent;
            this.lbWizardTitle.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbWizardTitle.Location = new System.Drawing.Point(15, 9);
            this.lbWizardTitle.Name = "lbWizardTitle";
            this.lbWizardTitle.Size = new System.Drawing.Size(0, 19);
            this.lbWizardTitle.TabIndex = 0;
            // 
            // pnlCenter
            // 
            this.pnlCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCenter.Location = new System.Drawing.Point(0, 64);
            this.pnlCenter.Name = "pnlCenter";
            this.pnlCenter.Size = new System.Drawing.Size(593, 323);
            this.pnlCenter.TabIndex = 2;
            // 
            // BaseWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            
            this.ClientSize = new System.Drawing.Size(593, 448);
            this.Controls.Add(this.pnlCenter);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlBottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseWizard";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BaseWizard";
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.msBottom.ResumeLayout(false);
            this.msBottom.PerformLayout();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgWizard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private QuickReportLib.Controls.Plus.PanelWithLine pnlBottom;
        private System.Windows.Forms.Button btNext;
        private QuickReportLib.Controls.Plus.PanelWithColor pnlTop;
        private System.Windows.Forms.Button btLast;
        private System.Windows.Forms.Label lbWizardSummary;
        private System.Windows.Forms.Label lbWizardTitle;
        private System.Windows.Forms.MenuStrip msBottom;
        private System.Windows.Forms.ToolStripMenuItem msShortCutKey;
        private System.Windows.Forms.ToolStripMenuItem msBottomShortCutKeyLast;
        private System.Windows.Forms.ToolStripMenuItem msBottomShortCutKeyNext;
        private System.Windows.Forms.ToolStripMenuItem msBottomShortCutKeyFinish;
        private System.Windows.Forms.Panel pnlCenter;
        private System.Windows.Forms.PictureBox imgWizard;
    }
}