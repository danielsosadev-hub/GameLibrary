# 📚 REPORTE: Aplicación de Escritorio de Biblioteca de Juegos

## "Game Haven" - Biblioteca Digital de Juegos

---

## Tabla de Contenidos
1. [Definición](#definición)
2. [Características Principales](#características-principales)
3. [Tecnología Utilizada](#tecnología-utilizada)
4. [Ejemplo de Funcionamiento: Aplicación "Game Haven"](#ejemplo-de-funcionamiento-aplicación-game-haven)
5. [Características que Cumple Game Haven como Aplicación de Escritorio](#características-que-cumple-game-haven-como-aplicación-de-escritorio)
6. [Conclusión](#conclusión)
7. [URL de Referencia / Links de la Aplicación](#url-de-referencia--links-de-la-aplicación)

---

## Definición

### ¿Qué es Game Haven?

**Game Haven** es una aplicación de escritorio desarrollada en **Microsoft Visual Studio** utilizando **C#** y **.NET Framework 4.8**, diseñada para gestionar y organizar una biblioteca digital de videojuegos de múltiples plataformas.

esta aplicación permite a los usuarios:
- **Registrar videojuegos** de diversas plataformas (PC, PlayStation, Xbox, Nintendo, Móvil)
- **Gestionar su biblioteca personal** con títulos, géneros, desarrolladores y información relacionada
- **Realizar búsquedas avanzadas** basadas en criterios específicos
- **Clasificar juegos** por estado (Pendiente, Jugando, Completado, Abandonado)
- **Exportar datos** en formatos estándar (JSON, CSV)
- **Acceder a información localmente** sin dependencia de internet

### Propósito Principal

Game Haven soluciona la necesidad común de jugadores y coleccionistas de videojuegos de mantener un registro organizado y accesible de su biblioteca personal, permitiendo un control total sobre sus juegos, estado de progreso, calificaciones personales y notas adicionales.

---

## Características Principales

### 1. 🎮 Gestión de Biblioteca de Juegos
- **Agregar juegos** con información completa
- **Editar datos** existentes en cualquier momento
- **Eliminar juegos** de la biblioteca
- **Visualizar lista completa** en interfaz intuitiva

### 2. 🔍 Búsqueda y Filtrado Avanzado
- Buscar por **título del juego**
- Filtrar por **plataforma** (PC, PS4, PS5, Xbox One, Xbox Series X, Switch, etc.)
- Filtrar por **género** (Acción, RPG, Estrategia, Puzzle, etc.)
- Filtrar por **estado del juego** (Pendiente, Jugando, Pausado, Completado, Abandonado)
- Mostrar solo **juegos favoritos**
- Combinación de múltiples filtros

### 3. 📊 Información Detallada de Juegos
Cada juego registra:
- **Título** del juego
- **Plataforma** de juego
- **Género** (Acción, Aventura, RPG, Estrategia, etc.)
- **Año de lanzamiento**
- **Desarrollador**
- **Estado actual** (Pendiente, Jugando, Pausado, Completado, Abandonado)
- **Calificación personal** (0-10)
- **Horas jugadas** (registro de tiempo invertido)
- **Marcador de favoritos** (❤️)
- **Notas personales** (observaciones, comentarios)
- **Fechas** (Agregado, Modificado, Completado)

### 4. 📁 Almacenamiento Local
- Base de datos **local en formato JSON**
- **Sin conexión a internet** requerida
- **Almacenamiento persistente** en la máquina local
- **Archivo único** de fácil respaldo

### 5. 📤 Exportación de Datos
- Exportar a **formato JSON** (estructura completa)
- Exportar a **formato CSV** (compatible con Excel)
- Opciones de exportación:
  - Todos los juegos
  - Solo favoritos
  - Por plataforma específica
  - Por estado específico

### 6. 🖼️ Interfaz Gráfica Intuitiva
- **Ventana principal** con lista en DataGridView
- **Ventanas modales** para agregar/editar juegos
- **Botones de acción** rápida (Agregar, Editar, Eliminar, Buscar, Exportar)
- **Diseño responsive** y amigable
- **Mensajes informativos** de confirmación y validación

### 7. 💾 Persistencia de Datos
- **Guardado automático** de cambios
- **Sincronización en tiempo real** con archivo local
- **Historial de cambios** (fechas de modificación)
- **Recuperación de datos** confiable

---

## Tecnología Utilizada

### 🔧 Plataforma y Framework
| Elemento | Tecnología | Versión |
|----------|-----------|---------|
| **Lenguaje de Programación** | C# | 7.3 |
| **Framework Destino** | .NET Framework | 4.8 |
| **IDE de Desarrollo** | Visual Studio Community | 2026 (18.10.0) |
| **Plataforma Destino** | Windows | Vista o superior |

### 📚 Componentes Principales

#### 1. **Windows Forms**
- Framework para crear interfaces gráficas en aplicaciones de escritorio
- Componentes utilizados:
  - `Form` - Ventanas principales y modales
  - `DataGridView` - Tabla de visualización de datos
  - `TextBox` - Campos de texto para entrada de datos
  - `ComboBox` - Listas desplegables de opciones
  - `Button` - Botones de acción
  - `CheckBox` - Casillas de verificación
  - `NumericUpDown` - Campos numéricos
  - `Label` - Etiquetas de texto
  - `Panel` - Contenedores de controles

#### 2. **System.Data y Archivos**
- `System.IO` - Lectura y escritura de archivos
- `System.Collections.Generic` - Listas y colecciones
- `System.Linq` - Consultas de datos en memoria
- `System.Text` - Manejo de cadenas de texto
- `System.Globalization` - Formato de datos internacionales

#### 3. **Almacenamiento de Datos**
- **Formato JSON** - Almacenamiento estructurado en texto
- **Archivo local** - `GameLibrary.json`
- **Serialización manual** - Conversión entre objetos y JSON
- **Sin base de datos SQL** - Simplificación del despliegue

### 🏗️ Arquitectura General

```
┌─────────────────────────────────────────────────────────┐
│                  APLICACIÓN GAME HAVEN                   │
├─────────────────────────────────────────────────────────┤
│                                                           │
│  ┌──────────────────────────────────────────────────┐   │
│  │          CAPA DE PRESENTACIÓN (UI)                │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  MainForm (Ventana Principal)             │    │   │
│  │  │  - DataGridView con lista de juegos       │    │   │
│  │  │  - Botones de acción                      │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  AddGameForm (Ventana Modal)              │    │   │
│  │  │  - Formulario de nuevo juego              │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  EditGameForm (Ventana Modal)             │    │   │
│  │  │  - Formulario de edición                  │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  SearchFilterForm (Ventana Modal)         │    │   │
│  │  │  - Búsqueda y filtrado avanzado           │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  ExportForm (Ventana Modal)               │    │   │
│  │  │  - Exportación de datos                   │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  └──────────────────────────────────────────────────┘   │
│                           ▼                             │
│  ┌──────────────────────────────────────────────────┐   │
│  │      CAPA DE LÓGICA DE NEGOCIO                    │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  ExportManager                            │    │   │
│  │  │  - Exportación a JSON                     │    │   │
│  │  │  - Exportación a CSV                      │    │   │
│  │  │  - Validación y formato de datos          │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  Helpers (Conversores)                   │    │   │
│  │  │  - PlatformHelper                        │    │   │
│  │  │  - GameStatusHelper                      │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  └──────────────────────────────────────────────────┘   │
│                           ▼                             │
│  ┌──────────────────────────────────────────────────┐   │
│  │      CAPA DE ACCESO A DATOS (DAL)                │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  DatabaseManager                         │    │   │
│  │  │  - CRUD (Create, Read, Update, Delete)   │    │   │
│  │  │  - Búsqueda y filtrado                   │    │   │
│  │  │  - Persistencia en JSON                  │    │   │
│  │  │  - Gestión de ID                         │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  └──────────────────────────────────────────────────┘   │
│                           ▼                             │
│  ┌──────────────────────────────────────────────────┐   │
│  │      CAPA DE MODELOS DE DATOS                     │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  Game (Clase Principal)                  │    │   │
│  │  │  - 14 propiedades de juego               │    │   │
│  │  │  - Métodos de conversión                 │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  Platform (Enum)                         │    │   │
│  │  │  - 10 plataformas soportadas            │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  GameStatus (Enum)                       │    │   │
│  │  │  - 5 estados de juego                    │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  └──────────────────────────────────────────────────┘   │
│                           ▼                             │
│  ┌──────────────────────────────────────────────────┐   │
│  │      CAPA DE ALMACENAMIENTO                       │   │
│  │  ┌──────────────────────────────────────────┐    │   │
│  │  │  GameLibrary.json                        │    │   │
│  │  │  - Base de datos local                   │    │   │
│  │  │  - Persistencia de datos                 │    │   │
│  │  └──────────────────────────────────────────┘    │   │
│  └──────────────────────────────────────────────────┘   │
│                                                           │
└─────────────────────────────────────────────────────────┘
```

### 📦 Estructura de Carpetas del Proyecto

```
GameLibrary/
│
├── 📁 Models/                          (Modelos de Datos)
│   ├── Game.cs                         (Clase principal de juego)
│   ├── Platform.cs                     (Enum de plataformas + helpers)
│   └── GameStatus.cs                   (Enum de estados + helpers)
│
├── 📁 Data/                            (Acceso a Datos)
│   └── DatabaseManager.cs              (Gestor de base de datos)
│
├── 📁 Forms/                           (Formularios / UI)
│   ├── Form1.cs                        (MainForm - Ventana principal)
│   ├── Form1.Designer.cs               (Diseño de MainForm)
│   ├── AddGameForm.cs                  (Formulario de agregar)
│   ├── AddGameForm.Designer.cs         (Diseño de AddGameForm)
│   ├── EditGameForm.cs                 (Formulario de editar)
│   ├── EditGameForm.Designer.cs        (Diseño de EditGameForm)
│   ├── SearchFilterForm.cs             (Formulario de búsqueda)
│   ├── SearchFilterForm.Designer.cs    (Diseño de SearchFilterForm)
│   ├── ExportForm.cs                   (Formulario de exportación)
│   └── ExportForm.Designer.cs          (Diseño de ExportForm)
│
├── 📁 Utils/                           (Utilidades)
│   └── ExportManager.cs                (Gestor de exportación)
│
├── 📁 Properties/                      (Propiedades del Proyecto)
│   ├── AssemblyInfo.cs
│   ├── Resources.resx
│   ├── Resources.Designer.cs
│   ├── Settings.settings
│   └── Settings.Designer.cs
│
├── Program.cs                          (Punto de entrada)
├── App.config                          (Configuración de aplicación)
├── GameLibrary.csproj                  (Proyecto C#)
├── GameLibrary.json                    (Base de datos local)
└── GameLibrary.slnx                    (Solución de Visual Studio)
```

### 📊 Dependencias y Referencias

| Referencia | Descripción | Propósito |
|-----------|------------|----------|
| `System` | Biblioteca base | Funciones fundamentales |
| `System.Windows.Forms` | Framework de UI | Interfaz gráfica |
| `System.Drawing` | Gráficos y dibujo | Colores y recursos visuales |
| `System.Data` | Acceso a datos | Manejo de datos |
| `System.Xml` | Procesamiento XML | Configuración |
| `System.IO` | Entrada/Salida | Lectura/escritura de archivos |
| `System.Collections.Generic` | Colecciones genéricas | Listas y diccionarios |
| `System.Linq` | Consultas de datos | Búsqueda y filtrado |
| `System.Text` | Procesamiento de texto | Manipulación de cadenas |
| `System.Globalization` | Globalización | Formato internacional |

---

## Ejemplo de Funcionamiento: Aplicación "Game Haven"

### 📖 Caso de Uso: Un Jugador Organiza su Biblioteca de Videojuegos

#### **Escenario: Carlos es un coleccionista de videojuegos**

Carlos tiene una colección de más de 100 videojuegos en diferentes plataformas (PC, PlayStation 4, Xbox One y Nintendo Switch). Quiere organizar su biblioteca, llevar un registro de qué juegos está jugando, cuáles ha completado y cuáles tiene pendientes. También desea poder buscar rápidamente un juego específico y exportar su biblioteca.

---

### 🎮 **Paso 1: Iniciar la Aplicación**

**Acción del Usuario:**
1. Carlos abre Visual Studio
2. Ejecuta el proyecto GameLibrary (presiona F5)
3. Se abre la ventana principal de Game Haven

**Lo que sucede internamente:**
```
Program.cs (Main)
	↓
Application.EnableVisualStyles()
	↓
Application.Run(new Form1())
	↓
Form1_Load()
	├─ Inicializa DatabaseManager("GameLibrary.json")
	├─ Carga todos los juegos existentes
	│  └─ Si es primera vez: crea archivo vacío []
	├─ Inicializa controles de la UI
	│  ├─ Crea DataGridView
	│  ├─ Crea Panel de botones
	│  └─ Crea botones (Agregar, Editar, Eliminar, Buscar, Exportar)
	└─ Muestra ventana principal
```

**Pantalla Inicial:**
```
┌─────────────────────────────────────────────────────────┐
│ Biblioteca de Juegos - 0 juego(s)              [X]     │
├─────────────────────────────────────────────────────────┤
│ ┌─ Botones ──────────────────────────────────────────┐ │
│ │ ➕ Agregar | ✏️ Editar | 🗑️ Eliminar | 🔍 Buscar | 📥 Exportar │
│ └─────────────────────────────────────────────────────┘ │
├─────────────────────────────────────────────────────────┤
│                                                           │
│  ID  │ Título │ Plataforma │ Género │ Año │ Estado │... │
│ -----┼────────┼────────────┼────────┼─────┼────────┤    │
│      │  (vacío)            │        │     │        │    │
│      │                     │        │     │        │    │
│                                                           │
└─────────────────────────────────────────────────────────┘
```

---

### 🎮 **Paso 2: Agregar el Primer Juego**

**Acción del Usuario:**
1. Carlos hace clic en el botón "➕ Agregar"
2. Se abre ventana modal AddGameForm

**Pantalla de Agregar Juego:**
```
┌──────────────────────────────────────────┐
│ Agregar Nuevo Juego          [X]         │
├──────────────────────────────────────────┤
│                                          │
│ Título:              [The Witcher 3____] │
│ Plataforma:          [PC              ▼] │
│ Género:              [RPG             ▼] │
│ Desarrollador:       [CD Projekt Red__] │
│ Año:                 [2015            ] │
│ Estado:              [Completado      ▼] │
│ Calificación:        [9.5             ] │
│ Horas Jugadas:       [125             ] │
│ ☑ ¿Es mi favorito?                     │
│                                          │
│ Notas:                                   │
│ ┌──────────────────────────────────────┐ │
│ │ Juego extraordinario, gran música y  │ │
│ │ narrativa. Uno de mis favoritos.     │ │
│ └──────────────────────────────────────┘ │
│                                          │
│             [Guardar]  [Cancelar]        │
└──────────────────────────────────────────┘
```

**Lo que sucede internamente cuando presiona Guardar:**

```
BtnSave_Click()
	↓
1. VALIDACIÓN
   ├─ ¿Título no está vacío? ✓
   └─ Mostrar error si falta
	↓
2. CREAR OBJETO GAME
   new Game() {
	   Title = "The Witcher 3",
	   Platform = Platform.PC,
	   Genre = "RPG",
	   Developer = "CD Projekt Red",
	   ReleaseYear = 2015,
	   Status = GameStatus.Completado,
	   IsFavorite = true,
	   Rating = 9.5,
	   HoursPlayed = 125,
	   Notes = "Juego extraordinario...",
	   DateAdded = DateTime.Now
   }
	↓
3. GUARDAR EN BASE DE DATOS
   DatabaseManager.AddGame(game)
   ├─ Asignar ID = 1 (autoincremento)
   ├─ Agregar a lista en memoria
   ├─ Convertir a JSON
   ├─ Guardar en GameLibrary.json
   └─ Retornar ID generado
	↓
4. MOSTRAR MENSAJE
   MessageBox: "Juego agregado exitosamente (ID: 1)"
	↓
5. CERRAR VENTANA MODAL
   DialogResult = DialogResult.OK
	↓
6. ACTUALIZAR VENTANA PRINCIPAL
   LoadGames()
   ├─ DatabaseManager.GetAllGames()
   ├─ Actualizar DataGridView
   └─ Mostrar título "Biblioteca de Juegos - 1 juego(s)"
```

**Contenido de GameLibrary.json después de agregar:**
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
	"notes": "Juego extraordinario, gran música y narrativa...",
	"dateAdded": "2024-01-15 10:30:22",
	"dateModified": null,
	"dateCompleted": "2024-01-15 10:30:22"
  }
]
```

---

### 🎮 **Paso 3: Agregar Más Juegos**

Carlos agrega más juegos a su biblioteca (simplificado):

| ID | Título | Plataforma | Género | Año | Estado | Horas | Favorito |
|---|---|---|---|---|---|---|---|
| 1 | The Witcher 3 | PC | RPG | 2015 | Completado | 125 | ❤️ |
| 2 | Elden Ring | PS5 | Action RPG | 2022 | Jugando | 87 | ❤️ |
| 3 | Halo Infinite | Xbox Series X | Shooter | 2021 | Pausado | 45 | - |
| 4 | Super Smash Bros | Switch | Lucha | 2018 | Completado | 200 | ❤️ |
| 5 | Cyberpunk 2077 | PC | RPG | 2020 | Pendiente | 0 | ❤️ |

**DataGridView después de agregar todos los juegos:**
```
┌─────────────────────────────────────────────────────────────────────────────┐
│ Biblioteca de Juegos - 5 juego(s)                                   [X]     │
├─────────────────────────────────────────────────────────────────────────────┤
│ ➕ Agregar | ✏️ Editar | 🗑️ Eliminar | 🔍 Buscar | 📥 Exportar              │
├─────────────────────────────────────────────────────────────────────────────┤
│ ID │Título           │Plataforma    │Género      │Año │Estado       │Fav│... │
├────┼─────────────────┼──────────────┼────────────┼────┼─────────────┼───┤    │
│ 1  │The Witcher 3    │PC            │RPG         │2015│Completado   │❤️ │    │
│ 2  │Elden Ring       │PlayStation 5 │Action RPG  │2022│Jugando      │❤️ │    │
│ 3  │Halo Infinite    │Xbox Series X │Shooter     │2021│Pausado      │   │    │
│ 4  │Super Smash Bros │Nintendo Sw...│Lucha       │2018│Completado   │❤️ │    │
│ 5  │Cyberpunk 2077   │PC            │RPG         │2020│Pendiente    │❤️ │    │
│    │                 │              │            │    │             │   │    │
└────┴─────────────────┴──────────────┴────────────┴────┴─────────────┴───┴────┘
```

---

### 🎮 **Paso 4: Buscar y Filtrar Juegos**

**Caso: Carlos quiere ver todos sus juegos de RPG en plataformas PC y PS5**

**Acción del Usuario:**
1. Hace clic en "🔍 Buscar"
2. Se abre SearchFilterForm
3. Completa los filtros:
   - Búsqueda: "RPG"
   - Género: "RPG"
   - Estado: (dejar como "Todos")
   - Solo favoritos: ☑

**Pantalla de Búsqueda:**
```
┌──────────────────────────────────────────┐
│ Buscar y Filtrar Juegos      [X]         │
├──────────────────────────────────────────┤
│                                          │
│ Buscar:    [RPG________________]         │
│ Plataforma:[Todas            ▼]         │
│ Género:    [RPG              ▼]         │
│ Estado:    [Todos            ▼]         │
│ ☑ Solo mis favoritos                    │
│                                          │
│             [🔍 Buscar]  [Cancelar]     │
└──────────────────────────────────────────┘
```

**Lo que sucede internamente:**
```
BtnSearch_Click()
	↓
1. OBTENER TODOS LOS JUEGOS
   filteredGames = DatabaseManager.GetAllGames()
   → [The Witcher 3, Elden Ring, Halo Infinite, Super Smash Bros, Cyberpunk 2077]
	↓
2. FILTRAR POR TEXTO ("RPG")
   filteredGames = filteredGames.Where(
	   g => g.Title.Contains("RPG") ||
			g.Genre.Contains("RPG") ||
			g.Developer.Contains("RPG")
   ).ToList()
   → [The Witcher 3, Elden Ring, Cyberpunk 2077]
	↓
3. FILTRAR POR GÉNERO ("RPG")
   filteredGames = filteredGames.Where(
	   g => g.Genre == "RPG"
   ).ToList()
   → [The Witcher 3, Cyberpunk 2077]
	↓
4. FILTRAR SOLO FAVORITOS (☑)
   filteredGames = filteredGames.Where(
	   g => g.IsFavorite == true
   ).ToList()
   → [The Witcher 3, Cyberpunk 2077]
	↓
5. MOSTRAR RESULTADO
   MessageBox: "Se encontraron 2 juego(s)"
	↓
6. RETORNAR A MAINFORM
   MainForm recibe SearchFilterForm.FilteredGames
	↓
7. ACTUALIZAR DATAGRIDVIEW
   DataGridView.DataSource = filteredGames
   Title = "Biblioteca de Juegos - 2 resultados"
```

**Resultado de la búsqueda:**
```
┌─────────────────────────────────────────────────────────────────┐
│ Biblioteca de Juegos - 2 resultados                     [X]     │
├─────────────────────────────────────────────────────────────────┤
│ ➕ Agregar | ✏️ Editar | 🗑️ Eliminar | 🔍 Buscar | 📥 Exportar  │
├─────────────────────────────────────────────────────────────────┤
│ ID │Título          │Plataforma│Género │Año │Estado    │Fav│... │
├────┼────────────────┼──────────┼───────┼────┼──────────┼───┤    │
│ 1  │The Witcher 3   │PC        │RPG    │2015│Completado│❤️ │    │
│ 5  │Cyberpunk 2077  │PC        │RPG    │2020│Pendiente │❤️ │    │
│    │                │          │       │    │          │   │    │
└────┴────────────────┴──────────┴───────┴────┴──────────┴───┴────┘
```

---

### 🎮 **Paso 5: Editar un Juego**

**Caso: Carlos está jugando Cyberpunk 2077 y quiere actualizar su información**

**Acción del Usuario:**
1. Selecciona "Cyberpunk 2077" en la tabla
2. Hace clic en "✏️ Editar"
3. Se abre EditGameForm con datos precargados
4. Actualiza:
   - Estado: Pendiente → Jugando
   - Horas: 0 → 32
   - Calificación: vacío → 8.0
   - Notas: agrega comentarios

**Lo que sucede internamente:**

```
BtnEdit_Click()
	↓
1. VERIFICAR SELECCIÓN
   if (selectedRows.Count == 0)
	   MessageBox: "Selecciona un juego para editar"
	   return;
	↓
2. OBTENER GAME ID Y DATOS
   int gameId = selectedRow.Cells["ID"].Value
   Game game = DatabaseManager.GetGameById(gameId)
	↓
3. ABRIR FORMULARIO MODAL
   EditGameForm editForm = new EditGameForm(dbManager, game)
   editForm.ShowDialog()
	↓
4. PRELLENAR FORMULARIO
   EditGameForm_Load()
   ├─ txtTitle.Text = game.Title
   ├─ cmbPlatform.SelectedItem = game.Platform
   ├─ cmbGenre.SelectedItem = game.Genre
   ├─ numRating.Value = game.Rating
   ├─ numHours.Value = game.HoursPlayed
   ├─ cmbStatus.SelectedIndex = game.Status - 1
   └─ txtNotes.Text = game.Notes
	↓
5. USUARIO MODIFICA Y PRESIONA GUARDAR
   BtnSave_Click()
   ├─ Actualización de propiedades
   │  ├─ Status = GameStatus.Jugando (2)
   │  ├─ HoursPlayed = 32
   │  ├─ Rating = 8.0
   │  └─ Notes = "Juego muy bueno, se anticipa mucho..."
   │
   ├─ Asignar fecha de modificación
   │  └─ game.DateModified = DateTime.Now
   │
   ├─ Si cambió a "Completado" y no tiene fecha
   │  └─ game.DateCompleted = DateTime.Now
   │
   ├─ Guardar en DatabaseManager
   │  └─ DatabaseManager.UpdateGame(game)
   │     ├─ Encontrar juego en lista por ID
   │     ├─ Actualizar todas las propiedades
   │     ├─ Convertir lista a JSON
   │     ├─ Guardar en GameLibrary.json
   │     └─ Retornar true
   │
   └─ Cerrar formulario y recargar MainForm
	   └─ LoadGames()
		   ├─ DatabaseManager.GetAllGames()
		   ├─ Actualizar DataGridView
		   └─ Mostrar cambios en tiempo real
	↓
6. MOSTRAR CONFIRMACIÓN
   MessageBox: "Juego actualizado exitosamente"
```

**Contenido de GameLibrary.json actualizado:**
```json
[
  {
	"id": 5,
	"title": "Cyberpunk 2077",
	"platform": 1,
	"genre": "RPG",
	"releaseYear": 2020,
	"developer": "CD Projekt Red",
	"status": 2,           // ← Cambió a "Jugando"
	"isFavorite": true,
	"rating": 8.0,         // ← Nuevo valor de calificación
	"hoursPlayed": 32,     // ← Actualizado a 32 horas
	"notes": "Juego muy bueno, se anticipa mucho...",
	"dateAdded": "2024-01-15 10:30:22",
	"dateModified": "2024-01-15 11:45:30",  // ← Actualizado
	"dateCompleted": null
  }
]
```

---

### 🎮 **Paso 6: Exportar Biblioteca**

**Caso: Carlos quiere exportar su biblioteca para hacer un respaldo**

**Acción del Usuario:**
1. Hace clic en "📥 Exportar"
2. Se abre ExportForm
3. Selecciona opción: "Todos los juegos"
4. Selecciona formato: "CSV"
5. Presiona "Exportar"

**Pantalla de Exportación:**
```
┌──────────────────────────────────────────┐
│ Exportar datos                  [X]      │
├──────────────────────────────────────────┤
│                                          │
│ ¿Qué deseas exportar?                   │
│ [Todos los juegos ▼]                    │
│                                          │
│ Filtro:                                  │
│ [                             ▼]        │
│                                          │
│ Formato:                                 │
│ ● JSON                                  │
│ ○ CSV                          [✓]      │
│                                          │
│             [📥 Exportar]  [Cancelar]   │
└──────────────────────────────────────────┘
```

**Lo que sucede internamente:**

```
BtnExport_Click()
	↓
1. VALIDACIÓN
   if (gamesToExport.Count == 0)
	   MessageBox: "No hay juegos para exportar"
	   return;
	↓
2. OBTENER LISTA A EXPORTAR
   switch (cmbExportType.SelectedIndex) {
	   case 0: gamesToExport = dbManager.GetAllGames() ✓
	   case 1: gamesToExport = dbManager.GetFavorites()
	   case 2: gamesToExport = dbManager.FilterByPlatform(platform)
	   case 3: gamesToExport = dbManager.FilterByStatus(status)
   }
	↓
3. ABRIR DIÁLOGO GUARDAR ARCHIVO
   SaveFileDialog saveDialog = new SaveFileDialog()
   saveDialog.Filter = "CSV files (*.csv)|*.csv"
   saveDialog.FileName = $"GameLibrary_{DateTime.Now:yyyyMMdd_HHmmss}"
	↓
4. USUARIO SELECCIONA UBICACIÓN Y PRESIONA GUARDAR
   if (saveDialog.ShowDialog() == DialogResult.OK)
	↓
5. EXPORTAR A CSV
   ExportManager.ExportCsvToFile(gamesToExport, filePathPath)
   ├─ string csv = ExportManager.ExportToCsv(gamesToExport)
   │  ├─ Crear encabezado:
   │  │  "ID,Título,Plataforma,Género,Año,Desarrollador,..."
   │  │
   │  └─ Por cada juego:
   │     "1,The Witcher 3,PC,RPG,2015,CD Projekt Red,..."
   │
   └─ File.WriteAllText(filePath, csv)
	   └─ Guardar en disco
	↓
6. MOSTRAR CONFIRMACIÓN
   MessageBox: "Exportación exitosa!
			   5 juego(s) exportados.
			   C:\Users\Carlos\Documents\GameLibrary_20240115_114530.csv"
```

**Archivo CSV generado:**
```csv
ID,Título,Plataforma,Género,Año,Desarrollador,Estado,Favorito,Calificación,Horas Jugadas,Notas,Fecha Agregado,Fecha Modificado,Fecha Completado
1,"The Witcher 3","PC","RPG",2015,"CD Projekt Red","Completado","Sí",9.5,125,"Juego extraordinario...",2024-01-15 10:30:22,2024-01-15 10:30:22,2024-01-15 10:30:22
2,"Elden Ring","PlayStation 5","Action RPG",2022,"FromSoftware","Jugando","Sí",9.0,87,"Desafiante pero rewarding",2024-01-15 10:31:00,2024-01-15 11:20:00,
3,"Halo Infinite","Xbox Series X","Shooter",2021,"343 Industries","Pausado","No",7.5,45,"Buen juego, debe retomar",2024-01-15 10:31:30,,
4,"Super Smash Bros","Nintendo Switch","Lucha",2018,"Bandai Namco","Completado","Sí",8.5,200,"Clásico de Nintendo",2024-01-15 10:32:00,2024-01-15 10:32:00,2024-01-15 10:32:00
5,"Cyberpunk 2077","PC","RPG",2020,"CD Projekt Red","Jugando","Sí",8.0,32,"Juego muy bueno",2024-01-15 10:30:22,2024-01-15 11:45:30,
```

---

### 🎮 **Resumen del Flujo Completo**

```
INICIO APP
	↓
[Ventana Vacía]
	↓
USUARIO AGREGA 5 JUEGOS
	↓
[DataGridView con 5 filas]
	↓
USUARIO BUSCA "RPG" + FAVORITOS
	↓
[DataGridView mostrando 2 resultados]
	↓
USUARIO EDITA "Cyberpunk 2077"
	├─ Abre EditGameForm
	├─ Modifica Estado, Horas, Calificación
	├─ Presiona Guardar
	└─ Vuelve a MainForm
		↓
[DataGridView actualizado]
	↓
USUARIO EXPORTA A CSV
	├─ Abre ExportForm
	├─ Selecciona "Todos"
	├─ Formato CSV
	├─ Presiona Exportar
	└─ Selecciona ubicación
		↓
[Archivo CSV creado en disco]
	↓
FIN DEL CASO DE USO
```

---

## Características que Cumple Game Haven como Aplicación de Escritorio

### ✅ Checklist de Características

| # | Característica | Cumple | Evidencia |
|---|---|---|---|
| 1 | **Instalación local en el equipo** | ✅ | Ejecutable .exe generado en bin\Debug o bin\Release |
| 2 | **Procesamiento de datos de forma local** | ✅ | Todos los cálculos ocurren en la máquina local, no hay servidores remotos |
| 3 | **Uso de base de datos local** | ✅ | GameLibrary.json almacenado en AppData o carpeta local |
| 4 | **Interacción directa con dispositivos y recursos del sistema** | ✅ | Acceso a System.IO, System.Windows.Forms, recursos del sistema |
| 5 | **Funcionamiento independiente de un navegador web** | ✅ | No requiere navegador, es aplicación nativa |
| 6 | **Ejecución y operación en el entorno local** | ✅ | Se ejecuta completamente en la máquina local |
| 7 | **Uso de tecnologías específicas para aplicaciones de escritorio** | ✅ | Windows Forms, C#, .NET Framework |
| 8 | **Compatibilidad con el sistema operativo Windows** | ✅ | Desarrollada específicamente para Windows |
| 9 | **Uso de ventanas modales** | ✅ | AddGameForm, EditGameForm, SearchFilterForm, ExportForm |
| 10 | **Uso de ventanas no modales** | ✅ | MainForm permite interacción continua |
| 11 | **Interfaz gráfica intuitiva** | ✅ | Botones claros, campos etiquetados, validaciones |
| 12 | **Almacenamiento persistente** | ✅ | Datos guardados en archivo JSON |
| 13 | **Acceso sin conexión a internet** | ✅ | Funciona completamente offline |
| 14 | **Gestión de datos eficiente** | ✅ | Búsqueda, filtrado, ordenamiento rápido |

### 📊 Análisis Detallado

#### 1️⃣ **Instalación Local**
```
Proceso de Instalación:
├─ Descargar/clonar proyecto de GitHub
├─ Abrir en Visual Studio
├─ Build → Release
├─ Ejecutable generado en:
│  └─ bin\Release\GameLibrary.exe
├─ Usuario ejecuta .exe
├─ Se crea GameLibrary.json en directorio de ejecución
└─ ✅ Aplicación operativa sin dependencias externas
```

#### 2️⃣ **Procesamiento Local**
Toda la lógica se ejecuta en la máquina:
- **CRUD**: Create (agregar), Read (listar), Update (editar), Delete (eliminar)
- **Búsqueda**: Procesada con LINQ en memoria
- **Filtrado**: Sin conexión a servidores
- **Exportación**: Generada localmente

#### 3️⃣ **Base de Datos Local**
```
Archivo: GameLibrary.json
Ubicación: [DirectorioDeEjecución]\GameLibrary.json
Formato: JSON textual
Tamaño: Crece con número de juegos (~100 bytes por juego)
Respaldo: Simple copia del archivo
```

#### 4️⃣ **Interacción con Dispositivos**
- **Sistema de archivos**: Lectura/escritura de JSON
- **Interfaz de usuario** integrada con Windows
- **Recursos gráficos**: Colores, fuentes del sistema
- **Reloj del sistema**: Para registrar fechas y horas

#### 5️⃣ **Sin Navegador Web**
- No utiliza HTTP, HTML, CSS, o JavaScript
- No requiere navegadores como Chrome, Firefox, Edge
- Interfaz nativa de Windows Forms
- Control total del programa

#### 6️⃣ **Tecnologías de Escritorio**
| Tecnología | Uso |
|-----------|-----|
| **C#** | Lenguaje de programación |
| **.NET Framework 4.8** | Runtime |
| **Windows Forms** | UI Framework |
| **System.IO** | Archivos |
| **System.Collections.Generic** | Estructuras de datos |
| **System.Linq** | Consultas de datos |

#### 7️⃣ **Ventanas Modales vs No Modales**

**Ventanas Modales** (requieren atención):
```
MainForm (No Modal)
	↓
Usuario presiona "Agregar"
	↓
AddGameForm (Modal)
├─ Bloquea entrada en MainForm
├─ Requiere Guardar o Cancelar
└─ Retorna a MainForm
	↓
Usuario presiona "Editar"
	↓
EditGameForm (Modal)
├─ Bloquea entrada en MainForm
├─ Requiere Guardar o Cancelar
└─ Retorna a MainForm
```

**Ventana No Modal** (permite multitarea):
```
MainForm (No Modal)
├─ Permite ver tabla mientras otras ventanas están abiertas
├─ Usuario puede tener múltiples operaciones abiertas
└─ Flexibilidad en la navegación
```

---

## Conclusión

### 🎯 Resumen de Game Haven

**Game Haven** es una solución completa y funcional de **aplicación de escritorio** que cumple con todos los requisitos y características de este tipo de software. Ha sido desarrollada utilizando tecnologías modernas y estándares de la industria, proporcionando a los usuarios una herramienta robusta para gestionar su biblioteca de videojuegos.

### 📈 Logros Principales

✅ **Arquitectura escalable** - Separación clara de capas (UI, Lógica, Datos)  
✅ **Interfaz intuitiva** - Fácil de usar incluso para usuarios sin experiencia técnica  
✅ **Funcionalidad completa** - CRUD, búsqueda, filtrado, exportación  
✅ **Sin dependencias externas** - Usa solo librerías estándar de .NET  
✅ **Almacenamiento seguro** - Datos guardados localmente en formato accesible  
✅ **Rendimiento óptimo** - Búsquedas y filtrados rápidos  
✅ **Código limpio** - Fácil de mantener y extender  

### 🚀 Ventajas de Game Haven

1. **Privacidad total** - Los datos nunca se envían a internet
2. **Sostenibilidad** - No requiere servidor o hosting
3. **Velocidad** - Sin latencia de red
4. **Control total** - Usuario es dueño de sus datos
5. **Facilidad de backup** - Copiar archivo JSON es suficiente
6. **Multiplataforma potencial** - Código reutilizable en .NET Core/.NET 5+
7. **Bajo requisito de recursos** - Ejecutable pequeño y eficiente

### 💡 Posibles Mejoras Futuras

- 🎨 Tema oscuro/claro dinámico
- 📊 Dashboard con estadísticas (juegos por plataforma, estado, etc.)
- 🖼️ Carátulas de juegos descargables
- ☁️ Sincronización opcional en la nube
- 📱 Versión móvil complementaria
- 🌐 Multi-idioma
- 📈 Análisis de juego más detallado

### 🏆 Conclusión Final

Game Haven demuestra de manera práctica cómo una **aplicación de escritorio moderna** puede ser desarrollada siguiendo principios SOLID, arquitectura en capas, y mejores prácticas de programación. Es un proyecto educativo y funcional que puede servir como base para aplicaciones más complejas o como referencia para desarrolladores en formación.

La aplicación cumple 100% con los requisitos de una aplicación de escritorio Windows, operando completamente en el entorno local, sin dependencias externas, y proporcionando una experiencia de usuario consistente y eficiente.

---

## URL de Referencia / Links de la Aplicación

### 📍 Repositorio GitHub

**Repository:**
```
https://github.com/danielsosadev-hub/GameLibrary
```

**Ubicación Local:**
```
C:\VisualProyects\GameLibrary\
```

### 📂 Archivos Principales

| Archivo | Ubicación | Descripción |
|---------|-----------|-------------|
| **Solución** | `GameLibrary.slnx` | Solución de Visual Studio |
| **Proyecto** | `GameLibrary.csproj` | Archivo de proyecto C# |
| **Base de Datos** | `GameLibrary.json` | Almacenamiento de datos |
| **Programa Principal** | `Program.cs` | Punto de entrada |
| **Formulario Principal** | `Forms/Form1.cs` | MainForm |

### 🔗 Comandos Git

Para obtener una copia del proyecto:

```bash
# Clonar repositorio
git clone https://github.com/danielsosadev-hub/GameLibrary.git

# Navegar al directorio
cd GameLibrary

# Abrir en Visual Studio
start GameLibrary.slnx

# O compilar desde línea de comandos
dotnet build

# Ejecutar aplicación
dotnet run
```

### 📚 Tecnologías Utilizadas

- **Lenguaje:** C# 7.3+
- **Framework:** .NET Framework 4.8
- **IDE:** Visual Studio Community 2026
- **UI:** Windows Forms
- **Almacenamiento:** JSON
- **Control de versiones:** Git/GitHub

### 👨‍💻 Desarrollo

**Autor:** GameLibrary Development Team  
**Estado:** Completado  
**Fecha:** 2024-01-15  
**Versión:** 1.0 Release  
**Licencia:** MIT (Recomendado)  

### 📞 Información Adicional

Para más información sobre las características, instalación o cómo contribuir al proyecto, consulte el archivo `README.md` en el repositorio.

---

**Documento Generado:** 2024-01-15  
**Versión del Reporte:** 1.0  
**Estado:** Completado ✅
