using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContainerNavigator.GUI
{
    public partial class MainDialog : Form
    {
        // The location of a container image
        public string ImageLocation;
        // The "ShowGUI" setting
        public bool ShowGUI = true;

#pragma warning disable CS0108 // Disables Warning
        // If the left mouse button is down
        private bool MouseDown = false;
#pragma warning restore CS0108 // Restores Warning
        // Old Location of the mouse
        private Point OldLocation;

        // Constructor
        public MainDialog(string ImageLocation)
        { 
            // Runs designer method
            InitializeComponent();

            // Adds Settings Panel (General Tab)
            MainPanel.Panels.Add(new Panels.Settings());

            // Adds Creator Panel (Creator Tab)

            // Sets variable
            this.ImageLocation = ImageLocation;

            // Subscribes "Close" Method to BtnExit click event
            BtnExit.Click += (s, e) => Close();

            // Draws "X" on BtnExit to the BtnExit paint event
            BtnExit.Paint += (s, e) => e.Graphics.DrawString("X", BtnExit.Font, Brushes.WhiteSmoke, 1, -5);

            // Subscribes Title MouseMove
            Title.MouseMove += (s, e) => OnMouseMove(e);

            // Subscribes Title MouseDown
            Title.MouseDown += (s, e) => OnMouseDown(e);

            // Subscribes Title MouseUp
            Title.MouseUp += (s, e) => OnMouseUp(e);
        }

        // OnPaint derived & overriden method from "Form" 
        protected override void OnPaint(PaintEventArgs e)
        {
            // Runs method from base type
            base.OnPaint(e);

            // Creates top rectangle
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(250, 106, 0)), new Rectangle(0, 0, 954, 5));
        }

        // The draggable panel code

        // OnMouseDown derived & overriden method from "Form" 
        protected override void OnMouseDown(MouseEventArgs e)
        {
            // Runs method from base type
            base.OnMouseDown(e);
            // Checks the mouse button being pressed
            if (e.Button != MouseButtons.Left) 
                // If the left button isn't pressed
                return;
            // Sets MouseDown to "true"
            MouseDown = true;
            // Sets OldLocation to the mouse's current location
            OldLocation = e.Location;
        }

        // OnMouseUp derived & overriden method from "Form" 
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // Runs method from base type
            base.OnMouseUp(e);
            // Checks if the mouse button pressed is the left mouse button
            if (e.Button == MouseButtons.Left) 
                // Sets MouseDown to "false"
                MouseDown = false;
        }

        // OnMouseMove derived & overriden method from "Form" 
        protected override void OnMouseMove(MouseEventArgs e)
        {
            // Runs method from base type
            base.OnMouseMove(e);
            // Checks if MouseDown is "true"
            if (MouseDown) 
                // If MouseDown is "true"
                Location = new Point
                    // Sets the new X
                    (Location.X - OldLocation.X + e.X,
                    // Sets the new Y
                    Location.Y - OldLocation.Y + e.Y);
        }
    }
}
