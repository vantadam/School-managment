using Microsoft.AspNetCore.Mvc;
using StudentPortal.web.Data;
using StudentPortal.web.Models.Entities;
using StudentPortal.web.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentPortal.web.Controllers
{
    public class AdminsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public AdminsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddAdminViewModel viewModel)
        {
            var admin = new Admin
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Role = viewModel.Role,
            };
            await dbContext.Admins.AddAsync(admin);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Admins");

        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var admins = await dbContext.Admins.ToListAsync();
            return View(admins);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var admin = await dbContext.Admins.FindAsync(id);

            return View(admin);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Admin viewModel)
        {
            var admin = await dbContext.Admins.FindAsync(viewModel.Id);
            if (admin is not null)
            {
                admin.Name = viewModel.Name;
                admin.Email = viewModel.Email;
                admin.Phone = viewModel.Phone;
                admin.Role = viewModel.Role;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Admins");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Admin viewModel)
        {
            var admin = await dbContext.Admins
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (admin is not null)
            {
                dbContext.Admins.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Admins");
        }
    }
}
