using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<TData> : DataResult<TData>
    {
        public SuccessDataResult(TData data,string message) : base(data,true,message)
        {
            
        }
        public SuccessDataResult(TData data) : base(data,true)
        {
            
        }
        public SuccessDataResult(string message) : base(default,true,message)
        {
            
        }
        public SuccessDataResult() : base(default,true)
        {
            
        }
    }
}
