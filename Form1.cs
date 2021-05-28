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
        TicketOffice bought = new TicketOffice();
        bool tag = false; //Переменная, помогающая разделять реализацию вывода списка билетов в зависимости от того, какая кнопка была нажата перед покупкой

        private delegate void BuyTicket(object sender, EventArgs e);
        private event BuyTicket OnAdd;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Показать все");
            comboBox2.Items.Add("Показать все");
            OnAdd += BuyingTickets;
            foreach (Ticket ticket in tickets.GetTickets())
            {
                if (!comboBox1.Items.Contains(ticket.Name))
                {
                    comboBox1.Items.Add(ticket.Name);
                }

                if (!comboBox2.Items.Contains(ticket.Place))
                {
                    comboBox2.Items.Add(ticket.Place);
                }
            }
        }
        private void ShowTickets(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (Ticket ticket in tickets.GetSortedTicket())
            {
                if (ticket.Vacant == "свободно")
                {
                    listBox1.Items.Add(ticket.Numb + " \" " + ticket.Name + "\" " + ". " + ticket.Cost + "руб. " + ticket.Date + " " + ticket.Row + "-ый ряд " + ticket.Seat + "-ое место, " + ticket.Place + ", сейчас " + ticket.Vacant);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            tag = true;
            tickets.GetFreeSeatsForDate(textBox2.Text.ToString(), textBox3.Text.ToString(), comboBox1.Text, comboBox2.Text);
            ShowTickets(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tag = true;
            tickets.GetFreeSeatsForCost(Convert.ToInt32(textBox4.Text), Convert.ToInt32(textBox5.Text), comboBox1.Text, comboBox2.Text);
            ShowTickets(sender, e);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tag = true;
            tickets.GetFreeSeatsForTickets(Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text), Convert.ToInt32(textBox9.Text), comboBox1.Text, comboBox2.Text);
            ShowTickets(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tag = false;
            listBox1.Items.Clear();
            foreach (Ticket ticket in tickets.GetTickets())
            {
                listBox1.Items.Add(ticket.Numb + " \" " + ticket.Name + "\" " + ". " + ticket.Cost + "руб. " + ticket.Date + " " + ticket.Row + "-ый ряд " + ticket.Seat + "-ое место, " + ticket.Place + ", сейчас " + ticket.Vacant);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Location = this.Location;
            form.StartPosition = FormStartPosition.Manual;
            form.FormClosing += delegate { this.Show(); };
            form.Show();
            this.Hide();

            OnAdd?.Invoke(sender, e);

            foreach (Ticket ticket in bought.GetTickets())
            {
                form.listBox1.Items.Add(ticket.Numb + " \" " + ticket.Name + "\" " + ". " + ticket.Date + " " + ticket.Row + "-ый ряд " + ticket.Seat + "-ое место, " + ticket.Place);
            }

            if (tag == true) ShowTickets(sender, e);
            else
            {
                listBox1.Items.Clear();
                foreach (Ticket ticket in tickets.GetTickets()) listBox1.Items.Add(ticket.Numb + " \" " + ticket.Name + "\" " + ". " + ticket.Cost + "руб. " + ticket.Date + " " + ticket.Row + "-ый ряд " + ticket.Seat + "-ое место, " + ticket.Place + ", сейчас " + ticket.Vacant);
            }
        }

        private void BuyingTickets(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string str = listBox1.SelectedItem.ToString();
                string[] numb = str.Split('\"');
                foreach (Ticket ticket in tickets.GetTickets())
                {
                    if (ticket.Numb == Convert.ToInt32(numb[0]))
                    {
                        ticket.Vacant = "ПРОДАНО";
                        bought.AddTicket(ticket);
                    }
                }
            }
        }
    }
}
