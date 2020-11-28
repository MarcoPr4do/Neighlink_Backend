using NeighLink.DateLayer.Models;
using NeighLink.DateLayer.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NeighLink.DateLayer.Service.Impls
{
    public class ResidentServiceImpl : IResidentService
    {
        private ResidentRepository _residentRepository;
        private UserRepository _userRepository;
        public ResidentServiceImpl(neighlinkdbContext dbContext)
        {
            _residentRepository = new ResidentRepository( dbContext );
            _userRepository = new UserRepository( dbContext );
        }

        public async Task<Resident> Auth(string email, string password)
        {
            var user = await _userRepository.Auth( email, password );
            if (user == null) return null;
            var resident = await _residentRepository.GetByUserId( user.UserId );
            if (resident == null) return null;
            resident.User = user;
            return resident;
        }

        public async Task<Resident> AuthToken(string token)
        {
            return await _residentRepository.AuthToken( token );
        }

        public async Task Delete(int id)
        {
            await _residentRepository.Delete( id );
        }

        public async Task<Resident> GetById(int id)
        {
            return await _residentRepository.GetById( id );
        }

        public async Task<Resident> Insert(Resident entity)
        {
            return await _residentRepository.Insert( entity );
        }

        public async Task<IEnumerable<Resident>> List()
        {
            return await _residentRepository.List();
        }

        public async Task<Resident> Update(Resident entity)
        {
            return await _residentRepository.Update( entity );
        }
    }
}
