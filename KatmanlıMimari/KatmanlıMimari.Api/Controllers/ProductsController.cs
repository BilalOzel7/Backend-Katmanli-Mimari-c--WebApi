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
    public class ProductsController : ControllerBase
    {
        IProRepos _proRepos;
        GeneralResponse _response;

        public ProductsController(IProRepos proRepos,GeneralResponse response)
        {
            _proRepos = proRepos;
            _response = response;
        }

        [HttpGet]
        public List<ProductsDTO> List()
        {
            return _proRepos.OzetListe();
        }
        [HttpGet("{id:int}")]
        public Products Find(int id)
        {
            return _proRepos.Find(id);
        }
        [HttpPost]
        public GeneralResponse Add([FromBody] Products pro)
        {

            try
            {
                pro.ProductId = 0;
                _proRepos.Add(pro);
                _proRepos.Commit();
                _response.Msg = $"{pro.ProductName} Eklendi";
                // return cat.CategoryName + " " + "Eklendi";
            }
            catch (Exception ex)
            {

                _response.Msg = $"{pro.ProductName} Eklenemedi: {ex.Message}";
            }
            return _response;
        }
        [HttpPut]
        public GeneralResponse Update([FromBody] Products pro)
        {
            


            try
            {
                
                _proRepos.Update(pro);
                _proRepos.Commit();
                // return $"{cat.CategoryName} Güncellendi";
                _response.Status = true;
                _response.Msg = $"{pro.ProductName} Güncellendi";


            }
            catch (Exception ex)
            {

                //return $"{cat.CategoryName} Güncellenmedi: {ex.Message}";
                //_response.Status = false;
                _response.Msg = $"{pro.ProductName} Güncellenmedi";

            }
            return _response;
        }
        [HttpPost]
        public GeneralResponse Delete([FromBody] Products pro)
        {
            try
            {
                _proRepos.Delete(pro);
                _proRepos.Commit();
                _response.Msg = $"{pro.ProductName} Silindi";
                // return cat.CategoryName + " " + "Eklendi";
            }
            catch (Exception ex)
            {

                _response.Msg = $"{pro.ProductName} Silinemedi: {ex.Message}";
            }
            return _response;
        }

        [HttpGet("{id:int}")]
        public GeneralResponse Delete2(int id)
        {
            var pro = _proRepos.Find(id);
            try
            {
                _proRepos.Delete(pro);
                _proRepos.Commit();
                _response.Msg = $"{pro.ProductName} Silindi";
                // return cat.CategoryName + " " + "Eklendi";
            }
            catch (Exception ex)
            {

                _response.Msg = $"{pro.ProductName} Silinemedi: {ex.Message}";
            }
            return _response;
        }

    }
}
