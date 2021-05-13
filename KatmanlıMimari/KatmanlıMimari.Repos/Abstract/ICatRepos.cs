using KatmanlıMimari.Core;
using KatmanlıMimari.DTO;
using KatmanlıMimari.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KatmanlıMimari.Repos.Abstract
{
   public interface ICatRepos:IBaseRepository<Categories>
    {
        List<CategoriesDTO> OzetListe();
    }
}
