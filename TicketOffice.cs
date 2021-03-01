using System;
using System.Collections.Generic;
using System.IO;

/*Коллекция TicketOffice – набор объектов класса Ticket, экземпляры которого
представляют билеты на зрелищные мероприятия. Предусмотреть возможность
выполнения следующих операций: формирования списка свободных мест по
заданному условию (диапазон стоимости, дата проведения мероприятия,
расположения в зале).*/

namespace C_Sharp_Task_1._9_ArrayList
{
    class TicketOffice
    {
        LinkedList<Ticket> Tickets = new LinkedList<Ticket>();
        LinkedList<Ticket> SortedTickets = new LinkedList<Ticket>();

        public TicketOffice(string path)
        {
            var file = new StreamReader(path);
            while (!file.EndOfStream)
            {
                string str = file.ReadLine();
                string[] line = str.Split(';');
                Tickets.AddLast(new Ticket(int.Parse(line[0]), line[1], int.Parse(line[2]), line[3], line[4]));
            }
            file.Close();
        }

        public LinkedList<Ticket> GetSortedTicket() 
        {
            return SortedTickets;
        }

        public LinkedList<Ticket> GetTickets()
        {
            return Tickets;
        }

        public void AddTickets(Ticket ticket)
        {
            Tickets.AddLast(ticket);
        }

        public void GetFreeSeatsForCost(int min, int max) 
        {
            SortedTickets.Clear();
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.Cost >= min && ticket.Cost <= max) 
                {
                    SortedTickets.AddLast(ticket);
                }
            }
        }

        public void GetFreeSeatsForTickets(int min, int max)
        {
            SortedTickets.Clear();
            foreach (Ticket ticket in Tickets)
            {
                if (ticket.Seat >= min && ticket.Seat <= max)
                {
                    SortedTickets.AddLast(ticket);
                }
            }
        }


        public void GetFreeSeatsForDate(string date1, string date2)
        {
            SortedTickets.Clear(); 

            foreach (Ticket ticket in Tickets)
            {
                if (CheckDate(date1, ticket.Date, date2)) SortedTickets.AddLast(ticket); 
            }
        }

        public static bool CheckDate(string date1, string checkDate, string date2)
        {
            string[] arrdate1 = date1.Split('.');
            string[] arrcheckDate = checkDate.Split('.');
            string[] arrdate2 = date2.Split('.');

            DateTime d1 = new DateTime(int.Parse(arrdate1[2]), int.Parse(arrdate1[1]), int.Parse(arrdate1[0]));
            DateTime d2 = new DateTime(int.Parse(arrdate2[2]), int.Parse(arrdate2[1]), int.Parse(arrdate2[0])); 
            DateTime dCD = new DateTime(int.Parse(arrcheckDate[2]), int.Parse(arrcheckDate[1]), int.Parse(arrcheckDate[0]));
            return d1 <= dCD && dCD <= d2;
        }
    }
}
