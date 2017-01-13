﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PhotoGalleryNgCoreApi.Infrastructure.Repositories.Abstract;
using PhotoGalleryNgCoreApi.Infrastructure.Core;
using PhotoGalleryNgCoreApi.ViewModels;
using PhotoGalleryNgCoreApi.Entities;
using AutoMapper;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace PhotoGalleryNgCoreApi.Controllers
{
    [Route("api/[controller]")]
    public class AlbumsController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        IAlbumRepository _albumRepository;
        ILoggingRepository _loggingRepository;

        public AlbumsController(IAuthorizationService authorizationService, IAlbumRepository albumRepository, ILoggingRepository loggingRepository)
        {
            _authorizationService = authorizationService;
            _albumRepository = albumRepository;
            _loggingRepository = loggingRepository;
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{page:int=0}/{pageSize=12}")]
        public async Task<IActionResult> Get(int? page, int? pageSize)
        {
            PaginationSet<AlbumViewModel> pagedSet = new PaginationSet<AlbumViewModel>();

            try
            {
                if (await _authorizationService.AuthorizeAsync(User, "AdminOnly"))
                {
                    int currentPage = page.Value;
                    int currentPageSize = pageSize.Value;

                    List<Album> _albums = null;
                    int _totalAlbums = new int();

                    _albums = _albumRepository
                                .AllIncluding(a => a.Photos)
                                .OrderBy(a => a.Id)
                                .Skip(currentPage * currentPageSize)
                                .Take(currentPageSize)
                                .ToList();

                    _totalAlbums = _albumRepository.GetAll().Count();

                    IEnumerable<AlbumViewModel> _albumsVM = Mapper.Map<IEnumerable<Album>,
                        IEnumerable<AlbumViewModel>>(_albums);

                    pagedSet = new PaginationSet<AlbumViewModel>()
                    {
                        Page = currentPage,
                        TotalCount = _totalAlbums,
                        TotalPages = (int)Math.Ceiling((decimal)_totalAlbums / currentPageSize),
                        Items = _albumsVM
                    };
                }
                else
                {
                    Status_CodeResult _codeResult = new Status_CodeResult(401);
                    return new ObjectResult(_codeResult);
                }
            }
            catch(Exception ex)
            {
                _loggingRepository.Add(new Entities.Error() { Message = ex.Message, StackTrace = ex.StackTrace, DateCreated = DateTime.Now });
                _loggingRepository.Commit();
            }

            return new ObjectResult(pagedSet);
        }

        [Authorize(Policy = "AdminOnly")]
        [HttpGet("{id:int}/photos/{page:int=0}/{pageSize=12}")]
        public PaginationSet<PhotoViewModel> Get(int id, int? page, int? pageSize)
        {
            PaginationSet<PhotoViewModel> pagedSet = null;

            try
            {
                int currentPage = page.Value;
                int currentPageSize = pageSize.Value;

                List<Photo> _photos = null;
                int _totalPhotos = new int();


            }
        }
    }
}