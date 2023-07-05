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
    public class StudentRepositoryTest
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
        public async Task TestGetStudents()
        {
            // Arrange
            using (var dbContext = new AppDbContext(_options))
            {
                dbContext.Students.AddRange(
                    new Student { Id = Guid.NewGuid(), Name = "John Doe", DOB = "2022-10-09", NIN = "050505", StudentNumber = "595950", Surname = "Test" },
                    new Student { Id = Guid.NewGuid(), Name = "Jane Smith", DOB = "2022-10-09", NIN = "050505", StudentNumber = "595950",  Surname = "Test" },
                    new Student { Id = Guid.NewGuid(), Name = "Bob Johnson", DOB = "2022-10-09", NIN = "050505", StudentNumber = "595950",Surname = "Test" }
                );
                dbContext.SaveChanges();

                var repository = new StudentRepository(dbContext);

                // Act
                var students = await repository.GetAll();

                // Assert
                Assert.IsInstanceOf(typeof(IEnumerable<Student>), students);
                Assert.IsNotNull(students);
                Assert.AreEqual(3, students.Count());
            }
        }

        [Test]
        public async Task TestAddTeacher()
        {
            // Arrange
            using (var dbContext = new AppDbContext(_options))
            {
                var repository = new StudentRepository(dbContext);

                var newTeacher = new Student { Id = Guid.NewGuid(), Name = "Bob Johnson", DOB = "2022-10-09", NIN = "050505", StudentNumber = "595950", Surname = "Test" };

                // Act
                await repository.Add(newTeacher);
                dbContext.SaveChanges();

                // Assert
                var addedStudent = dbContext.Students.FirstOrDefault(t => t.Name == "Bob Johnson");
                Assert.IsNotNull(addedStudent);
                Assert.AreEqual("050505", addedStudent.NIN);
            }
        }

    }
}
