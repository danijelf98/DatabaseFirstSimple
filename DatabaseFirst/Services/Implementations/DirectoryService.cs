using AutoMapper;
using DatabaseFirst.Models.Binding;
using DatabaseFirst.Models.Dbo;
using DatabaseFirst.Models.ViewModel;
using DatabaseFirst.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DatabaseFirst.Services.Implementations
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IMapper mapper;
        private readonly DirectoryContext db;

        public DirectoryService(IMapper mapper, DirectoryContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<List<PersonViewModel>> GetAllPeople()
        {
            var dbo = await db.People
                .Include(y => y.Address)
                .ToListAsync();

            if (!dbo.Any())
            {
                return new List<PersonViewModel>();
            }

            return dbo.Select(p => mapper.Map<PersonViewModel>(p)).ToList();
        }
        public async Task<PersonViewModel> GetPersonById(int id)
        {
            var dbo = await db.People.FirstOrDefaultAsync(p => p.Id == id);
            return mapper.Map<PersonViewModel>(dbo);
        }
        public async Task<PersonViewModel> AddPerson(PersonBinding model)
        {
            var dbo = mapper.Map<Person>(model);
            db.People.Add(dbo);
            await db.SaveChangesAsync();
            return mapper.Map<PersonViewModel>(dbo);
        }
        public async Task<PersonViewModel> UpdatePerson(PersonUpdateBinding model)
        {
            var dbo = await db.People
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == model.Id);
            mapper.Map(model, dbo);
            await db.SaveChangesAsync();
            return mapper.Map<PersonViewModel>(dbo);
        }
        public async Task<PersonViewModel> DeletePerson(int id)
        {
            var dbo = await db.People
                .Include(p => p.Address)
                .FirstOrDefaultAsync(p => p.Id == id);

            db.People.Remove(dbo);
            db.Addresses.Remove(dbo.Address);
            await db.SaveChangesAsync();
            return mapper.Map<PersonViewModel>(dbo);
        }
    }
}
