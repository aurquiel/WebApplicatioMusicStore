using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using Microsoft.EntityFrameworkCore;
using WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters.Entities;

namespace WebApplicationMusicStore.DrivenAdapters.DatabaseAdapters
{
    public class AudioListPersistenceAdapter : IAudioListPersistencePort
    {
        private readonly AudioStoreDbContext _dbContext;
        private readonly IMapper _mapper;

        public AudioListPersistenceAdapter(AudioStoreDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task DeleteAudioFromAudioListStoreAsync(string audioName)
        {
            var entities = await _dbContext.AudioListEntity.Where(x => x.Name == audioName).ToListAsync();
            _dbContext.AudioListEntity.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAudioListStoreAsync(int storeId)
        {
            var entities = await _dbContext.AudioListEntity.Where(x => x.StoreId == storeId).ToListAsync();
            _dbContext.AudioListEntity.RemoveRange(entities);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<AudioFile>> GetAudioListStoreAsync(int storeId)
        {
            return _mapper.Map<List<AudioListEntity>, List<AudioFile>>(await _dbContext.AudioListEntity.Where(x => x.StoreId == storeId).OrderBy(x => x.Order).ToListAsync());
        }

        public async Task SynchronizeAudioListAllStoreAsync(List<AudioFile> audioListInFolderServer)
        {
            foreach(var audio in _dbContext.AudioListEntity)
            {
                if (!audioListInFolderServer.Any(x => x.Name ==  audio.Name))
                {
                    _dbContext.AudioListEntity.Remove(audio);
                    await _dbContext.SaveChangesAsync();
                }
            }
        }

        public async Task SynchronizeAudioListStoreAsync(List<AudioFile> audioList)
        {
            var a = _mapper.Map<List<AudioFile>, List<AudioListEntity>>(audioList);
            await _dbContext.AudioListEntity.AddRangeAsync(a);
            await _dbContext.SaveChangesAsync();
        }
    }
}
