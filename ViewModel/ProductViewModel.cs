using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Models;
using Interfaces;
using InventoryManager.Commands;

namespace InventoryManager.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private readonly ProductController _controller;
        public event PropertyChangedEventHandler? PropertyChanged;
        private int _id;
        private int _Stock;
        private string _productName = "";
        private decimal _precio;
        private string? _categoriaSeleccionada;
        private decimal _precioTotal;
        public ObservableCollection<Product> Productos { get; }
        public ObservableCollection<string> Categorias { get; set; }
        private Product? _productoSeleccionado;
        public ICommand CargarProductosCommand { get; }
        public ICommand GuardarProductoCommand { get; }
        public ICommand EliminarProductoCommand { get; }
        public ICommand LimpiarFormularioCommand { get; }

        public ProductViewModel(ProductController controller)
        {
            _controller = controller;

            // Inicializar comandos
            CargarProductosCommand = new RelayCommand(CargarProductos);
            GuardarProductoCommand = new RelayCommand(GuardarProducto);
            EliminarProductoCommand = new RelayCommand(EliminarProducto);
            LimpiarFormularioCommand = new RelayCommand(LimpiarFormulario);

            Productos = new ObservableCollection<Product>();
            Categorias = new ObservableCollection<string>
            {
                "Juguete",
                "Consumo",
                "Cristaleria",
                "Decoracion",
                "Otro"
            };

            CargarProductos();
        }

        /// <summary>
        /// Notifica a los observadores cuando una propiedad cambia (patrón INotifyPropertyChanged).
        /// </summary>
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged(); }
        }

        public int Stock
        {
            get => _Stock;
            set { _Stock = value; OnPropertyChanged(); }
        }

        public string ProductName
        {
            get => _productName;
            set { _productName = value; OnPropertyChanged(); }
        }

        public decimal Precio
        {
            get => _precio;
            set { _precio = value; OnPropertyChanged(); }
        }
        public string CategoriaSeleccionada
        {
            get => _categoriaSeleccionada;
            set
            {
                _categoriaSeleccionada = value;
                OnPropertyChanged();
            }
        }
        public decimal PrecioTotal
        {
            get => _precioTotal;
            set
            {
                _precioTotal = Precio * Stock;
                OnPropertyChanged();
            }
        }

        public Product? ProductoSeleccionado
        {
            get => _productoSeleccionado;
            set
            {
                _productoSeleccionado = value;
                OnPropertyChanged();

                if (value != null)
                {
                    Id = value.Id;
                    ProductName = value.ProductName;
                    Precio = value.Precio;
                    Stock = value.Stock;
                    CategoriaSeleccionada = value.Categoria;
                }
            }
        }



        /// <summary>
        /// Carga todos los productos desde el controlador y los muestra en la lista observable.
        /// </summary>
        private void CargarProductos()
        {
            Productos.Clear();
            foreach (var p in _controller.ObtenerProductos())
                Productos.Add(p);
        }

        /// <summary>
        /// Guarda o actualiza un producto. Si no hay producto seleccionado, crea uno nuevo.
        /// Si hay uno seleccionado, actualiza sus datos con confirmación.
        /// Valida que todos los campos sean correctos antes de guardar.
        /// </summary>
        private void GuardarProducto()
        {
            // Validaciones compartidas
            if (string.IsNullOrWhiteSpace(ProductName))
            {
                MessageBox.Show("El nombre es obligatorio.");
                return;
            }

            if (string.IsNullOrWhiteSpace(CategoriaSeleccionada))
            {
                MessageBox.Show("Seleccione una categoría.");
                return;
            }

            if (Precio <= 0)
            {
                MessageBox.Show("El precio debe ser mayor a 0.");
                return;
            }

            if (Stock < 0)
            {
                MessageBox.Show("El stock no puede ser negativo.");
                return;
            }

            // Si NO hay producto seleccionado → CREAR
            if (ProductoSeleccionado == null)
            {
                var nuevo = new Product
                {
                    Id = -1, // ID temporal; el repositorio lo asignará
                    ProductName = ProductName,
                    Precio = Precio,
                    Stock = Stock,
                    Categoria = CategoriaSeleccionada
                };
                try
                {
                    _controller.CrearProducto(nuevo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                // Si hay un producto seleccionado → ACTUALIZAR
                var actualizado = new Product
                {
                    Id = ProductoSeleccionado.Id,
                    ProductName = ProductName,
                    Precio = Precio,
                    Stock = Stock,
                    Categoria = CategoriaSeleccionada
                };

                try
                {
                    var result = MessageBox.Show(
                    $"¿Está seguro de modificar este producto?\n({ProductoSeleccionado.ProductName})",
                    "Confirmación",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);
                    if (result == MessageBoxResult.Yes)
                        _controller.ActualizarProducto(ProductoSeleccionado.Id, actualizado);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }

            CargarProductos();
            LimpiarFormulario();
        }


        /// <summary>
        /// Elimina el producto seleccionado tras pedir confirmación al usuario.
        /// Si no hay producto seleccionado, muestra un mensaje de error.
        /// </summary>
        private void EliminarProducto()
        {
            if (_productoSeleccionado == null)
            {
                MessageBox.Show("Seleccione un producto para eliminar.");
                return;
            }
            try
            {
                var result = MessageBox.Show(
                   $"¿Está seguro de eliminar este producto?\n({ProductoSeleccionado?.ProductName})",
                   "Confirmación",
                   MessageBoxButton.YesNo,
                   MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                    _controller.EliminarProducto(Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                CargarProductos();
                LimpiarFormulario();
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario y deselecciona el producto actual.
        /// Se ejecuta después de guardar o eliminar un producto.
        /// </summary>
        private void LimpiarFormulario()
        {
            Id = 0;
            ProductName = "";
            Precio = 0;
            Stock = 0;
            ProductoSeleccionado = null;
            CategoriaSeleccionada = null;
        }
    }
}
