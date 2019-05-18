using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarnsleyFern
{

    public partial class ColourPicker : Form
    {
        Bitmap bmp;//, shadeBitmap;
        int maxDist;

        const double downscaler = 2;

        public ColourPicker()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            //shadeBitmap = new Bitmap(this.Width, this.Height);

            maxDist = 900;
            double shifter = maxDist * 0.25;
            int ycomensate = 0;

            Point center = new Point(panel1.Width / 2, panel1.Height / 2);
            Point G = new Point(center.X, center.Y - (int)shifter - ycomensate);
            Point R = new Point(center.X - (int)shifter, center.Y + (int)shifter - ycomensate);
            Point B = new Point(center.X + (int)shifter, center.Y + (int)shifter - ycomensate);

            int bmpW = panel1.Width;
            int bmpH = panel1.Height;

            bmp = new Bitmap(bmpW, bmpH, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            for (int x = 0; x < bmpW; ++x)
            {
                for (int y = 0; y < bmpH; ++y)
                {
                    bmp.SetPixel(x, y, Color.FromArgb(SetVal(x, y, R.X, R.Y), SetVal(x, y, G.X, G.Y), SetVal(x, y, B.X, B.Y)));
                }
            }

            this.Size = new Size((int)(this.Width / downscaler), (int)(this.Height / downscaler));
            bmp = new Bitmap(bmp, panel1.Width, panel1.Height);
        }

        int SetVal(int x, int y, int px, int py)
        {
            int v = 255;

            double dist = ((x - px) * (x - px) + (y - py) * (y - py));
            if (dist < (maxDist * maxDist))
            {
                v -= (int)Math.Sqrt(dist);
                if (v<0)
                {
                    v = ~v + 1; //Fast, bitwise conversion of negative to positive.
                }
                if (v > 255)
                {
                    v = 255;
                }
            }
            return (int)v;
        }

        private void panel1_MouseMove_1(object sender, MouseEventArgs e)
        {
            try
            {
                this.BackColor = bmp.GetPixel(e.X, e.Y);
                //SetBorderColour();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        /*
        void SetBorderColour()
        {
            shadeBitmap.Dispose();
            shadeBitmap = new Bitmap(this.Width, this.Height);

            Color c = bmp.GetPixel(e.X, e.Y);

            for (int x = 0; x < this.Width; ++x)
            {
                for (int y = 0; y < this.Height; ++y)
                {
                    shadeBitmap.SetPixel(x, y, c);
                }
            }

            this.BackgroundImage = shadeBitmap;
        }
        */

        private void panel1_MouseClick_1(object sender, MouseEventArgs e)
        { 
            SetColourAndHide(e);
        }

        void SetColourAndHide(MouseEventArgs e)
        {
            try
            {
                Form1.colour = bmp.GetPixel(e.X, e.Y);
                this.Hide();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void ColourPicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            bmp.Dispose();
        }
    }
}
