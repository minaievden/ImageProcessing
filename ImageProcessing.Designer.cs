namespace ImageProcessing
{
    partial class ImageProcessing
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
            this.components = new System.ComponentModel.Container();
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItemFile = new System.Windows.Forms.MenuItem();
            this.menuItemOpen = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.saveImg = new System.Windows.Forms.MenuItem();
            this.saveImgImg = new System.Windows.Forms.MenuItem();
            this.menuItemSep1 = new System.Windows.Forms.MenuItem();
            this.menuItemExit = new System.Windows.Forms.MenuItem();
            this.menuItemView = new System.Windows.Forms.MenuItem();
            this.menuItemImageInfo = new System.Windows.Forms.MenuItem();
            this.menuItemSep2 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom = new System.Windows.Forms.MenuItem();
            this.menuItemZoom50 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom100 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom150 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom200 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom300 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom400 = new System.Windows.Forms.MenuItem();
            this.menuItemZoom500 = new System.Windows.Forms.MenuItem();
            this.menuItemImage = new System.Windows.Forms.MenuItem();
            this.menuItemRotateFlip = new System.Windows.Forms.MenuItem();
            this.menuItemFlipH = new System.Windows.Forms.MenuItem();
            this.menuItemFlipV = new System.Windows.Forms.MenuItem();
            this.menuItemCrop = new System.Windows.Forms.MenuItem();
            this.deleteCrop = new System.Windows.Forms.MenuItem();
            this.menuItemEdit = new System.Windows.Forms.MenuItem();
            this.menuItemUnbo = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFile,
            this.menuItemView,
            this.menuItemImage,
            this.menuItemEdit});
            // 
            // menuItemFile
            // 
            this.menuItemFile.Index = 0;
            this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemOpen,
            this.menuItemSave,
            this.menuItemSep1,
            this.menuItemExit});
            this.menuItemFile.Text = "Файл";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Index = 0;
            this.menuItemOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.menuItemOpen.Text = "Открыть";
            this.menuItemOpen.Click += new System.EventHandler(this.menuItemOpen_Click);
            // 
            // menuItemSave
            // 
            this.menuItemSave.Index = 1;
            this.menuItemSave.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.saveImg,
            this.saveImgImg});
            this.menuItemSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            this.menuItemSave.Text = "Сохранить";
            // 
            // saveImg
            // 
            this.saveImg.Index = 0;
            this.saveImg.Text = "Сохранить изображение";
            this.saveImg.Click += new System.EventHandler(this.saveImg_Click);
            // 
            // saveImgImg
            // 
            this.saveImgImg.Enabled = false;
            this.saveImgImg.Index = 1;
            this.saveImgImg.Text = "Сохранить изображение+выд.обл.";
            this.saveImgImg.Click += new System.EventHandler(this.saveImgImg_Click);
            // 
            // menuItemSep1
            // 
            this.menuItemSep1.Index = 2;
            this.menuItemSep1.Text = "-";
            // 
            // menuItemExit
            // 
            this.menuItemExit.Index = 3;
            this.menuItemExit.Text = "Выход";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.Index = 1;
            this.menuItemView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemImageInfo,
            this.menuItemSep2,
            this.menuItemZoom});
            this.menuItemView.Text = "Вид";
            // 
            // menuItemImageInfo
            // 
            this.menuItemImageInfo.Enabled = false;
            this.menuItemImageInfo.Index = 0;
            this.menuItemImageInfo.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
            this.menuItemImageInfo.Text = "Информация о изображении";
            this.menuItemImageInfo.Click += new System.EventHandler(this.menuItemImageInfo_Click);
            // 
            // menuItemSep2
            // 
            this.menuItemSep2.Index = 1;
            this.menuItemSep2.Text = "-";
            // 
            // menuItemZoom
            // 
            this.menuItemZoom.Index = 2;
            this.menuItemZoom.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemZoom50,
            this.menuItemZoom100,
            this.menuItemZoom150,
            this.menuItemZoom200,
            this.menuItemZoom300,
            this.menuItemZoom400,
            this.menuItemZoom500});
            this.menuItemZoom.Text = "Увеличить";
            // 
            // menuItemZoom50
            // 
            this.menuItemZoom50.Index = 0;
            this.menuItemZoom50.Text = "50%";
            this.menuItemZoom50.Click += new System.EventHandler(this.menuItemZoom50_Click);
            // 
            // menuItemZoom100
            // 
            this.menuItemZoom100.Checked = true;
            this.menuItemZoom100.Index = 1;
            this.menuItemZoom100.Text = "100%";
            this.menuItemZoom100.Click += new System.EventHandler(this.menuItemZoom100_Click);
            // 
            // menuItemZoom150
            // 
            this.menuItemZoom150.Index = 2;
            this.menuItemZoom150.Text = "150%";
            this.menuItemZoom150.Click += new System.EventHandler(this.menuItemZoom150_Click);
            // 
            // menuItemZoom200
            // 
            this.menuItemZoom200.Index = 3;
            this.menuItemZoom200.Text = "200%";
            this.menuItemZoom200.Click += new System.EventHandler(this.menuItemZoom200_Click);
            // 
            // menuItemZoom300
            // 
            this.menuItemZoom300.Index = 4;
            this.menuItemZoom300.Text = "300%";
            this.menuItemZoom300.Click += new System.EventHandler(this.menuItemZoom300_Click);
            // 
            // menuItemZoom400
            // 
            this.menuItemZoom400.Index = 5;
            this.menuItemZoom400.Text = "400%";
            this.menuItemZoom400.Click += new System.EventHandler(this.menuItemZoom400_Click);
            // 
            // menuItemZoom500
            // 
            this.menuItemZoom500.Index = 6;
            this.menuItemZoom500.Text = "500%";
            this.menuItemZoom500.Click += new System.EventHandler(this.menuItemZoom500_Click);
            // 
            // menuItemImage
            // 
            this.menuItemImage.Index = 2;
            this.menuItemImage.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemRotateFlip,
            this.menuItemCrop,
            this.deleteCrop});
            this.menuItemImage.Text = "Изображение";
            // 
            // menuItemRotateFlip
            // 
            this.menuItemRotateFlip.Index = 0;
            this.menuItemRotateFlip.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemFlipH,
            this.menuItemFlipV});
            this.menuItemRotateFlip.Text = "Отражение";
            // 
            // menuItemFlipH
            // 
            this.menuItemFlipH.Index = 0;
            this.menuItemFlipH.Text = "Отражение по горизонтали";
            this.menuItemFlipH.Click += new System.EventHandler(this.menuItemFlipH_Click);
            // 
            // menuItemFlipV
            // 
            this.menuItemFlipV.Index = 1;
            this.menuItemFlipV.Text = "Отражение по вертикали";
            this.menuItemFlipV.Click += new System.EventHandler(this.menuItemFlipV_Click);
            // 
            // menuItemCrop
            // 
            this.menuItemCrop.Index = 1;
            this.menuItemCrop.Text = "Выделить область";
            this.menuItemCrop.Click += new System.EventHandler(this.menuItemCrop_Click);
            // 
            // deleteCrop
            // 
            this.deleteCrop.Enabled = false;
            this.deleteCrop.Index = 2;
            this.deleteCrop.Text = "Удалить выделенную область";
            this.deleteCrop.Click += new System.EventHandler(this.deleteCrop_Click_1);
            // 
            // menuItemEdit
            // 
            this.menuItemEdit.Index = 3;
            this.menuItemEdit.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItemUnbo});
            this.menuItemEdit.Text = "Другое";
            this.menuItemEdit.Visible = false;
            // 
            // menuItemUnbo
            // 
            this.menuItemUnbo.Index = 0;
            this.menuItemUnbo.Shortcut = System.Windows.Forms.Shortcut.CtrlZ;
            this.menuItemUnbo.Text = "Отменить изменение";
            this.menuItemUnbo.Click += new System.EventHandler(this.menuItemUndo_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = -1;
            this.menuItem6.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 128);
            this.label1.TabIndex = 1;
            this.label1.Text = "Курсовая работа по МКИТ\r\nСтудента группы ИУС-11 \r\nМинаева Дениса\r\nДонНТУ 2013";
            this.label1.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(397, 147);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // ImageProcessing
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(764, 509);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Menu = this.MainMenu1;
            this.Name = "ImageProcessing";
            this.Text = "Курсова работа по МКИТ студента группы ИУС-11 Минаева Дениса";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ImageProcessing_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.pictureBox1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MainMenu MainMenu1;
        private System.Windows.Forms.MenuItem menuItemFile;
        private System.Windows.Forms.MenuItem menuItemOpen;
        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.MenuItem menuItemSep1;
        private System.Windows.Forms.MenuItem menuItemExit;
        private System.Windows.Forms.MenuItem menuItemView;
        private System.Windows.Forms.MenuItem menuItemImageInfo;
        private System.Windows.Forms.MenuItem menuItemSep2;
        private System.Windows.Forms.MenuItem menuItemZoom;
        private System.Windows.Forms.MenuItem menuItemZoom50;
        private System.Windows.Forms.MenuItem menuItemZoom100;
        private System.Windows.Forms.MenuItem menuItemZoom150;
        private System.Windows.Forms.MenuItem menuItemZoom200;
        private System.Windows.Forms.MenuItem menuItemZoom300;
        private System.Windows.Forms.MenuItem menuItemZoom400;
        private System.Windows.Forms.MenuItem menuItemZoom500;
        private System.Windows.Forms.MenuItem menuItemImage;
        private System.Windows.Forms.MenuItem menuItemRotateFlip;
        private System.Windows.Forms.MenuItem menuItemFlipH;
        private System.Windows.Forms.MenuItem menuItemFlipV;
        private System.Windows.Forms.MenuItem menuItemCrop;
        private System.Windows.Forms.MenuItem saveImg;
        private System.Windows.Forms.MenuItem saveImgImg;
        private System.Windows.Forms.MenuItem deleteCrop;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MenuItem menuItemEdit;
        private System.Windows.Forms.MenuItem menuItemUnbo;
    }
}

