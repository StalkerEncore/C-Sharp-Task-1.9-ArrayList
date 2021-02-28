namespace C_Sharp_Task_1._9_ArrayList
{
    class Ticket
    {
     
        public Ticket(int cost, string Date, int Site, bool Vacant, string Name)
        {
            this.Date = Date; 
            this.Cost = cost;
            this.Site = Site;
            this.Vacant = Vacant;
            this.Name = Name;
        }
        public Ticket() { } 

        public string Date { set; get; }
        public string Name { set; get; }
        public int Site { set; get; }
        public int Cost { set; get; }
        public bool Vacant { set; get; }
  
    }
}
