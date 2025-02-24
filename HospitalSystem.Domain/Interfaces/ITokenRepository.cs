using HospitalSystem.Domain.Entities;
using HospitalSystem.Domain.Entities.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSystem.Domain.Interfaces
{
    public interface ITokenRepository
    {
        Tokens Authenticate(Person person);
    }
}
