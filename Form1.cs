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

        private void Form1_Load(object sender, EventArgs e) {}
        private void ShowTickets(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            foreach (Ticket ticket in tickets.GetSortedTicket())
            {
                if (ticket.Vacant == "free")
                {
                    textBox1.Text += "\" " +  ticket.Name + "\" " + ". " + ticket.Cost + "rub. " + ticket.Date + " " + ticket.Seat + "-th seat, now is " + ticket.Vacant + Environment.NewLine;
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            tickets.GetFreeSeatsForDate(textBox2.Text.ToString(), textBox3.Text.ToString());
            ShowTickets(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tickets.GetFreeSeatsForCost(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text));
            ShowTickets(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tickets.GetFreeSeatsForTickets(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text));
            ShowTickets(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            foreach (Ticket ticket in tickets.GetTickets())
            {
                textBox1.Text += "\" " + ticket.Name + "\" " + ". " + ticket.Cost + "rub. " + ticket.Date + " " + ticket.Seat + "-th seat, now is " + ticket.Vacant + Environment.NewLine;
            }
        }
    }
}
