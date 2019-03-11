using System.Collections.ObjectModel;
using System.Configuration;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Model;

namespace TheDebtBook.ViewModel
{
    public class MainViewModel : BindableBase
    {


        #region Properties

        private Debtor _modelDebtor;
        public Debtor ModelDebtor
        {
            get { return _modelDebtor; }
            set {SetProperty(ref _modelDebtor, value);}
        }

        private Payment _modelPayment;
        public Payment ModelPayment
        {
            get { return _modelPayment; }
            set { SetProperty(ref _modelPayment, value); }
        }

        private ObservableCollection<Debtor> debtors;

        public ObservableCollection<Debtor> Debtors
        {
            get { return debtors; }
            set { SetProperty(ref debtors, value); }
        }

        #endregion //Properties


        #region Commands

        private ICommand _AddDebtorCommand;

        public ICommand AddDebtorCommand
        {
            get { return _AddDebtorCommand ?? (_AddDebtorCommand = new DelegateCommand(AddDebtorCommandExecute)); }
        }

        private void AddDebtorCommandExecute()
        {

        }




        #endregion


    }
}