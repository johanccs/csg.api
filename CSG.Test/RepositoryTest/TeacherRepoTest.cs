using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Interfaces.BaseRepo;
using CSG.Repositories.Repos;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSG.Test.RepositoryTest
{
    public class TeacherRepoTest
    {
        [Fact]
        public void GetAllTeacherRecordsFromDbContextNotNull()
        {
            var dbContext = new SQLConnType(@"localhost\SQLEXPRESS14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new TeacherRepo(dbContext);

            var result = sysUnderTest.GetAllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllTeacherRecordsFromDbContextGreaterThanZeroRecords()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new TeacherRepo(dbContext);

            var result = sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]       
        public void InsertTeacherRecord_Succeed()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new TeacherRepo(dbContext);

            var teacher = new Teacher(Guid.NewGuid().ToString());
            teacher.Name = "Johan";
            teacher.Surname = "Potgieter";
            teacher.DateRegistered = DateTime.Now.Date;

            sysUnderTest.InsertEntityAsync(teacher);

            var result = sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }
    }
}
