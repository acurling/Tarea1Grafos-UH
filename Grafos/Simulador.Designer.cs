
namespace Grafos
{
    partial class Simulador
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
            this.components = new System.ComponentModel.Container();
            this.CMSCrearVertice = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.nuevoVertice = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarVertice = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminarArco = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.Pizarra = new System.Windows.Forms.Panel();
            this.CMSCrearVertice.SuspendLayout();
            this.SuspendLayout();
            // 
            // CMSCrearVertice
            // 
            this.CMSCrearVertice.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CMSCrearVertice.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoVertice,
            this.eliminarVertice,
            this.eliminarArco});
            this.CMSCrearVertice.Name = "contextMenuStrip1";
            this.CMSCrearVertice.Size = new System.Drawing.Size(182, 76);
            this.CMSCrearVertice.Opening += new System.ComponentModel.CancelEventHandler(this.CMSCrearVertice_Opening);
            // 
            // nuevoVertice
            // 
            this.nuevoVertice.AccessibleName = "CMSCrearVertice";
            this.nuevoVertice.Name = "nuevoVertice";
            this.nuevoVertice.Size = new System.Drawing.Size(181, 24);
            this.nuevoVertice.Text = "Nuevo Vertice";
            this.nuevoVertice.Click += new System.EventHandler(this.nuevoVertice_Click);
            // 
            // eliminarVertice
            // 
            this.eliminarVertice.Name = "eliminarVertice";
            this.eliminarVertice.Size = new System.Drawing.Size(181, 24);
            this.eliminarVertice.Text = "Eliminar Vertice";
            this.eliminarVertice.Click += new System.EventHandler(this.EliminarVertice_Click);
            // 
            // eliminarArco
            // 
            this.eliminarArco.Name = "eliminarArco";
            this.eliminarArco.Size = new System.Drawing.Size(181, 24);
            this.eliminarArco.Text = "Eliminar Arco";
            this.eliminarArco.Click += new System.EventHandler(this.EliminarArco_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(57, 28);
            this.label1.MinimumSize = new System.Drawing.Size(800, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(800, 57);
            this.label1.TabIndex = 1;
            this.label1.Text = "Simulador de Grafos";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Pizarra
            // 
            this.Pizarra.Location = new System.Drawing.Point(43, 129);
            this.Pizarra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Pizarra.Name = "Pizarra";
            this.Pizarra.Size = new System.Drawing.Size(841, 455);
            this.Pizarra.TabIndex = 2;
            this.Pizarra.Paint += new System.Windows.Forms.PaintEventHandler(this.Pizarra_Paint);
            this.Pizarra.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseDown);
            this.Pizarra.MouseLeave += new System.EventHandler(this.Pizarra_MouseLeave);
            this.Pizarra.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseMove);
            this.Pizarra.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Pizarra_MouseUp);
            // 
            // Simulador
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 600);
            this.Controls.Add(this.Pizarra);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Simulador";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Pizarra_Load);
            this.CMSCrearVertice.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip CMSCrearVertice;
        private System.Windows.Forms.ToolStripMenuItem nuevoVertice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Pizarra;
        private System.Windows.Forms.ToolStripMenuItem eliminarVertice;
        private System.Windows.Forms.ToolStripMenuItem eliminarArco;
    }
}

