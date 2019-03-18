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
    public class MainViewModel : BindableBase, IViewModel
    {

        public MainViewModel()
        {
            debtors = new ObservableCollection<IDebtor>();
            Debtors.Add(new Debtor("Britta Nielsen"));
            Debtors.Add(new Debtor("Tobias Lund"));
            Debtors[0].PayOrBorrow(-012397345);
            Debtors[1].PayOrBorrow(6969);
        }

        #region Properties

        //Current chosen debtor (used in TransactionView)
        private IDebtor _modelDebtor;
        public IDebtor ModelDebtor
        {
            get { return _modelDebtor; }
            set {SetProperty(ref _modelDebtor, value);}
        }

     
        //List of debtors used by datagrid in MainWindow
        private ObservableCollection<IDebtor> debtors;
        public ObservableCollection<IDebtor> Debtors
        {
            get { return debtors; }
            set { SetProperty(ref debtors, value); }
        }

        //Debt property used to create new debtor
        private double _newDebtorDebt;
        public double newDebtorDebt
        {
            get { return _newDebtorDebt; }
            set
            {
                SetProperty(ref _newDebtorDebt, value);
            }
        }

        //Name property used to create new debtor
        private string _newDebtorName;
        public string newDebtorName
        {
            get { return _newDebtorName;}
            set { SetProperty(ref _newDebtorName, value); }
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
            if (!String.IsNullOrEmpty(newDebtorName))
            {
                var newDebtor = new Debtor();
                // Set properties and add to list
                newDebtor.Name = newDebtorName;
                newDebtor.PayOrBorrow(newDebtorDebt);
                Debtors.Add(newDebtor);
                _modelDebtor = newDebtor;

                //Reset textbox binded properties
                newDebtorName = "";
                newDebtorDebt = 0;
            }
            else
            {
                MessageBox.Show($"Cannot add debtor with no name");
            }
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
            // Save chosen debtor in ModelDebtor property
            ModelDebtor = e;

            // Create window
            var window = new TransactionsView();

            // Show window, do nothing upon close. 
            if (window.ShowDialog() == true)
            { }
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
            // Must have value
            if (!String.IsNullOrEmpty(val))
            {
                // ****Check if val is a number*****//
                double v;
                bool success = double.TryParse(val, out v);
                // *********************************//
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