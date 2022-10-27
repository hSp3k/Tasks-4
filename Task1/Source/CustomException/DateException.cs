using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Source.CustomException
{
    internal class DateException : Exception
    {
        public DateException(string? message) : base(message) { }
    }
}
