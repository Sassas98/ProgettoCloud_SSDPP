namespace ProgettoCloud_SSDPP.Models {
    public class Fascia {
        public int idPrevisioneFascia { get; set; }
        public string fascia { get; set; }
        public string fasciaPer { get; set; }
        public string fasciaOre { get; set; }
        public string icona { get; set; }
        public string descIcona { get; set; }
        public string idPrecProb { get; set; }
        public string descPrecProb { get; set; }
        public string idPrecInten { get; set; }
        public string descPrecInten { get; set; }
        public string idTempProb { get; set; }
        public string descTempProb { get; set; }
        public string idVentoIntQuota { get; set; }
        public string descVentoIntQuota { get; set; }
        public string idVentoDirQuota { get; set; }
        public string descVentoDirQuota { get; set; }
        public string idVentoIntValle { get; set; }
        public string descVentoIntValle { get; set; }
        public string idVentoDirValle { get; set; }
        public string descVentoDirValle { get; set; }
        public string iconaVentoQuota { get; set; }
        public int zeroTermico { get; set; }
        public int limiteNevicate { get; set; }
    }
}
