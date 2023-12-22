using System;
using System.Collections.Generic;
using System.Linq;
using AlugueldeTemas.Context;
using AlugueldeTemas.Models;

namespace AlugueldeTemas.Services
{
    public class ItemService : IDisposable
    {
        private readonly EFContext dbContext;

        public ItemService(EFContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public List<ItemTema> ListarItens()
        {
            return dbContext?.Itens.ToList() ?? new List<ItemTema>();
        }

        public ItemTema ObterItemPorId(int id)
        {
            return dbContext?.Itens.Find(id);
        }

        public void GravarItem(ItemTema item)
        {
            dbContext.Itens.Add(item);
            dbContext.SaveChanges();
        }

        public void AtualizarItem(ItemTema item)
        {
            dbContext.Entry(item).State = System.Data.Entity.EntityState.Modified;
            dbContext.SaveChanges();
        }

        public void ExcluirItem(int id)
        {
            var item = dbContext.Itens.Find(id);
            if (item != null)
            {
                dbContext.Itens.Remove(item);
                dbContext.SaveChanges();
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
