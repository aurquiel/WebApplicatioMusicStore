using ApiTestUnitTesting.MockDependicies;
using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.UsesCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class AudioUnitTest
    {
        private readonly AudioController _audioController;
        private readonly AudioListController _audioListController;
        private IMapper _mapper;
        private static List<AudioFileDto> _audioFileServerDtoList = new List<AudioFileDto>();
        private static List<AudioFileDto> _audioListFileDtoList = new List<AudioFileDto>();

        public AudioUnitTest()
        {
            _mapper = MapperTotalSingleton.GetMapper();
            _audioController = new AudioController(_mapper,
                new AudioUseCase(new AudioPersistenceAdapter(new WebHostEnvironmentDummy(), new AudioFileDetailsPersistenceAdapter())));
            _audioListController = new AudioListController(_mapper,
                new AudioListUseCase(new AudioListPersistenceAdapter(new WebHostEnvironmentDummy(), new AudioFileDetailsPersistenceAdapter())));
        }

        [Fact, Priority(-10)]
        public async Task DownloadAudiosListServer()
        {
            var result = await _audioController.DownloadAudiosListServer();
            _audioFileServerDtoList = result.Data;
            Assert.True(result.Status);
        }

        [Fact, Priority(-9)]
        public async Task UploadAudio()
        {
            //Setup mock file using a memory stream
            byte[] mp3Bytes = File.ReadAllBytesAsync(new WebHostEnvironmentDummy().ContentRootPath + "App_Data\\audioTest\\test.mp3").Result;

            using (var stream = new MemoryStream(mp3Bytes))
            {
                var formFile = new FormFile(baseStream: stream, baseStreamOffset: 0, length: stream.Length, name: "test.mp3", fileName: "test.mp3");

                var result = await _audioController.UploadAudio(formFile);

                Assert.True(result.Status);
            }

            var result2 = await _audioController.DownloadAudiosListServer();

            Assert.True(result2.Data.Any(x => x.Name == "test.mp3"));
        }

        [Fact, Priority(-8)]
        public async Task DownloadAudioListStore()
        {
            var result = await _audioListController.DownloadAudioListStore("1020");
            _audioListFileDtoList = result.Data;
            Assert.True(result.Status);
        }

        [Fact, Priority(-7)]
        public async Task SynchronizeAudioListStore()
        {
            _audioListFileDtoList.Add(new AudioFileDto { Name = "test.mp3" });
            var result = await _audioListController.SynchronizeAudioListStore(new SynchronizeAudioListStoreDto { storeCode = "1020", audioList = _audioListFileDtoList });

            Assert.True(result.Status);

            var result2 = await _audioListController.DownloadAudioListStore("1020");
            _audioListFileDtoList = result2.Data;

            Assert.True(result2.Data.Any(x => x.Name == "test.mp3"));
        }


        [Fact, Priority(-6)]
        public async Task DownloadAudio()
        {
            var result = (FileContentResult)await _audioController.DownloadAudio("test.mp3");

            Assert.Equal(result.FileDownloadName, "test.mp3");

        }

        [Fact, Priority(-5)]
        public async Task DeleteAudio()
        {
            var result = await _audioController.DeleteAudio("test.mp3");
            Assert.True(result.Status);

            var result2 = await _audioController.DownloadAudiosListServer();
            Assert.False(result2.Data.Any(x => x.Name == "test.mp3"));

            var result3 = await _audioListController.DownloadAudioListStore("1020");
            _audioListFileDtoList = result3.Data;
            Assert.False(result3.Data.Any(x => x.Name == "test.mp3"));

        }

        [Fact, Priority(-4)]
        public async Task SynchronizeAudioListAllStore()
        {
            var result = await _audioListController.SynchronizeAudioListAllStore();
            Assert.True(result.Status);

            var result2 = await _audioListController.DownloadAudioListStore("1020");

            Assert.Equal(result2.Data, _audioListFileDtoList);
        }
    }
}