
using BLL.DLL;
using BLL.Models;
using Microsoft.VisualBasic;

namespace BLL.Services
{
    public abstract class Service
    {
        protected readonly StudentsDBContext StudentsDBContext;

        public bool IsSuccessful { get; private set; }

        public string? Message { get; private set; }

        public Service(StudentsDBContext studentsDBContext) 
        {
            StudentsDBContext = studentsDBContext;
        }

        public Service Success(string? message)
        {
            IsSuccessful = true;
            Message = message == null ? Constants.Constants.SUCCESS_DEFAULT_MESSAGE : message;
            return this;
        }

        public Service Error(string? message)
        {
            IsSuccessful = false;
            Message = message == null ? Constants.Constants.ERROR_DEFAULT_MESSAGE : message;
            return this;
        }
    }
}
