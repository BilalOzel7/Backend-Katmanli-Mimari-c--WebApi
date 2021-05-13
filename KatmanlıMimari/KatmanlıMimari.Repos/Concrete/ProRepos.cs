using KatmanlıMimari.Core;
using KatmanlıMimari.Dal;
using KatmanlıMimari.DTO;
using KatmanlıMimari.Entities;
using KatmanlıMimari.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KatmanlıMimari.Repos.Concrete
{
   public class ProRepos: BaseRepository<Products>, IProRepos
    {
        public ProRepos(ProductsContext db) : base(db)
        {

        }
        public List<ProductsDTO> OzetListe()
        {
            return Set().Select(x => new ProductsDTO
            {
                
                ProductId = x.ProductId,
                ProductName = x.ProductName
            }).ToList();
        }
    }
}
