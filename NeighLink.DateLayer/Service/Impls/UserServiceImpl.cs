using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class UserServiceImpl : IUserService
    {
        private UserRepository _userRepository;
        public UserServiceImpl(neighlinkdbContext dbContext)
        {
            _userRepository = new UserRepository( dbContext );
        }
        public async Task Delete(int id)
        {
            await _userRepository.Delete( id );
        }

        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById( id );
        }

        public async Task<User> Insert(User entity)
        {
            return await _userRepository.Insert( entity );
        }

        public async Task<IEnumerable<User>> List()
        {
            return await _userRepository.List();
        }

        public async Task<User> Update(User entity)
        {
            return await _userRepository.Update( entity );
        }
    }
}
