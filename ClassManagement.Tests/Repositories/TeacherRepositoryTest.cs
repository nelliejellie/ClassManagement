using Classmanagement.Repository.Repositories;
using ClassManagement.Api.AppContext;
using ClassManagement.Api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassManagement.Tests.Repositories
{
    [TestFixture]
    public class TeacherRepositoryTest
    {
        private DbContextOptions<AppDbContext> _options;

        [SetUp]
        public void Setup()
        {
            _options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;
        }

        [Test]
        public async Task TestGetTeachers()
        {
            // Arrange
            using (var dbContext = new AppDbContext(_options))
            {
                dbContext.Teachers.AddRange(
                    new Teacher { Id = Guid.NewGuid(), Name = "John Doe", DOB = "2022-10-09", NIN="050505",TeacherNumber="595950",Salary=455,Surname="Test",Title="Mr"},
                    new Teacher { Id = Guid.NewGuid(), Name = "Jane Smith", DOB = "2022-10-09", NIN = "050505", TeacherNumber = "595950", Salary = 455, Surname = "Test", Title = "Mr" },
                    new Teacher { Id = Guid.NewGuid(), Name = "Bob Johnson", DOB = "2022-10-09", NIN = "050505", TeacherNumber = "595950", Salary = 455, Surname = "Test", Title = "Mr" }
                );
                dbContext.SaveChanges();

                var repository = new TeacherRepository(dbContext);

                // Act
                var teachers = await repository.GetAll();

                // Assert
                Assert.IsInstanceOf(typeof(IEnumerable<Teacher>), teachers);
                Assert.IsNotNull(teachers);
                Assert.AreEqual(3, teachers.Count());
            }
        }

        [Test]
        public async Task TestAddTeacher()
        {
            // Arrange
            using (var dbContext = new AppDbContext(_options))
            {
                var repository = new TeacherRepository(dbContext);

                var newTeacher = new Teacher { Id = Guid.NewGuid(), Name = "Bob Johnson", DOB = "2022-10-09", NIN = "050505", TeacherNumber = "595950", Salary = 455, Surname = "Test", Title = "Mr" };

                // Act
                await repository.Add(newTeacher);
                dbContext.SaveChanges();

                // Assert
                var addedTeacher = dbContext.Teachers.FirstOrDefault(t => t.Name == "Bob Johnson");
                Assert.IsNotNull(addedTeacher);
                Assert.AreEqual("050505", addedTeacher.NIN);
            }
        }
    }

    
}
