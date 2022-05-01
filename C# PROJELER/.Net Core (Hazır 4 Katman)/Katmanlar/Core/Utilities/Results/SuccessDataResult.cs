using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        //Direk mesajı geçmek istiyorum çünkü işlem başarılıyken gircek 
        //buraya success=true yani
        public SuccessDataResult(T data, string message) : base(data, success:true, message)
        {

        }
        public SuccessDataResult(T data) : base(data, success: true)
        {

        }
        public SuccessDataResult(string message) : base(default, success: true, message)
        {

        }
        public SuccessDataResult() : base(default, success: true)
        {

        }
    }
}
