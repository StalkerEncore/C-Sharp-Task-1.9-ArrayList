using System;
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
       
        TicketOffice tickets = new TicketOffice("text.txt");
  
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Console.WriteLine("\n лол");
            tickets.AddTickets(new Ticket(100, "19.02.2000", 10, true, "Хлеб"));
            tickets.AddTickets(new Ticket(100, "15.02.2002", 10, true, "Хле2б"));
            //tickets.GetFreeSeatsForDate("10.02.2000", "5.03.2000");
            ShowTickets(sender, e); 
            tickets.GetFreeSeatsForCost(100, 200);

            foreach (Ticket ticket in tickets.GetSortedTicket())
            {
                Console.WriteLine(ticket.Cost.ToString() + " " + ticket.Date + " " + ticket.Name);
            }
        }

        private void ShowTickets(object sender, EventArgs e)
        {
            foreach (var ticket in tickets.GetTickets())
            {
                textBox1.Text += ticket.Name + " " + ticket.Cost + " " + ticket.Date + Environment.NewLine;
            }
            
        }
    }
}
