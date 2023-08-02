using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Nucleo.Forms.Telas.Controls
{
    public class Botao : Button
    {
        private int TamanhoBorda = 0;
        private int CurvaturaBorda = 15;
        private Color CorBorda = Color.Transparent;

        public Botao()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = TamanhoBorda;
            this.Size = new Size(80, 30);

            this.BackColor = Color.DarkSlateGray;
            this.ForeColor = Color.Transparent;
        }


        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath novo = new GraphicsPath();
            novo.StartFigure();
            novo.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            novo.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            novo.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            novo.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            novo.CloseFigure();

            return novo;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 0.8F);

            if (CurvaturaBorda > 2)
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, CurvaturaBorda))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, CurvaturaBorda - 0.8F))
                using (Pen penBorder = new Pen(this.Parent.BackColor, 2))
                using (Pen penSurface = new Pen(CorBorda, TamanhoBorda))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathSurface);
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    if (TamanhoBorda >= 1)
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else
            {
                this.Region = new Region(rectSurface);
                if(TamanhoBorda >= 1)
                {
                    using(Pen penBorder = new Pen(CorBorda, TamanhoBorda))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 0.8F, this.Height - 0.8F);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);

            this.Parent.BackColorChanged += Parent_BackColorChanged;
        }

        private void Parent_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }
    }
}
