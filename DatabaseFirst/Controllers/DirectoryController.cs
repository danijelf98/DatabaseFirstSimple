using AutoMapper;
using DatabaseFirst.Models.Binding;
using DatabaseFirst.Models.Dbo;
using DatabaseFirst.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DatabaseFirst.Controllers
{
    public class DirectoryController : Controller
    {
        private readonly IDirectoryService directoryService;
        private readonly IMapper mapper;

        public DirectoryController(IDirectoryService directoryService, IMapper mapper)
        {
            this.directoryService = directoryService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> People()
        {
            var people = await directoryService.GetAllPeople();
            return View(people);
        }
        public async Task<IActionResult> AddPerson()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPerson(PersonBinding model)
        {
            await directoryService.AddPerson(model);
            return RedirectToAction("People");
        }
        //popraviti
        public async Task<IActionResult> PersonDetails(int id)
        {
            var dbo = await directoryService.GetPersonById(id);
            return View(dbo);
        }
        public async Task<IActionResult> DeletePerson(int id)
        {
            await directoryService.DeletePerson(id);
            return RedirectToAction("People");
        }
        public async Task<IActionResult> EditPerson(int id)
        {
            var dbo = await directoryService.GetPersonById(id);
            var model = mapper.Map<PersonUpdateBinding>(dbo);
             
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EditPerson(PersonUpdateBinding model)
        {
            await directoryService.UpdatePerson(model);
            return RedirectToAction("People");
        }
    }
}
