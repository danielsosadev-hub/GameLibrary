using System;
using System.Windows.Forms;
using GameLibrary.Data;
using GameLibrary.Models;

namespace GameLibrary.Forms
{
    public partial class AddGameForm : Form
    {
        private readonly DatabaseManager _dbManager;
        private Game _newGame;

        public AddGameForm(DatabaseManager dbManager)
        {
            InitializeComponent();
            _dbManager = dbManager;
            _newGame = new Game();
        }

        private void AddGameForm_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Agregar Nuevo Juego";
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;

                LoadPlatforms();
                LoadGenres();

                // Valores por defecto
                cmbStatus.SelectedIndex = 0;
                numRating.Value = 0;
                numHours.Value = 0;
                chkFavorite.Checked = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPlatforms()
        {
            cmbPlatform.Items.Clear();
            foreach (Platform platform in Enum.GetValues(typeof(Platform)))
            {
                cmbPlatform.Items.Add(PlatformHelper.GetDisplayName(platform));
            }
            cmbPlatform.SelectedIndex = 0;
        }

        private void LoadGenres()
        {
            cmbGenre.Items.Clear();
            var genres = new[] { "Acción", "Aventura", "RPG", "Estrategia", "Puzzle", "Deportes", "Shooter", "Simulación", "Carreras", "Otro" };
            foreach (var genre in genres)
            {
                cmbGenre.Items.Add(genre);
            }
            cmbGenre.SelectedIndex = cmbGenre.Items.Count - 1;
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar título
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("El título del juego es obligatorio", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTitle.Focus();
                    return;
                }

                // Crear el nuevo juego
                _newGame.Title = txtTitle.Text.Trim();
                _newGame.Platform = PlatformHelper.GetPlatformFromString(cmbPlatform.SelectedItem.ToString());
                _newGame.Genre = cmbGenre.SelectedItem.ToString();
                _newGame.Developer = txtDeveloper.Text.Trim();
                _newGame.Status = (GameStatus)cmbStatus.SelectedIndex + 1;
                _newGame.IsFavorite = chkFavorite.Checked;
                _newGame.Notes = txtNotes.Text.Trim();

                if (numRating.Value > 0)
                    _newGame.Rating = (double)numRating.Value;

                if (numReleaseYear.Value > 1980)
                    _newGame.ReleaseYear = (int)numReleaseYear.Value;

                if (numHours.Value > 0)
                    _newGame.HoursPlayed = (int)numHours.Value;

                // Guardar en BD
                int newId = _dbManager.AddGame(_newGame);
                MessageBox.Show($"Juego agregado exitosamente (ID: {newId})", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
