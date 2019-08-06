using System;
using System.ComponentModel.DataAnnotations;

namespace Token.Presentation.Model
{
    /// <summary>
    /// Model responsable for itens on the user interface. It represent the user interface. Not related to the database tables or domain layer.
    /// </summary>
    public class TokenModel
    {
        public DateTime Date { get; set; }
        public long CardNumber { get; set; }
        public int CVV { get; set; } 
    }   
}
