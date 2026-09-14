using System;
using System.Collections.Generic;
using System.Windows.Forms;
using GameLibrary.Data;
using GameLibrary.Models;
using GameLibrary.Utils;

namespace GameLibrary.Forms
{
    public partial class ExportForm : Form
    {
        private readonly DatabaseManager _dbManager;

        public ExportForm(DatabaseManager dbManager)
        {
            InitializeComponent();
            _dbManager = dbManager;
        }

        private void ExportForm_Load(object sender, EventArgs e)
        {
            try
            {
                Text = "Exportar datos";
                StartPosition = FormStartPosition.CenterParent;
                FormBorderStyle = FormBorderStyle.FixedDialog;
                MaximizeBox = false;
                MinimizeBox = false;

                // Cargar opciones
                cmbExportType.Items.Clear();
                cmbExportType.Items.Add("Todos los juegos");
                cmbExportType.Items.Add("Juegos favoritos");
                cmbExportType.Items.Add("Por plataforma");
                cmbExportType.Items.Add("Por estado");
                cmbExportType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbExportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualizar opciones según el tipo de exportación
            if (cmbExportType.SelectedIndex == 2) // Por plataforma
            {
                cmbFilter.Items.Clear();
                cmbFilter.Enabled = true;
                foreach (Platform platform in Enum.GetValues(typeof(Platform)))
                {
                    cmbFilter.Items.Add(PlatformHelper.GetDisplayName(platform));
                }
                cmbFilter.SelectedIndex = 0;
            }
            else if (cmbExportType.SelectedIndex == 3) // Por estado
            {
                cmbFilter.Items.Clear();
                cmbFilter.Enabled = true;
                foreach (GameStatus status in Enum.GetValues(typeof(GameStatus)))
                {
                    cmbFilter.Items.Add(GameStatusHelper.GetDisplayName(status));
                }
                cmbFilter.SelectedIndex = 0;
            }
            else
            {
                cmbFilter.Enabled = false;
                cmbFilter.Items.Clear();
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener la lista de juegos según el filtro
                List<Game> gamesToExport = GetGamesToExport();

                if (gamesToExport.Count == 0)
                {
                    MessageBox.Show("No hay juegos para exportar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Diálogo para guardar archivo
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.Filter = rbJson.Checked ? "JSON files (*.json)|*.json" : "CSV files (*.csv)|*.csv";
                saveDialog.FileName = $"GameLibrary_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    if (rbJson.Checked)
                    {
                        ExportManager.ExportJsonToFile(gamesToExport, saveDialog.FileName);
                    }
                    else
                    {
                        ExportManager.ExportCsvToFile(gamesToExport, saveDialog.FileName);
                    }

                    MessageBox.Show($"Exportación exitosa!\n{gamesToExport.Count} juego(s) exportados.\n\n{saveDialog.FileName}",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la exportación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Game> GetGamesToExport()
        {
            switch (cmbExportType.SelectedIndex)
            {
                case 0: // Todos
                    return _dbManager.GetAllGames();

                case 1: // Favoritos
                    return _dbManager.GetFavorites();

                case 2: // Por plataforma
                    {
                        string platformName = cmbFilter.SelectedItem.ToString();
                        Platform platform = PlatformHelper.GetPlatformFromString(platformName);
                        return _dbManager.FilterByPlatform(platform);
                    }

                case 3: // Por estado
                    {
                        string statusName = cmbFilter.SelectedItem.ToString();
                        GameStatus status = GameStatusHelper.GetStatusFromString(statusName);
                        return _dbManager.FilterByStatus(status);
                    }

                default:
                    return new List<Game>();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
