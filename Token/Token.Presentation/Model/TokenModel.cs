using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Token.Presentation.Model
{
    /// <summary>
    /// Model responsable for itens on the user interface. It represent the user interface. Not related to the database tables or domain layer.
    /// </summary>

    public class TokenModel
    {
        public string CardNumber { get; set; }  //CardNumber inserted
        public int CVV { get; set; }            //CVV inserted on the user interface
        public DateTime Date { get; set; }      //Date inserted on the user interface 
        public string Token { get; set; }       //Token number gerated
        public bool IsValid { get; set; }       //Bool to check if a token is valid after search on the database
    }   
}
