using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class AdministratorServiceImpl : IAdministratorService
    {
        private AdministratorRepository _administratorRepository;
        private UserRepository _userRepository;
        public AdministratorServiceImpl(neighlinkdbContext dbContext)
        {
            _administratorRepository = new AdministratorRepository( dbContext );
            _userRepository = new UserRepository( dbContext );
        }

        public async Task<Administrator> Auth(string email, string password)
        {
            var user = await _userRepository.Auth( email, password );
            if (user == null) return null;
            var admin = await _administratorRepository.GetById( user.UserId );
            if (admin == null) return null;
            admin.User = user;
            return admin;
        }

        public Task<Administrator> AuthToken(string token)
        {
            return _administratorRepository.AuthToken( token );
        }

        public async Task Delete(int id)
        {
            await _administratorRepository.Delete( id );
        }

        public async Task<Administrator> GetById(int id)
        {
            return await _administratorRepository.GetById( id );
        }

        public async Task<Administrator> Insert(Administrator entity)
        {
            return await _administratorRepository.Insert( entity );
        }

        public async Task<IEnumerable<Administrator>> List()
        {
            return await _administratorRepository.List();
        }

        public async Task<Administrator> Update(Administrator entity)
        {
            return await _administratorRepository.Update( entity );
        }
    }
}
