using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace ImageProcessing
{
    public class ImageHandler
    {
        private string _bitmapPath;//���������� ��� �������� ������� ��� ���� �����������
        public Bitmap _currentBitmap = null;//������� �����������
        int[][] colorOfPixel; // ������� ��� �������� �������� �������� �������� (���������������) �����������
        int[][] beforeProcessing; // ������� ��� �������� �������� �������� ����������� ����� ����������
        int trueWidth; // ��������� ������ ����������� 
        int trueHeight;//  ��������� ������ ����������� 
        bool isPicture = false;// ������� �������������� ��������

       public bool IsPicture//�������� �� ������� �������������� �������� � ������
       {
           get { return isPicture; }
       }

       public int Width//��������� ������ �������� �����������
       {
           get { return colorOfPixel.Length; }
       }

       public int Height//��������� ������ �������� �����������
       {
           get { return colorOfPixel[0].Length; }
       }

       public int TrueWidth//��������� ������ ���������� �����������
       {
           get { return trueWidth; }
       }

       public int TrueHeight//��������� ������ ���������� �����������
       {
           get { return trueHeight; }
       }
       public Bitmap GetBitmap()//��������� �������� �����������
       {
           return _currentBitmap;
       }

       public string BitmapPath//��������� ���� � �����������
       {
           get { return _bitmapPath; }
           set { _bitmapPath = value; }
       }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//������ � ���������� �� ����������� ������� �������� � ��������� ����������� �� ������� ��������
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       public void SetBitmap(Bitmap bitmap)//������� ��������������� �����������
       {
           isPicture = true;
           trueWidth = bitmap.Width;
           trueHeight =   bitmap.Height;
           colorOfPixel = MakeMatrixs(bitmap);
           beforeProcessing = (int[][])colorOfPixel.Clone() ;
           CreateBitmap();
       }

       void CreateBitmap()//������ �������� ����������� �� ���������� �� ������� �������� colorOfPixel
       {
           _currentBitmap = MakeBitmap(colorOfPixel, colorOfPixel.Length, colorOfPixel[0].Length);
       }

       int[][] MakeMatrixs(Bitmap bitmap)//��������� ������� �������� �� ��������
       {
           int height = bitmap.Height;
           int width = bitmap.Width;
           int[][] colorOfPixel = new int[width][];//��������� ����� ��� �������
           for (int i = 0; i < width; i++)
           {
               colorOfPixel[i] = new int[height];//��������� ����� ��� �������
           }

           for (int i = 0; i < height; i++)
           {
               for (int j = 0; j < width; j++)
               {
                   colorOfPixel[j][i] = bitmap.GetPixel(j, i).ToArgb();//����������� ��������
               }

           }
           return colorOfPixel;//������� �������
       }

       public Bitmap MakeBitmap(int[][] matrix, int width, int height)//������� �������� ����������� �� ������� ��������
       {
           Bitmap bm = new Bitmap(width, height);//������� ����������� � ������ ��������
           for (int i = 0; i < height; i++)
           {
               for (int j = 0; j < width; j++)
               {
                   bm.SetPixel(j, i, Color.FromArgb(matrix[j][i]));//���������� �����������
               }
           }
           return bm;
       }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//����������� �����������
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void RotateFlip(RotateFlipType rotateFlipType)//������� ����������� ����������� �����������
        {
            beforeProcessing = colorOfPixel;
            int[][] arry = new int[colorOfPixel.Length][];//��������� ����� ��� �������
            for (int i = 0; i < colorOfPixel.Length; i++)
            {
                arry[i] = new int[colorOfPixel[0].Length];//��������� ����� ��� �������
            }

            if (rotateFlipType == RotateFlipType.RotateNoneFlipX)
            {
                for (int i = 0; i < colorOfPixel[0].Length; i++)
                {
                    for (int j = 0; j < colorOfPixel.Length; j++)
                    {
                        arry[colorOfPixel.Length - j - 1][i] = colorOfPixel[j][i]; //����������� �� ��� �
                    }

                }
            }

            if (rotateFlipType == RotateFlipType.RotateNoneFlipY)
            {
                for (int i = 0; i < colorOfPixel[0].Length; i++)
                {
                    for (int j = 0; j < colorOfPixel.Length; j++)
                    {
                        arry[j][colorOfPixel[0].Length - i - 1] = colorOfPixel[j][i]; //����������� �� ��� �
                    }

                }
            }
            colorOfPixel = null; 
            colorOfPixel = arry;
            arry = null;
            CreateBitmap();
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//��������� �������
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DrawOutCropArea(int xPosition, int yPosition, int width, int height)//��������� ��������� �������
        {
            Bitmap bmap = _currentBitmap;//�������� ������� ��������
            Graphics gr = Graphics.FromImage(bmap);//Graphics �� �������
            Brush cBrush = new Pen(Color.FromArgb(150, Color.White)).Brush;//����� ��� �������� �����������
            Rectangle rect1 = new Rectangle(0, 0, _currentBitmap.Width, yPosition);//������� 
            Rectangle rect2 = new Rectangle(0, yPosition, xPosition, height);//������
            Rectangle rect3 = new Rectangle(0, (yPosition + height), _currentBitmap.Width, _currentBitmap.Height);//�������������� ���
            Rectangle rect4 = new Rectangle((xPosition + width), yPosition, (_currentBitmap.Width - xPosition - width), height);//���������� �������
            gr.FillRectangle(cBrush, rect1);//����������� 
            gr.FillRectangle(cBrush, rect2);//���
            gr.FillRectangle(cBrush, rect3);//��������������
            gr.FillRectangle(cBrush, rect4);//� ����� ������� �������
        }

        public Bitmap PasteTogether(Bitmap bmp, int x, int y)// ���������� ����������� � ������� � � � - ���������� ��������� 
        //������������ ����������� ������������ ����� (0,0) ��������
        {
            int maxX = colorOfPixel.Length, maxY = colorOfPixel[0].Length;
            int[][] matrixBmp = MakeMatrixs(bmp);
            int[][] newMatrixs;
            if (maxX < x + bmp.Width)//����������� ������ ����� ��������
            {
                maxX = x + bmp.Width;
            }

            if (maxY < y + bmp.Height)//�����. ������ ����� ��������
            {
                maxY = y + bmp.Height;
            }
            newMatrixs = new int[maxX][];//��������� ����� ��� ������ ����� ��������
            for (int i = 0; i < maxX; i++)//��������� ����� ��� ������ ����� ��������
            {
                newMatrixs[i] = new int[maxY];
            }

            for (int i = 0; i < colorOfPixel[0].Length; i++)
            {
                for (int j = 0; j < colorOfPixel.Length; j++)
                {
                    newMatrixs[j][i] = colorOfPixel[j][i];//����������� ������� �������� � �����
                }

            }

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    newMatrixs[j + x][i + y] = colorOfPixel[j][i];//��������� ����������� ��������
                }

            }

            return MakeBitmap(newMatrixs, maxX, maxY);//��������� ���������� �� ������ ��������
        }

        public void RemoveCropAreaDraw()//������ ��������� ��������� �������
        {
            CreateBitmap();//������ �������� ����������� �� ��������� �� ���������� �������
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
//��-�������� ������������
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BiInterp(int newX, int newY) //���������� | ���������� �������� newX - ����� ������, newY - ����� ������
        {
            colorOfPixel = Resample(colorOfPixel, colorOfPixel.Length, colorOfPixel[0].Length, newX, newY);
            CreateBitmap();
        }
        int[][] Resample(int [][] colorOfPixel,int width, int height, int newX, int newY)//���������� ������������
        {
            int i, j;
            int topPix, leftPix;//������ �������� � �������� ��������
            float distanceW, distanceH;
            float tmp;
            float d1, d2, d3, d4;//�����������
            int pix1, pix2, pix3, pix4;//��������� ������� */
            int p1Col, p2Col, p3Col, p4Col;//��� ������ ������������� �����
            int red, green, blue;//������������ �����
            int[][] newMatrix = new int[newX][];//�������� ������� ������� �������
            for ( i = 0; i < newX; i++)
            {
                newMatrix[i] = new int[newY];
            }

            for (j = 0; j < newY; j++)//�������� ���������� � - ������� 
            {
                tmp = (float)(j) / (newY - 1) * (height - 1);//����� �������� ������� � �������������� ��������
                topPix = (int)Math.Floor(tmp);//���������� ����, �.�. ������� ����� �������� �������
	            if (topPix < 0) 
                {
                    topPix = 0;//���� < 0 (������ ��� ���) �� =0
	            }        
                else 
                {
		            if (topPix >= height - 1) 
                    {
                        topPix = height - 2;//���� ������ ������, �� ������������� �������
		            }   
	            }
                distanceH = tmp - topPix;//������� � ������������ �������� 

                for (i = 0; i < newX; i++)//��������� �� � 
                {
                    tmp = (float)(i) / (newX - 1) * (width - 1);
	                leftPix = (int) Math.Floor(tmp);
	                if (leftPix < 0) 
                    {
		                leftPix = 0;
	                } 
                    else 
                    {
                        if (leftPix >= width - 1)
                        {
                            leftPix = width - 2;
		                }
	                }
	                distanceW = tmp - leftPix;
 
	                /* ������������ */
	                d1 = (1 - distanceW) * (1 - distanceH);
	                d2 = distanceW * (1 - distanceH);
	                d3 = distanceW * distanceH;
	                d4 = (1 - distanceW) * distanceH;
 
	                /* ��������� �������: a[i][j] */
                    pix1 = colorOfPixel[leftPix][topPix];  // ����� ������� 
                    pix2 = colorOfPixel[leftPix + 1][topPix]; // ������ �������
                    pix3 = colorOfPixel[leftPix + 1][topPix + 1]; // ������ ������
                    pix4 = colorOfPixel[leftPix][topPix + 1]; // ����� ������

                    p1Col = pix1 & 255; // �������� �������� blue
                    p2Col = pix2 & 255;
                    p3Col = pix3 & 255;
                    p4Col = pix4 & 255;
                    blue = (byte)(p1Col * d1 + p2Col * d2 + p3Col * d3 + p4Col * d4);

                    p1Col = pix1 & 65280; /* �������� �������� green*/ p1Col >>= 8;// �������� � ������ ����������
                    p2Col = pix2 & 65280; p2Col >>= 8;
                    p3Col = pix3 & 65280; p3Col >>= 8;
                    p4Col = pix4 & 65280; p4Col >>= 8;
                    green = (byte)(p1Col * d1 + p2Col * d2 + p3Col * d3 + p4Col * d4);

                    p1Col = pix1 & 16711680; /* �������� ��������  red */ p1Col >>= 16; // �������� � ������ ����������
                    p2Col = pix2 & 16711680; p2Col >>= 16;
                    p3Col = pix3 & 16711680; p3Col >>= 16;
                    p4Col = pix4 & 16711680; p4Col >>= 16;
                    red = (byte)(p1Col * d1 + p2Col * d2 + p3Col * d3 + p4Col * d4);

                    newMatrix[i][j] = (255 << 24) | (red << 16) | (green << 8) | blue;// ����������� ����� 255 - �������� ����� ������
      
	            }
            }
            return newMatrix;
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
//������ � ��������� �� ��� �����
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ResetBitmap()//������� �� ��� �����
        {
            if (beforeProcessing != null && colorOfPixel != null)//���� ������� ����������� �� ����� ���� � ����������� �� ���������� �������� �� ����� ����
            {
                int[][] arry = colorOfPixel;
                colorOfPixel = beforeProcessing;
                beforeProcessing = arry;
                CreateBitmap();
                arry = null;
            }
        }

        public void SaveBitmap(string saveFilePath)//������� ���������� �����������
        {
            _bitmapPath = saveFilePath;
            if (System.IO.File.Exists(saveFilePath))
                System.IO.File.Delete(saveFilePath);
            GetBitmap().Save(saveFilePath);
        }

        public void RestorePrevious()//������� ���������� ����������� �� ���������� ��������� �������
        {
            beforeProcessing = (int[][])colorOfPixel.Clone();//����������� �� ���������� ���������=�������� �����������
        } 

    }
}

