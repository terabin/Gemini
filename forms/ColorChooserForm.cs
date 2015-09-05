using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Gemini
{

	/// <summary>
	///   Summary description for ColorChooser.
	/// </summary>
	public partial class ColorChooserForm : Form
	{
		/// <summary>
		///   Required designer variable.
		/// </summary>

		public ColorChooserForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		public Color Color
		{
			// Get or set the color to be
			// displayed in the color wheel.
			get { return myColorWheel.Color; }

			set
			{
				// Indicate the color change type. Either RGB or HSV
				// will cause the color wheel to update the position
				// of the pointer.
				changeType = ChangeStyle.RGB;
				argb = new ColorHandler.ARGB(value.A, value.R, value.G, value.B);
				hsv = ColorHandler.RGBtoHSV(argb);
			}
		}

		private void ColorChooserLoad(object sender, EventArgs e)
		{
			// Turn on double-buffering, so the form looks better. 
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.DoubleBuffer, true);

			// These properties are set in design view, as well, but they
			// have to be set to false in order for the Paint
			// event to be able to display their contents.
			// Never hurts to make sure they're invisible.
			pnlSelectedColor.Visible = false;
			pnlBrightness.Visible = false;
			pnlColor.Visible = false;

			// Calculate the coordinates of the three
			// required regions on the form.
			Rectangle selectedColorRectangle = new Rectangle(pnlSelectedColor.Location, pnlSelectedColor.Size);
			Rectangle brightnessRectangle = new Rectangle(pnlBrightness.Location, pnlBrightness.Size);
			Rectangle colorRectangle = new Rectangle(pnlColor.Location, pnlColor.Size);

			// Create the new ColorWheel class, indicating
			// the locations of the color wheel itself, the
			// brightness area, and the position of the selected color.
			myColorWheel = new ColorWheel(colorRectangle, brightnessRectangle, selectedColorRectangle);
			myColorWheel.ColorChanged += MyColorWheelColorChanged;

			// Set the RGB and HSV values 
			// of the NumericUpDown controls.
			SetRGB(argb);
			SetHSV(hsv);
		}

		private void HandleMouse(object sender, MouseEventArgs e)
		{
			// If you have the left mouse button down, 
			// then update the selectedPoint value and 
			// force a repaint of the color wheel.
			if (e.Button != MouseButtons.Left)
				return;
			changeType = ChangeStyle.MouseMove;
			selectedPoint = new Point(e.X, e.Y);
			Invalidate();
		}

		private void FormMainMouseUp(object sender, MouseEventArgs e)
		{
			myColorWheel.SetMouseUp();
			changeType = ChangeStyle.None;
		}

		private void SetRGBLabels(ColorHandler.ARGB argb)
		{
			RefreshText(lblRed, argb.Red);
			RefreshText(lblBlue, argb.Blue);
			RefreshText(lblGreen, argb.Green);
			RefreshText(lblAlpha, argb.Alpha);
			tbHexCode.Text = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", argb.Alpha, argb.Red, argb.Green, argb.Blue);
		}

		private void SetHSVLabels(ColorHandler.HSV HSV)
		{
			RefreshText(lblHue, HSV.Hue);
			RefreshText(lblSaturation, HSV.Saturation);
			RefreshText(lblValue, HSV.Value);
			RefreshText(lblAlpha, HSV.Alpha);
		}

		private void SetRGB(ColorHandler.ARGB argb)
		{
			// Update the RGB values on the form.
			RefreshValue(tbRed, argb.Red);
			RefreshValue(tbBlue, argb.Blue);
			RefreshValue(tbGreen, argb.Green);
			RefreshValue(tbAlpha, argb.Alpha);
			SetRGBLabels(argb);
		}

		private void SetHSV(ColorHandler.HSV HSV)
		{
			// Update the HSV values on the form.
			RefreshValue(tbHue, HSV.Hue);
			RefreshValue(tbSaturation, HSV.Saturation);
			RefreshValue(tbValue, HSV.Value);
			RefreshValue(tbAlpha, HSV.Alpha);
			SetHSVLabels(HSV);
		}

		private static void RefreshValue(TrackBar hsv, int value)
		{
			hsv.Value = value;
		}

		private static void RefreshText(Control lbl, int value)
		{
			lbl.Text = value.ToString();
		}

		private void MyColorWheelColorChanged(object sender, ColorChangedEventArgs e)
		{
			SetRGB(e.ARGB);
			SetHSV(e.HSV);
		}

		private void HandleHSVScroll(object sender, EventArgs e)
		// If the H, S, or V values change, use this 
		// code to update the RGB values and invalidate
		// the color wheel (so it updates the pointers).
		// Check the isInUpdate flag to avoid recursive events
		// when you update the NumericUpdownControls.
		{
			changeType = ChangeStyle.HSV;
			hsv = new ColorHandler.HSV(tbAlpha.Value, tbHue.Value, tbSaturation.Value, tbValue.Value);
			SetRGB(ColorHandler.HSVtoRGB(hsv));
			SetHSVLabels(hsv);
			Invalidate();
		}

		private void HandleRGBScroll(object sender, EventArgs e)
		{
			// If the R, G, or B values change, use this 
			// code to update the HSV values and invalidate
			// the color wheel (so it updates the pointers).
			// Check the isInUpdate flag to avoid recursive events
			// when you update the NumericUpdownControls.
			changeType = ChangeStyle.RGB;
			argb = new ColorHandler.ARGB(tbAlpha.Value, tbRed.Value, tbGreen.Value, tbBlue.Value);
			SetHSV(ColorHandler.RGBtoHSV(argb));
			SetRGBLabels(argb);
			Invalidate();
		}

		private void TbAlphaScroll(object sender, EventArgs e)
		{
			changeType = ChangeStyle.RGB;
			argb = new ColorHandler.ARGB(tbAlpha.Value, tbRed.Value, tbGreen.Value, tbBlue.Value);
			RefreshText(lblAlpha, tbAlpha.Value);
			tbHexCode.Text = string.Format("{0:X2}{1:X2}{2:X2}{3:X2}", argb.Alpha, argb.Red, argb.Green, argb.Blue);
			Invalidate();
		}

		private void ColorChooserPaint(object sender, PaintEventArgs e)
		{
			// Depending on the circumstances, force a repaint
			// of the color wheel passing different information.
			switch (changeType)
			{
				case ChangeStyle.HSV:
					myColorWheel.Draw(e.Graphics, hsv);
					break;
				case ChangeStyle.MouseMove:
				case ChangeStyle.None:
					myColorWheel.Draw(e.Graphics, selectedPoint);
					break;
				case ChangeStyle.RGB:
					myColorWheel.Draw(e.Graphics, argb);
					break;
			}
		}

		private void TbHexCodeMouseDown(object sender, MouseEventArgs e)
		{
			tbHexCode.SelectionStart = 0;
			tbHexCode.SelectionLength = tbHexCode.Text.Length;
		}


		#region Nested type: ChangeStyle

		private enum ChangeStyle
		{
			MouseMove,
			RGB,
			HSV,
			None
		}

		#endregion
	}

	public class ColorWheel : IDisposable
	{
		// These resources should be disposed
		// of when you're done with them.

		#region Delegates

		public delegate void ColorChangedEventHandler(object sender, ColorChangedEventArgs e);

		#endregion

		// Keep track of the current mouse state. 

		#region MouseState enum

		public enum MouseState
		{
			MouseUp,
			ClickOnColor,
			DragInColor,
			ClickOnBrightness,
			DragInBrightness,
			ClickOutsideRegion,
			DragOutsideRegion,
		}

		#endregion

		// The code needs to convert back and forth between 
		// degrees and radians. There are 2*PI radians in a 
		// full circle, and 360 degrees. This constant allows
		// you to convert back and forth.
		private const double DEGREES_PER_RADIAN = 180.0 / Math.PI;

		// COLOR_COUNT represents the number of distinct colors
		// used to create the circular gradient. Its value 
		// is somewhat arbitrary -- change this to 6, for 
		// example, to see what happens. 1536 (6 * 256) seems 
		// a good compromise -- it's enough to get a full 
		// range of colors, but it doesn't overwhelm the processor
		// attempting to generate the image. The color wheel
		// contains 6 sections, and each section displays 
		// 256 colors. Seems like a reasonable compromise.
		private const int COLOR_COUNT = 6 * 256;
		private readonly int brightnessMax;
		private readonly int brightnessMin;

		private readonly Rectangle brightnessRectangle;
		private readonly Region brightnessRegion;
		private readonly double brightnessScaling;
		private readonly int brightnessX;
		private readonly Region colorRegion;
		private readonly int radius;
		private readonly Rectangle selectedColorRectangle;
		public ColorChangedEventHandler ColorChanged;

		// selectedColor is the actual value selected
		// by the user. fullColor is the same color, 
		// with its brightness set to 255.
		private ColorHandler.HSV HSV;
		private ColorHandler.ARGB argb;

		// Locations for the two "pointers" on the form.

		private int brightness;
		private Point brightnessPoint;
		private Point centerPoint;
		private Bitmap colorImage;
		private Point colorPoint;
		private Rectangle colorRectangle;
		private MouseState currentState = MouseState.MouseUp;
		private Color fullColor;
		private Graphics g;
		private Color selectedColor = Color.White;

		public ColorWheel(Rectangle colorRectangle, Rectangle brightnessRectangle, Rectangle selectedColorRectangle)
		{
			// Caller must provide locations for color wheel
			// (colorRectangle), brightness "strip" (brightnessRectangle)
			// and location to display selected color (selectedColorRectangle).

			using (var path = new GraphicsPath())
			{
				// Store away locations for later use. 
				this.colorRectangle = colorRectangle;
				this.brightnessRectangle = brightnessRectangle;
				this.selectedColorRectangle = selectedColorRectangle;

				// Calculate the center of the circle.
				// Start with the location, then offset
				// the point by the radius.
				// Use the smaller of the width and height of
				// the colorRectangle value.
				radius = Math.Min(colorRectangle.Width, colorRectangle.Height) / 2;
				centerPoint = colorRectangle.Location;
				centerPoint.Offset(radius, radius);

				// Start the pointer in the center.
				colorPoint = centerPoint;

				// Create a region corresponding to the color circle.
				// Code uses this later to determine if a specified
				// point is within the region, using the IsVisible 
				// method.
				path.AddEllipse(colorRectangle);
				colorRegion = new Region(path);

				// set { the range for the brightness selector.
				brightnessMin = this.brightnessRectangle.Top;
				brightnessMax = this.brightnessRectangle.Bottom;

				// Create a region corresponding to the
				// brightness rectangle, with a little extra 
				// "breathing room". 

				path.AddRectangle(new Rectangle(brightnessRectangle.Left, brightnessRectangle.Top - 10,
					brightnessRectangle.Width + 10, brightnessRectangle.Height + 20));
				// Create region corresponding to brightness
				// rectangle. Later code uses this to 
				// determine if a specified point is within
				// the region, using the IsVisible method.
				brightnessRegion = new Region(path);

				// Set the location for the brightness indicator "marker".
				// Also calculate the scaling factor, scaling the height
				// to be between 0 and 255. 
				brightnessX = brightnessRectangle.Left + brightnessRectangle.Width;
				brightnessScaling = (double)255 / (brightnessMax - brightnessMin);

				// Calculate the location of the brightness
				// pointer. Assume it's at the highest position.
				brightnessPoint = new Point(brightnessX, brightnessMax);

				// Create the bitmap that contains the circular gradient.
				CreateGradient();
			}
		}

		public Color Color
		{
			get { return selectedColor; }
		}

		#region IDisposable Members

		void IDisposable.Dispose()
		{
			// Dispose of graphic resources
			if (colorImage != null)
				colorImage.Dispose();
			if (colorRegion != null)
				colorRegion.Dispose();
			if (brightnessRegion != null)
				brightnessRegion.Dispose();
			if (g != null)
				g.Dispose();
		}

		#endregion

		protected void OnColorChanged(ColorHandler.ARGB argb, ColorHandler.HSV HSV)
		{
			var e = new ColorChangedEventArgs(argb, HSV);
			ColorChanged(this, e);
		}

		public void SetMouseUp()
		{
			// Indicate that the user has
			// released the mouse.
			currentState = MouseState.MouseUp;
		}

		public void Draw(Graphics g, ColorHandler.HSV HSV)
		{
			// Given HSV values, update the screen.
			this.g = g;
			this.HSV = HSV;
			CalcCoordsAndUpdate(this.HSV);
			UpdateDisplay();
		}

		public void Draw(Graphics g, ColorHandler.ARGB argb)
		{
			// Given RGB values, calculate HSV and then update the screen.
			this.g = g;
			HSV = ColorHandler.RGBtoHSV(argb);
			CalcCoordsAndUpdate(HSV);
			UpdateDisplay();
		}

		public void Draw(Graphics g, Point mousePoint)
		{
			// You've moved the mouse. 
			// Now update the screen to match.

			// Keep track of the previous color pointer point, 
			// so you can put the mouse there in case the 
			// user has clicked outside the circle.
			Point newColorPoint = colorPoint;
			Point newBrightnessPoint = brightnessPoint;

			// Store this away for later use.
			this.g = g;

			if (currentState == MouseState.MouseUp)
			{
				if (!mousePoint.IsEmpty)
				{
					if (colorRegion.IsVisible(mousePoint))
					{
						// Is the mouse point within the color circle?
						// If so, you just clicked on the color wheel.
						currentState = MouseState.ClickOnColor;
					}
					else if (brightnessRegion.IsVisible(mousePoint))
					{
						// Is the mouse point within the brightness area?
						// You clicked on the brightness area.
						currentState = MouseState.ClickOnBrightness;
					}
					else
					{
						// Clicked outside the color and the brightness
						// regions. In that case, just put the 
						// pointers back where they were.
						currentState = MouseState.ClickOutsideRegion;
					}
				}
			}

			switch (currentState)
			{
				case MouseState.ClickOnBrightness:
				case MouseState.DragInBrightness:
					// Calculate new color information
					// based on the brightness, which may have changed.
					Point newPoint = mousePoint;
					if (newPoint.Y < brightnessMin)
					{
						newPoint.Y = brightnessMin;
					}
					else if (newPoint.Y > brightnessMax)
					{
						newPoint.Y = brightnessMax;
					}
					newBrightnessPoint = new Point(brightnessX, newPoint.Y);
					brightness = (int)((brightnessMax - newPoint.Y) * brightnessScaling);
					HSV.Value = brightness;
					argb = ColorHandler.HSVtoRGB(HSV);
					break;

				case MouseState.ClickOnColor:
				case MouseState.DragInColor:
					// Calculate new color information
					// based on selected color, which may have changed.
					newColorPoint = mousePoint;

					// Calculate x and y distance from the center,
					// and then calculate the angle corresponding to the
					// new location.
					Point delta = new Point(
						mousePoint.X - centerPoint.X, mousePoint.Y - centerPoint.Y);
					int degrees = CalcDegrees(delta);

					// Calculate distance from the center to the new point 
					// as a fraction of the radius. Use your old friend, 
					// the Pythagorean theorem, to calculate this value.
					double distance = Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y) / radius;

					if (currentState == MouseState.DragInColor)
					{
						if (distance > 1)
						{
							// Mouse is down, and outside the circle, but you 
							// were previously dragging in the color circle. 
							// What to do?
							// In that case, move the point to the edge of the 
							// circle at the correct angle.
							distance = 1;
							newColorPoint = GetPoint(degrees, radius, centerPoint);
						}
					}

					// Calculate the new HSV and RGB values.
					HSV.Hue = (degrees * 255 / 360);
					HSV.Saturation = (int)(distance * 255);
					HSV.Value = brightness;
					argb = ColorHandler.HSVtoRGB(HSV);
					fullColor = ColorHandler.HSVtoColor(HSV.Alpha, HSV.Hue, HSV.Saturation, 255);
					break;
			}
			selectedColor = ColorHandler.HSVtoColor(HSV);

			// Raise an event back to the parent form,
			// so the form can update any UI it's using 
			// to display selected color values.
			OnColorChanged(argb, HSV);

			// On the way out, set the new state.
			switch (currentState)
			{
				case MouseState.ClickOnBrightness:
					currentState = MouseState.DragInBrightness;
					break;
				case MouseState.ClickOnColor:
					currentState = MouseState.DragInColor;
					break;
				case MouseState.ClickOutsideRegion:
					currentState = MouseState.DragOutsideRegion;
					break;
			}

			// Store away the current points for next time.
			colorPoint = newColorPoint;
			brightnessPoint = newBrightnessPoint;

			// Draw the gradients and points. 
			UpdateDisplay();
		}

		private Point CalcBrightnessPoint(int brightness)
		{
			// Take the value for brightness (0 to 255), scale to the 
			// scaling used in the brightness bar, then add the value 
			// to the bottom of the bar. return the correct point at which 
			// to display the brightness pointer.
			return new Point(brightnessX,
				(int)(brightnessMax - brightness / brightnessScaling));
		}

		private void UpdateDisplay()
		{
			// Update the gradients, and place the 
			// pointers correctly based on colors and 
			// brightness.

			using (Brush selectedBrush = new SolidBrush(selectedColor))
			{
				// Draw the saved color wheel image.
				g.DrawImage(colorImage, colorRectangle);

				// Draw the "selected color" rectangle.
				using (TextureBrush textureBrush = 
					new TextureBrush(Properties.Resources.bg))
				{
					g.FillRectangle(textureBrush, selectedColorRectangle);
				}
				g.FillRectangle(selectedBrush, selectedColorRectangle);
				g.DrawRectangle(Pens.Black, selectedColorRectangle);
				// Draw the "brightness" rectangle.
				DrawLinearGradient(fullColor);
				// Draw the two pointers.
				DrawColorPointer(colorPoint);
				DrawBrightnessPointer(brightnessPoint);
			}
		}

		private void CalcCoordsAndUpdate(ColorHandler.HSV HSV)
		{
			// Convert color to real-world coordinates and then calculate
			// the various points. HSV.Hue represents the degrees (0 to 360), 
			// HSV.Saturation represents the radius. 
			// This procedure doesn't draw anything--it simply 
			// updates class-level variables. The UpdateDisplay
			// procedure uses these values to update the screen.

			// Given the angle (HSV.Hue), and distance from 
			// the center (HSV.Saturation), and the center, 
			// calculate the point corresponding to 
			// the selected color, on the color wheel.
			colorPoint = GetPoint((double)HSV.Hue / 255 * 360,
				(double)HSV.Saturation / 255 * radius,
				centerPoint);

			// Given the brightness (HSV.value), calculate the 
			// point corresponding to the brightness indicator.
			brightnessPoint = CalcBrightnessPoint(HSV.Value);

			// Store information about the selected color.
			brightness = HSV.Value;
			selectedColor = ColorHandler.HSVtoColor(HSV);
			argb = ColorHandler.HSVtoRGB(HSV);

			// The full color is the same as HSV, except that the 
			// brightness is set to full (255). This is the top-most
			// color in the brightness gradient.
			fullColor = ColorHandler.HSVtoColor(HSV.Alpha, HSV.Hue, HSV.Saturation, 255);
		}

		private void DrawLinearGradient(Color TopColor)
		{
			// Given the top color, draw a linear gradient
			// ranging from black to the top color. Use the 
			// brightness rectangle as the area to fill.
			using (var lgb =
				new LinearGradientBrush(brightnessRectangle, TopColor,
					Color.Black, LinearGradientMode.Vertical))
			{
				g.FillRectangle(lgb, brightnessRectangle);
			}
		}

		private int CalcDegrees(Point pt)
		{
			int degrees;

			if (pt.X == 0)
			{
				// The point is on the y-axis. Determine whether 
				// it's above or below the x-axis, and return the 
				// corresponding angle. Note that the orientation of the
				// y-coordinate is backwards. That is, A positive Y value 
				// indicates a point BELOW the x-axis.
				if (pt.Y > 0)
				{
					degrees = 270;
				}
				else
				{
					degrees = 90;
				}
			}
			else
			{
				// This value needs to be multiplied
				// by -1 because the y-coordinate
				// is opposite from the normal direction here.
				// That is, a y-coordinate that's "higher" on 
				// the form has a lower y-value, in this coordinate
				// system. So everything's off by a factor of -1 when
				// performing the ratio calculations.
				degrees = (int)(-Math.Atan((double)pt.Y / pt.X) * DEGREES_PER_RADIAN);

				// If the x-coordinate of the selected point
				// is to the left of the center of the circle, you 
				// need to add 180 degrees to the angle. ArcTan only
				// gives you a value on the right-hand side of the circle.
				if (pt.X < 0)
				{
					degrees += 180;
				}

				// Ensure that the return value is 
				// between 0 and 360.
				degrees = (degrees + 360) % 360;
			}
			return degrees;
		}

		private void CreateGradient()
		{
			// Create a new PathGradientBrush, supplying
			// an array of points created by calling
			// the GetPoints method.
			using (var pgb =
				new PathGradientBrush(GetPoints(radius, new Point(radius, radius))))
			{
				// Set the various properties. Note the SurroundColors
				// property, which contains an array of points, 
				// in a one-to-one relationship with the points
				// that created the gradient.
				pgb.CenterColor = Color.White;
				pgb.CenterPoint = new PointF(radius, radius);
				pgb.SurroundColors = GetColors();

				// Create a new bitmap containing
				// the color wheel gradient, so the 
				// code only needs to do all this 
				// work once. Later code uses the bitmap
				// rather than recreating the gradient.
				colorImage = new Bitmap(
					colorRectangle.Width, colorRectangle.Height,
					PixelFormat.Format32bppArgb);

				using (Graphics newGraphics =
					Graphics.FromImage(colorImage))
				{
					newGraphics.FillEllipse(pgb, 0, 0,
						colorRectangle.Width, colorRectangle.Height);
				}
			}
		}

		private Color[] GetColors()
		{
			// Create an array of COLOR_COUNT
			// colors, looping through all the 
			// hues between 0 and 255, broken
			// into COLOR_COUNT intervals. HSV is
			// particularly well-suited for this, 
			// because the only value that changes
			// as you create colors is the Hue.
			var Colors = new Color[COLOR_COUNT];

			for (int i = 0; i <= COLOR_COUNT - 1; i++)
				Colors[i] = ColorHandler.HSVtoColor(255, (int)((double)(i * 255) / COLOR_COUNT), 255, 255);
			return Colors;
		}

		private Point[] GetPoints(double radius, Point centerPoint)
		{
			// Generate the array of points that describe
			// the locations of the COLOR_COUNT colors to be 
			// displayed on the color wheel.
			var Points = new Point[COLOR_COUNT];

			for (int i = 0; i <= COLOR_COUNT - 1; i++)
				Points[i] = GetPoint((double)(i * 360) / COLOR_COUNT, radius, centerPoint);
			return Points;
		}

		private Point GetPoint(double degrees, double radius, Point centerPoint)
		{
			// Given the center of a circle and its radius, along
			// with the angle corresponding to the point, find the coordinates. 
			// In other words, conver  t from polar to rectangular coordinates.
			double radians = degrees / DEGREES_PER_RADIAN;

			return new Point((int)(centerPoint.X + Math.Floor(radius * Math.Cos(radians))),
				(int)(centerPoint.Y - Math.Floor(radius * Math.Sin(radians))));
		}

		private void DrawColorPointer(Point pt)
		{
			// Given a point, draw the color selector. 
			// The constant SIZE represents half
			// the width -- the square will be twice
			// this value in width and height.
			const int SIZE = 3;
			g.DrawRectangle(Pens.Black,
				pt.X - SIZE, pt.Y - SIZE, SIZE * 2, SIZE * 2);
		}

		private void DrawBrightnessPointer(Point pt)
		{
			// Draw a triangle for the 
			// brightness indicator that "points"
			// at the provided point.
			const int HEIGHT = 10;
			const int WIDTH = 7;

			var Points = new Point[3];
			Points[0] = pt;
			Points[1] = new Point(pt.X + WIDTH, pt.Y + HEIGHT / 2);
			Points[2] = new Point(pt.X + WIDTH, pt.Y - HEIGHT / 2);
			g.FillPolygon(Brushes.Black, Points);
		}
	}

	public class ColorHandler
	{
		// Handle conversions between RGB and HSV    
		// (and Color types, as well).

		public static ARGB HSVtoRGB(int a, int h, int s, int v)
		{
			// H, S, and V must all be between 0 and 255.
			return HSVtoRGB(new HSV(a, h, s, v));
		}

		public static Color HSVtoColor(HSV hsv)
		{
			ARGB argb = HSVtoRGB(hsv);
			return Color.FromArgb(argb.Alpha, argb.Red, argb.Green, argb.Blue);
		}

		public static Color HSVtoColor(int a, int h, int s, int v)
		{
			return HSVtoColor(new HSV(a, h, s, v));
		}

		public static ARGB HSVtoRGB(HSV HSV)
		{
			// HSV contains values scaled as in the color wheel:
			// that is, all from 0 to 255. 

			// for ( this code to work, HSV.Hue needs
			// to be scaled from 0 to 360 (it//s the angle of the selected
			// point within the circle). HSV.Saturation and HSV.value must be 
			// scaled to be between 0 and 1.

			double h;
			double s;
			double v;

			double r = 0;
			double g = 0;
			double b = 0;

			// Scale Hue to be between 0 and 360. Saturation
			// and value scale to be between 0 and 1.
			h = ((double)HSV.Hue / 255 * 360) % 360;
			s = (double)HSV.Saturation / 255;
			v = (double)HSV.Value / 255;

			if (s == 0)
			{
				// If s is 0, all colors are the same.
				// This is some flavor of gray.
				r = v;
				g = v;
				b = v;
			}
			else
			{
				// The color wheel consists of 6 sectors.
				// Figure out which sector you//re in.
				double sectorPos = h / 60;
				int sectorNumber = (int)(Math.Floor(sectorPos));

				// get the fractional part of the sector.
				// That is, how many degrees into the sector
				// are you?
				double fractionalSector = sectorPos - sectorNumber;

				// Calculate values for the three axes
				// of the color. 
				double p = v * (1 - s);
				double q = v * (1 - (s * fractionalSector));
				double t = v * (1 - (s * (1 - fractionalSector)));

				// Assign the fractional colors to r, g, and b
				// based on the sector the angle is in.
				switch (sectorNumber)
				{
					case 0:
						r = v;
						g = t;
						b = p;
						break;

					case 1:
						r = q;
						g = v;
						b = p;
						break;

					case 2:
						r = p;
						g = v;
						b = t;
						break;

					case 3:
						r = p;
						g = q;
						b = v;
						break;

					case 4:
						r = t;
						g = p;
						b = v;
						break;

					case 5:
						r = v;
						g = p;
						b = q;
						break;
				}
			}
			// return an RGB structure, with values scaled
			// to be between 0 and 255.
			return new ARGB(HSV.Alpha, (int)(r * 255), (int)(g * 255), (int)(b * 255));
		}

		public static HSV RGBtoHSV(ARGB argb)
		{
			// In this function, R, G, and B values must be scaled 
			// to be between 0 and 1.
			// HSV.Hue will be a value between 0 and 360, and 
			// HSV.Saturation and value are between 0 and 1.
			// The code must scale these to be between 0 and 255 for
			// the purposes of this application.

			double r = (double)argb.Red / 255;
			double g = (double)argb.Green / 255;
			double b = (double)argb.Blue / 255;

			double h;
			double s;
			double v;

			double min = Math.Min(Math.Min(r, g), b);
			double max = Math.Max(Math.Max(r, g), b);
			v = max;
			double delta = max - min;
			if (max == 0 || delta == 0)
			{
				// R, G, and B must be 0, or all the same.
				// In this case, S is 0, and H is undefined.
				// Using H = 0 is as good as any...
				s = 0;
				h = 0;
			}
			else
			{
				s = delta / max;
				if (r == max)
				{
					// Between Yellow and Magenta
					h = (g - b) / delta;
				}
				else if (g == max)
				{
					// Between Cyan and Yellow
					h = 2 + (b - r) / delta;
				}
				else
				{
					// Between Magenta and Cyan
					h = 4 + (r - g) / delta;
				}
			}
			// Scale h to be between 0 and 360. 
			// This may require adding 360, if the value
			// is negative.
			h *= 60;
			if (h < 0)
			{
				h += 360;
			}

			// Scale to the requirements of this 
			// application. All values are between 0 and 255.
			return new HSV(argb.Alpha, (int)(h / 360 * 255), (int)(s * 255), (int)(v * 255));
		}

		#region Nested type: ARGB

		public struct ARGB
		{
			// All values are between 0 and 255.
			public ARGB(int a, int r, int g, int b)
				: this()
			{
				Alpha = a;
				Red = r;
				Green = g;
				Blue = b;
			}

			public int Alpha { get; set; }
			public int Red { get; set; }
			public int Green { get; set; }
			public int Blue { get; set; }

			public override string ToString()
			{
				return String.Format("({0}, {1}, {2} {3})", Alpha, Red, Green, Blue);
			}
		}

		#endregion

		#region Nested type: HSV

		public struct HSV
		{
			// All values are between 0 and 255.
			public HSV(int a, int h, int s, int v)
				: this()
			{
				Alpha = a;
				Hue = h;
				Saturation = s;
				Value = v;
			}

			public int Alpha { get; set; }
			public int Hue { get; set; }
			public int Saturation { get; set; }
			public int Value { get; set; }

			public override string ToString()
			{
				return String.Format("({0}, {1}, {2})", Hue, Saturation, Value);
			}
		}

		#endregion
	}

	public class ColorChangedEventArgs : EventArgs
	{
		public ColorChangedEventArgs(ColorHandler.ARGB argb, ColorHandler.HSV HSV)
		{
			ARGB = argb;
			this.HSV = HSV;
		}

		public ColorHandler.ARGB ARGB { get; private set; }

		public ColorHandler.HSV HSV { get; private set; }
	}
}
