namespace APITrentino.Models {
    public class Previsione {
        public string localita { get; set; }
        public int quota { get; set; }
        public Giorno[] giorni { get; set; }
    }
}
