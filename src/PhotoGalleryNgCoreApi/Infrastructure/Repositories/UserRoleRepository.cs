using PhotoGalleryNgCoreApi.Entities;
using PhotoGalleryNgCoreApi.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryNgCoreApi.Infrastructure.Repositories
{
    public class UserRoleRepository : EntityBaseRepository<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(PhotoGalleryContext context) : base(context)
        {

        }
    }
}
