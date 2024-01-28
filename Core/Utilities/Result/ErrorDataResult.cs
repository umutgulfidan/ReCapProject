using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class ErrorDataResult<TData> : DataResult<TData>
    {
        public ErrorDataResult(TData data , string message) : base(data,false,message)
        {
            
        }
        public ErrorDataResult(TData data) : base(data,false)
        {
            
        }
        public ErrorDataResult(string message) : base(default,false,message)
        {
            
        }
        public ErrorDataResult() : base(default,false)
        {
            
        }
    }
}
