using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace WhoIsDemo.view.tool
{
    public class Transform
    {
        #region variables                
        private static readonly Transform instance = new Transform();
        public static Transform Instance => instance;
        #endregion

        #region methods
        public Transform() { }

        public Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;
            byte[] byteBuffer;
            MemoryStream memoryStream;
            try
            {
                byteBuffer = Convert.FromBase64String(base64String);
                memoryStream = new MemoryStream(byteBuffer);


                memoryStream.Position = 0;


                bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

                memoryStream.Close();

            }
            catch (System.InvalidOperationException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (System.AccessViolationException ex)
            {
                Console.WriteLine("Error Access Violation. " + ex.Message);
            }
            catch (System.ArgumentException ax)
            {
                Console.WriteLine("Error Access Violation. " + ax.Message);
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine("Error Format. " + ex.Message);
            }
            finally
            {
                memoryStream = null;
                byteBuffer = null;
            }

            return bmpReturn;
        }

        public Bitmap ResizeBitmap(Bitmap bmp)
        {
            int width = (int)(bmp.Width * 0.5);
            int height = (int)(bmp.Height * 0.5);
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }

        public Bitmap AdjustAlpha(Bitmap image, float translucency)
        {

            float t = translucency;
            ColorMatrix cm = new ColorMatrix(new float[][]
                {
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, t, 0},
                    new float[] {0, 0, 0, 0, 1},
                });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(cm);

            Point[] points =
            {
                new Point(0, 0),
                new Point(image.Width, 0),
                new Point(0, image.Height),
            };
            Rectangle rect =
                new Rectangle(0, 0, image.Width, image.Height);


            Bitmap bm = new Bitmap(image.Width, image.Height);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                gr.DrawImage(image, points, rect,
                    GraphicsUnit.Pixel, attributes);
            }

            return bm;
        }

        #endregion
    }
}
