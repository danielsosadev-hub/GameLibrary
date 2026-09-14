namespace GameLibrary.Models
{
    /// <summary>
    /// Enumeración de plataformas de juegos soportadas
    /// </summary>
    public enum Platform
    {
        PC = 1,
        PlayStation4 = 2,
        PlayStation5 = 3,
        XboxOne = 4,
        XboxSeriesX = 5,
        Nintendo_Switch = 6,
        Nintendo_Wii = 7,
        Nintendo_3DS = 8,
        Mobile = 9,
        Other = 10
    }

    /// <summary>
    /// Clase auxiliar para manejar la conversión de Platform
    /// </summary>
    public static class PlatformHelper
    {
        public static string GetDisplayName(Platform platform)
        {
            switch (platform)
            {
                case Platform.PC:
                    return "PC";
                case Platform.PlayStation4:
                    return "PlayStation 4";
                case Platform.PlayStation5:
                    return "PlayStation 5";
                case Platform.XboxOne:
                    return "Xbox One";
                case Platform.XboxSeriesX:
                    return "Xbox Series X|S";
                case Platform.Nintendo_Switch:
                    return "Nintendo Switch";
                case Platform.Nintendo_Wii:
                    return "Nintendo Wii";
                case Platform.Nintendo_3DS:
                    return "Nintendo 3DS";
                case Platform.Mobile:
                    return "Móvil";
                case Platform.Other:
                    return "Otra";
                default:
                    return "Desconocida";
            }
        }

        public static Platform GetPlatformFromString(string name)
        {
            if (string.IsNullOrEmpty(name))
                return Platform.Other;

            switch (name)
            {
                case "PC":
                    return Platform.PC;
                case "PlayStation 4":
                    return Platform.PlayStation4;
                case "PlayStation 5":
                    return Platform.PlayStation5;
                case "Xbox One":
                    return Platform.XboxOne;
                case "Xbox Series X|S":
                    return Platform.XboxSeriesX;
                case "Nintendo Switch":
                    return Platform.Nintendo_Switch;
                case "Nintendo Wii":
                    return Platform.Nintendo_Wii;
                case "Nintendo 3DS":
                    return Platform.Nintendo_3DS;
                case "Móvil":
                    return Platform.Mobile;
                default:
                    return Platform.Other;
            }
        }
    }
}

