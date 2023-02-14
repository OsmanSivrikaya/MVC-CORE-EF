using core_mvc_case.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Abstract;
using System.Diagnostics;

namespace core_mvc_case.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IPersonelService _personelService;

        public HomeController(IConfiguration configuration, IPersonelService personelService)
        {
            _configuration = configuration;
            _personelService = personelService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<JsonResult> PersonelGetir(Personel personel)
        {
            var result = await _personelService.GetAllAsync();
            return Json(result);
        }
        public async Task PersonelEkle(Personel personel)
        {
            await _personelService.AddAsync(personel);
        }
        public async Task PersonelGuncelle(Personel personel)
        {
            await _personelService.UpdateAsync(personel);
        }
        public async Task Delete(Personel personel)
        {
            await _personelService.DeleteAsync(personel);
        }
    }
}