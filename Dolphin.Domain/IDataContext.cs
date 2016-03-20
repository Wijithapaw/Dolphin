using Dolphin.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin.Domain
{
    public interface IDataContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Donor> Donors { get; set; }

        int SaveChanges();
    }
}
