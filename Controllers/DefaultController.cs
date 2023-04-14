using Departman_Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Departman_Core.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Birims.ToList();
            
            return View(degerler);
        }
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public IActionResult BirimSil(int id)
        {
            var dep = c.Birims.Find(id);
            c.Birims.Remove(dep);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var Birim = c.Birims.Find(id);
            return View("BirimGetir", Birim);
        }
        public IActionResult BirimGuncelle(Birim d)
        {
            var dep = c.Birims.Find(d.BirimId);
            dep.BirimAd = d.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimDetay(int id)
        {
            var degerler = c.Personels.Where(X => X.BirimID == id).ToList();
            var birimad = c.Birims.Where(x => x.BirimId == id).Select(y =>
            y.BirimAd).FirstOrDefault();
            ViewBag.brm = birimad;
            return View(degerler);
        }
    }
}
