﻿using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {

        [HttpGet]

        public IActionResult CategoryList()
        {
            var c = new Context();
            return Ok(c.Catogaries.ToList());
        }

        [HttpGet ("{id}")]

        public IActionResult CategoryIdGetir(int id) 
        
        {
            using var c = new Context();
            var value = c.Catogaries.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }

        [HttpPost]
        public IActionResult CategoryAdd(Catogary p)
        {
           using var c= new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("", p);

        }

        [HttpDelete]

        public IActionResult CategoryDelete(int id)
        {
            using var c = new Context();
            var value= c.Catogaries.Find(id); 
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent();
            }
        }

        [HttpPut]
        public IActionResult UpdateCategory(Catogary p)
        {
            using var c= new Context();
            var value = c.Find<Catogary>(p.KategoriID);
            if (value == null)
            {
                return NotFound();
            }
            else
            {
                value.KategoriName= p.KategoriName;
                c.Update(value);
                c.SaveChanges();
                return NoContent();
            }
           
        }
    }
}
