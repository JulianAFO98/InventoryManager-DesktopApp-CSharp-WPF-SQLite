using System.Configuration;
using System.Data;
using System.Windows;
using InventoryManager.Views;
using InventoryManager.ViewModels;
using InventoryManager.Services;
namespace InventoryManager;

/// <summary>
/// Punto de entrada de la aplicación InventoryManager.
/// Configura la inyección de dependencias y inicializa la ventana principal con el patrón MVVM.
/// </summary>
public partial class App : Application
{
    /// <summary>
    /// Se ejecuta al iniciar la aplicación.
    /// Realiza la inyección de dependencias: crea el repositorio, servicio, controlador y ViewModel.
    /// Luego crea y muestra la ventana principal.
    /// </summary>
    /// <param name="e">Argumentos de inicio de la aplicación.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        
        // Inyección de dependencias: crear las capas de la aplicación
        var repo = new ProductRepository();                    // Capa de datos
        var service = new ProductService(repo);                    // Capa de servicio
        var controller = new ProductController(service);           // Capa de controlador
        var vm = new ProductViewModel(controller);                 // Capa de presentación (ViewModel)
        
        // Crear y mostrar la ventana principal con el ViewModel
        var ventana = new MainWindow(vm);
        ventana.Show();
    }
}

