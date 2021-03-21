using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Repositories.Repos;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSG.Test.RepositoryTest
{
    public class RegistrationsRepoTest
    {
        [Fact]
        public void GetAllRegistrationRecordsFromDbContextNotNull()
        {
            var dbContext = new SQLConnType(@"localhost\SQLEXPRESS14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new RegistrationRepo(dbContext);

            var result = sysUnderTest.GetAllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllRegistrationRecordsFromDbContextGreaterThanZeroRecords()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new RegistrationRepo(dbContext);

            var result = await sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task InsertRegistrationRecord_Succeed()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new RegistrationRepo(dbContext);          
            var reg = new Registration(Guid.NewGuid().ToString());
           
            reg.AttendanceDate = DateTime.Now.Date;
            reg.AttendanceStatusId = 1;
            reg.ClassId = "50f14850-1161-4b7f-8093-af335090268f";
            reg.Grade = 75;
            reg.StudentId = "50f14850-1161-4b7f-8093-af335090268f";
            reg.TeacherId = "50f14850-1161-4b7f-8093-af335090268f";
            
            await sysUnderTest.InsertEntityAsync(reg);

            var result = await sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task DeleteClassRecordByID_Succeed()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new RegistrationRepo(dbContext);
            var regEnt = new Registration("50f14850-1161-4b7f-8093-af335090268f");

            await sysUnderTest.DeleteByIdAsync(regEnt.Id);

            var result = await sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task DeleteAllClassRecords_Succeed()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new ClassRepo(dbContext);

            await sysUnderTest.DeleteAllAsync();

            var result = await sysUnderTest.GetAllAsync();

            Assert.True(result.Count == 0);
        }
    }
}
