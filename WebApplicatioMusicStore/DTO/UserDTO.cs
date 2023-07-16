
using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.DTO
{
    public class UserDTO
    {

        public int Id { get; set; }
        public string? Alias { get; set; }
        public string? Password { get; set; }
        public int StoreId { get; set; }
        public string? Rol { get; set; }
        public DateTime CreationDateTime { get; set; }

        public UserDTO()
        {
            
        }

        public UserDTO(User user)
        {
            this.Id = user.Id;
            this.Alias = user.Alias;
            this.Password = user.Password;
            this.StoreId = user.StoreId;
            this.Rol = user.Rol;
            this.CreationDateTime = user.CreationDateTime;
        }

        public static UserDTO FromDBToDTO(User user)
        {
            return new UserDTO(user);
        }

        public static List<UserDTO> FromDBToDTO(List<User> userList)
        {
            List<UserDTO> result = new();

            foreach (var item in userList)
            {
                result.Add(FromDBToDTO(item));
            }

            return result;
        }

        public static User FromDTOToDB(UserDTO userDTO)
        {
            return new User
            {
                Id = userDTO.Id,
                Alias = userDTO.Alias,
                Password = userDTO.Password,
                StoreId = userDTO.StoreId,
                Rol = userDTO.Rol,
                CreationDateTime = userDTO.CreationDateTime
        };
        }
    }
}
