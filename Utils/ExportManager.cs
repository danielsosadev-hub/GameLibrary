using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GameLibrary.Models;

namespace GameLibrary.Utils
{
    /// <summary>
    /// Gestor de exportación de datos a diferentes formatos
    /// </summary>
    public class ExportManager
    {
        /// <summary>
        /// Exporta una lista de juegos a formato JSON
        /// </summary>
        public static string ExportToJson(List<Game> games)
        {
            if (games == null || games.Count == 0)
                throw new ArgumentException("No hay juegos para exportar");

            var sb = new StringBuilder();
            sb.AppendLine("[");

            for (int i = 0; i < games.Count; i++)
            {
                var game = games[i];
                sb.AppendLine("  {");
                sb.AppendLine($"    \"id\": {game.Id},");
                sb.AppendLine($"    \"title\": \"{EscapeJson(game.Title)}\",");
                sb.AppendLine($"    \"platform\": \"{PlatformHelper.GetDisplayName(game.Platform)}\",");
                sb.AppendLine($"    \"genre\": \"{EscapeJson(game.Genre ?? "")}\",");

                string releaseYearStr;
                if (game.ReleaseYear.HasValue)
                    releaseYearStr = game.ReleaseYear.Value.ToString();
                else
                    releaseYearStr = "null";
                sb.AppendLine($"    \"releaseYear\": {releaseYearStr},");

                sb.AppendLine($"    \"developer\": \"{EscapeJson(game.Developer ?? "")}\",");
                sb.AppendLine($"    \"status\": \"{GameStatusHelper.GetDisplayName(game.Status)}\",");
                sb.AppendLine($"    \"isFavorite\": {(game.IsFavorite ? "true" : "false")},");

                string ratingStr;
                if (game.Rating.HasValue)
                    ratingStr = game.Rating.Value.ToString("0.0");
                else
                    ratingStr = "null";
                sb.AppendLine($"    \"rating\": {ratingStr},");

                string hoursStr;
                if (game.HoursPlayed.HasValue)
                    hoursStr = game.HoursPlayed.Value.ToString();
                else
                    hoursStr = "null";
                sb.AppendLine($"    \"hoursPlayed\": {hoursStr},");

                sb.AppendLine($"    \"notes\": \"{EscapeJson(game.Notes ?? "")}\",");
                sb.AppendLine($"    \"dateAdded\": \"{game.DateAdded:yyyy-MM-dd HH:mm:ss}\",");

                string dateModStr;
                if (game.DateModified.HasValue)
                    dateModStr = $"\"{game.DateModified:yyyy-MM-dd HH:mm:ss}\"";
                else
                    dateModStr = "null";
                sb.AppendLine($"    \"dateModified\": {dateModStr},");

                string dateCompStr;
                if (game.DateCompleted.HasValue)
                    dateCompStr = $"\"{game.DateCompleted:yyyy-MM-dd HH:mm:ss}\"";
                else
                    dateCompStr = "null";
                sb.AppendLine($"    \"dateCompleted\": {dateCompStr}");

                sb.Append("  }");

                if (i < games.Count - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }

            sb.AppendLine("]");
            return sb.ToString();
        }

        /// <summary>
        /// Exporta una lista de juegos a formato CSV
        /// </summary>
        public static string ExportToCsv(List<Game> games)
        {
            if (games == null || games.Count == 0)
                throw new ArgumentException("No hay juegos para exportar");

            var sb = new StringBuilder();

            // Encabezados
            sb.AppendLine("ID,Título,Plataforma,Género,Año,Desarrollador,Estado,Favorito,Calificación,Horas Jugadas,Notas,Fecha Agregado,Fecha Modificado,Fecha Completado");

            // Datos
            foreach (var game in games)
            {
                string dateModified = game.DateModified.HasValue ? game.DateModified.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                string dateCompleted = game.DateCompleted.HasValue ? game.DateCompleted.Value.ToString("yyyy-MM-dd HH:mm:ss") : "";
                string year = game.ReleaseYear.HasValue ? game.ReleaseYear.Value.ToString() : "";
                string rating = game.Rating.HasValue ? game.Rating.Value.ToString("0.0") : "";
                string hours = game.HoursPlayed.HasValue ? game.HoursPlayed.Value.ToString() : "";
                string favorite = game.IsFavorite ? "Sí" : "No";

                var row = string.Format("{0},\"{1}\",\"{2}\",\"{3}\",{4},\"{5}\",\"{6}\",{7},{8},{9},\"{10}\",{11},{12},{13}",
                    game.Id,
                    EscapeCsv(game.Title),
                    PlatformHelper.GetDisplayName(game.Platform),
                    EscapeCsv(game.Genre ?? ""),
                    year,
                    EscapeCsv(game.Developer ?? ""),
                    GameStatusHelper.GetDisplayName(game.Status),
                    favorite,
                    rating,
                    hours,
                    EscapeCsv(game.Notes ?? ""),
                    game.DateAdded.ToString("yyyy-MM-dd HH:mm:ss"),
                    dateModified,
                    dateCompleted);

                sb.AppendLine(row);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Exporta a archivo JSON
        /// </summary>
        public static void ExportJsonToFile(List<Game> games, string filePath)
        {
            try
            {
                string json = ExportToJson(games);
                File.WriteAllText(filePath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar a JSON: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Exporta a archivo CSV
        /// </summary>
        public static void ExportCsvToFile(List<Game> games, string filePath)
        {
            try
            {
                string csv = ExportToCsv(games);
                File.WriteAllText(filePath, csv, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al exportar a CSV: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Escapa caracteres especiales para JSON
        /// </summary>
        private static string EscapeJson(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            return text
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\n", "\\n")
                .Replace("\r", "\\r")
                .Replace("\t", "\\t");
        }

        /// <summary>
        /// Escapa caracteres especiales para CSV
        /// </summary>
        private static string EscapeCsv(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            return text.Replace("\"", "\"\"");
        }
    }
}
