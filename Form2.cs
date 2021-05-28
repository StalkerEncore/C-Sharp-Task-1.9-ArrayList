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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           //foreach (Ticket ticket in bought.GetTickets()) listBox1.Items.Add(ticket.Numb + " \" " + ticket.Name + "\" " + ". " + ticket.Cost + "руб. " + ticket.Date + " " + ticket.Row + "-ый ряд " + ticket.Seat + "-ое место, " + ticket.Place + ", сейчас " + ticket.Vacant);
        }

        private void button1_Click(object sender, EventArgs e) { Close(); }
    }
}
