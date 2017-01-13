using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PhotoGalleryNgCoreApi.Infrastructure.Repositories.Abstract;
using PhotoGalleryNgCoreApi.Infrastructure.Repositories;
using PhotoGalleryNgCoreApi.Infrastructure.Core;
using PhotoGalleryNgCoreApi.ViewModels;
using PhotoGalleryNgCoreApi.Entities;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PhotoGalleryNgCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class PhotosController : Controller
    {
        IPhotoRepository _photoRepository;
        LoggingRepository _loggingRepository;
        

        [HttpGet("{page:int=0}/{pageSize=12}")]
        public PaginationSet<PhotoViewModel> Get(int? page, int? pageSize)
        {
            PaginationSet<PhotoViewModel> pagedSet = null;

            try
            {
                int currentPage = page.Value;
                int currentPageSize = pageSize.Value;

                List<Photo> _photos = null;
                int _totalPhotos = new int();

                _photos = _photoRepository.AllIncluding(p => p.Album)
                                          .OrderBy(p => p.Id)
                                          .Skip(currentPage * currentPageSize)
                                          .Take(currentPageSize)
                                          .ToList();

                _totalPhotos = _photoRepository.GetAll().Count();

                IEnumerable<PhotoViewModel> _photosVM = Mapper.Map<IEnumerable<Photo>, IEnumerable<PhotoViewModel>>(_photos);

                pagedSet = new PaginationSet<PhotoViewModel>()
                {
                    Page = currentPage,
                    TotalCount = _totalPhotos,
                    TotalPages = (int)Math.Ceiling((decimal)_totalPhotos / currentPage),
                    Items = _photosVM
                };
            }
            catch (Exception ex)
            {
                _loggingRepository.Add(new Entities.Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                _loggingRepository.Commit();
            }

            return pagedSet;
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            IActionResult _result = new ObjectResult(false);
            GenericResult _removeResult = null;

            try
            {
                Photo _photoToRemove = this._photoRepository.GetSingle(id);
                this._photoRepository.Delete(_photoToRemove);
                this._photoRepository.Commit();

                _removeResult = new GenericResult()
                {
                    Succeeded = true,
                    Message = "Photo removed."
                };
            }
            catch (Exception ex)
            {
                _removeResult = new GenericResult()
                {
                    Succeeded = false,
                    Message = ex.Message
                };

                _loggingRepository.Add(new Entities.Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                _loggingRepository.Commit();
            }

            _result = new ObjectResult(_removeResult);
            return _result;
        }
    }
}
