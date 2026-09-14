namespace GameLibrary.Forms
{
    partial class AddGameForm
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
            this.ClientSize = new System.Drawing.Size(500, 600);
            this.Text = "Agregar Juego";

            // Label y TextBox para Título
            var lblTitle = new System.Windows.Forms.Label { Text = "Título:", Location = new System.Drawing.Point(10, 10), Width = 100 };
            this.txtTitle = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(120, 10), Width = 360, Height = 25 };

            // Label y ComboBox para Plataforma
            var lblPlatform = new System.Windows.Forms.Label { Text = "Plataforma:", Location = new System.Drawing.Point(10, 45), Width = 100 };
            this.cmbPlatform = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(120, 45), Width = 360, Height = 25, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };

            // Label y ComboBox para Género
            var lblGenre = new System.Windows.Forms.Label { Text = "Género:", Location = new System.Drawing.Point(10, 80), Width = 100 };
            this.cmbGenre = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(120, 80), Width = 360, Height = 25, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };

            // Label y TextBox para Desarrollador
            var lblDeveloper = new System.Windows.Forms.Label { Text = "Desarrollador:", Location = new System.Drawing.Point(10, 115), Width = 100 };
            this.txtDeveloper = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(120, 115), Width = 360, Height = 25 };

            // Label y NumericUpDown para Año
            var lblYear = new System.Windows.Forms.Label { Text = "Año:", Location = new System.Drawing.Point(10, 150), Width = 100 };
            this.numReleaseYear = new System.Windows.Forms.NumericUpDown { Location = new System.Drawing.Point(120, 150), Width = 360, Height = 25, Minimum = 1980, Maximum = System.DateTime.Now.Year + 5, Value = System.DateTime.Now.Year };

            // Label y ComboBox para Estado
            var lblStatus = new System.Windows.Forms.Label { Text = "Estado:", Location = new System.Drawing.Point(10, 185), Width = 100 };
            this.cmbStatus = new System.Windows.Forms.ComboBox { Location = new System.Drawing.Point(120, 185), Width = 360, Height = 25, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.cmbStatus.Items.AddRange(new string[] { "Pendiente", "Jugando", "Pausado", "Completado", "Abandonado" });

            // Label y NumericUpDown para Calificación
            var lblRating = new System.Windows.Forms.Label { Text = "Calificación:", Location = new System.Drawing.Point(10, 220), Width = 100 };
            this.numRating = new System.Windows.Forms.NumericUpDown { Location = new System.Drawing.Point(120, 220), Width = 360, Height = 25, Minimum = 0, Maximum = 10, DecimalPlaces = 1 };

            // Label y NumericUpDown para Horas
            var lblHours = new System.Windows.Forms.Label { Text = "Horas Jugadas:", Location = new System.Drawing.Point(10, 255), Width = 100 };
            this.numHours = new System.Windows.Forms.NumericUpDown { Location = new System.Drawing.Point(120, 255), Width = 360, Height = 25, Minimum = 0, Maximum = 1000 };

            // CheckBox para Favorito
            this.chkFavorite = new System.Windows.Forms.CheckBox { Text = "¿Es mi favorito?", Location = new System.Drawing.Point(120, 290), Width = 360, Height = 25 };

            // Label y TextBox para Notas
            var lblNotes = new System.Windows.Forms.Label { Text = "Notas:", Location = new System.Drawing.Point(10, 325), Width = 100 };
            this.txtNotes = new System.Windows.Forms.TextBox { Location = new System.Drawing.Point(120, 325), Width = 360, Height = 100, Multiline = true, ScrollBars = System.Windows.Forms.ScrollBars.Vertical };

            // Botones
            this.btnSave = new System.Windows.Forms.Button { Text = "Guardar", Location = new System.Drawing.Point(300, 450), Width = 100, Height = 35 };
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);

            this.btnCancel = new System.Windows.Forms.Button { Text = "Cancelar", Location = new System.Drawing.Point(410, 450), Width = 100, Height = 35 };
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);

            // Agregar controles al formulario
            this.Controls.Add(lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(lblPlatform);
            this.Controls.Add(this.cmbPlatform);
            this.Controls.Add(lblGenre);
            this.Controls.Add(this.cmbGenre);
            this.Controls.Add(lblDeveloper);
            this.Controls.Add(this.txtDeveloper);
            this.Controls.Add(lblYear);
            this.Controls.Add(this.numReleaseYear);
            this.Controls.Add(lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(lblRating);
            this.Controls.Add(this.numRating);
            this.Controls.Add(lblHours);
            this.Controls.Add(this.numHours);
            this.Controls.Add(this.chkFavorite);
            this.Controls.Add(lblNotes);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);

            this.Load += new System.EventHandler(this.AddGameForm_Load);
        }

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.ComboBox cmbPlatform;
        private System.Windows.Forms.ComboBox cmbGenre;
        private System.Windows.Forms.TextBox txtDeveloper;
        private System.Windows.Forms.NumericUpDown numReleaseYear;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.NumericUpDown numRating;
        private System.Windows.Forms.NumericUpDown numHours;
        private System.Windows.Forms.CheckBox chkFavorite;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
