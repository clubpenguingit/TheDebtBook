﻿using System;

namespace TheDebtBook.Model
{
    public class Payment : IPayment
    {
        public Payment(DateTime date, double pay)
        {
            Date = date;
            Amount = pay;
        }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
    }
}