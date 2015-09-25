using System;
using System.Drawing;
using System.Windows.Forms;

namespace Gemini.Rendering
{
  public class ToolStripRenderer : ToolStripSystemRenderer
  {
    protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
    {
      //base.OnRenderToolStripBorder(e);
    }

    protected override void OnRenderToolStripBackground(ToolStripRenderEventArgs e)
    {
      ToolStripDropDown dr = e.ToolStrip as ToolStripDropDown;

      if (dr != null)
      {
        e.Graphics.FillRectangle(SystemBrushes.Control, e.AffectedBounds);
      }
    }
  }
}
