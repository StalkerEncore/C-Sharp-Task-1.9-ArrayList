using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Коллекция TicketOffice – набор объектов класса Ticket, экземпляры которого
представляют билеты на зрелищные мероприятия. Предусмотреть возможность
выполнения следующих операций: формирования списка свободных мест по
заданному условию (диапазон стоимости, дата проведения мероприятия,
расположения в зале).*/

namespace C_Sharp_Task_1._9_ArrayList
{
    class TicketOffice : LinkedList<Ticket>
    {
        public LinkedList<Ticket> Tickets = new LinkedList<Ticket>();
        LinkedList<Ticket> SortedTickets = new LinkedList<Ticket>();
        public LinkedList<Ticket> GetSortedTicket() 
        {
            return SortedTickets;
        }
        public void GetFreeSeats(int min, int max) 
        {
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.Cost >= min && ticket.Cost <= max) 
                {
                    SortedTickets.AddLast(ticket);
                }
            }
        }

        /*public void GetFreeSeats(string min_dd, string min_mm, string min_yy, string max)
        {
            foreach (var ticket in Tickets)
            {
                if (ticket.Date <= max && ticket.Cost >= min)
                {

                }
            }
        }*/
        /*public void GetFreeSeats(int min, int max)
        {
            foreach (var ticket in Tickets)
            {
                if (ticket.Cost <= max && ticket.Cost >= min)
                {

                }
            }
        }*/

    }
}
