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
        OpenFileDialog oDlg;//���������� ���� ����������� ���� �������� �����
        SaveFileDialog sDlg1;//���������� ���� ����������� ���� ���������� �����
        SaveFileDialog sDlg2;//���������� ���� ����������� ���� ���������� �����
        private MenuItem cZoom;//���������� ��� ���� ���������� �����������
        Bitmap temp;//���������� ��� �������� ���������� �����������
        Bitmap cloneBitmap;//���������� ��� �������� ���������� �������
        int cropX = 0, cropY = 0, widthImgCrop = 100, heightImgCrop = 100;//���������� ��� �������� ��������� ����������� �����������, ������ � ������
        ImageHandler imageHandler = new ImageHandler();//�������� ���������� ������ imageHandler
        public ImageProcessing()
        {
            InitializeComponent();

            oDlg = new OpenFileDialog();//�������� ����������� ���� ��� �������� �����
            oDlg.RestoreDirectory = true;
            oDlg.InitialDirectory = "C:\\";
            oDlg.FilterIndex = 1;
            oDlg.Filter = "jpg Files (*.jpg)|*.jpg";
            /*************************/
            sDlg1 = new SaveFileDialog();//�������� ����������� ���� ��� ���������� �����
            sDlg1.RestoreDirectory = true;
            sDlg1.InitialDirectory = "C:\\";
            sDlg1.FilterIndex = 1;
            sDlg1.Filter = "bmp Files (*.bmp)|*.bmp";
            /*************************/
            sDlg2 = new SaveFileDialog();//�������� ����������� ���� ��� ���������� ����� � ���������� ������������
            sDlg2.RestoreDirectory = true;
            sDlg2.InitialDirectory = "C:\\";
            sDlg2.FilterIndex = 1;
            sDlg2.Filter = "bmp Files (*.bmp)|*.bmp";

            cZoom = menuItemZoom50;
        }

        private void ImageProcessing_Paint(object sender, PaintEventArgs e)//������� ������� ����������� �� �����
        {
            if(imageHandler.IsPicture)
            {
                e.Graphics.DrawImage(imageHandler.GetBitmap(), new Rectangle(this.AutoScrollPosition.X, this.AutoScrollPosition.Y,Convert.ToInt32(imageHandler.Width),Convert.ToInt32(imageHandler.Height)));
            }
        }

        private void menuItemOpen_Click(object sender, EventArgs e)//������� ����������� ��������� ��������� ����������� � ������� ������
        {
            if (DialogResult.OK == oDlg.ShowDialog())
            {
                imageHandler.SetBitmap((Bitmap)Bitmap.FromFile(oDlg.FileName));
                imageHandler.BitmapPath = oDlg.FileName;
                this.AutoScroll = true;
                this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height));
                this.Invalidate();
                menuItemImageInfo_Click(0,e);//����� ���������� � �����������
            }
        }

        private void menuItemUndo_Click(object sender, EventArgs e)//������� ������ ��������
        {
            imageHandler.ResetBitmap();
            this.AutoScrollMinSize = new Size(Convert.ToInt32(imageHandler.Width ), Convert.ToInt32(imageHandler.Height ));
            //������������� ����������� ������� ��� ��������� 
            this.Invalidate();//�������������� �����������
        }

        private void menuItemImageInfo_Click(object sender, EventArgs e)//������� ������ ���������� � �����������
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
            imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipX);//������ ���������� �������� �� ������� ������� � ����������� ���������� ���������� �� �����������
            this.Invalidate();
        }
        private void menuItemFlipV_Click(object sender, EventArgs e)
        {
            imageHandler.RotateFlip(RotateFlipType.RotateNoneFlipY);//������ ���������� �������� �� ������� ������� � ����������� ���������� ���������� �� ���������
            this.Invalidate();
        }
        private void pictureBox1_KeyDown(object sender, KeyEventArgs e)//������� ���������� ��� ����������� ���������� �������
        {
            if (e.KeyCode == Keys.Right)
            {
                pictureBox1.Location = new System.Drawing.Point(cropX + 10, cropY);//���������� pictureBox1 �� X �� 10 ������
                cropX = cropX + 10;
            }
            if (e.KeyCode == Keys.Left)
            {
                pictureBox1.Location = new System.Drawing.Point(cropX - 10, cropY);//���������� pictureBox1 �� X �� 10 �����
                cropX = cropX - 10;
            }
            if (e.KeyCode == Keys.Up)
            {
                pictureBox1.Location = new System.Drawing.Point(cropX, cropY - 10);//���������� pictureBox1 �� Y �� 10 ����
                cropY = cropY - 10;
            }
            if (e.KeyCode == Keys.Down)
            {
                pictureBox1.Location = new System.Drawing.Point(cropX, cropY + 10);//���������� pictureBox1 �� Y �� 10 �����
                cropY = cropY + 10;
            }

        }
        private void menuItemCrop_Click(object sender, EventArgs e)//������� ���������� ��� ��������� �������
        {
            bool flag = false;//���������� ����� �� ������ ������ ������� ��������� �� ������� �����������
            CropForm cpFrm = new CropForm();//������� ����� ��� ����������� ���������� ���������
            do
            {
                  flag = false;
                  cpFrm.CropXPosition = 0;
                  cpFrm.CropYPosition = 0;
                  cpFrm.CropWidth = imageHandler.Width;//���������� �� ����� ��������� ������
                  cpFrm.CropHeight = imageHandler.Height;//� ������ ����������� ��� �������� ����������� ����������
                  if (cpFrm.ShowDialog() == DialogResult.OK)
                  {
                       Rectangle rec = new Rectangle(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth, cpFrm.CropHeight);//������� ������������� � ��������� ����������� ���������
                       this.Cursor = Cursors.WaitCursor;//������ � ������ ��������
                       imageHandler.RestorePrevious();//����� ���������� ��� ��������
                       imageHandler.DrawOutCropArea(cpFrm.CropXPosition, cpFrm.CropYPosition, cpFrm.CropWidth, cpFrm.CropHeight);//����� ������� ��������� ��������� �������
                       this.Invalidate();
                       if (MessageBox.Show("�������� ��������� �������?", "ImageProcessing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                       {
                            try
                            {        
                                cropX = cpFrm.CropXPosition; cropY = cpFrm.CropYPosition; widthImgCrop = cpFrm.CropWidth; heightImgCrop = cpFrm.CropHeight;
                                temp = (Bitmap)imageHandler.GetBitmap();
                                Bitmap bmap = (Bitmap)temp.Clone();// ����� ��������
                                Graphics gr = Graphics.FromImage(bmap);//������� ������ Graphics �� ��������
                                RectangleF cloneRect = new RectangleF(cropX, cropY, widthImgCrop, heightImgCrop);// ������������� ����� ��������� �������
                                System.Drawing.Imaging.PixelFormat format = bmap.PixelFormat;// 
                                cloneBitmap = bmap.Clone(cloneRect, format);// ������� ����� �� �������� �� ��������� ������� cloneRect
                                pictureBox1.Location = new System.Drawing.Point(cropX, cropY);// ������������� pictureBox ��� ������ �������� � ��������� � � �. �. �� ����� ��� � ���� �������� ������� 
                                pictureBox1.Image = cloneBitmap;// �������� ��������
                                pictureBox1.Size = new System.Drawing.Size(Convert.ToInt32(widthImgCrop ), Convert.ToInt32(heightImgCrop));//������� ����� ��� ������
                                pictureBox1.Visible = true;//pictureBox1 � ���������� ������������ ���������� �������
                                imageHandler.RemoveCropAreaDraw();
                                this.saveImgImg.Enabled = true;

                                this.deleteCrop.Enabled = true;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(this,"�������� ������� ��� ��������!", "��������", MessageBoxButtons.OK);
                                flag=true;
                            }  
                      }
                      else
                      {
                          imageHandler.RemoveCropAreaDraw();//������ ��������� ��������� �������
                     
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
   
        private void saveImg_Click(object sender, EventArgs e)//���������� ����������� ��� ���������� �������
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
                      imageHandler.PasteTogether(cloneBitmap, cropX, cropY).Save(sDlg2.FileName);//�������� �����������
                }
            }
        }
        private void deleteCrop_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;//pictureBox1 ������ ���������
            saveImgImg.Enabled = false;
            deleteCrop.Enabled = false;
        }
        private void menuItemExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
}