using PhotoGalleryNgCoreApi.Entities;
using PhotoGalleryNgCoreApi.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryNgCoreApi.Infrastructure.Repositories
{
    public class PhotoRepository : EntityBaseRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(PhotoGalleryContext context) : base(context)
        {

        }
    }
}
