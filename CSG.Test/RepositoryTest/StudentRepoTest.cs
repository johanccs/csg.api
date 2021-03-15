using CSG.Data.DbContext;
using CSG.Repositories.Repos;
using Xunit;

namespace CSG.Test.RepositoryTest
{
    public class StudentRepoTest
    {

        [Fact]
        public void GetAllStudentRecordsFromDbContextNotNull()
        {
            var dbContext = new SQLConnType(@"localhost\SQLEXPRESS14", "CSG", "sa", "@1Mops4moa", "sp_GetStudents");
            var sysUnderTest = new StudentRepo(dbContext);

            var result = sysUnderTest.GetAll();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllTeacherRecordsFromDbContextGreaterThanZeroRecords()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa", "sp_GetStudents");
            var sysUnderTest = new StudentRepo(dbContext);

            var result = sysUnderTest.GetAll();

            Assert.True(result.Count > 0);
        }
    }
}
