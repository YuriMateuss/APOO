using System.Collections.Generic;
using System.Web.Mvc;
using AlugueldeTemas.Models; 
using AlugueldeTemas.Services;

namespace AlugueldeTemas.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService _itemService;

        public ItemController()
        {
            _itemService = new ItemService(); 
        }

        public ActionResult Index()
        {
            List<ItemTema> itens = _itemService.ListarItens();
            return View(itens);
        }

        public ActionResult Details(int id)
        {
            ItemTema item = _itemService.ObterItemPorId(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ItemTema itemTema)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _itemService.GravarItem(itemTema);
                    return RedirectToAction("Index");
                }

                return View(itemTema);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ItemTema item = _itemService.ObterItemPorId(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ItemTema itemTema)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _itemService.AtualizarItem(itemTema);
                    return RedirectToAction("Index");
                }

                return View(itemTema);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            ItemTema item = _itemService.ObterItemPorId(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View(item);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _itemService.ExcluirItem(id);
            return RedirectToAction("Index");
        }
    }
}
