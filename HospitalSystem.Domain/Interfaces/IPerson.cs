using HospitalSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person?> CreateAsync(Person person);
        Task<Person?> GetByIdAsync(string id);
        Task<Person[]> GetAllAsync();
        Task<Person?> Update(Person person);
        Task<Person?> DeleteByIdAsync(string id);
    }
}
