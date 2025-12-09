using System.Configuration;
using System.Data;
using System.Windows;
using InventoryManager.Views;
using InventoryManager.ViewModels;
using InventoryManager.Services;
namespace InventoryManager;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        var repo = new ProductRepositoryList();
        var service = new ProductService(repo);
        var controller = new ProductController(service);
        var vm = new ProductViewModel(controller);
        var ventana = new MainWindow(vm);
        ventana.Show();
    }
}

