using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWS.BOClass
{
    public class Invoice
    {
        public string CompanyCode { get; set; }
        public string InvNum { get; set; }
        public int QTY { get; set; }
        public decimal Amount { get; set; }

        public List<Ticket> Tickets { get; set; }

        public Invoice()
        {

        }

        public Invoice(bool HasData)
        {
            if (HasData)
            {
                CompanyCode = "GT";
                InvNum = "GI00000001";
                QTY = 10;
                Amount = 1200;

                Tickets = new List<Ticket>();
                Tickets.Add(new Ticket(true));
            }
        }
    }

    public class Ticket
    {
        public string TicketNum { get; set; }
        public List<TicketDetail> Details { get; set; }

        public Ticket()
        {

        }
        public Ticket(bool hasData)
        {
            if (hasData)
            {
                TicketNum = "999122222";

                TicketDetail dtl1 = new TicketDetail();
                dtl1.SegNum = "00001";
                TicketDetail dtl2 = new TicketDetail();
                dtl2.SegNum = "00002";
                Details = new List<TicketDetail>();
                Details.Add(dtl1);
                Details.Add(dtl2);
            }
        }

        public class TicketDetail
        {
            public string SegNum { get; set; }

            public TicketDetail()
            {

            }
        }
    }
}
