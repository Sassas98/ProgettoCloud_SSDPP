namespace ProgettoCloud_SSDPP.Models {
    public class Giorno {
        public int idPrevisioneGiorno { get; set; }
        public string giorno { get; set; }
        public int idIcona { get; set; }
        public string icona { get; set; }
        public string descIcona { get; set; }
        public string testoGiorno { get; set; }
        public int tMinGiorno { get; set; }
        public int tMaxGiorno { get; set; }
        public Fascia[] fasce { get; set; }
    }
}
