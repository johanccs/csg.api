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
        public void GetAllRegistrationRecordsFromDbContextGreaterThanZeroRecords()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new RegistrationRepo(dbContext);

            var result = sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void InsertRegistrationRecord_Succeed()
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
            
            sysUnderTest.InsertEntityAsync(reg);

            var result = sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void DeleteClassRecordByID_Succeed()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new RegistrationRepo(dbContext);
            var regEnt = new Registration("50f14850-1161-4b7f-8093-af335090268f");

            sysUnderTest.DeleteByIdAsync(regEnt.Id);

            var result = sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public void DeleteAllClassRecords_Succeed()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new ClassRepo(dbContext);

            sysUnderTest.DeleteAllAsync();

            var result = sysUnderTest.GetAllAsync();

            Assert.True(result.Count == 0);
        }
    }
}
