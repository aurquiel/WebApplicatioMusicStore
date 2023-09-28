using ApiTestUnitTesting.MockDependicies;
using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.UsesCases;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;
using WebApplicationMusicStore.DrivenAdapters.FileManager;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using WebApplicationMusicStore.DrivingAdapters.Utils;
using Xunit.Priority;

namespace ApiTestUnitTesting
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class RegisterUnitTest
    {
        private readonly RegisterController _registerController;
        private IMapper _mapper;

        public RegisterUnitTest()
        {
            _mapper = MapperTotalSingleton.GetMapper();
            _registerController = new RegisterController( _mapper,
                new RegisterUseCase(new RegisterPersistenceAdapter(new AudioStoreDbContext(), _mapper)));
        }

        [Fact, Priority(-6)]
        public async Task RegisterInsert()
        {
            var result = await _registerController.RegisterInsert(new List<RegisterDto> { 
                new RegisterDto { StoreId = 2, Activity = 1, Message = "Reproduciendo", CreationDateTime = new DateTime(2023, 12, 24) },
                new RegisterDto { StoreId = 2, Activity = 1, Message = "Reproduciendo", CreationDateTime = new DateTime(2023, 09, 29) }
            });

            Assert.True(result.Status);
            var listDb = _mapper.Map<List<Register>, List<RegisterDto>>(await GetRegisterFromDb());
            Assert.Equal(new DateTime(2023, 12, 24), listDb[0].CreationDateTime);
            Assert.Equal(new DateTime(2023, 09, 29), listDb[1].CreationDateTime);
        }

        private async Task<List<Register>> GetRegisterFromDb()
        {
            using(AudioStoreDbContext _dbContext = new AudioStoreDbContext())
            {
                return _mapper.Map<List<RegisterEntity>, List<Register>>(await _dbContext.RegistersEntity.ToListAsync());
            }
        }

        [Fact, Priority(-5)]
        public async Task GetRegisters()
        {
            var result = await _registerController.GetRegisters(2, "2023-09-01", "2023-12-31");

            Assert.True(result.Status);
            var listDb = _mapper.Map<List<Register>, List<RegisterDto>>(await GetRegisterFromDb());
            Assert.Equal(result.Data, listDb);
        }

        [Fact, Priority(-4)]
        public async Task GetRegistersByMonth()
        {
            var result = await _registerController.GetRegistersByMonth(2, "2023-09-01");
            Assert.True(result.Status);
            var listDb = _mapper.Map<List<Register>, List<RegisterDto>>(await GetRegisterByMonthFromDb());
            Assert.Equal(result.Data, listDb);
        }

        private async Task<List<Register>> GetRegisterByMonthFromDb()
        {
            using (AudioStoreDbContext _dbContext = new AudioStoreDbContext())
            {
                return _mapper.Map<List<RegisterEntity>, List<Register>>(await _dbContext.RegistersEntity.Where(x => x.CreationDateTime.Month == 9).ToListAsync());
            }
        }

        [Fact, Priority(-3)]
        public async Task RegisterDelete()
        {
            var result = await _registerController.RegisterDelete(2);
            Assert.Equal(true, result.Status);
    }
    }
}