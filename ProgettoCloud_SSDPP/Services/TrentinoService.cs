using ProgettoCloud_SSDPP.Models;
using System.Text.Json;

namespace ProgettoCloud_SSDPP.Services {
    public class TrentinoService {

        private readonly HttpClient client = new HttpClient();
        private readonly string url1 = "https://www.meteotrentino.it/protcivtn-meteo/api/front/localitaOpenData";
        private readonly string url2 = "https://www.meteotrentino.it/protcivtn-meteo/api/front/previsioneOpenDataLocalita?localita=";

        public async Task<List<City>> getCities() {
            HttpResponseMessage response = await client.GetAsync(url1);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Cities cities = JsonSerializer.Deserialize<Cities>(responseBody) ?? new();
            return cities.localita ?? [];
        }

        public async Task<Previsione?> getCity(string city) {
            HttpResponseMessage response = await client.GetAsync(url2 + city);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var data = JsonSerializer.Deserialize<PrevisioneData>(responseBody);
            return data == null || data.previsione == null ?
                null: data.previsione.FirstOrDefault();
        }

        internal async Task<Giorno?> GetMeteo(string comune, int distanzaGiorni) {
            var previsione = await getCity(comune);
            var giorni = previsione?.giorni;
            if (giorni == null || distanzaGiorni >= giorni.Length)
                return null;
            return giorni[distanzaGiorni];
        }


    }
}
