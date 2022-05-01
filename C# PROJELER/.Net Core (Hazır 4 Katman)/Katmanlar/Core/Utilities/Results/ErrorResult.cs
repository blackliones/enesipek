using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        //Success=false oldugunda çalıştırılacağı için tekrar sorguya gerek yok 
        public ErrorResult(string message) : base(success: false, message)
        {
        }

        public ErrorResult() : base(success: false)
        {
        }
    }
}
