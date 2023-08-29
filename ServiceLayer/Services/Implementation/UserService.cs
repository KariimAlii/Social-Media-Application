using API.Services.Contracts;
using AutoMapper;
using DataAccessLayer.Data;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Entities;
using ModelLayer.Models;

namespace ServiceLayer.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> GetAllUsers()
        {
            var usersFromDB = await _unitOfWork._UserRepo.GetAllAsync();

            return _mapper.Map<List<UserModel>>(usersFromDB);
        }
        public async Task<UserModel> GetUserById(int id)
        {
            var userFromDB = await _unitOfWork._UserRepo.GetByIdAsync(id);
            return _mapper.Map<UserModel>(userFromDB);
        }
        public async Task<int> AddUser(UserModel newUserModel)
        {
            var newUser = _mapper.Map<User>(newUserModel);  
            await _unitOfWork._UserRepo.AddAsync(newUser);
            await _unitOfWork.SaveChangesAsync(); //====> returns the object added with its {Id} set by database provider
            return newUser.Id;
        }
        public async Task<bool> isUserExists(string UserName, string Email)
        {
            var user = await _unitOfWork._UserRepo.GetFirstOrDefaultWith(u => u.UserName == UserName.ToLower() || u.Email == Email.ToLower());
            if (user == null) return false;
            else return true;
        }
        public async Task<UserModel> getUserByUserName(string UserName)
        {
            var userFromDB = await _unitOfWork._UserRepo.GetFirstOrDefaultWith(u => u.UserName == UserName);

            return _mapper.Map<UserModel>(userFromDB);
        }
    }
}
