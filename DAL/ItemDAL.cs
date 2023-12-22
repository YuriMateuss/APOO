using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AlugueldeTemas.Context;
using AlugueldeTemas.Models;

namespace AlugueldeTemas.DAL
{
    public class ItemDAL
    {
        private readonly EFContext context;

        public ItemDAL(EFContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public void Gravar(ItemTema item)
        {
            context.Itens.Add(item);
            context.SaveChanges();
        }
    }
}
