using MVC_KuzeyYeli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_KuzeyYeli.Controllers
{
    public class UrunController : Controller
    {

        KuzeyYeliContext ctx = new KuzeyYeliContext();
        public ActionResult Index()
        {
            //Listeleme işlemi
          List<Urunler> urunler=  ctx.Urunlers.ToList();

            /**Bir View metodunun ("View(urunler)") parametreleri arasına bir değişken vermek o değişkeni MODEL yöntemi ile 
             View'a gönder demektir
            Ama Model yöntemi ile tek bir tablo döndürüle bilir,ikinci bir tablo da ki verileri listeleyemeyiz
            */
            ViewBag.Kate = ctx.Kategorilers.ToList();//ViewBag ile birden fazla tablo göndere biliriz

            return View(urunler);
        }

        public ActionResult UrunEkle()
        {
            List<Kategoriler> kat = ctx.Kategorilers.ToList();
            List<Tedarikciler> ted = ctx.Tedarikcilers.ToList();
            ViewBag.kate = kat;
            ViewBag.teda = ted;

            return View();
        }

        [HttpPost]
        public ActionResult UrunEkle(string urunAdi,decimal fiyat,short stok,int kId,int tId)
        {
            //Yeni bir ürün ekleme işlemi
            Urunler u = new Urunler();
            u.UrunAdi = urunAdi;
            u.Fiyat = fiyat;
            u.Stok = stok;
            u.KategoriID = kId;
            u.TedarikciID = tId;
            ctx.Urunlers.Add(u);
            ctx.SaveChanges();
            //RedirectToAction metodu ilgili action metoda yönlendirme yapar.
            //Eğer çalıştırılacak action başka bir kontroller da ise action isminden sonra controller ismi de verilir
            return RedirectToAction("Index");
        }
    }
}