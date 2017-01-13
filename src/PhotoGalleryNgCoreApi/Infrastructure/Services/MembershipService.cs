using PhotoGalleryNgCoreApi.Infrastructure.Core;
using PhotoGalleryNgCoreApi.Infrastructure.Repositories.Abstract;
using PhotoGalleryNgCoreApi.Infrastructure.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhotoGalleryNgCoreApi.Entities;

namespace PhotoGalleryNgCoreApi.Infrastructure.Services
{
    public class MembershipService : IMembershipService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IEncryptionService _encryptionService;

        public MembershipService(IUserRepository userRepository, IRoleRepository roleRepository, IUserRoleRepository userRoleRepository, IEncryptionService encryptionService)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _encryptionService = encryptionService;
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            var memberCtx = new MembershipContext();

            var user = _userRepository.GetSingleByUsername(username);
            if (user != null && isUserValid(user, password))
            {

            }
        }

        private bool isUserValid(User user, string password)
        {
            if (isPasswordValid(user, password))
            {
                return !user.IsLocked;
            }
            return false;
        }

        private bool isPasswordValid(User user, string password)
        {
            return string.Equals(_encryptionService.EncryptPassword(password, user.Salt), user.HashedPassword);
        }
    }
}
