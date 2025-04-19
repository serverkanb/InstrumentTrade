namespace InstrumentTrade.WebUI.Models
{
    public class ReviewViewModel
    {
        public string Author { get; set; }      // Yorumu yapan 
        public string Comment { get; set; }     //Yorum
        public DateTime Date { get; set; }      // Yorum tarihi

        public int Rating { get; set; }
    }
}
