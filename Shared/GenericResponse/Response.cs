using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Shared.GenericResponse
{
    public class Response<T>
    {
        private T _data;
        private bool _success = true;
        private int _total;
        private string _message;

        public Response()
        {
        }

        [DataMember()]
        public bool success
        {
            get { return _success; }
            set { _success = value; }
        }

        [DataMember()]
        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        [DataMember()]
        public T data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Response(ref T data)
        {
            _data = data;
        }
    }

    public class CustomApiError
    {
        public string? error { get; set; }
        public string? error_description { get; set; }
    }
}
