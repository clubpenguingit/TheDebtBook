using TheDebtBook.ViewModel;

namespace TheDebtBook
{
    public class ViewModelLocator
    {
        private MainViewModel _model;
        public MainViewModel MainViewModel
        {
            get { return _model; }
        }

        public ViewModelLocator()
        {
            _model = new MainViewModel();
        }
    }
}