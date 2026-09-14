namespace GameLibrary.Models
{
    /// <summary>
    /// Enumeración de estados de un juego
    /// </summary>
    public enum GameStatus
    {
        Pendiente = 1,
        Jugando = 2,
        Pausado = 3,
        Completado = 4,
        Abandonado = 5
    }

    /// <summary>
    /// Clase auxiliar para manejar la conversión de GameStatus
    /// </summary>
    public static class GameStatusHelper
    {
        public static string GetDisplayName(GameStatus status)
        {
            switch (status)
            {
                case GameStatus.Pendiente:
                    return "Pendiente";
                case GameStatus.Jugando:
                    return "Jugando";
                case GameStatus.Pausado:
                    return "Pausado";
                case GameStatus.Completado:
                    return "Completado";
                case GameStatus.Abandonado:
                    return "Abandonado";
                default:
                    return "Desconocido";
            }
        }

        public static GameStatus GetStatusFromString(string name)
        {
            if (string.IsNullOrEmpty(name))
                return GameStatus.Pendiente;

            switch (name.ToLower())
            {
                case "pendiente":
                    return GameStatus.Pendiente;
                case "jugando":
                    return GameStatus.Jugando;
                case "pausado":
                    return GameStatus.Pausado;
                case "completado":
                    return GameStatus.Completado;
                case "abandonado":
                    return GameStatus.Abandonado;
                default:
                    return GameStatus.Pendiente;
            }
        }
    }
}

