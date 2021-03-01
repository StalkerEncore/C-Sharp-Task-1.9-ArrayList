namespace C_Sharp_Task_1._9_ArrayList
{
    class Ticket
    {
     
        public Ticket(int cost, string Date, int Seat, string Vacant, string Name)
        {
            this.Date = Date; 
            this.Cost = cost;
            this.Seat = Seat;
            this.Vacant = Vacant;
            this.Name = Name;
        }
        public Ticket() { } 

        public string Date { set; get; }
        public string Name { set; get; }
        public int Seat { set; get; }
        public int Cost { set; get; }
        public string Vacant { set; get; }
  
    }
}
