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
        private string _bitmapPath;//переменная для хранения адресса для сохр изображения
        public Bitmap _currentBitmap = null;//текущее изображение
        int[][] colorOfPixel; // матрица для хранения значений пикселей текущего (обрабатываемого) изображения
        int[][] beforeProcessing; // матрица для хранения значений пикселей изображения перед изменением
        int trueWidth; // начальная длинна изображения 
        int trueHeight;//  начальная высота изображения 
        bool isPicture = false;// наличие обрабатываемой картинки

       public bool IsPicture//проверка на наличие обрабатываемой картинки в классе
       {
           get { return isPicture; }
       }

       public int Width//получение ширины текущего изображения
       {
           get { return colorOfPixel.Length; }
       }

       public int Height//получение высоту текущего изображения
       {
           get { return colorOfPixel[0].Length; }
       }

       public int TrueWidth//получение ширины начального изображения
       {
           get { return trueWidth; }
       }

       public int TrueHeight//получение высоты начального изображения
       {
           get { return trueHeight; }
       }
       public Bitmap GetBitmap()//получение текущего изображения
       {
           return _currentBitmap;
       }

       public string BitmapPath//получение пути к изображению
       {
           get { return _bitmapPath; }
           set { _bitmapPath = value; }
       }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//РАБОТА С ПОЛУЧЕНИЕМ ИЗ ИЗОБРАЖЕНИЯ МАТРИЦЫ ПИКСЕЛЕЙ И ПОЛУЧЕНИЯ ИЗОБРАЖЕНИЯ ИЗ МАТРИЦЫ ПИКСЕЛЕЙ
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
       public void SetBitmap(Bitmap bitmap)//задание обрабатываемого изображения
       {
           isPicture = true;
           trueWidth = bitmap.Width;
           trueHeight =   bitmap.Height;
           colorOfPixel = MakeMatrixs(bitmap);
           beforeProcessing = (int[][])colorOfPixel.Clone() ;
           CreateBitmap();
       }

       void CreateBitmap()//замена текущего изображения на полученной из массива пикселей colorOfPixel
       {
           _currentBitmap = MakeBitmap(colorOfPixel, colorOfPixel.Length, colorOfPixel[0].Length);
       }

       int[][] MakeMatrixs(Bitmap bitmap)//получение матрицы пикселей из картинки
       {
           int height = bitmap.Height;
           int width = bitmap.Width;
           int[][] colorOfPixel = new int[width][];//выделение места под матрицу
           for (int i = 0; i < width; i++)
           {
               colorOfPixel[i] = new int[height];//выделение места под матрицу
           }

           for (int i = 0; i < height; i++)
           {
               for (int j = 0; j < width; j++)
               {
                   colorOfPixel[j][i] = bitmap.GetPixel(j, i).ToArgb();//копирование пикселей
               }

           }
           return colorOfPixel;//возврат матрицы
       }

       public Bitmap MakeBitmap(int[][] matrix, int width, int height)//функция собирает изображение из массива пикселей
       {
           Bitmap bm = new Bitmap(width, height);//оздание изображения с нужным размером
           for (int i = 0; i < height; i++)
           {
               for (int j = 0; j < width; j++)
               {
                   bm.SetPixel(j, i, Color.FromArgb(matrix[j][i]));//заполнение изображения
               }
           }
           return bm;
       }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//ОТОБРАЖЕНИЕ ИЗОБРАЖЕНИЯ
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void RotateFlip(RotateFlipType rotateFlipType)//функция зеркального отображения изображения
        {
            beforeProcessing = colorOfPixel;
            int[][] arry = new int[colorOfPixel.Length][];//выделение места под матрицу
            for (int i = 0; i < colorOfPixel.Length; i++)
            {
                arry[i] = new int[colorOfPixel[0].Length];//выделение места под матрицу
            }

            if (rotateFlipType == RotateFlipType.RotateNoneFlipX)
            {
                for (int i = 0; i < colorOfPixel[0].Length; i++)
                {
                    for (int j = 0; j < colorOfPixel.Length; j++)
                    {
                        arry[colorOfPixel.Length - j - 1][i] = colorOfPixel[j][i]; //перемещение по оси Х
                    }

                }
            }

            if (rotateFlipType == RotateFlipType.RotateNoneFlipY)
            {
                for (int i = 0; i < colorOfPixel[0].Length; i++)
                {
                    for (int j = 0; j < colorOfPixel.Length; j++)
                    {
                        arry[j][colorOfPixel[0].Length - i - 1] = colorOfPixel[j][i]; //перемещение по оси У
                    }

                }
            }
            colorOfPixel = null; 
            colorOfPixel = arry;
            arry = null;
            CreateBitmap();
        }
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//ВЫДЕЛЕНИЕ ОБЛАСТИ
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void DrawOutCropArea(int xPosition, int yPosition, int width, int height)//выделения выбранной области
        {
            Bitmap bmap = _currentBitmap;//копируем текущую картинку
            Graphics gr = Graphics.FromImage(bmap);//Graphics из рисунка
            Brush cBrush = new Pen(Color.FromArgb(150, Color.White)).Brush;//кисть для закраски изображения
            Rectangle rect1 = new Rectangle(0, 0, _currentBitmap.Width, yPosition);//выделяю 
            Rectangle rect2 = new Rectangle(0, yPosition, xPosition, height);//четыре
            Rectangle rect3 = new Rectangle(0, (yPosition + height), _currentBitmap.Width, _currentBitmap.Height);//прямоугольника без
            Rectangle rect4 = new Rectangle((xPosition + width), yPosition, (_currentBitmap.Width - xPosition - width), height);//выделенной области
            gr.FillRectangle(cBrush, rect1);//закрашиваем 
            gr.FillRectangle(cBrush, rect2);//эти
            gr.FillRectangle(cBrush, rect3);//прямоугольники
            gr.FillRectangle(cBrush, rect4);//в более светлый оттенок
        }

        public Bitmap PasteTogether(Bitmap bmp, int x, int y)// склеивание изображения с текущим У и Х - координаты положения 
        //склеиваемого изображения относительно точки (0,0) текущего
        {
            int maxX = colorOfPixel.Length, maxY = colorOfPixel[0].Length;
            int[][] matrixBmp = MakeMatrixs(bmp);
            int[][] newMatrixs;
            if (maxX < x + bmp.Width)//определение длинны новой картинки
            {
                maxX = x + bmp.Width;
            }

            if (maxY < y + bmp.Height)//опред. высоты новой картинки
            {
                maxY = y + bmp.Height;
            }
            newMatrixs = new int[maxX][];//выделение места под массив новой картинки
            for (int i = 0; i < maxX; i++)//выделение места под массив новой картинки
            {
                newMatrixs[i] = new int[maxY];
            }

            for (int i = 0; i < colorOfPixel[0].Length; i++)
            {
                for (int j = 0; j < colorOfPixel.Length; j++)
                {
                    newMatrixs[j][i] = colorOfPixel[j][i];//копирование текущей картинки в новую
                }

            }

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    newMatrixs[j + x][i + y] = colorOfPixel[j][i];//наложение склеиваемой картинки
                }

            }

            return MakeBitmap(newMatrixs, maxX, maxY);//получение изобржения по масиву пикселей
        }

        public void RemoveCropAreaDraw()//отмена выделения выбранной области
        {
            CreateBitmap();//замена текущего изображения на сделанное по хранящейся матрице
        }

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
//БИ-ЛИНЕЙНАЯ ИНТЕРПОЛЯЦИЯ
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void BiInterp(int newX, int newY) //увеличение | уменьшение картинки newX - новая длинна, newY - новая высота
        {
            colorOfPixel = Resample(colorOfPixel, colorOfPixel.Length, colorOfPixel[0].Length, newX, newY);
            CreateBitmap();
        }
        int[][] Resample(int [][] colorOfPixel,int width, int height, int newX, int newY)//билинейная интерполяция
        {
            int i, j;
            int topPix, leftPix;//адреса пикселей в исходной картинке
            float distanceW, distanceH;
            float tmp;
            float d1, d2, d3, d4;//коэфициенты
            int pix1, pix2, pix3, pix4;//окрестные пикселы */
            int p1Col, p2Col, p3Col, p4Col;//для отбора составляющего цвета
            int red, green, blue;//составляющие цвета
            int[][] newMatrix = new int[newX][];//сождание матрицы нужного размера
            for ( i = 0; i < newX; i++)
            {
                newMatrix[i] = new int[newY];
            }

            for (j = 0; j < newY; j++)//отбираем координату у - целевую 
            {
                tmp = (float)(j) / (newY - 1) * (height - 1);//адрес искомого пикселя в первоначальной картинке
                topPix = (int)Math.Floor(tmp);//округление вниз, т.е. возятие адрес верхнего пикселя
	            if (topPix < 0) 
                {
                    topPix = 0;//если < 0 (незнаю как это) то =0
	            }        
                else 
                {
		            if (topPix >= height - 1) 
                    {
                        topPix = height - 2;//если больше высоты, то предпоследний пиксель
		            }   
	            }
                distanceH = tmp - topPix;//разница в расположении пикселей 

                for (i = 0; i < newX; i++)//тожесамое по Х 
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
 
	                /* Коэффициенты */
	                d1 = (1 - distanceW) * (1 - distanceH);
	                d2 = distanceW * (1 - distanceH);
	                d3 = distanceW * distanceH;
	                d4 = (1 - distanceW) * distanceH;
 
	                /* Окрестные пиксели: a[i][j] */
                    pix1 = colorOfPixel[leftPix][topPix];  // левый вкрхний 
                    pix2 = colorOfPixel[leftPix + 1][topPix]; // правый верхний
                    pix3 = colorOfPixel[leftPix + 1][topPix + 1]; // правый нижний
                    pix4 = colorOfPixel[leftPix][topPix + 1]; // левый нижний

                    p1Col = pix1 & 255; // отбираем значение blue
                    p2Col = pix2 & 255;
                    p3Col = pix3 & 255;
                    p4Col = pix4 & 255;
                    blue = (byte)(p1Col * d1 + p2Col * d2 + p3Col * d3 + p4Col * d4);

                    p1Col = pix1 & 65280; /* отбираем значение green*/ p1Col >>= 8;// сдвигаем в начало переменной
                    p2Col = pix2 & 65280; p2Col >>= 8;
                    p3Col = pix3 & 65280; p3Col >>= 8;
                    p4Col = pix4 & 65280; p4Col >>= 8;
                    green = (byte)(p1Col * d1 + p2Col * d2 + p3Col * d3 + p4Col * d4);

                    p1Col = pix1 & 16711680; /* отбираем значение  red */ p1Col >>= 16; // сдвигаем в начало переменной
                    p2Col = pix2 & 16711680; p2Col >>= 16;
                    p3Col = pix3 & 16711680; p3Col >>= 16;
                    p4Col = pix4 & 16711680; p4Col >>= 16;
                    red = (byte)(p1Col * d1 + p2Col * d2 + p3Col * d3 + p4Col * d4);

                    newMatrix[i][j] = (255 << 24) | (red << 16) | (green << 8) | blue;// составление цвета 255 - значение альфа канала
      
	            }
            }
            return newMatrix;
        }
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// 
//РАБОТА С ВОЗВРАТОМ НА ШАГ НАЗАД
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public void ResetBitmap()//Возврат на шаг назад
        {
            if (beforeProcessing != null && colorOfPixel != null)//если текущее изображение не равно нулю и изображение до выполнения процесса не равно нулю
            {
                int[][] arry = colorOfPixel;
                colorOfPixel = beforeProcessing;
                beforeProcessing = arry;
                CreateBitmap();
                arry = null;
            }
        }

        public void SaveBitmap(string saveFilePath)//функция сохранения изображения
        {
            _bitmapPath = saveFilePath;
            if (System.IO.File.Exists(saveFilePath))
                System.IO.File.Delete(saveFilePath);
            GetBitmap().Save(saveFilePath);
        }

        public void RestorePrevious()//функция сохранения изображения до выполнения выделения области
        {
            beforeProcessing = (int[][])colorOfPixel.Clone();//изображения до выполнения выделения=текущему изображения
        } 

    }
}

