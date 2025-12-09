using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InventoryManager.ViewModels;
namespace InventoryManager.Views;

/// <summary>
/// Ventana principal de la aplicación InventoryManager.
/// Presenta la interfaz de usuario para gestionar productos (crear, editar, eliminar, visualizar).
/// Utiliza el patrón MVVM con ProductViewModel como fuente de datos.
/// </summary>
public partial class MainWindow : Window
{
    /// <summary>
    /// Constructor de la ventana principal.
    /// Inicializa los componentes XAML y establece el ViewModel como contexto de datos.
    /// </summary>
    /// <param name="viewModel">El ProductViewModel que proporciona los datos y comandos para la UI.</param>
    public MainWindow(ProductViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}