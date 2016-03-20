using Dolphin.Domain;
using Dolphin.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dolphin.Test.Mocks
{
    public class MockDataContext : IDataContext
    {
        public Mock<DbSet<User>> MockUsers = new Mock<DbSet<User>>();
        public Mock<DbSet<Donor>> MockDonors = new Mock<DbSet<Donor>>();

        public IDbSet<User> Users { get { return MockUsers.Object; } set { } }
        public IDbSet<Donor> Donors { get { return MockDonors.Object; } set { } }

        public int SaveChanges() { return 0; }
    }
}
