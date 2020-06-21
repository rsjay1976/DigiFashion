using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TailoringApp
{
    public partial class Form1 : Form
    {
        private Bitmap bitmap;
       
        public Form1()
        {
            InitializeComponent();
            this.bitmap = new Bitmap(2000,2000);
            this.pictureBox1.Image = this.bitmap;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black, 0);
            Graphics gr;

            if (this.bitmap != null)
            {
                this.bitmap.Dispose();
            }
            this.bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            using ( gr = Graphics.FromImage(bitmap))
            {
                GraphicsUnit originalunit = gr.PageUnit;
                gr.PageUnit = GraphicsUnit.Inch ;
                gr.ResetTransform();               
                gr.ScaleTransform(1.0F, -1.0F );
                gr.TranslateTransform(0.0F, -(float)Height);
                gr.Clear(Color.White);
                float x = 0;
                float y = 6f;
                double Seam = 1.5;
                double back_dart = 0.75;


                float waist = (float)Convert.ToDouble(textBox1.Text);
                waist = (waist / 2) + (float)Seam + (float)back_dart;
                //  gr.DrawString("x1 : " + x , this.Font, Brushes.Black, 1, 0);
                //  gr.DrawString("y1 : " + y, this.Font, Brushes.Black, 1, 1);
                gr.DrawString("Height : " + Height , this.Font, Brushes.Black, 1, 1);
                gr.DrawString("gr.DpiX : " + gr.DpiX, this.Font, Brushes.Black, 1, 4);
                PointF start1 = new PointF(x, y);
                PointF end1 = new PointF((x + waist ) , y);
                DrawGraphicsUnitPixelUnit(gr, Color.Black, start1, end1);



                float back_side_len = (float)Convert.ToDouble(textBox2.Text);
                float back_chest_width = (float)Convert.ToDouble(textBox3.Text);
                back_chest_width = (back_chest_width / 2) + (float)Seam;
                float diff = back_chest_width - waist;
                x = end1.X;
                y = end1.Y;                              
                back_side_len = back_side_len + y;  
                PointF start2 = new PointF(x, y);
                PointF end2 = new PointF((x + diff)  , 3 );
                DrawGraphicsUnitPixelUnit(gr, Color.Black, new PointF(8.25f, 6f), new PointF(8.25f , -1f));
                // DrawGraphicsUnitPixelUnit(gr, Color.Black, start2, end2);             
                //gr.DrawString("x2 : " + x, this.Font, Brushes.Black, 1, 6);
                //gr.DrawString("y2 : " + y, this.Font, Brushes.Black, 1, 9);
                //gr.DrawString("y - back_side_len : " + (y - back_side_len), this.Font, Brushes.Black, 1, 13);
                //gr.DrawString("y + back_side_len : " + (y + back_side_len), this.Font, Brushes.Black, 1, 16);
                //gr.DrawString("diff : " + diff, this.Font, Brushes.Black, 1, 19);


                // gr.DrawBezier(pen, 1,5, 1, 2, 5, 6, 5, 2);

            }
            this.pictureBox1.Image = this.bitmap;

            this.pictureBox1.Image.Save("D:\\Kavery\\BMP\\Pattupavadai.bmp");

        }

        private void DrawGraphicsUnitPixelUnit(Graphics g, Color color, PointF start, PointF end)
        {
             
             GraphicsUnit originalUnit = g.PageUnit;
             g.PageUnit = GraphicsUnit.Pixel;
             using (Pen pen = new Pen(color, 1))
             {
                 g.DrawLine(pen,
                     start.X * g.DpiX,
                     start.Y * g.DpiY,
                     end.X * g.DpiX,
                     end.Y * g.DpiY);
             }
              g.PageUnit = originalUnit;

            // throw new NotImplementedException();



             ///////////// *************************** ///////////////////////


            /* Pen pen = new Pen(Color.Black, 1);


             if (this.bitmap != null)
             {
                 this.bitmap.Dispose();
             }
             this.bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
             using (Graphics gr = Graphics.FromImage(bitmap))
             {

                 GraphicsUnit originalUnit = gr.PageUnit;
                 gr.PageUnit = GraphicsUnit.Pixel;

                 gr.Clear(Color.White);

                 float x = 1;
                 float y = 1;

                 float waist = (float)Convert.ToDouble(textBox1.Text);
                 waist = waist / 4;

                 PointF start = new PointF(x, y);
                 PointF end = new PointF((x + waist + 1) / 2, 1);
                 DrawGraphicsUnitPixelUnit(gr, Color.Black, start, end);


                 //gr.DrawLine(pen, 0, 200, 100, 200);
                 //gr.DrawLine(pen, 100, 200, 85, 185);
                 //gr.DrawLine(pen, 85, 185, 130, 100);
                 //gr.DrawLine(pen, 130, 100, 110, 100);

                 //gr.DrawArc(pen, 80, 20, 50, 80, 80, 140);
                 //gr.DrawLine(pen, 80, 40, 45, 45);
                 // gr.DrawArc(pen, 0, 0, 45, 120, 90, -130); 
                 //gr.DrawBezier

                 gr.PageUnit = originalUnit;

             }
             this.pictureBox1.Image = this.bitmap;


             ///////////////////////**********************************////////////////////// */

         

        }

        

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            //////////111111111111111111111111111111111111////////////
            // CorelDRAW.Application app = new CorelDRAW.Application();
            //// app.Visible = true;
            // app.CreateDocument();
            // app.ActiveDocument.Unit = CorelDRAW.cdrUnit.cdrInch;
            // app.ActiveLayer.CreateLineSegment(0, 0.25, 2.5, 0.25).Outline.Width = 0.001;
            // app.ActiveLayer.CreateLineSegment(2.5, 0.25, 3, 3).Outline.Width = 0.001;
            // app.ActiveLayer.CreateCurveSegment(3, 3, 2, 5, 1.75, 185, 0, 0.25).Outline.Width = 0.001;
            // app.ActiveLayer.CreateLineSegment(0.75, 5, 2, 5).Outline.Width = 0.001;
            // app.ActiveLayer.CreateCurveSegment(0.75, 5, 0, 2, 0, 200, 1.5, 0).Outline.Width = 0.001;
            // app.ActiveDocument.ExportBitmap(@"D:\\Kavery\\BMP\\Pattupavadai.bmp",
            //                     CorelDRAW.cdrFilter.cdrBMP,
            //                      CorelDRAW.cdrExportRange.cdrCurrentPage,
            //                     CorelDRAW.cdrImageType.cdrRGBColorImage ,
            //                     3000, 4000, 300, 300, CorelDRAW.cdrAntiAliasingType.cdrNoAntiAliasing,
            //                     true,
            //                     false,
            //                     true,
            //                     false,
            //                     CorelDRAW.cdrCompressionType.cdrCompressionNone,
            //                     null).Finish();
            // app.ActiveDocument.Close();
            // app.Quit();

            //////////111111111111111111111111111111111111////////////
            


            //////////222222222222222222222222222222222222////////////
            //Pen pen = new Pen(Color.Black, 1);
            //Point start;
            //Point end;
            //if (this.bitmap != null)
            //{
            //    this.bitmap.Dispose();
            //}
            //this.bitmap = new Bitmap(ClientSize.Width, ClientSize.Height);
            //using (Graphics gr = Graphics.FromImage(bitmap))
            //{
            //    GraphicsUnit originalUnit = gr.PageUnit;
            //    gr.PageUnit = GraphicsUnit.Pixel;
            //    gr.Clear(Color.White);
            //    //gr.DrawLine(pen, 0, 200, 100, 200);
            //    //gr.DrawLine(pen, 100, 200, 85, 185);
            //    //gr.DrawLine(pen, 85, 185, 130, 100);
            //    //gr.DrawLine(pen, 130, 100, 110, 100);
            //    //gr.DrawArc(pen, 80, 20, 50, 80, 80, 140);
            //    //gr.DrawLine(pen, 80, 40, 45, 45);
            //    //gr.DrawArc(pen, 0, 0, 45, 120, 90, -130);               

            //}
            //this.pictureBox1.Image = this.bitmap;
            ///////////2222222222222222222222222///////////////////




            //////////3333333333333333333333333333333333333////////////
            //gr.DrawLine(pen, 0, 200, 100, 200);
            //gr.DrawLine(pen, 100, 200, 85, 185);
            //gr.DrawLine(pen, 85, 185, 130, 100);
            //gr.DrawLine(pen, 130, 100, 110, 100);

            //gr.DrawArc(pen, 80, 20, 50, 80, 80, 140);
            //gr.DrawLine(pen, 80, 40, 45, 45);
            //gr.DrawArc(pen, 0, 0, 45, 120, 90, -130); 
            /////////////3333333333333333333333333//////////////////////



        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

       
    }
}
