﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_Sharp_Task_1._9_ArrayList
{
    public partial class Form1 : Form
    {
        TicketOffice Tickets = new TicketOffice();
        LinkedList<Ticket> SortedTickets = new LinkedList<Ticket>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Tickets.Tickets.AddLast(new Ticket(100, 19, 02, 2000, "10.2", true, "Хлеб"));
            Tickets.Tickets.AddLast(new Ticket(10, 1, 0, 200, "10", true, "Беб"));
            Console.WriteLine("\n лол");
            
            Tickets.GetFreeSeats(0, 200);

            foreach (Ticket ticket in Tickets.GetSortedTicket())
            {
                Console.WriteLine(ticket);
            }
        }
    }
}