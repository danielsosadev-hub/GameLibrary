using System;
using System.Windows.Forms;
using GameLibrary.Data;
using GameLibrary.Models;

namespace GameLibrary.Forms
{
    public partial class EditGameForm : Form
    {
        private readonly DatabaseManager _dbManager;
        private Game _game;

        public EditGameForm(DatabaseManager dbManager, Game game)
        {
            InitializeComponent();
            _dbManager = dbManager;
            _game = game;
        }

        private void EditGameForm_Load(object sender, EventArgs e)
        {
            try
            {
                Text = $"Editar Juego - {_game.Title}";
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;

                LoadPlatforms();
                LoadGenres();
                PopulateForm();
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
        }

        private void LoadGenres()
        {
            cmbGenre.Items.Clear();
            var genres = new[] { "Acción", "Aventura", "RPG", "Estrategia", "Puzzle", "Deportes", "Shooter", "Simulación", "Carreras", "Otro" };
            foreach (var genre in genres)
            {
                cmbGenre.Items.Add(genre);
            }
        }

        private void PopulateForm()
        {
            txtTitle.Text = _game.Title;
            cmbPlatform.SelectedItem = PlatformHelper.GetDisplayName(_game.Platform);
            cmbGenre.SelectedItem = _game.Genre ?? "Otro";
            txtDeveloper.Text = _game.Developer ?? "";
            numReleaseYear.Value = _game.ReleaseYear ?? DateTime.Now.Year;
            cmbStatus.SelectedIndex = (int)_game.Status - 1;
            numRating.Value = (decimal?)_game.Rating ?? 0;
            numHours.Value = _game.HoursPlayed ?? 0;
            chkFavorite.Checked = _game.IsFavorite;
            txtNotes.Text = _game.Notes ?? "";
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

                // Actualizar el juego
                _game.Title = txtTitle.Text.Trim();
                _game.Platform = PlatformHelper.GetPlatformFromString(cmbPlatform.SelectedItem.ToString());
                _game.Genre = cmbGenre.SelectedItem.ToString();
                _game.Developer = txtDeveloper.Text.Trim();
                _game.Status = (GameStatus)cmbStatus.SelectedIndex + 1;
                _game.IsFavorite = chkFavorite.Checked;
                _game.Notes = txtNotes.Text.Trim();

                if (numRating.Value > 0)
                    _game.Rating = (double)numRating.Value;
                else
                    _game.Rating = null;

                if (numReleaseYear.Value > 1980)
                    _game.ReleaseYear = (int)numReleaseYear.Value;
                else
                    _game.ReleaseYear = null;

                if (numHours.Value > 0)
                    _game.HoursPlayed = (int)numHours.Value;
                else
                    _game.HoursPlayed = null;

                // Si cambió a "Completado" y no tiene fecha, asignarla
                if (_game.Status == GameStatus.Completado && !_game.DateCompleted.HasValue)
                {
                    _game.DateCompleted = DateTime.Now;
                }

                // Guardar cambios en BD
                _dbManager.UpdateGame(_game);
                MessageBox.Show("Juego actualizado exitosamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
