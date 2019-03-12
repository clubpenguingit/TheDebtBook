using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TheDebtBook.Model
{

    public class TransList : ObservableCollection<Payment> { }

    public class Debtor
    {
        public Debtor(string name = "NN", double debt = 0)
        {
            Name = name;
            Debt = debt;
            TransactionsList = new TransList();
            TransactionsList.Add(new Payment(DateTime.Now,0));
        }

        public TransList TransactionsList { get; set; }
        public string Name  { get; set; }
        public double Debt  { get; set; }

        public void Borrow(double amount)
        {
            Debt -= amount;
            TransactionsList.Add(new Payment(DateTime.Now, amount));
        }

        public void PayBack(double amount)
        {
            Debt += amount;
            TransactionsList.Add(new Payment(DateTime.Now, amount));
        }
    }
}