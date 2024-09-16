using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.src.User.domain.dto;
using backend.src.User.domain.entity;

namespace backend.src.User.domain.repository
{
    public interface UserRepository
    {
        Task<List<UserEntity>> GetAllAsync();
        Task<UserEntity?> GetByIdAsync(int id);
        Task<UserEntity> CreateAsync(UserEntity user);
        Task<UserEntity?> DeleteByIdAsync(int id);
        Task<UserEntity?> UpdateByIdAsync(int id, UpdateUserDto user);

    }
}