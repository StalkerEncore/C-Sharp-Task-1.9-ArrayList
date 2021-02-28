using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Task_1._9_ArrayList
{
    class Ticket
    {
        private struct date 
        { 
            int dd; int mm; int yy;
            public date(int dd, int mm, int yy)
            {
                this.dd = dd;
                this.mm = mm;
                this.yy = yy;
            }
        }
        private int cost;
        private string seat;
        private bool vacant;
        private string name;
        public Ticket(int cost, int dd, int mm, int yy, string seat, bool vacant, string name)
        {
            date date = new date(dd, mm, yy);
            this.cost = cost;
            this.seat = seat;
            this.vacant = vacant;
            this.name = name;
        }

        public int Cost { get => cost; set => cost = value; }
        public string Seat { get => seat; set => seat = value; }
        public bool Vacant { get => vacant; set => vacant = value; }
    }
}
