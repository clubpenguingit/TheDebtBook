using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
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
            Debtors.Add(new Debtor("Britta Nielsen",121000000));
            Debtors.Add(new Debtor("Tobias Lund", -1000));
            Debtors[1].TransactionsList.Add(new Payment(DateTime.Now, 6969));
        }

        #region Properties

       // public List<Payment> CurrentTransList { get; set; }
        public TransList CurrentTransList { get; set; }
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
            CurrentTransList = e.TransactionsList;
            Debug.WriteLine("Translist set");
            var window = new TransactionsView();

            if (window.ShowDialog() == true)
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
                    CurrentTransList.Add(new Payment(DateTime.Now, double.Parse(val)));
            }



        }




        #endregion //Commands




    }
}