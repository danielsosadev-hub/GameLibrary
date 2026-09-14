# 🎮 Game Haven - Biblioteca de Videojuegos

Una aplicación de escritorio profesional desarrollada en **C# con .NET Framework 4.8** para gestionar y organizar tu biblioteca personal de videojuegos.

## 📋 Características Principales

✅ **Gestión Completa de Biblioteca**
- Agregar, editar y eliminar videojuegos
- Información detallada de cada juego (título, plataforma, género, desarrollador, etc.)
- Estado de progreso (Pendiente, Jugando, Pausado, Completado, Abandonado)
- Calificación personal (0-10)
- Marcador de favoritos
- Notas personales

✅ **Búsqueda y Filtrado Avanzado**
- Buscar por título del juego
- Filtrar por plataforma (PC, PS4, PS5, Xbox, Nintendo Switch, etc.)
- Filtrar por género (RPG, Acción, Aventura, Estrategia, etc.)
- Filtrar por estado de progreso
- Mostrar solo juegos favoritos
- Combinación de múltiples filtros

✅ **Exportación de Datos**
- Exportar a JSON (formato estructurado)
- Exportar a CSV (compatible con Excel)
- Exportar todos los juegos o aplicar filtros

✅ **Almacenamiento Local**
- Base de datos local en formato JSON
- Funciona completamente offline
- No requiere conexión a internet
- Privacidad total de tus datos

✅ **Interfaz Intuitiva**
- Diseño limpio y moderno
- Ventanas modales para agregar/editar
- DataGridView para visualizar lista
- Validaciones de entrada
- Mensajes informativos de confirmación

---

## 🛠️ Tecnología Utilizada

| Componente | Especificación |
|-----------|-----------------|
| **Lenguaje** | C# 7.3+ |
| **Framework** | .NET Framework 4.8 |
| **IDE Recomendado** | Visual Studio Community 2026 |
| **UI Framework** | Windows Forms |
| **Base de Datos** | JSON (Local) |
| **SO Destino** | Windows Vista o superior |

---

## 📦 Estructura del Proyecto

```
GameLibrary/
├── Models/
│   ├── Game.cs                  # Modelo principal de videojuego
│   ├── Platform.cs              # Enum de plataformas + helpers
│   └── GameStatus.cs            # Enum de estados + helpers
│
├── Data/
│   └── DatabaseManager.cs       # Gestor de persistencia (JSON)
│
├── Forms/
│   ├── Form1.cs                 # Ventana principal
│   ├── AddGameForm.cs           # Formulario para agregar juego
│   ├── EditGameForm.cs          # Formulario para editar juego
│   ├── SearchFilterForm.cs      # Búsqueda y filtrado avanzado
│   └── ExportForm.cs            # Exportación de datos
│
├── Utils/
│   └── ExportManager.cs         # Utilidades de exportación (JSON/CSV)
│
├── Properties/                  # Propiedades del proyecto
├── Program.cs                   # Punto de entrada
├── App.config                   # Configuración de aplicación
├── GameLibrary.json             # Base de datos local (creada en runtime)
└── GameLibrary.csproj           # Archivo de proyecto
```

---

## 🚀 Instalación y Uso

### Requisitos Previos
- .NET Framework 4.8 o superior instalado
- Visual Studio Community 2026 (o una versión compatible)
- Git (para clonar el repositorio)

### Pasos de Instalación

1. **Clonar el Repositorio**
```bash
git clone https://github.com/danielsosadev-hub/GameLibrary.git
cd GameLibrary
```

2. **Abrir en Visual Studio**
```bash
# Abrir con Visual Studio
start GameLibrary.slnx
```

3. **Compilar el Proyecto**
- En Visual Studio: `Ctrl + Shift + B` o `Build → Build Solution`
- O en PowerShell:
```bash
dotnet build
```

4. **Ejecutar la Aplicación**
- En Visual Studio: Presionar `F5` o `Debug → Start Debugging`
- O en PowerShell:
```bash
dotnet run
```

---

## 📖 Guía de Uso Básico

### Agregar un Juego

1. Abre la aplicación
2. Presiona el botón **"➕ Agregar"**
3. Completa el formulario con:
   - Título del juego
   - Plataforma
   - Género
   - Desarrollador
   - Año de lanzamiento
   - Estado actual
   - Calificación (opcional)
   - Horas jugadas (opcional)
   - Notas personales (opcional)
4. Presiona **"Guardar"**

### Buscar y Filtrar Juegos

1. Presiona el botón **"🔍 Buscar"**
2. Ingresa criterios de búsqueda:
   - Texto para búsqueda por título/género
   - Selecciona plataforma (opcional)
   - Selecciona estado (opcional)
   - Marca "Solo mis favoritos" si deseas
3. Presiona **"🔍 Buscar"**
4. La tabla se actualizará mostrando solo los resultados

### Editar un Juego

1. Selecciona el juego en la lista
2. Presiona el botón **"✏️ Editar"**
3. Modifica los campos deseados
4. Presiona **"Guardar"**

### Eliminar un Juego

1. Selecciona el juego en la lista
2. Presiona el botón **"🗑️ Eliminar"**
3. Confirma la eliminación en el mensaje de confirmación

### Exportar Biblioteca

1. Presiona el botón **"📥 Exportar"**
2. Selecciona qué deseas exportar:
   - Todos los juegos
   - Solo favoritos
   - Por plataforma específica
   - Por estado específico
3. Selecciona formato:
   - JSON (estructura completa)
   - CSV (compatible con Excel)
4. Presiona **"Exportar"** y selecciona ubicación para guardar

---

## 📊 Información de Videojuegos

Cada juego registra la siguiente información:

| Campo | Tipo | Descripción |
|-------|------|-------------|
| **ID** | Número | Identificador único (autogenerado) |
| **Título** | Texto | Nombre del videojuego |
| **Plataforma** | Enum | PC, PS4, PS5, Xbox One, Xbox Series X/S, Nintendo Switch, etc. |
| **Género** | Texto | Acción, RPG, Aventura, Estrategia, Puzzle, Deportes, etc. |
| **Año** | Número | Año de lanzamiento |
| **Desarrollador** | Texto | Estudio desarrollador |
| **Estado** | Enum | Pendiente, Jugando, Pausado, Completado, Abandonado |
| **Calificación** | Número | Puntuación personal (0-10) |
| **Horas Jugadas** | Número | Tiempo invertido en el juego |
| **Favorito** | Booleano | Marcador de favorito (❤️) |
| **Notas** | Texto | Comentarios personales |
| **Fecha Agregado** | DateTime | Fecha de registración en la app |
| **Fecha Modificado** | DateTime | Última actualización |
| **Fecha Completado** | DateTime | Fecha de finalización |

---

## 💾 Almacenamiento de Datos

### Archivo GameLibrary.json

La base de datos se almacena en un archivo JSON simple:

```json
[
  {
	"id": 1,
	"title": "The Witcher 3",
	"platform": 1,
	"genre": "RPG",
	"releaseYear": 2015,
	"developer": "CD Projekt Red",
	"status": 4,
	"isFavorite": true,
	"rating": 9.5,
	"hoursPlayed": 125,
	"notes": "Juego extraordinario...",
	"dateAdded": "2024-01-15 10:30:22",
	"dateModified": "2024-01-15 11:45:30",
	"dateCompleted": "2024-01-15 10:30:22"
  }
]
```

### Respaldos

Para hacer respaldo de tu biblioteca:
1. Copia el archivo `GameLibrary.json`
2. Guárdalo en una ubicación segura
3. Para restaurar, pega el archivo en el directorio de la aplicación

---

## 🏗️ Arquitectura del Proyecto

Game Haven sigue una arquitectura en capas:

```
┌─────────────────────────────────────┐
│     CAPA DE PRESENTACIÓN (UI)       │
│  Forms: Main, Add, Edit, Search...  │
├─────────────────────────────────────┤
│   CAPA DE LÓGICA DE NEGOCIO         │
│  ExportManager, Helpers             │
├─────────────────────────────────────┤
│  CAPA DE ACCESO A DATOS (DAL)       │
│  DatabaseManager (JSON)             │
├─────────────────────────────────────┤
│     CAPA DE MODELOS                 │
│  Game, Platform, GameStatus         │
├─────────────────────────────────────┤
│  ALMACENAMIENTO                     │
│  GameLibrary.json                   │
└─────────────────────────────────────┘
```

---

## 🐛 Solución de Problemas

### El archivo GameLibrary.json no se crea

**Solución:** Asegúrate de tener permisos de escritura en el directorio de la aplicación. Ejecuta Visual Studio como administrador.

### Los datos no se guardan

**Solución:** Verifica que:
- El directorio de salida tiene permisos de escritura
- La aplicación no está en "Modo Solo Lectura"
- Hay espacio disponible en disco

### La búsqueda no funciona correctamente

**Solución:** 
- Verifica la ortografía del término de búsqueda
- Asegúrate de que los datos están guardados (presiona Guardar después de editar)

### Interfaz lenta con muchos juegos

**Solución:** 
- Para 1000+ juegos, considera optimizar el archivo JSON
- Usa filtros para reducir cantidad de registros mostrados

---

## 📝 Notas de Desarrollo

### Cómo Extender la Aplicación

1. **Agregar nuevas plataformas:**
   - Edita `Models/Platform.cs`
   - Agrega nuevo valor al enum
   - Actualiza helpers si es necesario

2. **Agregar nuevos géneros:**
   - Edita `Forms` para agregar nuevas opciones en ComboBox
   - Los géneros se almacenan como texto, así que no requieren cambios de modelo

3. **Agregar más campos a los juegos:**
   - Edita `Models/Game.cs`
   - Actualiza `DatabaseManager.cs` para serialización
   - Actualiza formularios correspondientes

### Mejoras Planificadas

- [ ] Dashboard con estadísticas
- [ ] Carátulas de juegos
- [ ] Tema oscuro/claro
- [ ] Soporte multi-idioma
- [ ] Sincronización en la nube (opcional)

---

## 📄 Documentación Adicional

- **REPORTE_APLICACION_GAME_HAVEN.md** - Reporte técnico detallado en Markdown
- **REPORTE_GAME_HAVEN.html** - Reporte visual en HTML con estilos

---

## 📞 Soporte y Contribuciones

### Reportar Issues
Si encuentras un bug o tienes sugerencias, por favor abre un Issue en GitHub:
- [GitHub Issues](https://github.com/danielsosadev-hub/GameLibrary/issues)

### Contribuciones
Las contribuciones son bienvenidas! Por favor:
1. Fork el repositorio
2. Crea una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abre un Pull Request

---

## 📄 Licencia

Este proyecto está bajo la licencia MIT. Ver archivo `LICENSE` para más detalles.

---

## 👨‍💻 Autor

**Daniel Sosa**
- GitHub: [@danielsosadev-hub](https://github.com/danielsosadev-hub)
- Repositorio: [GameLibrary](https://github.com/danielsosadev-hub/GameLibrary)

---

## 🙏 Agradecimientos

Gracias a:
- La comunidad de .NET
- Stack Overflow por las soluciones
- Todos los que usen y contribuyan a este proyecto

---

## 📅 Historial de Cambios

### v1.0 - 15 de Enero, 2024
- ✅ Versión inicial completada
- ✅ Todas las características principales implementadas
- ✅ Base de datos local en JSON
- ✅ Exportación a JSON y CSV
- ✅ Búsqueda y filtrado avanzado
- ✅ Documentación completa
- ✅ Publicación en GitHub

---

## ⭐ Si te gusta el proyecto

Si este proyecto te ha sido útil, por favor considerá darle una ⭐ en GitHub!

---

**Última actualización:** 15 de Enero, 2024  
**Versión:** 1.0 Release  
**Estado:** Completado ✅
