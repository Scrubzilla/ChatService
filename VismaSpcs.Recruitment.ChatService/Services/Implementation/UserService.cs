using VismaSpcs.Recruitment.ChatService.Dtos;
using VismaSpcs.Recruitment.ChatService.Entities;
using VismaSpcs.Recruitment.ChatService.Enums;
using VismaSpcs.Recruitment.ChatService.Extensions;
using VismaSpcs.Recruitment.ChatService.Repositories;
using VismaSpcs.Recruitment.ChatService.Repositories.Interface;
using VismaSpcs.Recruitment.ChatService.Services.Interface;

namespace VismaSpcs.Recruitment.ChatService.Services
{
    public class UserService :  IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserProfile(Guid userId)
        {
            var user = await _userRepository.GetAsync(u => u.Id == userId);
            return user.MapToDto();
        }

        public async Task UpdateStatusMessage(Guid userId, string statusMessage)
        {
            await _userRepository.UpdateStatusMessage(userId, statusMessage);
        }

        public async Task UpdateStatus(Guid userId, UserStatusEnum status)
        {
            await _userRepository.UpdateStatus(userId, status);
        }

        public async Task<List<UserEntity>> GetUsersById(List<Guid> userIds)
        {
            return await _userRepository.GetManyAsync(userIds);
        }
    }
}