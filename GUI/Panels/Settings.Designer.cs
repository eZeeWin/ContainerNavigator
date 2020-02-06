namespace ContainerNavigator.GUI.Panels
{
    partial class Settings
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TitleLocation = new System.Windows.Forms.Label();
            this.Location = new System.Windows.Forms.Button();
            this.ShowGUI = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // TitleLocation
            // 
            this.TitleLocation.AutoSize = true;
            this.TitleLocation.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleLocation.Location = new System.Drawing.Point(3, 3);
            this.TitleLocation.Name = "TitleLocation";
            this.TitleLocation.Size = new System.Drawing.Size(119, 37);
            this.TitleLocation.TabIndex = 0;
            this.TitleLocation.Text = "Location";
            // 
            // Location
            // 
            this.Location.FlatAppearance.BorderSize = 3;
            this.Location.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Location.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location.Location = new System.Drawing.Point(128, 3);
            this.Location.Name = "Location";
            this.Location.Size = new System.Drawing.Size(465, 37);
            this.Location.TabIndex = 1;
            this.Location.UseVisualStyleBackColor = true;
            this.Location.Click += new System.EventHandler(this.Location_Click);
            // 
            // ShowGUI
            // 
            this.ShowGUI.AutoSize = true;
            this.ShowGUI.Checked = true;
            this.ShowGUI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowGUI.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowGUI.Location = new System.Drawing.Point(0, 46);
            this.ShowGUI.Name = "ShowGUI";
            this.ShowGUI.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowGUI.Size = new System.Drawing.Size(153, 41);
            this.ShowGUI.TabIndex = 2;
            this.ShowGUI.Text = "Show GUI";
            this.ShowGUI.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ForeColor = System.Drawing.Color.Black;
            this.Controls.Add(this.ShowGUI);
            this.Controls.Add(this.Location);
            this.Controls.Add(this.TitleLocation);
            this.Name = "General";
            this.Size = new System.Drawing.Size(930, 399);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLocation;
        private System.Windows.Forms.Button Location;
        private System.Windows.Forms.CheckBox ShowGUI;
    }
}
