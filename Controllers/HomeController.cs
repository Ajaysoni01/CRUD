using CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUD.Controllers
{
    public class HomeController : Controller
    {
        private readonly EmpDBContext empDB;

        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}


        public HomeController(EmpDBContext EmpDB) 
        {
            this.empDB = EmpDB;
        }

        
        public async Task<IActionResult> Index()
        {
             var stdData = await empDB.Employess.ToListAsync();
            return View(stdData);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDB emp)
        {
            if (ModelState.IsValid) 
            {
               await empDB.Employess.AddAsync(emp);   
               await empDB.SaveChangesAsync();
                TempData["Insert_success"] = "";
                return RedirectToAction("Index","Home");
            }
                

            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id == null || empDB.Employess == null )
            {
                return NotFound();
            }
            var stdData = await empDB.Employess.FirstOrDefaultAsync(x => x.Id == id);
            if (stdData == null)   
            {
                return NotFound();  
            }    
            return View(stdData);
        }


        public async Task <IActionResult> Edit(int? id)
        {
            if (id == null || empDB.Employess == null)
            {
                return NotFound();
            }
            var stdData = await empDB.Employess.FindAsync(id);

            if (stdData == null)
            {
                return NotFound();
            }

            return View(stdData);
        }

        [HttpPost]

        public async Task<IActionResult> Edit(int? id, EmployeeDB std)
        {
            if(id != std.Id) 
            { 
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                empDB.Update(std);
                await empDB.SaveChangesAsync();
                TempData["In_success"] = "";
                return RedirectToAction("Index", "Home");
            }

            return View(std);
        }




        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || empDB.Employess == null)
            {
                return NotFound();
            }
            var stdData = await empDB.Employess.FirstOrDefaultAsync(x => x.Id == id);

            if (stdData == null) { 
                return NotFound();  
            
            }
            return View(stdData);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteCof(int? id)
        {
            var stdData = await empDB.Employess.FindAsync(id);
            if (stdData != null) 
            {
                empDB.Employess.Remove(stdData);
            }
            await empDB.SaveChangesAsync();
            TempData["Delete_success"] = "";
            return RedirectToAction("Index", "Home");   
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}