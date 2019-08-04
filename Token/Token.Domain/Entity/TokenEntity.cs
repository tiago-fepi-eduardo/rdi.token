using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace Token.Domain.Entity
{
    public class TokenEntity : BaseEntity
    {
        public override DateTime Date { get; set; }
        public string CardNumber { get; private set; }
        public int CVV { get; private set; }
        
        public void SetCard(string _cardNumber, DateTime _date, int _cvv)
        {
            CardNumber = _cardNumber;
            Date = _date;
            CVV = _cvv;
        }
    }
}
