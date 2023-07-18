﻿using WebApplicatioMusicStore.Database;

namespace WebApplicatioMusicStore.DTO
{
    public class RegisterDTO
    {
        public int Id { get; set; }
        public int StoreId { get; set; }
        public DateTime CreationDateTime { get; set; }

        public RegisterDTO()
        {
            
        }

        public RegisterDTO(Register register)
        {
            this.Id = register.Id;
            this.StoreId = register.StoreId;  
            this.CreationDateTime = register.CreationDateTime;
        }

        public static RegisterDTO FromDBToDTO(Register register)
        {
            return new RegisterDTO(register);   
        }

        public static List<RegisterDTO> FromDBToDTO(List<Register> registerList)
        {
            List<RegisterDTO> result = new();

            foreach (var item in registerList)
            {
                result.Add(FromDBToDTO(item));
            }

            return result;
        }

        public static Register FromDTOToDB(RegisterDTO registerDTO)
        {
            return new Register
            {
                Id = registerDTO.Id,
                StoreId = registerDTO.StoreId,
                CreationDateTime = registerDTO.CreationDateTime
            };
        }
    }
}
