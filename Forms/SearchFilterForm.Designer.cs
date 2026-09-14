namespace GameLibrary.Forms
{
    partial class SearchFilterForm
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
            this.Text = "Buscar y Filtrar";

            // Label y TextBox para búsqueda
            var lblSearch = new System.Windows.Forms.Label { Text = "Buscar:", Location = new System.Drawing.Point(10, 10), Width = 100 };
            this.txtSearch = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(120, 10), Width = 360, Height = 25 };

            // Label y ComboBox para Plataforma
            var lblPlatform = new System.Windows.Forms.Label { Text = "Plataforma:", Location = new System.Drawing.Point(10, 45), Width = 100 };
            this.cmbPlatform = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(120, 45), Width = 360, Height = 25, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };

            // Label y ComboBox para Género
            var lblGenre = new System.Windows.Forms.Label { Text = "Género:", Location = new System.Drawing.Point(10, 80), Width = 100 };
            this.cmbGenre = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(120, 80), Width = 360, Height = 25, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };

            // Label y ComboBox para Estado
            var lblStatus = new System.Windows.Forms.Label { Text = "Estado:", Location = new System.Drawing.Point(10, 115), Width = 100 };
            this.cmbStatus = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(120, 115), Width = 360, Height = 25, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };

            // CheckBox para Favoritos
            this.chkFavorites = new System.Windows.Forms.CheckBox { Text = "Solo mis favoritos", Location = new System.Drawing.Point(120, 150), Width = 360, Height = 25 };

            // Botones
            this.btnSearch = new System.Windows.Forms.Button { Text = "🔍 Buscar", Location = new System.Drawing.Point(300, 230), Width = 100, Height = 35 };
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);

            this.btnCancel = new System.Windows.Forms.Button { Text = "Cancelar", Location = new System.Drawing.Point(410, 230), Width = 100, Height = 35 };
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // Agregar controles
            this.Controls.Add(lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(lblPlatform);
            this.Controls.Add(this.cmbPlatform);
            this.Controls.Add(lblGenre);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.chkFavorites);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCancel);

            this.Load += new System.EventHandler(this.SearchFilterForm_Load);
        }

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbPlatform;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.CheckBox chkFavorites;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
    }
}
