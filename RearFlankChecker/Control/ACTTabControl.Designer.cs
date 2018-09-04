namespace RearFlankChecker
{
    partial class ACTTabControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.groupView = new System.Windows.Forms.GroupBox();
            this.labelViewY = new System.Windows.Forms.Label();
            this.labelViewX = new System.Windows.Forms.Label();
            this.udViewY = new System.Windows.Forms.NumericUpDown();
            this.udViewX = new System.Windows.Forms.NumericUpDown();
            this.labelViewOrientation = new System.Windows.Forms.Label();
            this.trackBarOpacity = new System.Windows.Forms.TrackBar();
            this.labelCurrOpacity = new System.Windows.Forms.Label();
            this.labelOpacity = new System.Windows.Forms.Label();
            this.checkViewMouseEnable = new System.Windows.Forms.CheckBox();
            this.checkViewVisible = new System.Windows.Forms.CheckBox();
            this.groupSound = new System.Windows.Forms.GroupBox();
            this.checkSoundEnable = new System.Windows.Forms.CheckBox();
            this.groupView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udViewY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.udViewX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).BeginInit();
            this.groupSound.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupView
            // 
            this.groupView.Controls.Add(this.labelViewY);
            this.groupView.Controls.Add(this.labelViewX);
            this.groupView.Controls.Add(this.udViewY);
            this.groupView.Controls.Add(this.udViewX);
            this.groupView.Controls.Add(this.labelViewOrientation);
            this.groupView.Controls.Add(this.trackBarOpacity);
            this.groupView.Controls.Add(this.labelCurrOpacity);
            this.groupView.Controls.Add(this.labelOpacity);
            this.groupView.Controls.Add(this.checkViewMouseEnable);
            this.groupView.Controls.Add(this.checkViewVisible);
            this.groupView.Location = new System.Drawing.Point(19, 110);
            this.groupView.Name = "groupView";
            this.groupView.Size = new System.Drawing.Size(402, 163);
            this.groupView.TabIndex = 4;
            this.groupView.TabStop = false;
            this.groupView.Text = "ビューア";
            // 
            // labelViewY
            // 
            this.labelViewY.AutoSize = true;
            this.labelViewY.Location = new System.Drawing.Point(222, 87);
            this.labelViewY.Name = "labelViewY";
            this.labelViewY.Size = new System.Drawing.Size(14, 12);
            this.labelViewY.TabIndex = 11;
            this.labelViewY.Text = "Y:";
            // 
            // labelViewX
            // 
            this.labelViewX.AutoSize = true;
            this.labelViewX.Location = new System.Drawing.Point(100, 87);
            this.labelViewX.Name = "labelViewX";
            this.labelViewX.Size = new System.Drawing.Size(14, 12);
            this.labelViewX.TabIndex = 12;
            this.labelViewX.Text = "X:";
            // 
            // udViewY
            // 
            this.udViewY.Location = new System.Drawing.Point(242, 85);
            this.udViewY.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udViewY.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.udViewY.Name = "udViewY";
            this.udViewY.Size = new System.Drawing.Size(80, 19);
            this.udViewY.TabIndex = 9;
            this.udViewY.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udViewY.ValueChanged += new System.EventHandler(this.udViewY_ValueChanged);
            // 
            // udViewX
            // 
            this.udViewX.Location = new System.Drawing.Point(120, 85);
            this.udViewX.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.udViewX.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.udViewX.Name = "udViewX";
            this.udViewX.Size = new System.Drawing.Size(80, 19);
            this.udViewX.TabIndex = 10;
            this.udViewX.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.udViewX.ValueChanged += new System.EventHandler(this.udViewX_ValueChanged);
            // 
            // labelViewOrientation
            // 
            this.labelViewOrientation.AutoSize = true;
            this.labelViewOrientation.Location = new System.Drawing.Point(16, 87);
            this.labelViewOrientation.Name = "labelViewOrientation";
            this.labelViewOrientation.Size = new System.Drawing.Size(53, 12);
            this.labelViewOrientation.TabIndex = 8;
            this.labelViewOrientation.Text = "表示位置";
            // 
            // trackBarOpacity
            // 
            this.trackBarOpacity.Location = new System.Drawing.Point(93, 116);
            this.trackBarOpacity.Maximum = 100;
            this.trackBarOpacity.Minimum = 1;
            this.trackBarOpacity.Name = "trackBarOpacity";
            this.trackBarOpacity.Size = new System.Drawing.Size(234, 45);
            this.trackBarOpacity.TabIndex = 7;
            this.trackBarOpacity.TickFrequency = 10;
            this.trackBarOpacity.Value = 80;
            this.trackBarOpacity.Scroll += new System.EventHandler(this.trackBarOpacity_Scroll);
            // 
            // labelCurrOpacity
            // 
            this.labelCurrOpacity.AutoSize = true;
            this.labelCurrOpacity.Location = new System.Drawing.Point(329, 121);
            this.labelCurrOpacity.Name = "labelCurrOpacity";
            this.labelCurrOpacity.Size = new System.Drawing.Size(21, 12);
            this.labelCurrOpacity.TabIndex = 5;
            this.labelCurrOpacity.Text = "??%";
            // 
            // labelOpacity
            // 
            this.labelOpacity.AutoSize = true;
            this.labelOpacity.Location = new System.Drawing.Point(16, 121);
            this.labelOpacity.Name = "labelOpacity";
            this.labelOpacity.Size = new System.Drawing.Size(53, 12);
            this.labelOpacity.TabIndex = 6;
            this.labelOpacity.Text = "不透明度";
            // 
            // checkViewMouseEnable
            // 
            this.checkViewMouseEnable.AutoSize = true;
            this.checkViewMouseEnable.Checked = true;
            this.checkViewMouseEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkViewMouseEnable.Location = new System.Drawing.Point(16, 54);
            this.checkViewMouseEnable.Name = "checkViewMouseEnable";
            this.checkViewMouseEnable.Size = new System.Drawing.Size(157, 16);
            this.checkViewMouseEnable.TabIndex = 3;
            this.checkViewMouseEnable.Text = "マウスで移動できるようにする";
            this.checkViewMouseEnable.UseVisualStyleBackColor = true;
            this.checkViewMouseEnable.CheckedChanged += new System.EventHandler(this.checkViewMouseEnable_CheckedChanged);
            // 
            // checkViewVisible
            // 
            this.checkViewVisible.AutoSize = true;
            this.checkViewVisible.Checked = true;
            this.checkViewVisible.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkViewVisible.Location = new System.Drawing.Point(16, 27);
            this.checkViewVisible.Name = "checkViewVisible";
            this.checkViewVisible.Size = new System.Drawing.Size(67, 16);
            this.checkViewVisible.TabIndex = 2;
            this.checkViewVisible.Text = "表示する";
            this.checkViewVisible.UseVisualStyleBackColor = true;
            this.checkViewVisible.CheckedChanged += new System.EventHandler(this.checkViewVisible_CheckedChanged);
            // 
            // groupSound
            // 
            this.groupSound.Controls.Add(this.checkSoundEnable);
            this.groupSound.Location = new System.Drawing.Point(19, 24);
            this.groupSound.Name = "groupSound";
            this.groupSound.Size = new System.Drawing.Size(402, 66);
            this.groupSound.TabIndex = 5;
            this.groupSound.TabStop = false;
            this.groupSound.Text = "効果音";
            // 
            // checkSoundEnable
            // 
            this.checkSoundEnable.AutoSize = true;
            this.checkSoundEnable.Checked = true;
            this.checkSoundEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkSoundEnable.Location = new System.Drawing.Point(16, 27);
            this.checkSoundEnable.Name = "checkSoundEnable";
            this.checkSoundEnable.Size = new System.Drawing.Size(161, 16);
            this.checkSoundEnable.TabIndex = 1;
            this.checkSoundEnable.Text = "方向指定を間違えたら鳴らす";
            this.checkSoundEnable.UseVisualStyleBackColor = true;
            // 
            // ACTTabControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupSound);
            this.Controls.Add(this.groupView);
            this.Name = "ACTTabControl";
            this.Size = new System.Drawing.Size(451, 298);
            this.groupView.ResumeLayout(false);
            this.groupView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.udViewY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.udViewX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarOpacity)).EndInit();
            this.groupSound.ResumeLayout(false);
            this.groupSound.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupView;
        private System.Windows.Forms.Label labelViewY;
        private System.Windows.Forms.Label labelViewX;
        private System.Windows.Forms.NumericUpDown udViewY;
        private System.Windows.Forms.NumericUpDown udViewX;
        private System.Windows.Forms.Label labelViewOrientation;
        private System.Windows.Forms.TrackBar trackBarOpacity;
        private System.Windows.Forms.Label labelCurrOpacity;
        private System.Windows.Forms.Label labelOpacity;
        private System.Windows.Forms.CheckBox checkViewMouseEnable;
        private System.Windows.Forms.CheckBox checkViewVisible;
        private System.Windows.Forms.GroupBox groupSound;
        private System.Windows.Forms.CheckBox checkSoundEnable;
    }
}
