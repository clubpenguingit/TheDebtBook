using System.Collections.ObjectModel;
using System.Windows.Input;
using Prism.Commands;
using TheDebtBook.Model;

namespace TheDebtBook.ViewModel
{
    public interface IViewModel
    {
        ObservableCollection<IDebtor> Debtors { get; set; }
        IDebtor ModelDebtor { get; set; }
        double newDebtorDebt { get; set; }
        string newDebtorName { get; set; }

        ICommand AddDebtorCommand { get; }
        ICommand ShowTransactionCommand { get; }
        ICommand AddTransactionCommand { get; }
    }
}