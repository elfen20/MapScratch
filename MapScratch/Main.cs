using Gma.System.MouseKeyHook;
using System.Drawing;
using System.Windows.Forms;

namespace MapScratch
{
    public partial class Main : Form
    {
        IKeyboardMouseEvents KMEvents = null;

        Point p1 = Point.Empty;
        Point p2 = Point.Empty;
        Rectangle r = Rectangle.Empty;
        Bitmap bmp;

        public Main()
        {
            InitializeComponent();
            KMEvents = Hook.GlobalEvents();
            KMEvents.MouseDown += EvtMouseDown;
            KMEvents.KeyDown += EvtKeyDown;
        }

        private void EvtKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                if (p1 == Point.Empty)
                {
                    p1 = Cursor.Position;
                }
                else
                {
                    p2 = Cursor.Position;
                    bmp = new Bitmap(p2.X - p1.X, p2.Y - p1.Y);
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(p1.X, p1.Y, 0, 0, bmp.Size);
                    }
                    pictureBox1.Image = bmp;

                    p1 = Point.Empty;
                    p2 = Point.Empty;
                }
            }
        }

        private void EvtMouseWheel(object sender, MouseEventArgs e)
        {
            this.Text = e.Button.ToString();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (KMEvents == null) return;
            KMEvents.Dispose();
        }

        private void EvtMouseDown(object sender, MouseEventArgs e)
        {
            this.Text = (string.Format("MouseDown \t\t {0}\n", e.Button));
        }

    }
}
