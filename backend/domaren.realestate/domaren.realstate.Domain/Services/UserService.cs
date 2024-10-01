using AutoMapper;
using domaren.realstate.Domain.Contracts;
using domaren.realstate.Domain.Models;
using domaren.realstate.Domain.Repositories.Contarcts;
using domaren.realstate.Domain.Repositories.Models;

namespace domaren.realstate.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHashProvider _passwordHashProvider;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper, IPasswordHashProvider passwordHashProvider)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHashProvider = passwordHashProvider;
        }

        public User? GetUser(int id)
        {
            var userRecord = _userRepository.GetUser(id);
            var user = _mapper.Map <User>(userRecord);

            return user;
        }

        public int SaveUser(User user)
        {
            var userRecord = _mapper.Map<UserRecord>(user);
            userRecord.PasswordHash = _passwordHashProvider.EncryptPassword(user.Password);

            return _userRepository.SaveUser(userRecord);
        }
    }
}
