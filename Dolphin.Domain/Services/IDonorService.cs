using Dolphin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin.Domain.Services
{
    public interface IDonorService
    {
        IEnumerable<Donor> GetAll();

        Donor Get(string id);

        Donor Create(Donor donor);

        void Update(Donor donor);
    }
}
