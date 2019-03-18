using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheDebtBook.Model
{


    public class Debtor : INotifyPropertyChanged, IDebtor
    {
       
        public Debtor(string name = "NN", double debt = 0)
        {
            Name = name;           
            TransactionsList = new TransList();
            if (debt != 0)
                PayOrBorrow(debt);
        }

        public TransList TransactionsList { get; set; }
        public string Name  { get; set; }
        public double Debt  { get; private set; }
        

        public void PayOrBorrow(double amount)
        {
            Debt += amount;
            TransactionsList.Add(new Payment(DateTime.Now, amount));
            Notify("Debt");
            //Behøver ikke notify på TransactionsList da den er ObservableCollection 
        }

        #region PropertyChangedOgNotifyRegion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void Notify([CallerMemberName]string propName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propName));
            }
        }

        #endregion
        
    }
}