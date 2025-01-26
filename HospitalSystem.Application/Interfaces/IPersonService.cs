using HospitalSystem.Domain.Entities.persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Application.Interfaces
{
    public interface IPersonService
    {
        Task<Person?> CreateAsync(Person person);
        Task<Person?> GetByIdAsync(string id);
        Task<Person[]> GetAllAsync();
        Task<Person?> Update(Person person);
        Task<Person?> DeleteByIdAsync(string id);
    }
}
