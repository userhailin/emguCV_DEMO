namespace EmguCV.demo5
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.imageBox1 = new Emgu.CV.UI.ImageBox();
            this.LoadImage = new System.Windows.Forms.Button();
            this.FormColor = new System.Windows.Forms.Button();
            this.ScreenCapture = new System.Windows.Forms.Button();
            this.WinTitleBox = new System.Windows.Forms.TextBox();
            this.WindowTitle = new System.Windows.Forms.Button();
            this.GrayCheck = new System.Windows.Forms.Button();
            this.ImageCapture = new System.Windows.Forms.Button();
            this.GrayConvert = new System.Windows.Forms.Button();
            this.canny = new System.Windows.Forms.Button();
            this.Equalization = new System.Windows.Forms.Button();
            this.GaussianBlur = new System.Windows.Forms.Button();
            this.MeanFilter = new System.Windows.Forms.Button();
            this.HoughCircles = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageBox1
            // 
            this.imageBox1.Location = new System.Drawing.Point(59, 12);
            this.imageBox1.Name = "imageBox1";
            this.imageBox1.Size = new System.Drawing.Size(737, 473);
            this.imageBox1.TabIndex = 2;
            this.imageBox1.TabStop = false;
            // 
            // LoadImage
            // 
            this.LoadImage.Location = new System.Drawing.Point(416, 491);
            this.LoadImage.Name = "LoadImage";
            this.LoadImage.Size = new System.Drawing.Size(88, 36);
            this.LoadImage.TabIndex = 3;
            this.LoadImage.Text = "加载图像";
            this.LoadImage.UseVisualStyleBackColor = true;
            this.LoadImage.Click += new System.EventHandler(this.LoadImage_Click);
            // 
            // FormColor
            // 
            this.FormColor.Location = new System.Drawing.Point(510, 491);
            this.FormColor.Name = "FormColor";
            this.FormColor.Size = new System.Drawing.Size(86, 36);
            this.FormColor.TabIndex = 4;
            this.FormColor.Text = "窗口变色";
            this.FormColor.UseVisualStyleBackColor = true;
            this.FormColor.Click += new System.EventHandler(this.FormColor_Click);
            // 
            // ScreenCapture
            // 
            this.ScreenCapture.Location = new System.Drawing.Point(190, 491);
            this.ScreenCapture.Name = "ScreenCapture";
            this.ScreenCapture.Size = new System.Drawing.Size(107, 36);
            this.ScreenCapture.TabIndex = 5;
            this.ScreenCapture.Text = "窗口捕获";
            this.ScreenCapture.UseVisualStyleBackColor = true;
            this.ScreenCapture.Click += new System.EventHandler(this.ScreenCapture_Click);
            // 
            // WinTitleBox
            // 
            this.WinTitleBox.Location = new System.Drawing.Point(802, 56);
            this.WinTitleBox.Multiline = true;
            this.WinTitleBox.Name = "WinTitleBox";
            this.WinTitleBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.WinTitleBox.Size = new System.Drawing.Size(333, 390);
            this.WinTitleBox.TabIndex = 6;
            // 
            // WindowTitle
            // 
            this.WindowTitle.Location = new System.Drawing.Point(68, 491);
            this.WindowTitle.Name = "WindowTitle";
            this.WindowTitle.Size = new System.Drawing.Size(116, 36);
            this.WindowTitle.TabIndex = 7;
            this.WindowTitle.Text = "窗口标题";
            this.WindowTitle.UseVisualStyleBackColor = true;
            this.WindowTitle.Click += new System.EventHandler(this.WindowTitle_Click);
            // 
            // GrayCheck
            // 
            this.GrayCheck.Location = new System.Drawing.Point(303, 492);
            this.GrayCheck.Name = "GrayCheck";
            this.GrayCheck.Size = new System.Drawing.Size(107, 35);
            this.GrayCheck.TabIndex = 8;
            this.GrayCheck.Text = "灰度判断";
            this.GrayCheck.UseVisualStyleBackColor = true;
            this.GrayCheck.Click += new System.EventHandler(this.GrayCheck_Click);
            // 
            // ImageCapture
            // 
            this.ImageCapture.Location = new System.Drawing.Point(602, 492);
            this.ImageCapture.Name = "ImageCapture";
            this.ImageCapture.Size = new System.Drawing.Size(106, 35);
            this.ImageCapture.TabIndex = 10;
            this.ImageCapture.Text = "开启摄像头";
            this.ImageCapture.UseVisualStyleBackColor = true;
            this.ImageCapture.Click += new System.EventHandler(this.ImageCapture_Click);
            // 
            // GrayConvert
            // 
            this.GrayConvert.Location = new System.Drawing.Point(68, 534);
            this.GrayConvert.Name = "GrayConvert";
            this.GrayConvert.Size = new System.Drawing.Size(116, 30);
            this.GrayConvert.TabIndex = 11;
            this.GrayConvert.Text = "灰度转换";
            this.GrayConvert.UseVisualStyleBackColor = true;
            this.GrayConvert.Click += new System.EventHandler(this.GrayConvert_Click);
            // 
            // canny
            // 
            this.canny.Location = new System.Drawing.Point(191, 534);
            this.canny.Name = "canny";
            this.canny.Size = new System.Drawing.Size(106, 30);
            this.canny.TabIndex = 12;
            this.canny.Text = "canny算子";
            this.canny.UseVisualStyleBackColor = true;
            this.canny.Click += new System.EventHandler(this.canny_Click);
            // 
            // Equalization
            // 
            this.Equalization.Location = new System.Drawing.Point(304, 534);
            this.Equalization.Name = "Equalization";
            this.Equalization.Size = new System.Drawing.Size(106, 30);
            this.Equalization.TabIndex = 13;
            this.Equalization.Text = "直方图均方化";
            this.Equalization.UseVisualStyleBackColor = true;
            this.Equalization.Click += new System.EventHandler(this.Equalization_Click);
            // 
            // GaussianBlur
            // 
            this.GaussianBlur.Location = new System.Drawing.Point(416, 534);
            this.GaussianBlur.Name = "GaussianBlur";
            this.GaussianBlur.Size = new System.Drawing.Size(88, 30);
            this.GaussianBlur.TabIndex = 14;
            this.GaussianBlur.Text = "高斯滤波";
            this.GaussianBlur.UseVisualStyleBackColor = true;
            this.GaussianBlur.Click += new System.EventHandler(this.GaussianBlur_Click);
            // 
            // MeanFilter
            // 
            this.MeanFilter.Location = new System.Drawing.Point(511, 534);
            this.MeanFilter.Name = "MeanFilter";
            this.MeanFilter.Size = new System.Drawing.Size(85, 30);
            this.MeanFilter.TabIndex = 15;
            this.MeanFilter.Text = "均值滤波";
            this.MeanFilter.UseVisualStyleBackColor = true;
            this.MeanFilter.Click += new System.EventHandler(this.MeanFilter_Click);
            // 
            // HoughCircles
            // 
            this.HoughCircles.Location = new System.Drawing.Point(603, 534);
            this.HoughCircles.Name = "HoughCircles";
            this.HoughCircles.Size = new System.Drawing.Size(105, 30);
            this.HoughCircles.TabIndex = 16;
            this.HoughCircles.Text = "霍夫圆检测";
            this.HoughCircles.UseVisualStyleBackColor = true;
            this.HoughCircles.Click += new System.EventHandler(this.HoughCircles_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 597);
            this.Controls.Add(this.HoughCircles);
            this.Controls.Add(this.MeanFilter);
            this.Controls.Add(this.GaussianBlur);
            this.Controls.Add(this.Equalization);
            this.Controls.Add(this.canny);
            this.Controls.Add(this.GrayConvert);
            this.Controls.Add(this.ImageCapture);
            this.Controls.Add(this.GrayCheck);
            this.Controls.Add(this.WindowTitle);
            this.Controls.Add(this.WinTitleBox);
            this.Controls.Add(this.ScreenCapture);
            this.Controls.Add(this.FormColor);
            this.Controls.Add(this.LoadImage);
            this.Controls.Add(this.imageBox1);
            this.Name = "Form1";
            this.Text = "emguCV图像";
            ((System.ComponentModel.ISupportInitialize)(this.imageBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox imageBox1;
        private System.Windows.Forms.Button LoadImage;
        private System.Windows.Forms.Button FormColor;
        private System.Windows.Forms.Button ScreenCapture;
        private System.Windows.Forms.TextBox WinTitleBox;
        private System.Windows.Forms.Button WindowTitle;
        private System.Windows.Forms.Button GrayCheck;
        private System.Windows.Forms.Button ImageCapture;
        private System.Windows.Forms.Button GrayConvert;
        private System.Windows.Forms.Button canny;
        private System.Windows.Forms.Button Equalization;
        private System.Windows.Forms.Button GaussianBlur;
        private System.Windows.Forms.Button MeanFilter;
        private System.Windows.Forms.Button HoughCircles;
    }
}

