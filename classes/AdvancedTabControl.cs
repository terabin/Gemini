using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Gemini
{
  public partial class AdvancedTabControl : TabControl
  {
    private TabPage _tabBeforeClick;
    private Point _dragEntryPoint;

    public AdvancedTabControl()
    {
      InitializeComponent();
      this.imageList.Images.Add((Image)Gemini.Properties.Resources.CloseTab0);
      this.imageList.Images.Add((Image)Gemini.Properties.Resources.CloseTab1);
      this.imageList.Images.Add((Image)Gemini.Properties.Resources.CloseTab2);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      if (e.KeyData.ToString() == "W, Control")
      {
        e.SuppressKeyPress = true;
        e.Handled = true;
        if (SelectedTab != null) TabPageRemove(SelectedTab);
      }
    }

    protected override void OnDragOver(DragEventArgs e)
    {
      base.OnDragOver(e);
      Point p = PointToClient(new Point(e.X, e.Y));
      TabPage hoverTab = TabPageFromPoint(p);
      TabPage dragTab = (TabPage)e.Data.GetData(typeof(TabPage));
      if (hoverTab != null && dragTab != null)
      {
        e.Effect = DragDropEffects.Move;
        int hoverIndex = TabPages.IndexOf(hoverTab);
        int dragIndex = TabPages.IndexOf(dragTab);
        if (hoverIndex != dragIndex && (hoverIndex < dragIndex ? _dragEntryPoint.X > p.X : _dragEntryPoint.X < p.X))
        {
          _dragEntryPoint = p;
          TabPages.Remove(dragTab);
          TabPages.Insert(hoverIndex, dragTab);
          SelectedTab = dragTab;
        }
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (e.Button == MouseButtons.Left)
      {
        TabPage tp = TabPageFromPoint(e.Location);
        if (tp != null)
        {
          if (tp.ImageIndex == 0)
          {
            _dragEntryPoint = e.Location;
            DoDragDrop(tp, DragDropEffects.All);
          }
          else if (tp.ImageIndex == 1)
          {
            tp.ImageIndex = 2;
            SelectedTab = _tabBeforeClick;
          }
        }
      }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      TabPage tp = TabPageFromPoint(e.Location);
      if (tp != null)
      {
        if (e.Button == MouseButtons.Left)
        {
          foreach (TabPage tp_ in TabPages)
            if (tp_.ImageIndex != 0)
            {
              int i = (tp == tp_ && IsOverCloseButton(e.Location)) ? 2 : 1;
              if (tp_.ImageIndex != i) tp_.ImageIndex = i;
              break;
            }
        }
        else
        {
          foreach (TabPage tp_ in TabPages)
            if (tp != tp_ && tp_.ImageIndex != 0) tp_.ImageIndex = 0;
          int i = IsOverCloseButton(e.Location) ? 1 : 0;
          if (tp.ImageIndex != i) tp.ImageIndex = i;
          _tabBeforeClick = SelectedTab;
        }
      }
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      foreach (TabPage tp in TabPages)
        if (tp.ImageIndex != 0) tp.ImageIndex = 0;
    }

    protected override void OnMouseClick(MouseEventArgs e)
    {
      base.OnMouseClick(e);
      TabPage tp = TabPageFromPoint(e.Location);
      if (tp != null && ((e.Button == MouseButtons.Left && tp.ImageIndex == 2) || e.Button == MouseButtons.Middle))
        TabPageRemove(tp);
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
      base.OnControlAdded(e);
      ((TabPage)e.Control).ImageIndex = 0;
    }

    public bool IsOverCloseButton(Point p)
    {
      Rectangle r = GetTabRect(TabPages.IndexOf(TabPageFromPoint(p)));
      int x = p.X - r.X, y = p.Y - r.Y;
      return x > 4 && x < 24 && y > 1 && y < 17;
    }

    public TabPage TabPageFromPoint(Point p)
    {
      for (int i = 0; i < TabPages.Count; i++)
        if (GetTabRect(i).Contains(p)) return TabPages[i];
      return null;
    }

    public void TabPageRemove(TabPage tp)
    {
      int i = SelectedTab == tp ? SelectedIndex == TabCount - 1 ? SelectedIndex - 1 : SelectedIndex : -1;
      if (TabPageRemoving != null)
      {
        TabControlCancelEventArgs tccea = new TabControlCancelEventArgs(tp, TabPages.IndexOf(tp), false, TabControlAction.Deselecting);
        TabPageRemoving(this, tccea);
        if (tccea.Cancel) return;
      }
      TabPages.Remove(tp);
      if (i >= 0) SelectedIndex = i;
    }

    public void TabPageRemoveAt(int index)
    {
      TabPageRemove(TabPages[index]);
    }

    public void TabPageRemoveByKey(string key)
    {
      TabPageRemove(TabPages[key]);
    }

    [Category("Behavior")]
    public event TabPageRemovingEventHandler TabPageRemoving;
    public delegate void TabPageRemovingEventHandler(object sender, TabControlCancelEventArgs e);

  }


}