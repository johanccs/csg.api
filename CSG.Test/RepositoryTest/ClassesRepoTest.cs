﻿using CSG.Data.DataEntities;
using CSG.Data.DbContext;
using CSG.Repositories.Repos;
using System;
using System.Threading.Tasks;
using Xunit;

namespace CSG.Test.RepositoryTest
{
    public class ClassesRepoTest
    {
        [Fact]
        public void GetAllClassRecordsFromDbContextNotNull()
        {
            var dbContext = new SQLConnType(@"localhost\SQLEXPRESS14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new ClassRepo(dbContext);

            var result = sysUnderTest.GetAllAsync();

            Assert.NotNull(result);
        }

        [Fact]
        public async Task GetAllClassRecordsFromDbContextGreaterThanZeroRecords()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new ClassRepo(dbContext);

            var result = await sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task InsertClassRecord_Succeed()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new ClassRepo(dbContext);
            var classEnt = new ClassEntity(Guid.NewGuid().ToString());
            classEnt.ClassName = "English";
            classEnt.Description = "English Poetry";         

            await sysUnderTest.InsertEntityAsync(classEnt);

            var result = await sysUnderTest.GetAllAsync();

            Assert.True(result.Count > 0);
        }

        [Fact]
        public async Task DeleteClassRecordByID_Succeed()
        {
            var dbContext = new SQLConnType(@"localhost\SqlExpress14", "CSG", "sa", "@1Mops4moa");
            var sysUnderTest = new ClassRepo(dbContext);
            var classEnt = new ClassEntity("50f14850-1161-4b7f-8093-af335090268f");
          
            await sysUnderTest.DeleteByIdAsync(classEnt.Id);

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
