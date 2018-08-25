namespace DCUTest
{
    partial class doorSport
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.doorMB = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.doorMB)).BeginInit();
            this.SuspendLayout();
            // 
            // doorMB
            // 
            this.doorMB.Location = new System.Drawing.Point(30, 32);
            this.doorMB.Name = "doorMB";
            this.doorMB.Size = new System.Drawing.Size(152, 357);
            this.doorMB.TabIndex = 0;
            this.doorMB.TabStop = false;
            // 
            // doorSport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.doorMB);
            this.Name = "doorSport";
            this.Size = new System.Drawing.Size(428, 435);
            ((System.ComponentModel.ISupportInitialize)(this.doorMB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox doorMB;
    }
}
