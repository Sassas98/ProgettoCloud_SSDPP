namespace APITrentino.Models {
    public class PrevisioneData {
        public string fontedacitare { get; set; }
        public string codiceipatitolare { get; set; }
        public string nometitolare { get; set; }
        public string codiceipaeditore { get; set; }
        public string nomeeditore { get; set; }
        public string dataPubblicazione { get; set; }
        public int idPrevisione { get; set; }
        public string evoluzione { get; set; }
        public string evoluzioneBreve { get; set; }
        public Previsione[] previsione { get; set; }
    }
}
