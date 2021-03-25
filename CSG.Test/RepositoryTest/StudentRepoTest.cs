using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Repositories.Repos;
using System;
using Xunit;

namespace CSG.Test.RepositoryTest
{
    public class StudentRepoTest
    {

        [Fact]
        public void GetAllStudentRecordsFromDbContextNotNull()
        {
            var dbContext = new SQLConnType(@"localhost\SQLEXPRESS14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new StudentRepo(dbContext);

            var result = sysUnderTest.GetAllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllStudentRecordsFromDbContextGreaterThanZeroRecords()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new StudentRepo(dbContext);

            var result =  sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void InsertStudentRecord_Succeed()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new StudentRepo(dbContext);

            var student = new Student(Guid.NewGuid().ToString());
            student.Name = "Johan";
            student.Surname = "Potgieter";
            student.DateRegistered = DateTime.Now.Date;

             sysUnderTest.InsertEntityAsync(student);

            var result = sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }
    }
}
