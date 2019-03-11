using System.Collections.Generic;

namespace TheDebtBook.Model
{
    public class Debtor
    {
        public Debtor(string name = "NN", double debt = 0)
        {
            Name = name;
            Debt = debt;
        }

        public List<Payment> Type { get; set; }
        public string Name  { get; set; }
        public double Debt  { get; set; }

        public void Borrow(double amount)
        {

        }

        public void PayBack(double amount)
        {

        }
    }
}