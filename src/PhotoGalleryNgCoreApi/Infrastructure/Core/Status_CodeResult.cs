using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoGalleryNgCoreApi.Infrastructure.Core
{
    public class Status_CodeResult
    {
        private int _status;
        private string _message;

        public int Status
        {
            get
            {
                return _status;
            }
            private set { }
        }

        public string Message
        {
            get
            {
                return _message;
            }
            private set { }
        }

        public Status_CodeResult(int status)
        {
            if (status == 401)
                _message = "Unauthorized access. Login required";

            _status = status;
        }

        public Status_CodeResult(int code, string message)
        {
            _status = code;
            _message = message;
        }
    }
}
