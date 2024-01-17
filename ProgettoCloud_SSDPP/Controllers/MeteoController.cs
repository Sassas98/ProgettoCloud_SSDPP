using Microsoft.AspNetCore.Mvc;
using ProgettoCloud_SSDPP.Models;
using ProgettoCloud_SSDPP.Services;
using ProgettoCloud_SSDPP.ViewModels;
using System.Diagnostics;
using System.Text.Json;
using static ProgettoCloud_SSDPP.Services.TrentinoService;

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

        [HttpGet]
        public async Task<IActionResult> ProssimiGiorni(string id) {
            var previsione = await _service.getCity(id);
            var vm = new MeteoLocalitaViewModel();
            vm.localita = previsione.localita;
            vm.giorni = previsione.giorni.Select(g => {
                Models.Giorno giorno = new Giorno();
                giorno.giorno = g.giorno;
                giorno.testoGiorno = g.testoGiorno;
                giorno.descIcona = g.descIcona;
                giorno.iconaUrl = g.icona;
                giorno.tMaxGiorno = g.tMaxGiorno;
                giorno.tMinGiorno = g.tMinGiorno;
                return giorno;
            }).ToList();

            return View(vm);
        }

        public async Task<IActionResult> DelGiorno(string id, int gg) {
            var giorno = await _service.GetMeteo(id, gg);
			var vm = new MeteoDelGiornoViewModel();
            vm.localita = id;
            var nums = giorno?.giorno.Split('-');
            vm.giorno = nums[2] + '/' + nums[1] + '/' + nums[0];
            vm.orari = giorno.fasce.Select(f => {
                Models.Fascia fascia = new Fascia();
                fascia.fasciaOre = f.fasciaOre;
                fascia.fasciaPer = f.fasciaPer;
                fascia.icona = f.icona;
                fascia.descIcona = f.descIcona;
                fascia.IntensitaPrecipitazioni = f.descPrecInten;
                fascia.ProbabilitaPrecipitazioni = f.descPrecProb;
                return fascia;
            }).ToList();
			return View(vm);
        }

    }
}
