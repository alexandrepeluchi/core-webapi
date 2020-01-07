using System.Collections.Generic;
using System.Linq;
using APIIntroducao.Models;
using Microsoft.AspNetCore.Mvc;

namespace APIIntroducao.Controllers 
{
    // Restringe o formato de resposta e escolha de uma rota
    [Produces("application/json")]
    [Route("api/categories")]
    public class CategoriesController : Controller 
    {
        public readonly ApplicationDbContext context;
        public CategoriesController (ApplicationDbContext context) 
        {
            this.context = context;
        }

        // Método chamado via API, por isso a marcação HttpGet
        [HttpGet]
        public IEnumerable<Categories> Get() 
        {
            return context.Categories.ToList();
        }
    }
}