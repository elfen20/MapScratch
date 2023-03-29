using Gma.System.MouseKeyHook;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MapScratch
{
    public partial class Main : Form
    {
        IKeyboardMouseEvents KMEvents = null;

        Point PGrab1 = Point.Empty;
        Point PGrab2 = Point.Empty;
        Size GrabSize = Size.Empty;
        Point PMDown = Point.Empty;
        Point POffset = Point.Empty;

        Rectangle r = Rectangle.Empty;
        Bitmap StitchBmp;

        public Main()
        {
            InitializeComponent();
            KMEvents = Hook.GlobalEvents();
            KMEvents.MouseDown += EvtMouseDown;
            KMEvents.MouseUp += EvtMouseUp;
            KMEvents.KeyUp += EvtKeyUp;
        }


        private Size GetSize(Point p1, Point p2) => new Size(Math.Abs(p1.X - p2.X), Math.Abs(p1.Y - p2.Y));

        private Bitmap GrabScreen()
        {
            if (PGrab1 == Point.Empty || PGrab2 == Point.Empty) return null;
            var bmp = new Bitmap(GrabSize.Width, GrabSize.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(PGrab1.X, PGrab1.Y, 0, 0, bmp.Size);
            }
            return bmp;
        }

        private void EvtKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (PGrab1 == Point.Empty)
                {
                    PGrab1 = Cursor.Position;
                    Text = "P1 set, press F2 again to set P2";
                }
                else
                {
                    if (PGrab2 == Point.Empty)
                    {
                        PGrab2 = Cursor.Position;
                        GrabSize = GetSize(PGrab1, PGrab2);
                        Text = $"Grab: {PGrab1}-{PGrab2}";
                        GrabBitmap(0, 0);
                    }
                }
            }
        }


        private void EvtMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (new Rectangle(PGrab1, GrabSize).Contains(e.Location))
                    PMDown = e.Location;
                else
                    PMDown = Point.Empty;
            }
        }

        private void EvtMouseUp(object sender, MouseEventArgs e)
        {
            if (StitchBmp == null) return;
            if (e.Button == MouseButtons.Left && PMDown != Point.Empty)
            {
                int dX = e.Location.X - PMDown.X;
                int dY = e.Location.Y - PMDown.Y;
                if (dX*dY != 0)
                {
                    GrabBitmap(dX, dY);
                }
            }
        }

        private void GrabBitmap(int dX, int dY)
        {
            Point nOff = new Point(POffset.X - dX, POffset.Y - dY);
            int nWidth = StitchBmp?.Width ?? 0;
            int nHeight = StitchBmp?.Height ?? 0;
            int oX = 0;
            int oY = 0;
            if (nOff.X < 0)
            {
                nWidth = nWidth - nOff.X;
                oX = oX - nOff.X;
            };
            if (nOff.Y < 0)
            {
                nHeight = nHeight - nOff.Y;
                oY = oY - nOff.Y;
            };
            if (nOff.X + GrabSize.Width > nWidth)
            {
                nWidth = nOff.X + GrabSize.Width;
            }
            if (nOff.Y + GrabSize.Height > nHeight)
            {
                nHeight = nOff.Y + GrabSize.Height;
            }

            Bitmap bmp = new Bitmap(nWidth, nHeight);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                if (StitchBmp != null) g.DrawImage(StitchBmp, oX, oY);
                g.DrawImage(GrabScreen(), nOff.X + oX, nOff.Y + oY);

            }
            POffset = new Point(nOff.X + oX, nOff.Y + oY);

            StitchBmp = bmp;
            pBGrabImage.Image = StitchBmp;

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KMEvents == null) return;
            KMEvents.Dispose();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK && saveFileDialog1.FileName != "")
            {
                StitchBmp.Save(saveFileDialog1.FileName);
            }
        }
    }
}
