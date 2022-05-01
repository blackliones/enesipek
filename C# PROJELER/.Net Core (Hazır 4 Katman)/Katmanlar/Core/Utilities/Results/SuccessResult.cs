using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult:Result
    {
        //Direk mesajı geçmek istiyorum çünkü işlem başarılıyken gircek 
        //buraya success=true yani
        public SuccessResult(string message) : base(success: true, message)
        {

        }
        public SuccessResult() : base(success: true)
        {

        }
    }
}
