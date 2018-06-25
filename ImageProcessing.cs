using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace ImageProcessing
{
    public partial class ImageProcessing : Form
    {
        OpenFileDialog oDlg;//переменная типа диалогового окна открытия файла
        SaveFileDialog sDlg1;//переменная типа диалогового окна сохранения файла
        SaveFileDialog sDlg2;//переменная типа диалогового окна сохранения файла
        private MenuItem cZoom;//переменная для меню увеличения изображения
        Bitmap temp;//переменная для хранения временного изображения
        Bitmap cloneBitmap;//переменная для хранения выделенной области
        int cropX = 0, cropY = 0, widthImgCrop = 100, heightImgCrop = 100;//переменные для хранения координат выделяемого изображения, ширины и высоты
        ImageHandler imageHandler = new ImageHandler();//создание экземпляра класса imageHandler
        public ImageProcessing()
        {
            InitializeComponent();

            oDlg = new OpenFileDialog();//создание диалогового окна для открытия файла
            oDlg.RestoreDirectory = true;
            oDlg.InitialDirectory = "C:\\";
            oDlg.FilterIndex = 1;
            oDlg.Filter = "jpg Files (*.jpg)|*.jpg";
            /*************************/
            sDlg1 = new SaveFileDialog();//создание диалогового окна для сохранения файла
            sDlg1.RestoreDirectory = true;
            sDlg1.InitialDirectory = "C:\\";
            sDlg1.FilterIndex = 1;
            sDlg1.Filter = "bmp Files (*.bmp)|*.bmp";
            /*************************/
            sDlg2 = new SaveFileDialog();//создание диалогового окна для сохранения файла с выделенным изображением
            sDlg2.RestoreDirectory = true;
            sDlg2.InitialDirectory = "C:\\";
            sDlg2.FilterIndex = 1;
            sDlg2.Filter = "bmp Files (*.bmp)|*.bmp";

            cZoom = menuItemZoom50;
        }

        private void ImageProcessing_Paint(object sender, PaintEventArgs e)//функция выводит изображение на форму
        {
            if(imageHandler.IsPicture)
            {
                e.Graphics.DrawImage(imageHandler.GetBitmap(), new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y,Convert.ToInt32(imageHandler.Width),Convert.ToInt32(imageHandler.Height)));
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)//функция попиксельно считывает выбранное изображение и создает битмап
        {
            if (DialogResult.OK == oDlg.ShowDialog())
            {
                imageHandler.SetBitmap((Bitmap)Bitmap.FromFile(oDlg.FileName));
                imageHandler.BitmapPath = oDlg.FileName;
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height));
                this.Invalidate();
                menuItemImageInfo_Click(0,e);//вывод информации о изображении
            }
        }

        private void menuItemUndo_Click(object sender, EventArgs e)//функция отмены действия
        {
            imageHandler.ResetBitmap();
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height ));
            //пересчитываем минимальную область для прокрутки 
            this.Invalidate();//перерисовываем изображение
        }

        private void menuItemImageInfo_Click(object sender, EventArgs e)//функция вывода информации о изображении
        {
            menuItemImageInfo.Enabled = true;
            ImageInfo imgInfo = new ImageInfo(imageHandler);
            imgInfo.Show();
        }

        private void menuItemZoom50_Click(object sender, EventArgs e)
        {
            cZoom.Checked = false;
            menuItemZoom50.Checked = true;
            cZoom = menuItemZoom50;
            imageHandler.BiInterp((int)(imageHandler.TrueWidth * 0.5), (int) (imageHandler.TrueHeight * 0.5));
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height ));
            this.Invalidate();
        }
        private void menuItemZoom100_Click(object sender, EventArgs e)
        {
            cZoom.Checked = false;
            menuItemZoom100.Checked = true;
            cZoom = menuItemZoom100;
            imageHandler.BiInterp(imageHandler.TrueWidth , imageHandler.TrueHeight );
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height ));
            this.Invalidate();
        }
        private void menuItemZoom150_Click(object sender, EventArgs e)
        {
            cZoom.Checked = false;
            menuItemZoom150.Checked = true;
            cZoom = menuItemZoom150;
            imageHandler.BiInterp((int)(imageHandler.TrueWidth * 1.5), (int)(imageHandler.TrueHeight * 1.5));
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width), Convert.ToInt32(imageHandler.Height));
            this.Invalidate();
        }
        private void menuItemZoom200_Click(object sender, EventArgs e)
        {
            cZoom.Checked = false;
            menuItemZoom200.Checked = true;
            cZoom = menuItemZoom200;
            imageHandler.BiInterp(imageHandler.TrueWidth * 2, imageHandler.TrueHeight * 2);
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height ));
            this.Invalidate();

        }
        private void menuItemZoom300_Click(object sender, EventArgs e)
        {
            cZoom.Checked = false;
            menuItemZoom300.Checked = true;
            cZoom = menuItemZoom300;
            imageHandler.BiInterp(imageHandler.TrueWidth * 3, imageHandler.TrueHeight*3);
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height ));

            this.Invalidate();

        }
        private void menuItemZoom400_Click(object sender, EventArgs e)
        {
            cZoom.Checked = false;
            menuItemZoom400.Checked = true;
            cZoom = menuItemZoom400;
            imageHandler.BiInterp(imageHandler.TrueWidth * 4, imageHandler.TrueHeight * 4);
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height ));
            this.Invalidate();
        }
        private void menuItemZoom500_Click(object sender, EventArgs e)
        {
            cZoom.Checked = false;
            menuItemZoom500.Checked = true;
            cZoom = menuItemZoom500;
            imageHandler.BiInterp(imageHandler.TrueWidth * 5, imageHandler.TrueHeight * 5);
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height ));
            this.Invalidate();
        }
        private void menuItemFlipH_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipX);//Задает отсутствие поворота по часовой стрелке с последующим зеркальным отражением по горизонтали
            this.Invalidate();
        }
        private void menuItemFlipV_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipY);//Задает отсутствие поворота по часовой стрелке с последующим зеркальным отражением по вертикали
            this.Invalidate();
        }
        private void pictureBox1_KeyDown(object sender, KeyEventArgs e)//функция вызывается при перемещении выделенной области
        {
            if (e.KeyCode == Keys.Right)
            {
                pictureBox1.Location = new System.Drawing.Point(cropX + 10, cropY);//перемещает pictureBox1 по X на 10 вправо
                cropX = cropX + 10;
            }
            if (e.KeyCode == Keys.Left)
            {
                pictureBox1.Location = new System.Drawing.Point(cropX - 10, cropY);//перемещает pictureBox1 по X на 10 влево
                cropX = cropX - 10;
            }
            if (e.KeyCode == Keys.Up)
            {
                pictureBox1.Location = new System.Drawing.Point(cropX, cropY - 10);//перемещает pictureBox1 по Y на 10 вниз
                cropY = cropY - 10;
            }
            if (e.KeyCode == Keys.Down)
            {
                pictureBox1.Location = new System.Drawing.Point(cropX, cropY + 10);//перемещает pictureBox1 по Y на 10 вверх
                cropY = cropY + 10;
            }

        }
        private void menuItemCrop_Click(object sender, EventArgs e)//функция вызывается при выделении области
        {
            bool flag = false;//объявления флага на случай выхода области выделения за приделы изображения
            CropForm cpFrm = new CropForm();//создаем форму для определения параметров выделения
            do
            {
                  flag = false;
                  cpFrm.CropXPosition = 0;
                  cpFrm.CropYPosition = 0;
                  cpFrm.CropWidth = imageHandler.Width;//отображаем на форме выделения ширину
                  cpFrm.CropHeight = imageHandler.Height;//и высоту изображения для удобства определения параметров
                  if (cpFrm.ShowDialog() == DialogResult.OK)
                  {
                       Rectangle rec = new Rectangle(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth, cpFrm.CropHeight);//создаем прямоугольник с саданными параметрами выделения
                       this.Cursor = Cursors.WaitCursor;//курсор в режиме ожидания
                       imageHandler.RestorePrevious();//точка сохранения для возврата
                       imageHandler.DrawOutCropArea(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth, cpFrm.CropHeight);//вызов функции выделения выбранной области
                       this.Invalidate();
                       if (MessageBox.Show("Выделить выбранную область?", "ImageProcessing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                       {
                            try
                            {        
                                cropX = cpFrm.CropXPosition; cropY = cpFrm.CropYPosition; widthImgCrop = cpFrm.CropWidth; heightImgCrop = cpFrm.CropHeight;
                                temp = (Bitmap)imageHandler.GetBitmap();
                                Bitmap bmap = (Bitmap)temp.Clone();// копия картинки
                                Graphics gr = Graphics.FromImage(bmap);//создает объект Graphics из картинки
                                RectangleF cloneRect = new RectangleF(cropX, cropY, widthImgCrop, heightImgCrop);// прямоугольник соотв выделеной области
                                System.Drawing.Imaging.PixelFormat format = bmap.PixelFormat;// 
                                cloneBitmap = bmap.Clone(cloneRect, format);// вырезка куска из картинке по выделеной области cloneRect
                                pictureBox1.Location = new System.Drawing.Point(cropX, cropY);// устанавливаем pictureBox для вывода картинок в коордиаты Х У т. е. на месте где и была выделена область 
                                pictureBox1.Image = cloneBitmap;// помещаем картинку
                                pictureBox1.Size = new System.Drawing.Size(Convert.ToInt32(widthImgCrop ), Convert.ToInt32(heightImgCrop));//размеры штуки для вывода
                                pictureBox1.Visible = true;//pictureBox1 с выделенным изображением становится видимой
                                imageHandler.RemoveCropAreaDraw();
                                this.saveImgImg.Enabled = true;

                                this.deleteCrop.Enabled = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this,"Выделена область вне картинки!", "Внимание", MessageBoxButtons.OK);
                                flag=true;
                            }  
                      }
                      else
                      {
                          imageHandler.RemoveCropAreaDraw();//отмена выделения выбранной области
                     
                      }
                      this.AutoScroll = true;
                      this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height));
                               
                      this.Invalidate();
                      this.Cursor = Cursors.Default;
                      imageHandler.RemoveCropAreaDraw();
                       this.Invalidate();
                  }
            } 
            while(flag==true);

            this.Invalidate();
            this.Cursor = Cursors.Default; 
        }
   
        private void saveImg_Click(object sender, EventArgs e)//сохранение изображения без выделенной области
        {
            if (DialogResult.OK == sDlg1.ShowDialog())
            {
                imageHandler.SaveBitmap(sDlg1.FileName);
            }
        }
        private void saveImgImg_Click(object sender, EventArgs e)
        {
            {
                if (DialogResult.OK == sDlg2.ShowDialog())
                {
                      imageHandler.PasteTogether(cloneBitmap, cropX, cropY).Save(sDlg2.FileName);//сохраняю изображение
                }
            }
        }
        private void deleteCrop_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;//pictureBox1 делаем невидимым
            saveImgImg.Enabled = false;
            deleteCrop.Enabled = false;
        }
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}