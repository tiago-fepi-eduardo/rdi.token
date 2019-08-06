using System;
using System.ComponentModel.DataAnnotations;

namespace Token.Presentation.Model
{
    /// <summary>
    /// Model responsable for itens on the user interface. It represent the user interface. Not related to the database tables or domain layer.
    /// </summary>
    public class TokenModel
    {
        [Required(ErrorMessage = "CardNumber is required")]
        public long CardNumber { get; set; }

        [Range(0,999,ErrorMessage ="Number out of range. 0 - 999")]
        [Required(ErrorMessage = "CVV is required")]
        public int CVV { get; set; }

        [DisplayFormat(DataFormatString = "{0:d}")]
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }      
    }   
}
