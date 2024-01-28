using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class Result : IResult
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public Result(bool isSuccess,string message) : this(isSuccess)
        {
            Message = message;
        }
        public Result(bool isSuccess)
        {
            IsSuccess=isSuccess;
        }
    }
}
