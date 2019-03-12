using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheDebtBook.Model
{

    public class TransList : ObservableCollection<Payment> { }

    public class Debtor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify([CallerMemberName]string propName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }
        public Debtor(string name = "NN", double debt = 0)
        {
            Name = name;
            Debt = debt;
            TransactionsList = new TransList();
        }

        public TransList TransactionsList { get; set; }
        public string Name  { get; set; }
        public double Debt  { get; set; }
        

        public void PayOrBorrow(double amount)
        {
            Debt += amount;
            TransactionsList.Add(new Payment(DateTime.Now, amount));
            Notify("Debt");
        }
    }
}