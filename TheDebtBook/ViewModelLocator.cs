using TheDebtBook.ViewModel;

namespace TheDebtBook
{
    public class ViewModelLocator
    {
        private IViewModel _model;
        public IViewModel MainViewModel
        {
            get { return _model ?? (_model = new MainViewModel()); }
        }
    }
}