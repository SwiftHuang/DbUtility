using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestWS.BOClass
{
    public enum InvoiceType
    {
        None,
        Normal,
        UATP,
    }
    public class Invoice
    {
        public string CompanyCode { get; set; }
        public string InvNum { get; set; }
        public int QTY { get; set; }
        public decimal Amount { get; set; }
        public InvoiceType Types { get; set; }
        public Hotel HotelInfo { get; set; }
        public List<XO> XOList { get; set; }
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
                Types = InvoiceType.UATP;
                HotelInfo = new Hotel(true);
                Tickets = new List<Ticket>();
                Tickets.Add(new Ticket(true));
                XOList = new List<XO>();
                XOList.Add(new XO(true));
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

    public class XO
    {
        public string XONum { get; set; }
        public List<XODetail> Details { get; set; }

        public XO()
        {

        }
        public XO(bool hasData)
        {
            if (hasData)
            {
                XONum = "XO0000001";

                XODetail dtl1 = new XODetail();
                dtl1.SegNum = "X0001";
                XODetail dtl2 = new XODetail();
                dtl2.SegNum = "X0002";
                Details = new List<XODetail>();
                Details.Add(dtl1);
                Details.Add(dtl2);
            }
        }

    }

    public class XODetail
    {
        public string SegNum { get; set; }

        public XODetail()
        {

        }
    }

    public class Hotel
    {
        public string HotelCode { get; set; }
        public Hotel()
        {

        }
        public Hotel(bool hasData)
        {
            HotelCode = "HC0001";
        }
    }
}
