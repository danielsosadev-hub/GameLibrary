using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GameLibrary.Data;
using GameLibrary.Forms;
using GameLibrary.Models;
using GameLibrary.Utils;

namespace GameLibrary
{
    public partial class Form1 : Form
    {
        private DatabaseManager _dbManager;
        private BindingSource _bindingSource;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                // Inicializar gestor de base de datos
                _dbManager = new DatabaseManager("GameLibrary.db");

                // Inicializar binding source
                _bindingSource = new BindingSource();

                // Cargar la interfaz
                InitializeUI();
                LoadGames();

                Text = "Biblioteca de Juegos";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar la aplicación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitializeUI()
        {
            // Crear el DataGridView si no existe
            if (Controls.OfType<DataGridView>().Count() == 0)
            {
                var dgv = new DataGridView
                {
                    Name = "dgvGames",
                    Dock = DockStyle.Fill,
                    AllowUserToAddRows = false,
                    AllowUserToDeleteRows = false,
                    ReadOnly = true,
                    SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    RowHeadersVisible = false,
                    BackgroundColor = System.Drawing.SystemColors.AppWorkspace
                };

                // Crear panel de botones
                var panel = new Panel
                {
                    Name = "pnlButtons",
                    Dock = DockStyle.Top,
                    Height = 50,
                    BackColor = System.Drawing.SystemColors.Control
                };

                // Botones
                int x = 10;
                var btnAdd = new Button
                {
                    Text = "➕ Agregar",
                    Location = new System.Drawing.Point(x, 10),
                    Width = 90,
                    Height = 30
                };
                btnAdd.Click += BtnAdd_Click;
                panel.Controls.Add(btnAdd);

                x += 100;
                var btnEdit = new Button
                {
                    Text = "✏️ Editar",
                    Location = new System.Drawing.Point(x, 10),
                    Width = 90,
                    Height = 30
                };
                btnEdit.Click += BtnEdit_Click;
                panel.Controls.Add(btnEdit);

                x += 100;
                var btnDelete = new Button
                {
                    Text = "🗑️ Eliminar",
                    Location = new System.Drawing.Point(x, 10),
                    Width = 90,
                    Height = 30
                };
                btnDelete.Click += BtnDelete_Click;
                panel.Controls.Add(btnDelete);

                x += 100;
                var btnSearch = new Button
                {
                    Text = "🔍 Buscar",
                    Location = new System.Drawing.Point(x, 10),
                    Width = 90,
                    Height = 30
                };
                btnSearch.Click += BtnSearch_Click;
                panel.Controls.Add(btnSearch);

                x += 100;
                var btnExport = new Button
                {
                    Text = "📥 Exportar",
                    Location = new System.Drawing.Point(x, 10),
                    Width = 90,
                    Height = 30
                };
                btnExport.Click += BtnExport_Click;
                panel.Controls.Add(btnExport);

                Controls.Add(dgv);
                Controls.Add(panel);

                dgv.BringToFront();
            }
        }

        private void LoadGames()
        {
            try
            {
                var games = _dbManager.GetAllGames();
                var dgv = Controls.Find("dgvGames", false).FirstOrDefault() as DataGridView;

                if (dgv != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = BindGamesToDataGridView(games);
                }

                Text = $"Biblioteca de Juegos - {games.Count} juego(s)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando juegos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<dynamic> BindGamesToDataGridView(List<Game> games)
        {
            return games.Select(g => new
            {
                ID = g.Id,
                Título = g.Title,
                Plataforma = PlatformHelper.GetDisplayName(g.Platform),
                Género = g.Genre,
                Año = g.ReleaseYear.HasValue ? g.ReleaseYear.ToString() : "-",
                Desarrollador = g.Developer,
                Estado = GameStatusHelper.GetDisplayName(g.Status),
                Favorito = g.IsFavorite ? "❤️" : "",
                Calificación = g.Rating.HasValue ? g.Rating.Value.ToString("0.0") : "-"
            }).Cast<dynamic>().ToList();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new AddGameForm(_dbManager);
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadGames();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            var dgv = Controls.Find("dgvGames", false).FirstOrDefault() as DataGridView;
            if (dgv?.SelectedRows.Count > 0)
            {
                var row = dgv.SelectedRows[0];
                int gameId = (int)row.Cells["ID"].Value;

                var game = _dbManager.GetGameById(gameId);
                var editForm = new EditGameForm(_dbManager, game);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadGames();
                }
            }
            else
            {
                MessageBox.Show("Selecciona un juego para editar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var dgv = Controls.Find("dgvGames", false).FirstOrDefault() as DataGridView;
            if (dgv?.SelectedRows.Count > 0)
            {
                var row = dgv.SelectedRows[0];
                int gameId = (int)row.Cells["ID"].Value;
                string gameTitle = row.Cells["Título"].Value.ToString();

                if (MessageBox.Show($"¿Estás seguro de que deseas eliminar '{gameTitle}'?", "Confirmar eliminación",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        _dbManager.DeleteGame(gameId);
                        LoadGames();
                        MessageBox.Show("Juego eliminado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un juego para eliminar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var searchForm = new SearchFilterForm(_dbManager);
            if (searchForm.ShowDialog() == DialogResult.OK && searchForm.FilteredGames.Count > 0)
            {
                var dgv = Controls.Find("dgvGames", false).FirstOrDefault() as DataGridView;
                if (dgv != null)
                {
                    dgv.DataSource = null;
                    dgv.DataSource = BindGamesToDataGridView(searchForm.FilteredGames);
                    Text = $"Biblioteca de Juegos - {searchForm.FilteredGames.Count} resultados";
                }
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            var exportForm = new ExportForm(_dbManager);
            exportForm.ShowDialog();
        }
    }
}
