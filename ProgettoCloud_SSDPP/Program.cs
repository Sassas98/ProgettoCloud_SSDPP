using ProgettoCloud_SSDPP.Services;
using SoapCore;

namespace ProgettoCloud_SSDPP {
    public class Program {
        public static void Main(string[] args) {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints => endpoints.UseSoapEndpoint<ISoapService>
                ("/TrentinoService.wsdl", new SoapEncoderOptions(), SoapSerializer.XmlSerializer));

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Meteo}/{action=Index}/{id?}/{gg?}");

            app.Run();
        }
    }
}
