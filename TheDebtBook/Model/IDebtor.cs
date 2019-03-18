using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Model
{
    public interface IDebtor
    {
        string Name { get; set; }
        double Debt { get; }
        TransList TransactionList { get; set; }

        void PayOrBorrow(double amount);
        event PropertyChangedEventHandler PropertyChanged;
    }
}
