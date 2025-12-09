using System;
using System.Windows.Input;

namespace InventoryManager.Commands
{
    /// <summary>
    /// Implementación genérica de ICommand que permite vincular cualquier acción a un comando.
    /// Se utiliza en el ViewModel para conectar botones y acciones de la UI con métodos.
    /// Soporta validación opcional de si el comando puede ejecutarse.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// Acción que se ejecuta cuando se invoca el comando.
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// Función opcional que determina si el comando puede ejecutarse.
        /// Si es null, el comando siempre puede ejecutarse.
        /// </summary>
        private readonly Func<bool>? _canExecute;

        /// <summary>
        /// Constructor del comando relay.
        /// </summary>
        /// <param name="execute">Acción a ejecutar (obligatorio).</param>
        /// <param name="canExecute">Función que retorna si el comando puede ejecutarse (opcional).</param>
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        /// Determina si el comando puede ejecutarse.
        /// </summary>
        /// <param name="parameter">Parámetro no utilizado en esta implementación.</param>
        /// <returns>true si el comando puede ejecutarse, false en caso contrario.</returns>
        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute();

        /// <summary>
        /// Ejecuta la acción asociada al comando.
        /// </summary>
        /// <param name="parameter">Parámetro no utilizado en esta implementación.</param>
        public void Execute(object? parameter) => _execute();

        /// <summary>
        /// Evento que se dispara cuando el estado de ejecución del comando puede haber cambiado.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

}
