using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using GameLibrary.Models;
using System.Globalization;

namespace GameLibrary.Data
{
    /// <summary>
    /// Gestor de base de datos usando archivo local (JSON storage)
    /// </summary>
    public class DatabaseManager
    {
        private readonly string _databasePath;
        private List<Game> _games;
        private int _nextId;

        public DatabaseManager(string databasePath = "GameLibrary.json")
        {
            _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, databasePath);
            _games = new List<Game>();
            _nextId = 1;
            LoadDatabase();
        }

        private void LoadDatabase()
        {
            try
            {
                if (File.Exists(_databasePath))
                {
                    string json = File.ReadAllText(_databasePath, Encoding.UTF8);
                    _games = ParseJsonToGames(json);
                    if (_games.Count > 0)
                        _nextId = _games.Max(g => g.Id) + 1;
                }
                else
                {
                    _games = new List<Game>();
                    SaveDatabase();
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error cargando la base de datos: {ex.Message}", ex);
            }
        }

        private void SaveDatabase()
        {
            try
            {
                string json = ConvertGamesToJson(_games);
                File.WriteAllText(_databasePath, json, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error guardando la base de datos: {ex.Message}", ex);
            }
        }

        public List<Game> GetAllGames()
        {
            return new List<Game>(_games.OrderBy(g => g.Title));
        }

        public Game GetGameById(int id)
        {
            return _games.FirstOrDefault(g => g.Id == id);
        }

        public int AddGame(Game game)
        {
            if (string.IsNullOrWhiteSpace(game.Title))
                throw new ArgumentException("El título del juego es obligatorio");

            game.Id = _nextId++;
            game.DateAdded = DateTime.Now;
            _games.Add(game);
            SaveDatabase();
            return game.Id;
        }

        public bool UpdateGame(Game game)
        {
            if (game.Id <= 0)
                throw new ArgumentException("El ID del juego debe ser válido");

            var existing = _games.FirstOrDefault(g => g.Id == game.Id);
            if (existing == null)
                return false;

            existing.Title = game.Title;
            existing.Platform = game.Platform;
            existing.Genre = game.Genre;
            existing.ReleaseYear = game.ReleaseYear;
            existing.Developer = game.Developer;
            existing.Status = game.Status;
            existing.IsFavorite = game.IsFavorite;
            existing.Notes = game.Notes;
            existing.Rating = game.Rating;
            existing.DateModified = DateTime.Now;
            existing.DateCompleted = game.DateCompleted;
            existing.HoursPlayed = game.HoursPlayed;

            SaveDatabase();
            return true;
        }

        public bool DeleteGame(int id)
        {
            var game = _games.FirstOrDefault(g => g.Id == id);
            if (game == null)
                return false;

            _games.Remove(game);
            SaveDatabase();
            return true;
        }

        public List<Game> SearchByTitle(string title)
        {
            return _games
                .Where(g => g.Title.IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
                .OrderBy(g => g.Title)
                .ToList();
        }

        public List<Game> FilterByPlatform(Platform platform)
        {
            return _games
                .Where(g => g.Platform == platform)
                .OrderBy(g => g.Title)
                .ToList();
        }

        public List<Game> FilterByGenre(string genre)
        {
            return _games
                .Where(g => g.Genre == genre)
                .OrderBy(g => g.Title)
                .ToList();
        }

        public List<Game> FilterByStatus(GameStatus status)
        {
            return _games
                .Where(g => g.Status == status)
                .OrderBy(g => g.Title)
                .ToList();
        }

        public List<Game> GetFavorites()
        {
            return _games
                .Where(g => g.IsFavorite)
                .OrderBy(g => g.Title)
                .ToList();
        }

        public List<string> GetAvailablePlatforms()
        {
            var platforms = new List<string>();
            foreach (Platform platform in Enum.GetValues(typeof(Platform)))
            {
                platforms.Add(PlatformHelper.GetDisplayName(platform));
            }
            return platforms.OrderBy(p => p).ToList();
        }

        public List<string> GetAvailableGenres()
        {
            return _games
                .Where(g => !string.IsNullOrEmpty(g.Genre))
                .Select(g => g.Genre)
                .Distinct()
                .OrderBy(g => g)
                .ToList();
        }

        private string ConvertGamesToJson(List<Game> games)
        {
            var sb = new StringBuilder();
            sb.AppendLine("[");

            for (int i = 0; i < games.Count; i++)
            {
                var game = games[i];
                sb.AppendLine("  {");
                sb.AppendLine($"    \"id\": {game.Id},");
                sb.AppendLine($"    \"title\": \"{EscapeJsonString(game.Title)}\",");
                sb.AppendLine($"    \"platform\": {(int)game.Platform},");
                sb.AppendLine($"    \"genre\": \"{EscapeJsonString(game.Genre ?? "")}\",");
                string yearStr = game.ReleaseYear.HasValue ? game.ReleaseYear.Value.ToString() : "null";
                sb.AppendLine($"    \"releaseYear\": {yearStr},");
                sb.AppendLine($"    \"developer\": \"{EscapeJsonString(game.Developer ?? "")}\",");
                sb.AppendLine($"    \"status\": {(int)game.Status},");
                sb.AppendLine($"    \"isFavorite\": {(game.IsFavorite ? "true" : "false")},");
                string ratingStr = game.Rating.HasValue ? game.Rating.Value.ToString(CultureInfo.InvariantCulture) : "null";
                sb.AppendLine($"    \"rating\": {ratingStr},");
                string hoursStr = game.HoursPlayed.HasValue ? game.HoursPlayed.Value.ToString() : "null";
                sb.AppendLine($"    \"hoursPlayed\": {hoursStr},");
                sb.AppendLine($"    \"notes\": \"{EscapeJsonString(game.Notes ?? "")}\",");
                sb.AppendLine($"    \"dateAdded\": \"{game.DateAdded:yyyy-MM-dd HH:mm:ss}\",");
                sb.AppendLine($"    \"dateModified\": {(game.DateModified.HasValue ? $"\"{game.DateModified:yyyy-MM-dd HH:mm:ss}\"" : "null")},");
                sb.AppendLine($"    \"dateCompleted\": {(game.DateCompleted.HasValue ? $"\"{game.DateCompleted:yyyy-MM-dd HH:mm:ss}\"" : "null")}");
                sb.Append("  }");

                if (i < games.Count - 1)
                    sb.AppendLine(",");
                else
                    sb.AppendLine();
            }

            sb.AppendLine("]");
            return sb.ToString();
        }

        private List<Game> ParseJsonToGames(string json)
        {
            var games = new List<Game>();

            json = json.Trim();
            if (!json.StartsWith("[") || !json.EndsWith("]"))
                return games;

            json = json.Substring(1, json.Length - 2);
            var gameStrings = SplitJsonObjects(json);

            foreach (var gameStr in gameStrings)
            {
                try
                {
                    var game = ParseJsonGameObject(gameStr);
                    if (game != null)
                        games.Add(game);
                }
                catch
                {
                    // Ignorar líneas malformadas
                }
            }

            return games;
        }

        private List<string> SplitJsonObjects(string json)
        {
            var objects = new List<string>();
            int braceCount = 0;
            var currentObject = new StringBuilder();

            foreach (var ch in json)
            {
                if (ch == '{')
                    braceCount++;
                if (ch == '}')
                    braceCount--;

                currentObject.Append(ch);

                if (braceCount == 0 && currentObject.ToString().EndsWith("}"))
                {
                    string obj = currentObject.ToString().Trim();
                    if (obj.StartsWith("{") && obj.EndsWith("}"))
                    {
                        objects.Add(obj);
                        currentObject.Clear();
                    }
                }
            }

            return objects;
        }

        private Game ParseJsonGameObject(string jsonObj)
        {
            var game = new Game();

            game.Id = ExtractJsonInt(jsonObj, "id", 0);
            game.Title = ExtractJsonString(jsonObj, "title", "");
            game.Platform = (Platform)ExtractJsonInt(jsonObj, "platform", 1);
            game.Genre = ExtractJsonString(jsonObj, "genre", "");
            game.ReleaseYear = ExtractJsonIntNullable(jsonObj, "releaseYear");
            game.Developer = ExtractJsonString(jsonObj, "developer", "");
            game.Status = (GameStatus)ExtractJsonInt(jsonObj, "status", 1);
            game.IsFavorite = ExtractJsonBool(jsonObj, "isFavorite", false);
            game.Rating = ExtractJsonDoubleNullable(jsonObj, "rating");
            game.HoursPlayed = ExtractJsonIntNullable(jsonObj, "hoursPlayed");
            game.Notes = ExtractJsonString(jsonObj, "notes", "");
            game.DateAdded = ExtractJsonDateTime(jsonObj, "dateAdded", DateTime.Now);
            game.DateModified = ExtractJsonDateTimeNullable(jsonObj, "dateModified");
            game.DateCompleted = ExtractJsonDateTimeNullable(jsonObj, "dateCompleted");

            return game;
        }

        private string ExtractJsonString(string json, string key, string defaultValue)
        {
            string searchKey = $"\"{key}\":";
            int keyIndex = json.IndexOf(searchKey);
            if (keyIndex < 0)
                return defaultValue;

            int startQuote = json.IndexOf("\"", keyIndex + searchKey.Length);
            if (startQuote < 0)
                return defaultValue;

            int endQuote = json.IndexOf("\"", startQuote + 1);
            if (endQuote < 0)
                return defaultValue;

            return UnescapeJsonString(json.Substring(startQuote + 1, endQuote - startQuote - 1));
        }

        private int ExtractJsonInt(string json, string key, int defaultValue)
        {
            string searchKey = $"\"{key}\":";
            int keyIndex = json.IndexOf(searchKey);
            if (keyIndex < 0)
                return defaultValue;

            int startIdx = keyIndex + searchKey.Length;
            int endIdx = json.IndexOfAny(new[] { ',', '}' }, startIdx);
            if (endIdx < 0)
                return defaultValue;

            string numStr = json.Substring(startIdx, endIdx - startIdx).Trim();
            if (int.TryParse(numStr, out int result))
                return result;

            return defaultValue;
        }

        private int? ExtractJsonIntNullable(string json, string key)
        {
            string searchKey = $"\"{key}\":";
            int keyIndex = json.IndexOf(searchKey);
            if (keyIndex < 0)
                return null;

            int startIdx = keyIndex + searchKey.Length;
            int endIdx = json.IndexOfAny(new[] { ',', '}' }, startIdx);
            if (endIdx < 0)
                return null;

            string valStr = json.Substring(startIdx, endIdx - startIdx).Trim();
            if (valStr == "null")
                return null;

            if (int.TryParse(valStr, out int result))
                return result;

            return null;
        }

        private double? ExtractJsonDoubleNullable(string json, string key)
        {
            string searchKey = $"\"{key}\":";
            int keyIndex = json.IndexOf(searchKey);
            if (keyIndex < 0)
                return null;

            int startIdx = keyIndex + searchKey.Length;
            int endIdx = json.IndexOfAny(new[] { ',', '}' }, startIdx);
            if (endIdx < 0)
                return null;

            string valStr = json.Substring(startIdx, endIdx - startIdx).Trim();
            if (valStr == "null")
                return null;

            if (double.TryParse(valStr, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                return result;

            return null;
        }

        private bool ExtractJsonBool(string json, string key, bool defaultValue)
        {
            string searchKey = $"\"{key}\":";
            int keyIndex = json.IndexOf(searchKey);
            if (keyIndex < 0)
                return defaultValue;

            int startIdx = keyIndex + searchKey.Length;
            int endIdx = json.IndexOfAny(new[] { ',', '}' }, startIdx);
            if (endIdx < 0)
                return defaultValue;

            string valStr = json.Substring(startIdx, endIdx - startIdx).Trim().ToLower();
            if (valStr == "true")
                return true;
            if (valStr == "false")
                return false;

            return defaultValue;
        }

        private DateTime ExtractJsonDateTime(string json, string key, DateTime defaultValue)
        {
            string val = ExtractJsonString(json, key, "");
            if (string.IsNullOrEmpty(val))
                return defaultValue;

            if (DateTime.TryParseExact(val, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result;

            return defaultValue;
        }

        private DateTime? ExtractJsonDateTimeNullable(string json, string key)
        {
            string val = ExtractJsonString(json, key, "");
            if (string.IsNullOrEmpty(val))
                return null;

            if (DateTime.TryParseExact(val, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime result))
                return result;

            return null;
        }

        private string EscapeJsonString(string text)
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

        private string UnescapeJsonString(string text)
        {
            if (string.IsNullOrEmpty(text))
                return "";

            return text
                .Replace("\\t", "\t")
                .Replace("\\r", "\r")
                .Replace("\\n", "\n")
                .Replace("\\\"", "\"")
                .Replace("\\\\", "\\");
        }
    }
}
