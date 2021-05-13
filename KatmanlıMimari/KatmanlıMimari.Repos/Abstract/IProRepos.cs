using KatmanlıMimari.Core;
using KatmanlıMimari.DTO;
using KatmanlıMimari.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KatmanlıMimari.Repos.Abstract
{
  public interface IProRepos:IBaseRepository<Products>
    {
        List<ProductsDTO> OzetListe();
    }
}
