using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Spoiler.Lib.Win32Helpers;

namespace Spoiler.Lib
{
    public class Spoiler : Panel
    {
        private Color titlebarBackColor = SystemColors.ActiveCaption;
        [DefaultValue(typeof(Color), "162,188,216")]
        public Color TitlebarBackColor
        {
            get { return titlebarBackColor; }
            set
            {
                if (titlebarBackColor != value)
                {
                    titlebarBackColor = value;
                    Redraw();
                }
            }
        }

        private Color titlebarForeColor = Color.White;
        [DefaultValue(typeof(Color), "White")]
        public Color TitlebarForeColor
        {
            get { return titlebarForeColor; }
            set
            {
                if (titlebarForeColor != value)
                {
                    titlebarForeColor = value;
                    Redraw();
                }
            }
        }

        private bool showTitlebar = true;
        [DefaultValue(true)]
        public bool ShowTitlebar
        {
            get { return showTitlebar; }
            set
            {
                if (showTitlebar != value)
                {
                    showTitlebar = value;
                    RecalculateClientSize();
                    Redraw();
                }
            }
        }

        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Bindable(true)]
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                base.Text = value;
                Redraw();
            }
        }

        private Font titlebarFont = DefaultFont;
        public virtual Font TitlebarFont
        {
            get
            {
                return titlebarFont;
            }
            set
            {
                if (titlebarFont != value)
                {
                    titlebarFont = value;
                    RecalculateClientSize();
                    Redraw();
                }
            }
        }
        private bool ShouldSerializeTitlebarFont()
        {
            return TitlebarFont != DefaultFont;
        }
        private void ResetTitlebarFont()
        {
            TitlebarFont = DefaultFont;
        }

        private Padding titlebarTextPadding = new Padding(3);

        [DefaultValue(typeof(Padding), "3")]
        public virtual Padding TitlebarTextPadding
        {
            get
            {
                return titlebarTextPadding;
            }
            set
            {
                if (titlebarTextPadding != value)
                {
                    titlebarTextPadding = value;
                    RecalculateClientSize();
                    Redraw();
                }
            }
        }

        private int prevHeight;
        private bool collapsed;
        private Cursor defaultCursor;

        [DefaultValue(false)]
        public bool Collapsed
        {
            get
            {
                return collapsed;
            }
            set
            {
                if (collapsed != value)
                {
                    collapsed = value;
                    ToggleCollapsed();
                }
            }
        }

        private void ToggleCollapsed()
        {
            if (collapsed)
            {
                prevHeight = Height;
                Height = GetTitlebarHeight();
            }
            else
            {
                Height = prevHeight;
            }
        }

        public virtual int GetTitlebarHeight()
        {
            return (int)TitlebarFont.GetHeight() +
                titlebarTextPadding.Top +
                titlebarTextPadding.Bottom;
        }

        public virtual Rectangle GetTitlebarRectangle()
        {
            return new Rectangle(0, 0, Width, GetTitlebarHeight());
        }

        protected virtual void OnTitleMouseClick(MouseEventArgs e)
        {
            Collapsed = !collapsed;
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_NCPAINT:
                    WmNCPaint(ref m);
                    break;
                case WM_NCCALCSIZE:
                    WmNCCalcSize(ref m);
                    break;
                case WM_SETCURSOR:
                    if (m.LParam.Loword() == HTNOWHERE)
                    {
                        switch (m.LParam.Hiword())
                        {
                            case WM_LBUTTONUP:
                                OnTitleMouseClick(new MouseEventArgs(MouseButtons.Left, 1, Cursor.Position.X, Cursor.Position.Y, -1));
                                break;
                            case WM_MOUSEMOVE:
                                if (Cursor.Current == defaultCursor)
                                {
                                    Cursor.Current = Cursors.Hand;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    else if (m.LParam.Loword() == HTCLIENT)
                    {
                        switch (m.LParam.Hiword())
                        {
                            case WM_MOUSEMOVE:
                                if (Cursor.Current != defaultCursor)
                                {
                                    Cursor.Current = defaultCursor;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }

        }

        protected override void OnCursorChanged(EventArgs e)
        {
            base.OnCursorChanged(e);
            defaultCursor = Cursor.Current;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (collapsed)
            {
                Height = GetTitlebarHeight();
                return;
            }
            base.OnSizeChanged(e);
            Redraw();
        }

        private void Redraw()
        {
            RedrawWindow(Handle, IntPtr.Zero, IntPtr.Zero,
               RDW_FRAME | RDW_INVALIDATE | RDW_UPDATENOW);
        }

        private void RecalculateClientSize()
        {
            SetWindowPos(this.Handle, IntPtr.Zero, 0, 0, 0, 0,
                SWP_NOSIZE | SWP_NOMOVE | SWP_FRAMECHANGED | SWP_NOZOORDER);
        }

        private void WmNCCalcSize(ref Message m)
        {
            var h = ShowTitlebar ? GetTitlebarHeight() : 0;
            var b = BorderStyle == BorderStyle.FixedSingle ? 1 :
               BorderStyle == BorderStyle.Fixed3D ? 2 : 0;

            if (m.WParam != IntPtr.Zero)
            {
                var nccsp = (NCCALCSIZE_PARAMS)Marshal.PtrToStructure(m.LParam, typeof(NCCALCSIZE_PARAMS));
                nccsp.rgrc[0].top += h - b;
                nccsp.rgrc[0].bottom -= 0;
                nccsp.rgrc[0].left += 0;
                nccsp.rgrc[0].right -= 0;
                Marshal.StructureToPtr(nccsp, m.LParam, true);
                InvalidateRect(this.Handle, nccsp.rgrc[0], true);
                m.Result = IntPtr.Zero;
            }
        }

        private void WmNCPaint(ref Message m)
        {
            if (!ShowTitlebar)
                return;

            var dc = GetWindowDC(Handle);
            using (var g = Graphics.FromHdc(dc))
            {
                using (var b = new SolidBrush(TitlebarBackColor))
                    g.FillRectangle(b, GetTitlebarRectangle());
                if (BorderStyle != BorderStyle.None)
                    using (var p = new Pen(TitlebarBackColor))
                        g.DrawRectangle(p, 0, 0,
                            Width - 1, Height - 1);

                var tf = TextFormatFlags.NoPadding | TextFormatFlags.VerticalCenter;
                if (RightToLeft == RightToLeft.Yes)
                    tf |= TextFormatFlags.Right | TextFormatFlags.RightToLeft;
                var t = GetTitlebarRectangle();
                var r = new Rectangle(
                    t.Left + TitlebarTextPadding.Left,
                    t.Top,
                    t.Width - TitlebarTextPadding.Left - TitlebarTextPadding.Right,
                    t.Height);
                TextRenderer.DrawText(g, Text, TitlebarFont, r, TitlebarForeColor, tf);
            }
            ReleaseDC(Handle, dc);
            m.Result = IntPtr.Zero;
        }

        public override Size GetPreferredSize(Size proposedSize)
        {
            var size = base.GetPreferredSize(proposedSize);
            if (ShowTitlebar)
                size.Height += GetTitlebarHeight();
            return size;
        }

        protected override void OnRightToLeftChanged(EventArgs e)
        {
            base.OnRightToLeftChanged(e);
            RecalculateClientSize();
            Redraw();
        }
    }
}