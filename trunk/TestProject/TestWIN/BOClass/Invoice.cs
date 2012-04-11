using System;
using System.Collections.Generic;
using System.Linq;

namespace TestWIN.BOClassWIN
{
    public class Invoice
    {
        public String CompanyCode { get; set; }
        public String InvNum { get; set; }
        public Int32 QTY { get; set; }
        public Decimal Amount { get; set; }
        public Hotel HotelInfo { get; set; }
        public List<XO> XOList { get; set; }
        public List<Ticket> Tickets { get; set; }

        public Invoice()
        {

        }

    }

    public class Hotel
    {
        public String HotelCode { get; set; }

        public Hotel()
        {

        }

    }

    public class TicketDetail
    {
        public String SegNum { get; set; }

        public TicketDetail()
        {

        }

    }

    public class Ticket
    {
        public String TicketNum { get; set; }
        public List<TicketDetail> Details { get; set; }

        public Ticket()
        {

        }

    }

    public class XODetail
    {
        public String SegNum { get; set; }

        public XODetail()
        {

        }

    }

    public class XO
    {
        public String XONum { get; set; }
        public List<XODetail> Details { get; set; }

        public XO()
        {

        }

    }
}
