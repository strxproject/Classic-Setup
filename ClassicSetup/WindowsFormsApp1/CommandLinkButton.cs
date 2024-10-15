using System;
using System.Drawing;
using System.Windows.Forms;

namespace ClassicSetup
{
    public partial class CommandLinkButton : Button
    {
        private const int BS_COMMANDLINK = 0x0000000E;

        public string Description { get; set; }

        protected override CreateParams CreateParams
        {
            get
            {
                var cParams = base.CreateParams;
                cParams.Style |= BS_COMMANDLINK;
                return cParams;
            }
        }

        public CommandLinkButton()
        {
            InitializeComponent();
            this.FlatStyle = FlatStyle.System;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (!string.IsNullOrEmpty(Description))
            {
                var textSize = pevent.Graphics.MeasureString(Description, this.Font);
                pevent.Graphics.DrawString(Description, this.Font, Brushes.Black, new System.Drawing.PointF(0, this.Height - textSize.Height));
            }
        }
    }
}
