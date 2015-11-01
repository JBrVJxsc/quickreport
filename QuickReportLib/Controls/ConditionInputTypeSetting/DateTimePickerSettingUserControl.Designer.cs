namespace QuickReportLib.Controls.ConditionInputTypeSetting
{
    partial class DateTimePickerSettingUserControl
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            QuickReportLib.Objects.SystemValue.PCDate pcDate1 = new QuickReportLib.Objects.SystemValue.PCDate();
            QuickReportLib.Objects.SystemValue.PCDateTime pcDateTime1 = new QuickReportLib.Objects.SystemValue.PCDateTime();
            QuickReportLib.Objects.SystemValue.PCTime pcTime1 = new QuickReportLib.Objects.SystemValue.PCTime();
            QuickReportLib.Objects.SystemValue.ServerDate serverDate1 = new QuickReportLib.Objects.SystemValue.ServerDate();
            QuickReportLib.Objects.SystemValue.ServerDateTime serverDateTime1 = new QuickReportLib.Objects.SystemValue.ServerDateTime();
            QuickReportLib.Objects.SystemValue.ServerTime serverTime1 = new QuickReportLib.Objects.SystemValue.ServerTime();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cmbActionAfterEnterKeyDown = new QuickReportLib.Controls.Plus.ComboBoxActionAfterEnterKeyDown();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFixedValue = new System.Windows.Forms.DateTimePicker();
            this.cbUseFixedValue = new System.Windows.Forms.CheckBox();
            this.numSec = new System.Windows.Forms.NumericUpDown();
            this.numMin = new System.Windows.Forms.NumericUpDown();
            this.numHour = new System.Windows.Forms.NumericUpDown();
            this.numDay = new System.Windows.Forms.NumericUpDown();
            this.cmbAddOrSub = new QuickReportLib.Controls.Plus.ComboBoxPlus();
            this.lbSec = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.lbHour = new System.Windows.Forms.Label();
            this.lbDay = new System.Windows.Forms.Label();
            this.cmbDateTimeSystemValueTypes = new QuickReportLib.Controls.Plus.ComboBoxDateTimeSystemValue();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cmbActionAfterEnterKeyDown);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtFixedValue);
            this.groupBox1.Controls.Add(this.cbUseFixedValue);
            this.groupBox1.Controls.Add(this.numSec);
            this.groupBox1.Controls.Add(this.numMin);
            this.groupBox1.Controls.Add(this.numHour);
            this.groupBox1.Controls.Add(this.numDay);
            this.groupBox1.Controls.Add(this.cmbAddOrSub);
            this.groupBox1.Controls.Add(this.lbSec);
            this.groupBox1.Controls.Add(this.lbMin);
            this.groupBox1.Controls.Add(this.lbHour);
            this.groupBox1.Controls.Add(this.lbDay);
            this.groupBox1.Controls.Add(this.cmbDateTimeSystemValueTypes);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(3, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(326, 278);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            // 
            // cmbActionAfterEnterKeyDown
            // 
            this.cmbActionAfterEnterKeyDown.ActionAfterEnterKeyDown = QuickReportLib.Enums.ActionAfterEnterKeyDown.Query;
            this.cmbActionAfterEnterKeyDown.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Both;
            this.cmbActionAfterEnterKeyDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbActionAfterEnterKeyDown.FilterName = "过滤框";
            this.cmbActionAfterEnterKeyDown.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbActionAfterEnterKeyDown.FormattingEnabled = true;
            this.cmbActionAfterEnterKeyDown.Items.AddRange(new object[] {
            "查询",
            "选择下一个控件"});
            this.cmbActionAfterEnterKeyDown.Location = new System.Drawing.Point(68, 130);
            this.cmbActionAfterEnterKeyDown.Name = "cmbActionAfterEnterKeyDown";
            this.cmbActionAfterEnterKeyDown.Size = new System.Drawing.Size(239, 25);
            this.cmbActionAfterEnterKeyDown.TabIndex = 47;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 46;
            this.label2.Text = "回车后：";
            // 
            // dtFixedValue
            // 
            this.dtFixedValue.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtFixedValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtFixedValue.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFixedValue.Location = new System.Drawing.Point(107, 92);
            this.dtFixedValue.Name = "dtFixedValue";
            this.dtFixedValue.Size = new System.Drawing.Size(200, 23);
            this.dtFixedValue.TabIndex = 45;
            // 
            // cbUseFixedValue
            // 
            this.cbUseFixedValue.AutoSize = true;
            this.cbUseFixedValue.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbUseFixedValue.Location = new System.Drawing.Point(9, 94);
            this.cbUseFixedValue.Name = "cbUseFixedValue";
            this.cbUseFixedValue.Size = new System.Drawing.Size(87, 21);
            this.cbUseFixedValue.TabIndex = 44;
            this.cbUseFixedValue.Text = "使用固定值";
            this.cbUseFixedValue.UseVisualStyleBackColor = true;
            // 
            // numSec
            // 
            this.numSec.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numSec.Location = new System.Drawing.Point(248, 55);
            this.numSec.Name = "numSec";
            this.numSec.Size = new System.Drawing.Size(35, 23);
            this.numSec.TabIndex = 43;
            // 
            // numMin
            // 
            this.numMin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numMin.Location = new System.Drawing.Point(188, 55);
            this.numMin.Name = "numMin";
            this.numMin.Size = new System.Drawing.Size(35, 23);
            this.numMin.TabIndex = 42;
            // 
            // numHour
            // 
            this.numHour.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numHour.Location = new System.Drawing.Point(128, 55);
            this.numHour.Name = "numHour";
            this.numHour.Size = new System.Drawing.Size(35, 23);
            this.numHour.TabIndex = 41;
            // 
            // numDay
            // 
            this.numDay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numDay.Location = new System.Drawing.Point(68, 55);
            this.numDay.Name = "numDay";
            this.numDay.Size = new System.Drawing.Size(35, 23);
            this.numDay.TabIndex = 40;
            // 
            // cmbAddOrSub
            // 
            this.cmbAddOrSub.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Name;
            this.cmbAddOrSub.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAddOrSub.FilterName = "报表分类";
            this.cmbAddOrSub.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbAddOrSub.FormattingEnabled = true;
            this.cmbAddOrSub.Items.AddRange(new object[] {
            "+",
            "-"});
            this.cmbAddOrSub.Location = new System.Drawing.Point(9, 54);
            this.cmbAddOrSub.Name = "cmbAddOrSub";
            this.cmbAddOrSub.Size = new System.Drawing.Size(38, 25);
            this.cmbAddOrSub.TabIndex = 39;
            // 
            // lbSec
            // 
            this.lbSec.AutoSize = true;
            this.lbSec.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbSec.Location = new System.Drawing.Point(287, 57);
            this.lbSec.Name = "lbSec";
            this.lbSec.Size = new System.Drawing.Size(20, 17);
            this.lbSec.TabIndex = 38;
            this.lbSec.Text = "秒";
            // 
            // lbMin
            // 
            this.lbMin.AutoSize = true;
            this.lbMin.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbMin.Location = new System.Drawing.Point(227, 57);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(20, 17);
            this.lbMin.TabIndex = 37;
            this.lbMin.Text = "分";
            // 
            // lbHour
            // 
            this.lbHour.AutoSize = true;
            this.lbHour.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbHour.Location = new System.Drawing.Point(167, 57);
            this.lbHour.Name = "lbHour";
            this.lbHour.Size = new System.Drawing.Size(20, 17);
            this.lbHour.TabIndex = 36;
            this.lbHour.Text = "时";
            // 
            // lbDay
            // 
            this.lbDay.AutoSize = true;
            this.lbDay.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbDay.Location = new System.Drawing.Point(107, 57);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(20, 17);
            this.lbDay.TabIndex = 35;
            this.lbDay.Text = "天";
            // 
            // cmbDateTimeSystemValueTypes
            // 
            this.cmbDateTimeSystemValueTypes.ColumnShowState = QuickReportLib.Enums.ComboBoxPlusColumnShowState.Name;
            this.cmbDateTimeSystemValueTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDateTimeSystemValueTypes.FilterName = "报表分类";
            this.cmbDateTimeSystemValueTypes.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbDateTimeSystemValueTypes.FormattingEnabled = true;
            pcDate1.ID = "PCDate";
            pcDate1.Name = "本机日期";
            pcDate1.SortID = 0;
            pcDateTime1.ID = "PCDateTime";
            pcDateTime1.Name = "本机日期与时间";
            pcDateTime1.SortID = 0;
            pcTime1.ID = "PCTime";
            pcTime1.Name = "本机时间";
            pcTime1.SortID = 0;
            serverDate1.ID = "ServerDate";
            serverDate1.Name = "服务器日期";
            serverDate1.SortID = 0;
            serverDateTime1.ID = "ServerDateTime";
            serverDateTime1.Name = "服务器日期与时间";
            serverDateTime1.SortID = 0;
            serverTime1.ID = "ServerTime";
            serverTime1.Name = "服务器时间";
            serverTime1.SortID = 0;
            this.cmbDateTimeSystemValueTypes.Items.AddRange(new object[] {
            pcDate1,
            pcDateTime1,
            pcTime1,
            serverDate1,
            serverDateTime1,
            serverTime1});
            this.cmbDateTimeSystemValueTypes.Location = new System.Drawing.Point(68, 16);
            this.cmbDateTimeSystemValueTypes.Name = "cmbDateTimeSystemValueTypes";
            this.cmbDateTimeSystemValueTypes.SelectedSystemValueType = "";
            this.cmbDateTimeSystemValueTypes.Size = new System.Drawing.Size(239, 25);
            this.cmbDateTimeSystemValueTypes.TabIndex = 34;
            this.cmbDateTimeSystemValueTypes.SelectedIndexChanged += new System.EventHandler(this.cmbDateValueTypes_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "默认值：";
            // 
            // DateTimePickerSettingUserControl
            // 
            this.Controls.Add(this.groupBox1);
            this.Name = "DateTimePickerSettingUserControl";
            this.Size = new System.Drawing.Size(692, 278);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private QuickReportLib.Controls.Plus.ComboBoxActionAfterEnterKeyDown cmbActionAfterEnterKeyDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFixedValue;
        private System.Windows.Forms.CheckBox cbUseFixedValue;
        private System.Windows.Forms.NumericUpDown numSec;
        private System.Windows.Forms.NumericUpDown numMin;
        private System.Windows.Forms.NumericUpDown numHour;
        private System.Windows.Forms.NumericUpDown numDay;
        private QuickReportLib.Controls.Plus.ComboBoxPlus cmbAddOrSub;
        private System.Windows.Forms.Label lbSec;
        private System.Windows.Forms.Label lbMin;
        private System.Windows.Forms.Label lbHour;
        private System.Windows.Forms.Label lbDay;
        private QuickReportLib.Controls.Plus.ComboBoxDateTimeSystemValue cmbDateTimeSystemValueTypes;
        private System.Windows.Forms.Label label1;


    }
}
