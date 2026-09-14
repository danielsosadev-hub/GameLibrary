using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameLibrary.Data;
using GameLibrary.Models;

namespace GameLibrary.Forms
{
    public partial class SearchFilterForm : Form
    {
        private readonly DatabaseManager _dbManager;
        public List<Game> FilteredGames { get; private set; }

        public SearchFilterForm(DatabaseManager dbManager)
        {
            InitializeComponent();
            _dbManager = dbManager;
            FilteredGames = new List<Game>();
        }

        private void SearchFilterForm_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Buscar y Filtrar Juegos";
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;

                LoadPlatforms();
                LoadGenres();
                LoadStatuses();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPlatforms()
        {
            cmbPlatform.Items.Clear();
            cmbPlatform.Items.Add("Todas");
            foreach (Platform platform in Enum.GetValues(typeof(Platform)))
            {
                cmbPlatform.Items.Add(PlatformHelper.GetDisplayName(platform));
            }
            cmbPlatform.SelectedIndex = 0;
        }

        private void LoadGenres()
        {
            cmbGenre.Items.Clear();
            cmbGenre.Items.Add("Todos");
            var genres = _dbManager.GetAvailableGenres();
            foreach (var genre in genres)
            {
                cmbGenre.Items.Add(genre);
            }
            cmbGenre.SelectedIndex = 0;
        }

        private void LoadStatuses()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Todos");
            foreach (GameStatus status in Enum.GetValues(typeof(GameStatus)))
            {
                cmbStatus.Items.Add(GameStatusHelper.GetDisplayName(status));
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FilteredGames = _dbManager.GetAllGames();

                // Filtro por búsqueda de texto
                if (!string.IsNullOrWhiteSpace(txtSearch.Text))
                {
                    FilteredGames = FilteredGames.FindAll(g =>
                        g.Title.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        g.Genre?.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0 ||
                        g.Developer?.IndexOf(txtSearch.Text, StringComparison.OrdinalIgnoreCase) >= 0
                    );
                }

                // Filtro por plataforma
                if (cmbPlatform.SelectedIndex > 0)
                {
                    var platformName = cmbPlatform.SelectedItem.ToString();
                    Platform platform = PlatformHelper.GetPlatformFromString(platformName);
                    FilteredGames = FilteredGames.FindAll(g => g.Platform == platform);
                }

                // Filtro por género
                if (cmbGenre.SelectedIndex > 0)
                {
                    var genre = cmbGenre.SelectedItem.ToString();
                    FilteredGames = FilteredGames.FindAll(g => g.Genre == genre);
                }

                // Filtro por estado
                if (cmbStatus.SelectedIndex > 0)
                {
                    var statusName = cmbStatus.SelectedItem.ToString();
                    GameStatus status = GameStatusHelper.GetStatusFromString(statusName);
                    FilteredGames = FilteredGames.FindAll(g => g.Status == status);
                }

                // Filtro por favoritos
                if (chkFavorites.Checked)
                {
                    FilteredGames = FilteredGames.FindAll(g => g.IsFavorite);
                }

                MessageBox.Show($"Se encontraron {FilteredGames.Count} juego(s)", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
