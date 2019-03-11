

using Prism.Mvvm;
using TheDebtBook.Model;

namespace TheDebtBook.ViewModel
{
    public class MainViewModel : BindableBase
    {
        private Debtor _modelDebtor;

        public Debtor ModelDebtor
        {
            get { return _modelDebtor; }
            set
            {
                SetProperty(ref _modelDebtor, value);

            }



        }
    }
}