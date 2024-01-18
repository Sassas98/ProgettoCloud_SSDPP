using APITrentino.Models;
using System.ServiceModel;

namespace APITrentino.Services {
    [ServiceContract]
    public interface ITrentinoService {
        [OperationContract]
        public Task<Giorno?> GetMeteo(string comune, DateTime giorno);
    }
}
