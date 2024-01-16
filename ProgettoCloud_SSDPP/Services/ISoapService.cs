using ProgettoCloud_SSDPP.Models;
using System.ServiceModel;

namespace ProgettoCloud_SSDPP.Services {
    [ServiceContract]
    public interface ISoapService {
        [OperationContract]
        public Task<Giorno?> GetMeteo(string comune, int distanzaGiorni);
    }
}
