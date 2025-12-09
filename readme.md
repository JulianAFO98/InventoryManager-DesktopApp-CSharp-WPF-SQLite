# InventoryManager - Desktop App

Una aplicación de escritorio para la gestión de productos e inventario, desarrollada con C# y WPF.

## 📋 Descripción

InventoryManager es una aplicación desktop que permite:
- **Gestionar productos**: crear, editar, eliminar y visualizar productos
- **Almacenar datos**: persistencia de datos con SQLite
- **Interfaz intuitiva**: interfaz gráfica moderna basada en WPF

## 🛠️ Tecnologías Utilizadas

- **C# 9.0** - Lenguaje de programación
- **WPF (Windows Presentation Foundation)** - Framework para la interfaz gráfica
- **SQLite** - Base de datos local
- **.NET 9.0 (Windows)** - Framework de ejecución
- **XAML** - Markup language para la interfaz de usuario

## 📁 Estructura del Proyecto

```
InventoryManager/
├── Views/              # Ventanas de la aplicación
│   └── MainWindow.xaml
├── Models/             # Modelos de datos
│   └── Product.cs
├── Controllers/        # Lógica de negocio
│   └── ProductController.cs
├── Repositories/       # Acceso a datos
│   ├── ProductRepository.cs
│   └── ProductRepositoryList.cs
├── Interfaces/         # Contratos de interfaces
│   └── IRepositorioDAO.cs
└── App.xaml           # Configuración principal
```

## 🚀 Requisitos Previos

Para ejecutar esta aplicación en otra PC necesitas:

- **.NET 9.0 SDK** o posterior ([descargar aquí](https://dotnet.microsoft.com/download))
- **Windows 7 o superior** (la aplicación requiere Windows)
- Aproximadamente **50 MB** de espacio libre

## 💻 Instalación y Ejecución

### Opción 1: Desde el código fuente

1. **Clonar el repositorio**
   ```bash
   git clone https://github.com/JulianAFO98/InventoryManager-DesktopApp-C--WPF-SQLite.git
   cd InventoryManager
   ```

2. **Restaurar dependencias y compilar**
   ```bash
   dotnet build
   ```

3. **Ejecutar la aplicación**
   ```bash
   dotnet run
   ```

### Opción 2: Ejecutar el archivo compilado

Si ya está compilado, busca el archivo `InventoryManager.dll` en:
```
bin/Debug/net9.0-windows/
```

Y ejecuta:
```bash
dotnet bin/Debug/net9.0-windows/InventoryManager.dll
```

## 📝 Uso de la Aplicación

1. **Agregar Producto**: Completa los campos "Nombre" y "Precio" en el formulario lateral y presiona "Guardar"
2. **Ver Productos**: Los productos aparecerán en la tabla de la izquierda
3. **Datos**: Los productos se almacenan automáticamente en la base de datos SQLite

## 🗄️ Base de Datos

La aplicación utiliza SQLite, que crea automáticamente una base de datos local:
- Archivo: `productos.db` (creado en el directorio de ejecución)
- Sin configuración adicional necesaria
- Los datos persisten entre sesiones

## 🔧 Compilar para Distribución

Para crear un ejecutable portátil:

```bash
dotnet publish -c Release -r win-x64 --self-contained
```

El ejecutable se generará en: `bin/Release/net9.0-windows/win-x64/publish/`

## 📌 Notas

- La aplicación requiere .NET Runtime 9.0 para ejecutarse (o SDK si ejecutas con `dotnet run`)
- Los datos se almacenan localmente en SQLite, sin necesidad de servidor externo
- Es compatible con Windows 10/11 y versiones posteriores

## 👨‍💻 Autor

JulianAFO98

## 📄 Licencia

Este proyecto está bajo licencia MIT 
