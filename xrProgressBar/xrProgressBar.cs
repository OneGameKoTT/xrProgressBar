using System.Drawing;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;

namespace xrProgressBar
{
    public partial class xrProgressBar : UserControl
    {
        public xrProgressBar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            DoubleBuffered = true;
            Percent = 5;
            BarColor = Color.Orange;
        }
        private float _percent;
        public float Percent
        {
            get { return _percent; }
            set
            {
                _percent = value;
                Invalidate();
            }
        }

        private Color _BarColor;
        public Color BarColor
        {
            get { return _BarColor; }
            set
            {
                _BarColor = value;
                Invalidate();
            }
        }
        
        Bitmap bitmap = new Bitmap(Properties.Resources.prb);
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(BarColor), Width / 2, 0, (int)(Width / 2 * (Percent / 100f)), Height);
            e.Graphics.ScaleTransform(-1, 1);
            e.Graphics.FillRectangle(new SolidBrush(BarColor), -Width / 2, 0, (int)(Width / 2 * (Percent / 100f)), Height);
            e.Graphics.DrawImage(bitmap, -Width, 0, Width, Height);
            base.OnPaint(e);
        }
    }
}
