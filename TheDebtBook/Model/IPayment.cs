using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Model
{
    public interface IPayment
    {
        DateTime Date { get; set; }
        double Amount { get; set; }
    }
}
