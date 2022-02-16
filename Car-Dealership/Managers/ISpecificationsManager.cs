using Project.Entities;
using Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Managers
{
    public interface ISpecificationsManager
    {
        List<SpecificationsModel> GetSpecificationsFilteredOrdered();
        Task Create(Specifications model);
        Task Update(SpecificationsModel model);
        void Delete(string id);
    }
}
