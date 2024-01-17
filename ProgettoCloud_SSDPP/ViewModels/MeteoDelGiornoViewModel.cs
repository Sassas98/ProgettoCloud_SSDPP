using ProgettoCloud_SSDPP.Models;

namespace ProgettoCloud_SSDPP.ViewModels {
	public class MeteoDelGiornoViewModel {

		public string localita { get; set;}
		public string giorno { get; set;}
		public List<Fascia> orari { get; set; }
	}
}
