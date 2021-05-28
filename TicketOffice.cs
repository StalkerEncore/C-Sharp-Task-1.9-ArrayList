using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

/*Класс TicketOffice – набор объектов класса Ticket, экземпляры которого
представляют билеты на зрелищные мероприятия. В числе полей класса Ticket
должны присутствовать уникальный код билета, название зрелищного мероприятия, 
дата его проведения, расположения в зале (партер, бельэтаж, балкон), ряд и место,
цена, а также флаг продан/не продан. Класс Ticket должен включать метод вывода
информации о конкретном билете. Методы класса TicketOffice должны
обеспечивать выполнение операций по продаже билетов, формированию списка
имеющихся билетов на указанное мероприятие с группировкой по расположению в
зале и аналогичного списка на все мероприятия в указанном диапазоне дат,
Продажа билета должна сопровождаться генерацией события, результатом
обработки которого должна быть информация о проданном билете. Создать
отдельные формы для экземпляров класса TicketOffice и класса Ticket.*/

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
                Tickets.AddLast(new Ticket(int.Parse(line[0]), int.Parse(line[1]), line[2], int.Parse(line[3]), int.Parse(line[4]), line[5], line[6], line[7]));
            }
            file.Close();
        }
        public TicketOffice() 
        {

        }
        public void AddTicket(Ticket tikcet) 
        {
            Tickets.AddLast(tikcet);
        }
        public LinkedList<Ticket> GetSortedTicket() 
        {
            return SortedTickets;
        }

        public LinkedList<Ticket> GetTickets()
        {
            return Tickets;
        }
        public void GetFreeSeatsForCost(int min, int max, string name, string place) 
        {
            SortedTickets.Clear();
            var Sorted =
                from ticket in Tickets
                where ticket.Cost >= min && ticket.Cost <= max
                select ticket;
            foreach (Ticket ticket in Sorted)
            {
                if (!name.Equals("Показать все"))
                {
                    if (!place.Equals("Показать все"))
                    {
                        if (ticket.Name.Equals(name)) if (ticket.Place.Equals(place)) SortedTickets.AddLast(ticket);
                    }
                    else
                    {
                        if (ticket.Name.Equals(name)) SortedTickets.AddLast(ticket);
                    }
                }
                else
                {
                    if (!place.Equals("Показать все"))
                    {
                        if (ticket.Place.Equals(place)) SortedTickets.AddLast(ticket);
                    }
                    else
                    {
                        SortedTickets.AddLast(ticket);
                    }
                }
            }
        }

        public void GetFreeSeatsForTickets(int min2, int max2, int min1, int max1, string name, string place) 
        {
            SortedTickets.Clear();
            var Sorted =
                from ticket in Tickets
                where ticket.Row >= min1 && ticket.Row <= max1 && ticket.Seat >= min2 && ticket.Seat <= max2
                select ticket;
            
            foreach (Ticket ticket in Sorted)
            {
                if (!name.Equals("Показать все"))
                {
                    if (!place.Equals("Показать все"))
                    {
                        if (ticket.Name.Equals(name)) if(ticket.Place.Equals(place)) SortedTickets.AddLast(ticket);
                    }
                    else
                    {
                        if (ticket.Name.Equals(name)) SortedTickets.AddLast(ticket);
                    }
                }
                else
                {
                    if (!place.Equals("Показать все"))
                    {
                        if (ticket.Place.Equals(place)) SortedTickets.AddLast(ticket);
                    }
                    else
                    {
                        SortedTickets.AddLast(ticket);
                    }
                }
            }
        }

        public void GetFreeSeatsForDate(string date1, string date2, string name, string place)
        {
            SortedTickets.Clear();
            var Sorted =
                from ticket in Tickets
                where ticket.Name.Equals(name) && ticket.Place.Equals(place)
                select ticket;
            
            if (!name.Equals("Показать все"))
            {
                if (!place.Equals("Показать все"))
                {
                    foreach (Ticket ticket in Sorted)
                    {
                        if (CheckDate(date1, ticket.Date, date2))
                        {
                            SortedTickets.AddLast(ticket);
                        }
                    }
                }
                else
                {
                    var Sorted1 =
                        from ticket in Tickets
                        where ticket.Name.Equals(name)
                        select ticket;
                    foreach (Ticket ticket in Sorted1)
                    {
                        if (CheckDate(date1, ticket.Date, date2))
                        {
                            SortedTickets.AddLast(ticket);
                        }
                    }
                }
            }
            else 
            {
                if (!place.Equals("Показать все"))
                {
                    foreach (Ticket ticket in Sorted)
                    {
                        if (CheckDate(date1, ticket.Date, date2))
                        {
                            SortedTickets.AddLast(ticket);
                        }
                    }
                }
                else
                {
                    foreach (Ticket ticket in Tickets)
                    {
                        if (CheckDate(date1, ticket.Date, date2))
                        {
                            SortedTickets.AddLast(ticket);
                        }
                    }
                }
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
