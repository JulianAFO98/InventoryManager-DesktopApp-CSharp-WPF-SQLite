# InventoryManager - Desktop App

Una aplicación de escritorio para la gestión de productos e inventario, desarrollada con C# y WPF, siguiendo el patrón arquitectónico MVVM.

## 📋 Descripción

InventoryManager es una aplicación desktop que permite:
- **Gestionar productos**: crear, editar, eliminar y visualizar productos en tiempo real
- **Categorización**: clasificar productos por categoría (Juguete, Consumo, Cristalería, Decoración, Otro)
- **Cálculo automático**: calcula el precio total (Precio × Stock) automáticamente
- **Almacenamiento en memoria**: persistencia temporal durante la sesión
- **Interfaz intuitiva**: interfaz moderna basada en WPF con patrón MVVM

## 🛠️ Tecnologías Utilizadas

- **C# 12.0** - Lenguaje de programación moderno
- **WPF (Windows Presentation Foundation)** - Framework para interfaz gráfica
- **.NET 9.0 (Windows)** - Framework de ejecución
- **XAML** - Markup language para UI declarativa
- **MVVM Pattern** - Arquitectura de presentación
- **Almacenamiento** - Actualmente usa SQlite pero se puede reemplazar por memoria(List<T>)

## 📁 Estructura del Proyecto

```
InventoryManager/
├── Views/                    # Capas de presentación (UI)
│   ├── MainWindow.xaml       # Interfaz principal
│   └── MainWindow.xaml.cs    # Code-behind de la ventana
├── ViewModels/               # Lógica de presentación (MVVM)
│   └── ProductViewModel.cs   # ViewModel para productos
├── Models/                   # Modelos de datos
│   └── Product.cs            # Clase de producto
├── Controllers/              # Controladores de lógica de negocio
│   └── ProductController.cs  # Controlador de productos
├── Services/                 # Capa de servicios
│   └── ProductService.cs     # Servicio CRUD de productos
├── Repositories/             # Capa de acceso a datos
│   ├── ProductRepositoryList.cs  # Implementación en memoria(cambiar desde app.xaml.cs)
│   └── ProductRepository.cs      # Implementación SQLite 
├── Interfaces/               # Contratos e interfaces
│   └── IRepositorioDAO.cs    # Interfaz genérica CRUD
├── Commands/                 # Comandos WPF
│   └── RelayCommand.cs       # Implementación de ICommand
├── App.xaml                  # Configuración de aplicación
├── App.xaml.cs               # Setup de inyección de dependencias
└── .editorconfig             # Configuración del editor
```

## 🏗️ Arquitectura

El proyecto utiliza una **arquitectura en capas** con **patrón MVVM**:

```
UI (XAML/WPF)
    ↓
ViewModel (Lógica de presentación)
    ↓
Controller (Lógica de negocio)
    ↓
Service (Lógica CRUD)
    ↓
Repository (Acceso a datos)
```

**Flujo de datos:**
1. El usuario interactúa con la Vista (View)
2. Los comandos se envían al ViewModel
3. El ViewModel utiliza el Controlador
4. El Controlador valida y delega al Servicio
5. El Servicio usa el Repositorio para acceder a datos

## 🚀 Requisitos Previos

Para ejecutar esta aplicación en otra PC necesitas:

- **.NET 9.0 SDK** o posterior ([descargar aquí](https://dotnet.microsoft.com/download))
- **Windows 10/11 o superior** (aplicación Windows desktop)
- Aproximadamente **100 MB** de espacio libre
- Visual Studio Code o Visual Studio (opcional, para desarrollo)

## 💻 Instalación y Ejecución

### Opción 1: Desde el código fuente (recomendado)

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/JulianAFO98/InventoryManager-DesktopApp-C--WPF-SQLite.git
   cd InventoryManager/InventoryManager
   ```

2. **Restaurar dependencias y compilar**
   ```bash
   dotnet build
   ```

3. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

### Opción 2: Ejecutar desde el binario compilado

Si ya está compilado:

```bash
dotnet bin/Debug/net9.0-windows/InventoryManager.dll
```

O simplemente ejecuta el `.exe` generado:

```bash
bin/Debug/net9.0-windows/InventoryManager.exe
```

## 📝 Uso de la Aplicación

1. **Agregar Producto**:
   - Completa los campos: Nombre, Precio, Stock y Categoría
   - Presiona el botón "Guardar"
   - El producto aparecerá en la tabla

2. **Ver Productos**:
   - Los productos se muestran en la tabla de la izquierda
   - Haz clic en un producto para editarlo
   - Se cargarán automáticamente sus datos en el formulario

3. **Editar Producto**:
   - Selecciona un producto de la tabla
   - Modifica los datos que desees
   - Presiona "Guardar" y confirma la acción

4. **Eliminar Producto**:
   - Selecciona un producto
   - Presiona el botón "Eliminar"
   - Confirma la eliminación

5. **Limpiar Formulario**:
   - Presiona "Limpiar" para vaciar todos los campos

## 💾 Almacenamiento de Datos

**Estado Disponible**: Almacenamiento en memoria (List<T>)
- Los datos se pierden al cerrar la aplicación
- Ideal para pruebas y desarrollo
- Rápido y sin configuración

**Estado Actual**: SQLite local
- Requiere: NuGet `Microsoft.Data.Sqlite`
- Proporciona persistencia permanente

## 🔧 Compilar para Distribución

Para crear un ejecutable portátil:

```bash
dotnet publish -c Release -r win-x64 --self-contained
```

El ejecutable estará en: `bin/Release/net9.0-windows/win-x64/publish/`

Tamaño aproximado: ~150 MB (incluye .NET Runtime)

## 📚 Documentación del Código

Todos los métodos y clases principales están documentados con comentarios XML:

- Ejecuta `dotnet build` para generar IntelliSense
- Los comentarios aparecerán al usar las clases
- Facilitando la comprensión del código

## 🐛 Solución de Problemas

**La aplicación no inicia:**
- Verifica que tengas .NET 9.0 instalado: `dotnet --version`
- Intenta limpiar y recompilar: `dotnet clean && dotnet build`

## 📖 Explicación de Módulos

| Módulo | Responsabilidad |
|--------|-----------------|
| **Views** | Interfaz gráfica (XAML + WPF). Muestra datos y captura entrada del usuario. |
| **ViewModels** | Lógica de presentación. Conecta UI con controladores mediante commands y propiedades. |
| **Models** | Define la estructura de datos (Product). Contiene propiedades y lógica de entidad. |
| **Controllers** | Orquesta lógica de negocio. Valida datos y delega operaciones al servicio. |
| **Services** | Implementa operaciones CRUD. Conecta con repositorio y realiza transformaciones de datos. |
| **Repositories** | Accede a datos (en memoria o BD). Define interfaces y sus implementaciones. |
| **Interfaces** | Contratos que definen qué debe hacer cada clase (IRepositorioDAO<T>). |
| **Commands** | Implementa ICommand de WPF para vincular botones con acciones (RelayCommand). |

**Flujo de ejemplo - Crear producto:**
```
Usuario presiona "Guardar" → ViewModel ejecuta GuardarProductoCommand 
→ Controller valida datos → Service crea producto → Repository lo almacena
```

## 📌 Notas

- La aplicación requiere .NET Runtime 9.0 para ejecutarse (o SDK si ejecutas con `dotnet run`)
- Los datos se almacenan en memoria (List<T>) o en SQLite,dependiendo la necesidad o gusto.
- Compatible con Windows 10/11 y versiones posteriores

## 👨‍💻 Autor

JulianAFO98

## 📄 Licencia

Este proyecto está bajo licencia MIT 
