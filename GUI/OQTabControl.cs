using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace ContainerNavigator.GUI
{
    class OQTabControl : Control
    {
        [Category("Appearance"), Description("")]
        public Color SelectedColor { get; set; }
        [Category("Appearance")]
        public Color UnselectedColor { get; set; }
        [Category("Appearance")]
        public Color HoverColor { get; set; }
        [Category("Appearance")]
        public int Thickness {
            get => _Thickness;
            set {
                _Thickness = value;
                RenderPanel();
            }
        }
        [Category("Appearance")]
        public int Space { get; set; } = 80;
        public PanelCollection Panels {
            get => _Panels;
            set => _Panels = value;
        }
        [ReadOnly(true), Browsable(false)]
        public int SelectedIndex {
            get => _SelectedIndex;
            set {
                Graphics e = CreateGraphics();
                e.FillRectangle(new SolidBrush(UnselectedColor), HoverIndex * Space, Font.Height + 10, Space, Thickness);
                if (_SelectedIndex != -1) e.FillRectangle(new SolidBrush(UnselectedColor), _SelectedIndex * Space, Font.Height + 10, Space, Thickness);
                Panel.Controls.Clear();
                _SelectedIndex = value;
                Panel.Controls.Add(Panels[_SelectedIndex]);
                e.FillRectangle(new SolidBrush(SelectedColor), _SelectedIndex * Space, Font.Height + 10, Space, Thickness);
            }
        }

        private int _Thickness = 4;
        private int _SelectedIndex = -1;
        private int HoverIndex = -1;
        private Panel Panel;
        private PanelCollection _Panels = new PanelCollection();

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Brush brush = new SolidBrush(ForeColor);
            e.Graphics.FillRectangle(new SolidBrush(UnselectedColor), 0, Font.Height + 10, Width, Thickness);

            for (int i = 0; i < Panels.Count; i++)
                e.Graphics.DrawString(_Panels[i].Name, Font, brush, i * Space, 4);

            if (Panels.Count != 0) SelectedIndex = 0;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            Point point = new Point(e.Location.X / Space, e.Location.Y);

            if (point.X == _SelectedIndex) return; 

            Graphics g = CreateGraphics();
            bool valid = point.X < _Panels.Count && point.Y > 0 && point.Y < Font.Height + 10;
            if (valid && point.X != HoverIndex)
            {
                if (HoverIndex != -1) g.FillRectangle(new SolidBrush(UnselectedColor), HoverIndex * Space, Font.Height + 10, Space, Thickness);
                HoverIndex = point.X;
                g.FillRectangle(new SolidBrush(HoverColor), HoverIndex * Space, Font.Height + 10, Space, Thickness);
            }
            else if (!valid && HoverIndex != -1)
            {
                g.FillRectangle(new SolidBrush(UnselectedColor), HoverIndex * Space, Font.Height + 10, Space, Thickness);
                HoverIndex = -1;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            if (HoverIndex == -1) return;
            SelectedIndex = HoverIndex;
            HoverIndex = -1;
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            RenderPanel();
        }

        private void RenderPanel()
        {
            Panel = new Panel
            {
                Location = new Point(0, Font.Height + 10 + Thickness),
                Size = new Size(Width, Height - (Font.Height + 10 + Thickness)),
                Visible = true
            };
            Controls.Clear();
            Controls.Add(Panel);
        }

        public class PanelCollection : ICollection<Panel>, IList<Panel>, IEnumerable<Panel>
        {
            private List<Panel> panels = new List<Panel>();

            public Panel this[int index] { get => panels[index]; set => panels[index] = value; }
            public int Count => panels.Count;
            public bool IsReadOnly => false;
            public void Add(Panel panel) => panels.Add(panel);
            public void Clear() => panels.Clear();
            public bool Contains(Panel panel) => panels.Contains(panel);
            public void CopyTo(Panel[] array, int arrayIndex = 0) => panels.CopyTo(array, arrayIndex);
            public IEnumerator<Panel> GetEnumerator() => panels.GetEnumerator();
            public int IndexOf(Panel panel) => panels.IndexOf(panel);
            public void Insert(int index, Panel panel) => panels.Insert(index, panel);
            public bool Remove(Panel panel) => panels.Remove(panel);
            public void RemoveAt(int index) => panels.RemoveAt(index);
            IEnumerator IEnumerable.GetEnumerator() => panels.GetEnumerator();
            public override string ToString() => "(Collection)";
        }
    }
}
