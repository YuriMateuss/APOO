using System.Collections.Generic;
using System.Web.Mvc;
using AlugueldeTemas.Context;
using AlugueldeTemas.Models;
using AlugueldeTemas.Services;

namespace AlugueldeTemas.Controllers
{
    public class ItemController : Controller
    {
        private readonly ItemService itemService;

        public ItemController(ItemService itemService)
        {
            this.itemService = itemService;
        }

        public ActionResult Index()
        {
            List<ItemTema> itens = itemService.ListarItens();
            return View(itens);
        }

        public ActionResult Details(int id)
        {
            ItemTema item = itemService.ObterItemPorId(id);

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
                    itemService.GravarItem(itemTema);
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
            ItemTema item = itemService.ObterItemPorId(id);

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
                    itemService.AtualizarItem(itemTema);
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
            ItemTema item = itemService.ObterItemPorId(id);

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
            itemService.ExcluirItem(id);
            return RedirectToAction("Index");
        }
    }
}
