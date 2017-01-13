using PhotoGalleryNgCoreApi.Entities;
using PhotoGalleryNgCoreApi.Infrastructure.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryNgCoreApi.Infrastructure.Repositories
{
    public class LoggingRepository : EntityBaseRepository<Error>, ILoggingRepository
    {
        public LoggingRepository(PhotoGalleryContext context) : base(context)
        {

        }
        public override void Commit()
        {
            try
            {
                base.Commit();
            }
            catch { }
        }
    }
}
