using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Spoiler.Lib.Win32Helpers;

namespace Spoiler.Lib
{
    public class Spoiler : Panel
    {
        private string text;
        private bool isMouseOver;
        private int clientHeight;
        private Cursor currentCursor;

        [EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Текст заголовка")]
        [Browsable(true)]
        public override string Text
        {
            get => text; set
            {
                if (text == value)
                {
                    return;
                }
                text = value;
                Redraw();
            }
        }

        private void Redraw()
        {
            Win32Helpers.RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero, Win32Helpers.RDW_FRAME | Win32Helpers.RDW_INVALIDATE | Win32Helpers.RDW_UPDATENOW);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.Style |= WS_CAPTION;
                //cp.ExStyle &= ~0x00000100;//WS_EX_WINDOWEDGE
                return cp;
            }
        }

        public Spoiler()
        {
            Text = this.GetType().Name;
            Region = new Region(new Rectangle(0, 0, Width, Height));
            SetStyle(ControlStyles.ResizeRedraw |
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor, true);
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Region = new Region(new Rectangle(0, 0, Width, Height));
            Redraw();
        }

        protected override void OnMove(EventArgs e)
        {
            base.OnMove(e);
            Region = new Region(new Rectangle(0, 0, Width, Height));
            Redraw();
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCCALCSIZE:
                    WmNCCalcSize(ref m);
                    break;
                case WM_NCPAINT:
                    WmNCPaint(m);
                    break;
                case WM_NCLBUTTONDOWN:
                    Toggle();
                    break;
                case WM_NCHITTEST:
                    if (m.Result.ToInt32() == HTCAPTION)
                    {
                        // Change the cursor to a hand cursor if it's not already the hand cursor
                        if (Cursor.Current != Cursors.Hand)
                        {
                            Cursor.Current = Cursors.Hand;
                            SetCursor(IntPtr.Zero);
                        }
                        else
                        {
                            Cursor.Current = Cursors.Default;
                            SetCursor(IntPtr.Zero);
                        }
                    }
                    break;
                //case WM_NCMOUSEMOVE:
                //    if (m.WParam.ToInt32() == HTCAPTION && currentCursor == Cursors.Hand)
                //    {
                //        return;
                //    }
                //    break;
                default:
                    break;
            }
        }

        private void Toggle()
        {
            if (Height > SystemInformation.CaptionHeight)
            {
                clientHeight = ClientSize.Height;
                Height = SystemInformation.CaptionHeight;
            }
            else
            {
                Height += clientHeight;
            }
        }

        private void TrackMouseLeave()
        {
            //var tme = new TrackMouseEvent
            //{
            //    hwndTrack = Handle,
            //    dwFlags = (int)TrackMouseEventFalgs.ALL
            //};
            //Externs.TrackMouseEvent(tme);
        }

        private void WmNCPaint(Message m)
        {
            var hdc = Win32Helpers.GetWindowDC(m.HWnd);
            using (var g = Graphics.FromHdc(hdc))
            {
                DrawBorder(g);
                Title(g);
            }
            Win32Helpers.ReleaseDC(m.HWnd, hdc);
            m.Result = IntPtr.Zero;
        }

        private void Title(Graphics g)
        {
            var sf = new StringFormat
            {
                FormatFlags = StringFormatFlags.NoWrap,
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near,
                Trimming = StringTrimming.EllipsisCharacter
            };
            var rect = new Rectangle(0, 0, Width, SystemInformation.CaptionHeight);
            g.FillRegion(SystemBrushes.ActiveCaption, Region);
            //g.FillRectangle(SystemBrushes.ActiveCaption, rect);
            g.DrawString(Text, Font, SystemBrushes.ActiveCaptionText, rect, sf);
        }

        private void DrawBorder(Graphics g)
        {
            //throw new NotImplementedException();
        }

        private void WmNCCalcSize(ref Message m)
        {
            var h = SystemInformation.CaptionHeight;
            var bx = SystemInformation.HorizontalResizeBorderThickness + SystemInformation.FixedFrameBorderSize.Width;
            var by = SystemInformation.VerticalResizeBorderThickness + SystemInformation.FixedFrameBorderSize.Height;
            if (BorderStyle == BorderStyle.None)
            {
                bx++;
                by++;
            }
            else if (BorderStyle == BorderStyle.Fixed3D)
            {
                bx = SystemInformation.HorizontalResizeBorderThickness + SystemInformation.Border3DSize.Width;
                by = SystemInformation.VerticalResizeBorderThickness + SystemInformation.Border3DSize.Height;
            }
            if (m.WParam != IntPtr.Zero)
            {
                var nccsp = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                nccsp.rgrc[0].top -= by;
                nccsp.rgrc[0].bottom += by;
                nccsp.rgrc[0].left -= bx;
                nccsp.rgrc[0].right += bx;
                Marshal.StructureToPtr(nccsp, m.LParam, true);
                //InvalidateRect(this.Handle, nccsp.rgrc[0], true);
                m.Result = IntPtr.Zero;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            //Text = e.Location.ToString();
        }

        private Rectangle RecalcNonClientArea(Rectangle proposed)
        {
            return new Rectangle(
                proposed.Left + SystemInformation.BorderSize.Width,
                proposed.Top + SystemInformation.BorderSize.Height + SystemInformation.CaptionHeight,
                proposed.Width - 2 * SystemInformation.BorderSize.Width,
                proposed.Height - 2 * SystemInformation.BorderSize.Height + SystemInformation.CaptionHeight);
        }
    }
}
