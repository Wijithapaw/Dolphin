using Dolphin.Domain.Entities;
using Dolphin.Services;
using Dolphin.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Dolphin.Test.Services
{
    public class DonorServiceTests
    {
        public static DonorService CreateService(ICollection<Donor> data = null, MockDataContext context = null)
        {
            context = context ?? new MockDataContext();
            var service = new DonorService(context);

            context.MockDonors.SetupData(data, ids => context.Donors.SingleOrDefault(a => a.Id == ids[0].ToString()));

            return service;
        }

        public class GetMethod
        {
            [Fact]
            public void WhenGivenValidId_ReturnDonor()
            {
                var data = new List<Donor>() {
                      new Donor() { Id = "1", Email = "donor1@yopmail.com"},
                      new Donor() { Id = "2", Email = "donor2@yopmail.com"},
                      new Donor() { Id = "3", Email = "donor3@yopmail.com"},
                      new Donor() { Id = "4", Email = "donor4@yopmail.com"},
                      new Donor() { Id = "5", Email = "donor5@yopmail.com"}
                  };

                var service = CreateService(data);

                var donor = service.Get("1");
                Assert.NotNull(donor);
                Assert.Equal("donor1@yopmail.com", donor.Email);

                donor = service.Get("3");
                Assert.NotNull(donor);
                Assert.Equal("donor3@yopmail.com", donor.Email);

                donor = service.Get("4");
                Assert.NotNull(donor);
                Assert.Equal("donor4@yopmail.com", donor.Email);
            }

            [Fact]
            public void WhenGivenInValidId_ReturnNull()
            {
                var data = new List<Donor>() {
                      new Donor() { Id = "1", Email = "donor1@yopmail.com"},
                      new Donor() { Id = "2", Email = "donor2@yopmail.com"},
                      new Donor() { Id = "3", Email = "donor3@yopmail.com"},
                      new Donor() { Id = "4", Email = "donor4@yopmail.com"},
                      new Donor() { Id = "5", Email = "donor5@yopmail.com"}
                  };

                var service = CreateService(data);

                var donor = service.Get("10");
                Assert.Null(donor);
            }
        }

        public class GetAllMethod
        {
            [Fact]
            public void WhenNoDonorsExists_ReturnNon()
            {
                var data = new List<Donor>();

                var service = CreateService(data);

                var donors = service.GetAll();
                Assert.Equal(0, donors.Count());
            }

            [Fact]
            public void WhenDonorsExist_ReturnAllDonors()
            {
                var data = new List<Donor>() {
                      new Donor() { Id = "1", Email = "donor1@yopmail.com"},
                      new Donor() { Id = "2", Email = "donor2@yopmail.com"},
                      new Donor() { Id = "3", Email = "donor3@yopmail.com"},
                      new Donor() { Id = "4", Email = "donor4@yopmail.com"},
                      new Donor() { Id = "5", Email = "donor5@yopmail.com"}
                  };

                var service = CreateService(data);


                var donors = service.GetAll();

                Assert.Equal(5, donors.Count());
                Assert.Equal("donor4@yopmail.com", donors.First(a => a.Id == "4").Email);
            }
        }

        public class CreateMethod
        {
            [Fact]
            public void WhenNoDonorsExist_DonorCreateSuccessfully()
            {
                var data = new List<Donor>();

                var service = CreateService(data);

                var donor = new Donor() { Id = "1", FirstName = "Donor", LastName = "System", Email = "donor@yopmail.com" };

                var result = service.Create(donor);

                Assert.NotNull(result);
                Assert.Equal("donor@yopmail.com", result.Email);
                Assert.Equal("1", result.Id);
            }

            [Fact]
            public void WhenDonorsExists_DonorCreateSuccessfully()
            {
                var data = new List<Donor>() {
                      new Donor() { Id = "1", Email = "donor1@yopmail.com"},
                      new Donor() { Id = "2", Email = "donor2@yopmail.com"},
                      new Donor() { Id = "3", Email = "donor3@yopmail.com"},
                      new Donor() { Id = "4", Email = "donor4@yopmail.com"},
                      new Donor() { Id = "5", Email = "donor5@yopmail.com"}
                  };

                var service = CreateService(data);

                var donor = new Donor() { Id = "6", FirstName = "Donor6", LastName = "System6", Email = "donor6@yopmail.com" };

                var result = service.Create(donor);

                Assert.NotNull(result);
                Assert.Equal("donor6@yopmail.com", result.Email);
                Assert.Equal("6", result.Id);
            }
        }

        public class UpdateMethod
        {
            [Fact]
            public void WhenDonorExist_UpdateSuccessfully()
            {
                var data = new List<Donor>() {
                      new Donor() { Id = "1", Email = "donor1@yopmail.com"},
                      new Donor() { Id = "2", Email = "donor2@yopmail.com"},
                      new Donor() { Id = "3", Email = "donor3@yopmail.com"},
                      new Donor() { Id = "4", Email = "donor4@yopmail.com"},
                      new Donor() { Id = "5", Email = "donor5@yopmail.com"}
                  };

                var service = CreateService(data);

                var donor = new Donor() { Id = "3", FirstName = "Donor3", LastName = "System3", Email = "donor3.new@yopmail.com" };

                service.Update(donor);

                var updatedDonor = service.Get("3");

                Assert.NotNull(updatedDonor);
                Assert.Equal("donor3.new@yopmail.com", updatedDonor.Email);
                Assert.Equal("3", updatedDonor.Id);
            }

            public void WhenDonorNotExist_ThrowsException()
            {
                //TODO
            }
        }
    }
}
