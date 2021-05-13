using KatmanlıMimari.Core;
using KatmanlıMimari.Dal;
using KatmanlıMimari.DTO;
using KatmanlıMimari.Entities;
using KatmanlıMimari.Repos.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace KatmanlıMimari.Repos.Concrete
{
   public class CatRepos:BaseRepository<Categories>,ICatRepos
    {
        public CatRepos(ProductsContext db):base(db)
        {

        }

        public List<CategoriesDTO> OzetListe()
        {
           return  Set().Select(x => new CategoriesDTO
            {
                CategoryId = x.CategoryId,
                CategoryName=x.CategoryName
            }).ToList();
        }
    }
}
 