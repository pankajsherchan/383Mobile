using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sp16_p3_g8WebAPI.Models
{
    /*
        PurchaseTicketId
        This model keeps the detail records of each purchase like
        tickettype, ticketprice
    */
    public class PurchaseTicketLineItem
    {
        [Key]
        public int Id { get; set; }

        public int PurchaseTicketId { get; set; }
        
        public virtual PurchaseTicket PurchaseTicket { get; set; }
        
        // should infered from PurchaseTicket Model
        public int TicketCount { get; set; }

        public string TicketType { get; set; }

        public decimal TicketPrice { get; set; }
    }
}