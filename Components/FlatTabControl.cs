using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Design;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.IO;

namespace MyComponents
{
    /// <summary>
    /// Summary description for FlatTabControl.
	/// </summary>
	[ToolboxBitmap(typeof(System.Windows.Forms.TabControl))]
	public class FlatTabControl : System.Windows.Forms.TabControl
	{
		private System.ComponentModel.Container components = null;
		private SubClass scUpDown = null;
		private bool bUpDown; // true when the button UpDown is required
		private ImageList leftRightImages = null;
		private const int nMargin = 15;
		private Color mBackColor = Color.FromArgb(187,206,230);// SystemColors.Highlight;

		public FlatTabControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// double buffering
			this.SetStyle(ControlStyles.UserPaint, true);
			this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(ControlStyles.DoubleBuffer, true);
			this.SetStyle(ControlStyles.ResizeRedraw, true);
			this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			bUpDown = false;

			this.ControlAdded += new ControlEventHandler(FlatTabControl_ControlAdded);
			this.ControlRemoved += new ControlEventHandler(FlatTabControl_ControlRemoved);
			this.SelectedIndexChanged += new EventHandler(FlatTabControl_SelectedIndexChanged);

			leftRightImages = new ImageList();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FlatTabControl));
			Bitmap updownImage = ((System.Drawing.Bitmap)(resources.GetObject("TabIcons.bmp")));
			
			if (updownImage != null)
			{
				updownImage.MakeTransparent(Color.White);
				leftRightImages.Images.AddStrip(updownImage);
			}
		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}

				leftRightImages.Dispose();
			}
			base.Dispose( disposing );
		}
        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            base.Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            base.Invalidate();
        }
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e); 
			
			DrawControl(e.Graphics);
		}

        internal void DrawControl(Graphics g)
        {
            if (!Visible)
                return;

            Rectangle TabControlArea = this.ClientRectangle;
            Rectangle TabArea = this.DisplayRectangle;

            // fill client area
            RenderControlBackground(g, TabControlArea);

            // draw panel border
            int nDelta = SystemInformation.Border3DSize.Width;
            TabArea.Inflate(nDelta, nDelta);
            RenderTabPanelBorder(g, TabArea);


            // clip region for drawing tabs
            Region rsaved = g.Clip;

            int nWidth = TabArea.Width + nMargin;
            if (bUpDown)
            {
                // exclude updown control for painting
                if (Win32.IsWindowVisible(scUpDown.Handle))
                {
                    Rectangle rupdown = new Rectangle();
                    Win32.GetWindowRect(scUpDown.Handle, ref rupdown);
                    Rectangle rupdown2 = this.RectangleToClient(rupdown);

                    nWidth = rupdown2.X;
                }
            }


            for (int i = 0; i < this.TabCount; i++)
                DrawTab(g, this.TabPages[i], i);

            g.Clip = rsaved;

            //如果边框是两条线，则这里就只需要覆盖底线和右边的竖线，根据实际观察得知
            if (this.SelectedTab != null)
            {
                TabPage tabPage = this.SelectedTab;
                Color color = tabPage.BackColor;
                Pen border = new Pen(color);

                g.DrawLine(border, new Point(TabArea.X + 2, TabArea.Bottom - 2)
                    , new Point(TabArea.Right - 2, TabArea.Bottom - 2));

                g.DrawLine(border, new Point(TabArea.Right - 2, TabArea.Bottom - 2)
                , new Point(TabArea.Right-2,TabArea.Y+2));

                border.Dispose();
            }
        }

        /// <summary>
        /// 画tab panel控件容器的边框。可重写。
        /// </summary>
        /// <param name="g"></param>
        /// <param name="tabArea"></param>
        protected virtual void RenderTabPanelBorder(Graphics g, Rectangle tabArea)
        {
            Pen border1 = new Pen(Color.FromArgb(41,50,62));
            g.DrawRectangle(border1, tabArea);
            border1.Dispose();

            //内边框
            Pen border2 = new Pen(Color.FromArgb(119,140,166));
            //Pen border2 = new Pen(Color.FromArgb(255,0,0));
            tabArea.Inflate(-1, -1);
            g.DrawRectangle(border2, tabArea);
            //g.DrawRectangle(border2,tabArea.X+1,tabArea.Y+1,tabArea.Width-3,tabArea.Height-3);
            border2.Dispose();
        }

        /// <summary>
        /// 画整个控件背景。可重写以自定义样式。
        /// </summary>
        /// <param name="g"></param>
        /// <param name="TabControlArea"></param>
        protected  virtual void RenderControlBackground(Graphics g, Rectangle tabControlArea)
        {
            Brush br = new SolidBrush(mBackColor); //(SystemColors.Control); UPDATED
            g.FillRectangle(br, tabControlArea);
            br.Dispose();
        }

		protected virtual void DrawTab(Graphics g, TabPage tabPage, int nIndex)
		{
			Rectangle recBounds = this.GetTabRect(nIndex);
			RectangleF tabTextArea = (RectangleF)this.GetTabRect(nIndex);
            Point cusorPoint = PointToClient(MousePosition);

			bool bSelected = (this.SelectedIndex == nIndex);
            bool bHovered = recBounds.Contains(cusorPoint);

            if (bSelected)
            {
                Point[] pt = new Point[7];
                if (this.Alignment == TabAlignment.Top)
                {
                    pt[0] = new Point(recBounds.Left, recBounds.Bottom);
                    pt[1] = new Point(recBounds.Left, recBounds.Top + 3);
                    pt[2] = new Point(recBounds.Left + 3, recBounds.Top);
                    pt[3] = new Point(recBounds.Right - 3, recBounds.Top);
                    pt[4] = new Point(recBounds.Right, recBounds.Top + 3);
                    pt[5] = new Point(recBounds.Right, recBounds.Bottom);
                    pt[6] = new Point(recBounds.Left, recBounds.Bottom);
                }
                else
                {
                    pt[0] = new Point(recBounds.Left, recBounds.Top);
                    pt[1] = new Point(recBounds.Right, recBounds.Top);
                    pt[2] = new Point(recBounds.Right, recBounds.Bottom - 3);
                    pt[3] = new Point(recBounds.Right - 3, recBounds.Bottom);
                    pt[4] = new Point(recBounds.Left + 3, recBounds.Bottom);
                    pt[5] = new Point(recBounds.Left, recBounds.Bottom - 3);
                    pt[6] = new Point(recBounds.Left, recBounds.Top);
                }

                //----------------------------
                // fill this tab with background color
                Brush br = new SolidBrush(tabPage.BackColor);
                g.FillPolygon(br, pt);
                br.Dispose();
                //----------------------------
                //----------------------------
                // draw border
                //g.DrawRectangle(SystemPens.ControlDark, recBounds);

                //g.DrawPolygon(SystemPens.ControlDark, pt);
                using (Pen pen1 = new Pen(Color.FromArgb(41, 50, 62)))
                {
                    g.DrawPolygon(pen1, pt);

                }

                #region 内边框
                if (this.Alignment == TabAlignment.Top)
                {
                    pt[0] = new Point(recBounds.Left + 1, recBounds.Bottom);
                    pt[1] = new Point(recBounds.Left + 1, recBounds.Top + 3);
                    pt[2] = new Point(recBounds.Left + 3, recBounds.Top + 1);
                    pt[3] = new Point(recBounds.Right - 3, recBounds.Top + 1);
                    pt[4] = new Point(recBounds.Right - 1, recBounds.Top + 3);
                    pt[5] = new Point(recBounds.Right - 1, recBounds.Bottom);
                    pt[6] = new Point(recBounds.Left + 1, recBounds.Bottom);
                }
                else
                {
                    //这里未计算。
                    pt[0] = new Point(recBounds.Left, recBounds.Top);
                    pt[1] = new Point(recBounds.Right, recBounds.Top);
                    pt[2] = new Point(recBounds.Right, recBounds.Bottom - 3);
                    pt[3] = new Point(recBounds.Right - 3, recBounds.Bottom);
                    pt[4] = new Point(recBounds.Left + 3, recBounds.Bottom);
                    pt[5] = new Point(recBounds.Left, recBounds.Bottom - 3);
                    pt[6] = new Point(recBounds.Left, recBounds.Top);
                }

                //----------------------------
                // fill this tab with background color
                //Brush br1 = new SolidBrush(Color.FromArgb(119,140,166));
                using (Pen pen1 = new Pen(Color.FromArgb(119, 140, 166)))
                {
                    g.DrawPolygon(pen1, pt);

                }
                #endregion







                //----------------------------
                // clear bottom lines
                Pen pen = new Pen(tabPage.BackColor);

                switch (this.Alignment)
                {
                    case TabAlignment.Top:
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom);
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom + 1, recBounds.Right - 1, recBounds.Bottom + 1);
                        break;

                    case TabAlignment.Bottom:
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Top, recBounds.Right - 1, recBounds.Top);
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 1, recBounds.Right - 1, recBounds.Top - 1);
                        g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 2, recBounds.Right - 1, recBounds.Top - 2);
                        break;
                }

                pen.Dispose();
                //----------------------------
            }
            else if (bHovered)//如果不是选中，是hover状态
            {
                Color tabBackColor = Color.FromArgb(65,109,159);
            Color tabBorderColor=Color.FromArgb(41, 50, 62);
            Color tabBorderInnerColor=Color.FromArgb(89, 129, 175);

            Point[] pt = new Point[7];
            if (this.Alignment == TabAlignment.Top)
            {
                pt[0] = new Point(recBounds.Left, recBounds.Bottom);
                pt[1] = new Point(recBounds.Left, recBounds.Top + 3);
                pt[2] = new Point(recBounds.Left + 3, recBounds.Top);
                pt[3] = new Point(recBounds.Right - 3, recBounds.Top);
                pt[4] = new Point(recBounds.Right, recBounds.Top + 3);
                pt[5] = new Point(recBounds.Right, recBounds.Bottom);
                pt[6] = new Point(recBounds.Left, recBounds.Bottom);
            }
            else
            {
                pt[0] = new Point(recBounds.Left, recBounds.Top);
                pt[1] = new Point(recBounds.Right, recBounds.Top);
                pt[2] = new Point(recBounds.Right, recBounds.Bottom - 3);
                pt[3] = new Point(recBounds.Right - 3, recBounds.Bottom);
                pt[4] = new Point(recBounds.Left + 3, recBounds.Bottom);
                pt[5] = new Point(recBounds.Left, recBounds.Bottom - 3);
                pt[6] = new Point(recBounds.Left, recBounds.Top);
            }

            //----------------------------
            // fill this tab with background color
            Brush br = new SolidBrush(tabBackColor);
            g.FillPolygon(br, pt);
            br.Dispose();
            //----------------------------
            //----------------------------
            // draw border
            //g.DrawRectangle(SystemPens.ControlDark, recBounds);

            //g.DrawPolygon(SystemPens.ControlDark, pt);
            using (Pen pen1 = new Pen(tabBorderColor))
            {
                g.DrawPolygon(pen1, pt);

            }

            #region 内边框
            if (this.Alignment == TabAlignment.Top)
            {
                pt[0] = new Point(recBounds.Left + 1, recBounds.Bottom);
                pt[1] = new Point(recBounds.Left + 1, recBounds.Top + 3);
                pt[2] = new Point(recBounds.Left + 3, recBounds.Top + 1);
                pt[3] = new Point(recBounds.Right - 3, recBounds.Top + 1);
                pt[4] = new Point(recBounds.Right - 1, recBounds.Top + 3);
                pt[5] = new Point(recBounds.Right - 1, recBounds.Bottom);
                pt[6] = new Point(recBounds.Left + 1, recBounds.Bottom);
            }
            else
            {
                //这里未计算。
                pt[0] = new Point(recBounds.Left, recBounds.Top);
                pt[1] = new Point(recBounds.Right, recBounds.Top);
                pt[2] = new Point(recBounds.Right, recBounds.Bottom - 3);
                pt[3] = new Point(recBounds.Right - 3, recBounds.Bottom);
                pt[4] = new Point(recBounds.Left + 3, recBounds.Bottom);
                pt[5] = new Point(recBounds.Left, recBounds.Bottom - 3);
                pt[6] = new Point(recBounds.Left, recBounds.Top);
            }

            //----------------------------
            // fill this tab with background color
            //Brush br1 = new SolidBrush(Color.FromArgb(119,140,166));
            using (Pen pen1 = new Pen(tabBorderInnerColor))
            {
                g.DrawPolygon(pen1, pt);

            }
            #endregion







            //----------------------------
            // clear bottom lines
            Pen pen = new Pen(tabBorderColor);

            switch (this.Alignment)
            {
                case TabAlignment.Top:
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom, recBounds.Right - 1, recBounds.Bottom);
                    //g.DrawLine(pen, recBounds.Left + 1, recBounds.Bottom - 1, recBounds.Right - 1, recBounds.Bottom - 1);
                    break;

                case TabAlignment.Bottom:
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Top, recBounds.Right - 1, recBounds.Top);
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 1, recBounds.Right - 1, recBounds.Top - 1);
                    g.DrawLine(pen, recBounds.Left + 1, recBounds.Top - 2, recBounds.Right - 1, recBounds.Top - 2);
                    break;
            }

            pen.Dispose();
            }

            
			//----------------------------

			//----------------------------
			// draw tab's icon
			if ((tabPage.ImageIndex >= 0) && (ImageList != null) && (ImageList.Images[tabPage.ImageIndex] != null))
			{
				int nLeftMargin = 8;
				int nRightMargin = 2;

				Image img = ImageList.Images[tabPage.ImageIndex];
				
				Rectangle rimage = new Rectangle(recBounds.X + nLeftMargin, recBounds.Y + 1, img.Width, img.Height);
				
				// adjust rectangles
				float nAdj = (float)(nLeftMargin + img.Width + nRightMargin);

				rimage.Y += (recBounds.Height - img.Height) / 2;
				tabTextArea.X += nAdj;
				tabTextArea.Width -= nAdj;

				// draw icon
				g.DrawImage(img, rimage);
			}
			//----------------------------

			//----------------------------
			// draw string
			StringFormat stringFormat = new StringFormat();
			stringFormat.Alignment = StringAlignment.Center;  
			stringFormat.LineAlignment = StringAlignment.Center;

            if (bSelected)
            {
                using (SolidBrush br = new SolidBrush(Color.White))
                {
                    g.DrawString(tabPage.Text, Font, br, tabTextArea, stringFormat);
                }
            }
            else
            {
                using (SolidBrush br = new SolidBrush(Color.Black))
                {
                    g.DrawString(tabPage.Text, Font, br, tabTextArea, stringFormat);
                }
               
            }
			//----------------------------
		}

		internal void DrawIcons(Graphics g)
		{
			if ((leftRightImages == null) || (leftRightImages.Images.Count != 4))
				return;

			//----------------------------
			// calc positions
			Rectangle TabControlArea = this.ClientRectangle;

			Rectangle r0 = new Rectangle();
			Win32.GetClientRect(scUpDown.Handle, ref r0);

			Brush br = new SolidBrush(SystemColors.Control);
			g.FillRectangle(br, r0);
			br.Dispose();
			
			Pen border = new Pen(SystemColors.ControlDark);
			Rectangle rborder = r0;
			rborder.Inflate(-1, -1);
			g.DrawRectangle(border, rborder);
			border.Dispose();

			int nMiddle = (r0.Width / 2);
			int nTop = (r0.Height - 16) / 2;
			int nLeft = (nMiddle - 16) / 2;

			Rectangle r1 = new Rectangle(nLeft, nTop, 16, 16);
			Rectangle r2 = new Rectangle(nMiddle+nLeft, nTop, 16, 16);
			//----------------------------

			//----------------------------
			// draw buttons
			Image img = leftRightImages.Images[1];
			if (img != null)
			{
				if (this.TabCount > 0)
				{
					Rectangle r3 = this.GetTabRect(0);
					if (r3.Left < TabControlArea.Left)
						g.DrawImage(img, r1);
					else
					{
						img = leftRightImages.Images[3];
						if (img != null)
							g.DrawImage(img, r1);
					}
				}
			}

			img = leftRightImages.Images[0];
			if (img != null)
			{
				if (this.TabCount > 0)
				{
					Rectangle r3 = this.GetTabRect(this.TabCount - 1);
					if (r3.Right > (TabControlArea.Width - r0.Width))
						g.DrawImage(img, r2);
					else
					{
						img = leftRightImages.Images[2];
						if (img != null)
							g.DrawImage(img, r2);
					}
				}
			}
			//----------------------------
		}

		protected override void OnCreateControl()
		{
			base.OnCreateControl();

			FindUpDown();
		}

		private void FlatTabControl_ControlAdded(object sender, ControlEventArgs e)
		{
			FindUpDown();
			UpdateUpDown();
		}

		private void FlatTabControl_ControlRemoved(object sender, ControlEventArgs e)
		{
			FindUpDown();
			UpdateUpDown();
		}

		private void FlatTabControl_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateUpDown();
			Invalidate();	// we need to update border and background colors
		}

		private void FindUpDown()
		{
			bool bFound = false;

			// find the UpDown control
			IntPtr pWnd = Win32.GetWindow(this.Handle, Win32.GW_CHILD);
			
			while (pWnd != IntPtr.Zero)
			{
				//----------------------------
				// Get the window class name
				char[] className = new char[33];

				int length = Win32.GetClassName(pWnd, className, 32);

				string s = new string(className, 0, length);
				//----------------------------

				if (s == "msctls_updown32")
				{
					bFound = true;

					if (!bUpDown)
					{
						//----------------------------
						// Subclass it
						this.scUpDown = new SubClass(pWnd, true);
						this.scUpDown.SubClassedWndProc += new SubClass.SubClassWndProcEventHandler(scUpDown_SubClassedWndProc);
						//----------------------------

						bUpDown = true;
					}
					break;
				}
				
				pWnd = Win32.GetWindow(pWnd, Win32.GW_HWNDNEXT);
			}

			if ((!bFound) && (bUpDown))
				bUpDown = false;
		}

		private void UpdateUpDown()
		{
			if (bUpDown)
			{
				if (Win32.IsWindowVisible(scUpDown.Handle))
				{
					Rectangle rect = new Rectangle();

					Win32.GetClientRect(scUpDown.Handle, ref rect);
					Win32.InvalidateRect(scUpDown.Handle, ref rect, true);
				}
			}
		}

		#region scUpDown_SubClassedWndProc Event Handler

		private int scUpDown_SubClassedWndProc(ref Message m) 
		{
			switch (m.Msg)
			{
				case Win32.WM_PAINT:
				{
					//------------------------
					// redraw
					IntPtr hDC = Win32.GetWindowDC(scUpDown.Handle);
					Graphics g = Graphics.FromHdc(hDC);

					DrawIcons(g);

					g.Dispose();
					Win32.ReleaseDC(scUpDown.Handle, hDC);
					//------------------------

					// return 0 (processed)
					m.Result = IntPtr.Zero;

					//------------------------
					// validate current rect
					Rectangle rect = new Rectangle();

					Win32.GetClientRect(scUpDown.Handle, ref rect);
					Win32.ValidateRect(scUpDown.Handle, ref rect);
					//------------------------
				}
				return 1;
			}

			return 0;
		}
		#endregion

		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}


		#endregion

		#region Properties
		
		[Editor(typeof(TabpageExCollectionEditor), typeof(UITypeEditor))]
		public new TabPageCollection TabPages
		{
			get
			{
				return base.TabPages;
			}
		}

		new public TabAlignment Alignment
		{
			get {return base.Alignment;}
			set {
				TabAlignment ta = value;
                //if ((ta != TabAlignment.Top) && (ta != TabAlignment.Bottom))
                //    ta = TabAlignment.Top;
				
				base.Alignment = ta;}
		}

		[Browsable(false)]
		new public bool Multiline
		{
			get {return base.Multiline;}
			set {base.Multiline = false;}
		}
        /*
		[Browsable(true)]
		new public Color myBackColor
		{
			get {return mBackColor;}
			set {mBackColor = value;}
		}*/
        
		#endregion

		#region TabpageExCollectionEditor

		internal class TabpageExCollectionEditor : CollectionEditor
		{
			public TabpageExCollectionEditor(System.Type type): base(type)
			{
			}
            
			protected override Type CreateCollectionItemType()
			{
				return typeof(TabPage);
			}
		}
        
		#endregion
	}

	//#endregion
}
