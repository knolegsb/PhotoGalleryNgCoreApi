﻿using PhotoGalleryNgCoreApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace PhotoGalleryNgCoreApi.Infrastructure.Core
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public User Uset { get; set; }
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}