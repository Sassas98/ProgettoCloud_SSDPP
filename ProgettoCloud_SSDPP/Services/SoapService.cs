using ProgettoCloud_SSDPP.Models;
using System.ServiceModel;

namespace ProgettoCloud_SSDPP.Services {
    
    public class SoapService : ISoapService {

        private TrentinoService _service;

        public SoapService() {
            this._service = new TrentinoService();
        }

        public async Task<Giorno?> GetMeteo(string comune, int distanzaGiorni) {
            return await this._service.GetMeteo(comune, distanzaGiorni);
        }
    }
}
