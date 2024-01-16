using ProgettoCloud_SSDPP.Models;
using System.ServiceModel;

namespace ProgettoCloud_SSDPP.Services {
    [ServiceContract]
    public interface ITrentinoService {
        [OperationContract]
        public Task<Giorno?> GetMeteo(string comune, DateTime giorno);
    }
}
