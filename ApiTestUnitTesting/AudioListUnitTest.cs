using ApiTestUnitTesting.MockDependicies;
using AutoMapper;
using ClassLibraryDomain.UsesCases;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters;
using WebApplicationMusicStore.DrivenAdapters.FileManager;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using Xunit.Priority;

namespace ApiTestUnitTesting
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class AudioListUnitTest
    {
        private readonly AudioListController _audioListController;
        private IMapper _mapper;
        private static List<AudioFileDto> _audioFileDtoList = new List<AudioFileDto>();

        public AudioListUnitTest()
        {
            _mapper = MapperTotalSingleton.GetMapper();
            _audioListController = new AudioListController(_mapper,
                new AudioListUseCase(
                    new AudioListPersistenceAdapter(
                        new AudioStoreDbContext(), 
                        _mapper), 
                    new AudioPersistenceAdapter(
                        new WebHostEnvironmentDummy(), 
                        new AudioFileDetailsPersistenceAdapter())));
        }

        [Fact, Priority(-10)]
        public async Task DownloadAudioListStore()
        {
            var result = await _audioListController.DownloadAudioListStore(2);
            _audioFileDtoList = result.Data;
            Assert.True(result.Status);
        }

        [Fact, Priority(-9)]
        public async Task SynchronizeAudioListStore()
        {
            for(int i = 0; i < _audioFileDtoList.Count; i++)
            {
                _audioFileDtoList[i].Order = i;
                _audioFileDtoList[i].StoreId = 2;
            }

            var result = await _audioListController.SynchronizeAudioListStore(new SynchronizeAudioListStoreDto { storeId = 2, audioList = _audioFileDtoList });

            Assert.True(result.Status);

            var result2 = await _audioListController.DownloadAudioListStore(2);

            Assert.Equal(result2.Data, _audioFileDtoList);
        }

        [Fact, Priority(-2)]
        public async Task SynchronizeAudioListAllStore()
        {
            var result = await _audioListController.SynchronizeAudioListAllStore();
            Assert.True(result.Status);
        }
    }
}