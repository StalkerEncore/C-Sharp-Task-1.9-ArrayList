namespace C_Sharp_Task_1._9_ArrayList
{
    class Ticket
    {
     
        public Ticket(int Numb, int cost, string Date, int Row, int Seat, string Place, string Vacant, string Name)
        {
            this.Numb = Numb;
            this.Date = Date; 
            this.Cost = cost;
            this.Row = Row;
            this.Seat = Seat;
            this.Place = Place;
            this.Vacant = Vacant;
            this.Name = Name;

        }
        public Ticket() { }

        public int Numb { set; get; }
        public string Date { set; get; }
        public string Name { set; get; }
        public int Seat { set; get; }
        public int Row { set; get; }
        public string Place { set; get; }
        public int Cost { set; get; }
        public string Vacant { set; get; }

        public string Info() 
        {
            return Numb.ToString() + Cost.ToString() + Date + Row.ToString() + Seat.ToString() + Place + Vacant + Name; 
        }
    }
}
