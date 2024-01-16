using Microsoft.AspNetCore.Mvc;
using ProgettoCloud_SSDPP.Models;
using ProgettoCloud_SSDPP.Services;
using System.Diagnostics;
using System.Text.Json;

namespace ProgettoCloud_SSDPP.Controllers {
	public class MeteoController : Controller {
        private readonly TrentinoService _service;

        public MeteoController() {
            _service = new TrentinoService();
        }

        public async Task<IActionResult> Index() {
            var cities = await this._service.getCities();
            if(cities == null ) 
                return RedirectToAction("Error");
            return View(cities.Select(c => c.localita).Order().ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public async Task<IActionResult> ProssimiGiorni(string id) {
            var previsione = await _service.getCity(id);
            string jsonString = JsonSerializer.Serialize(previsione);
            return View(new Data(jsonString));
        }

        public async Task<IActionResult> DelGiorno(string id, int gg) {
            var giorno = await _service.GetMeteo(id, gg);
            string jsonString = JsonSerializer.Serialize(giorno);
            return View(new Data(jsonString));
        }

    }
}
