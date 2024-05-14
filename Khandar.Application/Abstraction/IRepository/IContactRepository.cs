using Khandar.Application.Abstraction.IRepository;
using Khandar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khandar.Application.Abstractions.IRepositories
{
    public interface IContactRepository:IBaseRepository<Contact>
    {
    }
}
