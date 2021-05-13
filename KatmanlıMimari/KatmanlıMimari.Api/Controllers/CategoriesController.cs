using KatmanlıMimari.DTO;
using KatmanlıMimari.DTO.Response;
using KatmanlıMimari.Entities;
using KatmanlıMimari.Repos.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KatmanlıMimari.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        ICatRepos _catRepos;
        GeneralResponse _response;
        public CategoriesController(ICatRepos catRepos,GeneralResponse response)
        {
            _catRepos = catRepos;
            _response = response;
        }
        [HttpGet]
        public List<CategoriesDTO> list()
        {
            return _catRepos.OzetListe();
        }

        [HttpGet("{id:int}")]
        public Categories Find(int id)
        {
            return _catRepos.Find(id);
        }
        [HttpPost]
        public GeneralResponse Add([FromBody] Categories cat)
        {
            
            try
            {
                cat.CategoryId = 0;
                _catRepos.Add(cat);
                _catRepos.Commit();
                _response.Msg= $"{cat.CategoryName} Eklendi";
                // return cat.CategoryName + " " + "Eklendi";
            }
            catch (Exception ex)
            {

               _response.Msg= $"{cat.CategoryName} Eklenemedi: {ex.Message}";
            }
            return _response;
        }
        [HttpPut]
        public GeneralResponse Update([FromBody] Categories cat)
        {
            string msg = " ";
            
            
            try
            {
                _catRepos.Update(cat);
                _catRepos.Commit();
                // return $"{cat.CategoryName} Güncellendi";
                _response.Status = true;
                _response.Msg = $"{cat.CategoryName} Güncellendi";

           
            }
            catch (Exception ex)
            {

                //return $"{cat.CategoryName} Güncellenmedi: {ex.Message}";
                _response.Status = false;
                _response.Msg = $"{cat.CategoryName} Güncellenmedi";

            }
            return _response;
        }
        [HttpPost]
        public GeneralResponse Delete([FromBody] Categories cat)
        {
            try
            {
                _catRepos.Delete(cat);
                _catRepos.Commit();
               _response.Msg= $"{cat.CategoryName} Silindi";
                // return cat.CategoryName + " " + "Eklendi";
            }
            catch (Exception ex)
            {

                _response.Msg= $"{cat.CategoryName} Silinemedi: {ex.Message}";
            }
            return _response;
        }
        [HttpGet("{id:int}")]
        public GeneralResponse Delete2(int id)
        {
            var cat = _catRepos.Find(id);
            try
            {
                _catRepos.Delete(cat);
                _catRepos.Commit();
                _response.Msg= $"{cat.CategoryName} Silindi";
                // return cat.CategoryName + " " + "Eklendi";
            }
            catch (Exception ex)
            {

                _response.Msg= $"{cat.CategoryName} Silinemedi: {ex.Message}";
            }
            return _response;
        }
    }
}
