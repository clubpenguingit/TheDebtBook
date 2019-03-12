using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using TheDebtBook.Model;

namespace TheDebtBook.ViewModel
{
    public class MainViewModel : BindableBase
    {

        public MainViewModel()
        {
            debtors = new ObservableCollection<Debtor>();
            Debtors.Add(new Debtor("Britta Nielsen"));
            Debtors.Add(new Debtor("Tobias Lund"));
            Debtors[1].PayOrBorrow(6969);
        }

        #region Properties

       // public List<Payment> CurrentTransList { get; set; }
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
            var newDebtor = new Debtor();
            Debtors.Add(newDebtor);
            _modelDebtor = newDebtor;
        }

        private ICommand _ShowTransactionCommand;

        public ICommand ShowTransactionCommand
        {
            get
            {
                return _ShowTransactionCommand ?? (_ShowTransactionCommand = new DelegateCommand<Debtor>(ShowTransactionCommandExecute));
            }
        }

        private void ShowTransactionCommandExecute(Debtor e)
        {
            ModelDebtor = e;
            var window = new TransactionsView();

            if (window.ShowDialog() == true) // Change window 
            {
                
            }
            
        }

        private ICommand _addTransaction;

        public ICommand AddTransactionCommand
        {
            get
            {
                return _addTransaction ?? (_addTransaction = new DelegateCommand<string>(AddTransactionExecute)); 

            }
        }

        private void AddTransactionExecute(string val)
        {
            if (!String.IsNullOrEmpty(val))
            {
                double v;
                bool success = double.TryParse(val, out v);
                if (success)
                {
                    ModelDebtor.PayOrBorrow(double.Parse(val));
                }
                else
                {
                    MessageBox.Show($"Value must be numeric.\n" +
                                    $"Value was {val.ToString()}");
                    return;
                }
            }



        }




        #endregion //Commands




    }
}