using ApiTestUnitTesting.MockDependicies;
using AutoMapper;
using ClassLibraryDomain.UsesCases;
using WebApplicationMusicStore.DrivenAdapters.FileManager;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters;
using WebApplicationMusicStore.DrivingAdapters.RestAdapters.Dtos;
using Xunit.Priority;

namespace ApiTestUnitTesting
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class AudioListUnitTest
    {
        //private readonly AudioListController _audioListController;
        //private IMapper _mapper;
        //private static List<AudioFileDto> _audioFileDtoList = new List<AudioFileDto>(); 

        //public AudioListUnitTest()
        //{
        //    _mapper = MapperTotalSingleton.GetMapper();
        //    _audioListController = new AudioListController(_mapper,
        //        new AudioListUseCase(new AudioListPersistenceAdapter(new WebHostEnvironmentDummy(), new AudioFileDetailsPersistenceAdapter())));
        //}

        //[Fact, Priority(-6)]
        //public async Task DownloadAudioListStore()
        //{
        //    var result = await _audioListController.DownloadAudioListStore("1020");
        //    _audioFileDtoList = result.Data;
        //    Assert.True(result.Status);
        //}

        //[Fact, Priority(-5)]
        //public async Task SynchronizeAudioListStore()
        //{
        //    var result = await _audioListController.SynchronizeAudioListStore(new SynchronizeAudioListStoreDto {storeCode = "1020", audioList = _audioFileDtoList });

        //    Assert.True(result.Status);

        //    var result2 = await _audioListController.DownloadAudioListStore("1020");

        //    Assert.Equal(result2.Data, _audioFileDtoList);  
        //}

        //[Fact, Priority(-4)]
        //public async Task SynchronizeAudioListAllStore()
        //{
        //    var result = await _audioListController.SynchronizeAudioListAllStore();
        //    Assert.True(result.Status);

        //    var result2 = await _audioListController.DownloadAudioListStore("1020");

        //    Assert.Equal(result2.Data, _audioFileDtoList);
        //}
    }
}