
using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.DTO
{
    public class StoreDTO
    {
        public int Id { get; set; }
        public string? Code { get; set; }
        public DateTime CreationDateTime { get; set; }

        public StoreDTO()
        {
            
        }

        public StoreDTO(Store store)
        {
            this.Id = store.Id;
            this.Code = store.Code;
            this.CreationDateTime = store.CreationDateTime;
        }

        public static StoreDTO FromDBToDTO(Store store)
        {
            return new StoreDTO(store);
        }

        public static List<StoreDTO> FromDBToDTO(List<Store> storeList)
        {
            List<StoreDTO> result = new();

            foreach (var item in storeList)
            {
                result.Add(FromDBToDTO(item));
            }

            return result;
        }

        public static Store FromDTOToDB(StoreDTO storeDTO)
        {
            return new Store
            {
                Id = storeDTO.Id,
                Code = storeDTO.Code,
                CreationDateTime = storeDTO.CreationDateTime
            };
        }
    }
}
