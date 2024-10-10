namespace GestionAcademica.UI.Desktop
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.itemMenuAdministracion = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.itemMenuVentanas = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMenuAdministracion,
            this.itemMenuVentanas});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.MdiWindowListItem = this.itemMenuVentanas;
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(800, 33);
            this.mainMenu.TabIndex = 1;
            this.mainMenu.Text = "mainMenu";
            // 
            // itemMenuAdministracion
            // 
            this.itemMenuAdministracion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemMenuEspecialidades});
            this.itemMenuAdministracion.Name = "itemMenuAdministracion";
            this.itemMenuAdministracion.Size = new System.Drawing.Size(147, 29);
            this.itemMenuAdministracion.Text = "&Administración";
            // 
            // itemMenuEspecialidades
            // 
            this.itemMenuEspecialidades.Name = "itemMenuEspecialidades";
            this.itemMenuEspecialidades.Size = new System.Drawing.Size(228, 34);
            this.itemMenuEspecialidades.Text = "&Especialidades";
            this.itemMenuEspecialidades.Click += new System.EventHandler(this.itemMenuEspecialidades_Click);
            // 
            // itemMenuVentanas
            // 
            this.itemMenuVentanas.Name = "itemMenuVentanas";
            this.itemMenuVentanas.Size = new System.Drawing.Size(99, 29);
            this.itemMenuVentanas.Text = "&Ventanas";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.mainMenu);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "[SGA] Sistema de Gestión Académica";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip mainMenu;
        private ToolStripMenuItem itemMenuAdministracion;
        private ToolStripMenuItem itemMenuEspecialidades;
        private ToolStripMenuItem itemMenuVentanas;
    }
}