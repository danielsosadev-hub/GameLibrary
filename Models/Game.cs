using System;

namespace GameLibrary.Models
{
    /// <summary>
    /// Clase que representa un juego en la biblioteca
    /// </summary>
    public class Game
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Platform Platform { get; set; }

        public string Genre { get; set; }

        public int? ReleaseYear { get; set; }

        public string Developer { get; set; }

        public GameStatus Status { get; set; }

        public bool IsFavorite { get; set; }

        public string Notes { get; set; }

        public double? Rating { get; set; } // Valoración de 0 a 10

        public DateTime DateAdded { get; set; }

        public DateTime? DateModified { get; set; }

        public DateTime? DateCompleted { get; set; }

        public int? HoursPlayed { get; set; }

        public Game()
        {
            Status = GameStatus.Pendiente;
            IsFavorite = false;
            DateAdded = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Title} ({PlatformHelper.GetDisplayName(Platform)}) - {GameStatusHelper.GetDisplayName(Status)}";
        }
    }
}
