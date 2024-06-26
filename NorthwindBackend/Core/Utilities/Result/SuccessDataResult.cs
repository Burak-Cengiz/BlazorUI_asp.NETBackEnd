﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Result
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, success:true)
        {
        }

        public SuccessDataResult(T data, string message) : base(data, success:true, message)
        {
        }

        public SuccessDataResult(string message) :base(default,success:true, message)
        {

        }
        public SuccessDataResult() : base(default, success: true)
        {

        }
    }
}
