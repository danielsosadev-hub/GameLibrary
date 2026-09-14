namespace GameLibrary.Forms
{
    partial class ExportForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 350);
            this.Text = "Exportar";

            // Label para tipo de exportación
            var lblType = new System.Windows.Forms.Label { Text = "¿Qué deseas exportar?", Location = new System.Drawing.Point(10, 10), Width = 400 };
            this.cmbExportType = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(10, 35), Width = 480, Height = 25, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.cmbExportType.SelectedIndexChanged += new System.EventHandler(this.CmbExportType_SelectedIndexChanged);

            // Label para filtro
            var lblFilter = new System.Windows.Forms.Label { Text = "Filtro:", Location = new System.Drawing.Point(10, 70), Width = 400, Enabled = false };
            this.cmbFilter = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(10, 95), Width = 480, Height = 25, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList, Enabled = false };

            // RadioButtons para formato
            var lblFormat = new System.Windows.Forms.Label { Text = "Formato:", Location = new System.Drawing.Point(10, 135), Width = 400 };
            this.rbJson = new System.Windows.Forms.RadioButton { Text = "JSON", Location = new System.Drawing.Point(10, 160), Width = 200, Checked = true };
            this.rbCsv = new System.Windows.Forms.RadioButton { Text = "CSV", Location = new System.Drawing.Point(10, 185), Width = 200 };

            // Botones
            this.btnExport = new System.Windows.Forms.Button { Text = "📥 Exportar", Location = new System.Drawing.Point(300, 250), Width = 100, Height = 35 };
            this.btnExport.Click += new System.EventHandler(this.BtnExport_Click);

            this.btnCancel = new System.Windows.Forms.Button { Text = "Cancelar", Location = new System.Drawing.Point(410, 250), Width = 100, Height = 35 };
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // Agregar controles
            this.Controls.Add(lblType);
            this.Controls.Add(this.cmbExportType);
            this.Controls.Add(lblFilter);
            this.Controls.Add(this.cmbFilter);
            this.Controls.Add(lblFormat);
            this.Controls.Add(this.rbJson);
            this.Controls.Add(this.rbCsv);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnCancel);

            this.Load += new System.EventHandler(this.ExportForm_Load);
        }

        private System.Windows.Forms.ComboBox cmbExportType;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.RadioButton rbJson;
        private System.Windows.Forms.RadioButton rbCsv;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnCancel;
    }
}
