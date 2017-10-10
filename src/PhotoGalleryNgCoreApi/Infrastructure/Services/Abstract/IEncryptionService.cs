using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryNgCoreApi.Infrastructure.Services
{
    public interface IEncryptionService
    {
        string CreateSalt();
        string EncryptPassword(string password, string salt);
    }
}
