using Dolphin.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dolphin.Domain.Entities;
using Dolphin.Domain;
using System.Runtime.Remoting.Contexts;

namespace Dolphin.Services
{
    public class DonorService : ServiceBase, IDonorService
    {

        public DonorService(IDataContext context) : base(context) { }

        public Donor Create(Donor donor)
        {
            Context.Donors.Add(donor);
            Context.SaveChanges();

            return donor;
        }

        public Donor Get(string id)
        {
            return Context.Donors.Find(id);
        }

        public IEnumerable<Donor> GetAll()
        {
            return Context.Donors;
        }

        public void Update(Donor model)
        {
            var donor = Get(model.Id);

            donor.FirstName = model.FirstName;
            donor.LastName = model.LastName;
            donor.Email = model.Email;

            Context.SaveChanges();
        }
    }
}
