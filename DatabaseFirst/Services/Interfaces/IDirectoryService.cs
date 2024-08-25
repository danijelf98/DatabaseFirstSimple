using DatabaseFirst.Models.Binding;
using DatabaseFirst.Models.ViewModel;

namespace DatabaseFirst.Services.Interfaces
{
    public interface IDirectoryService
    {
        Task<PersonViewModel> AddPerson(PersonBinding model);
        Task<PersonViewModel> DeletePerson(int id);
        Task<List<PersonViewModel>> GetAllPeople();
        Task<PersonViewModel> GetPersonById(int id);
        Task<PersonViewModel> UpdatePerson(PersonUpdateBinding model);
    }
}