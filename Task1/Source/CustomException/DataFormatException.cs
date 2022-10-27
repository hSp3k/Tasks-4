using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Source.CustomException
{
    internal class DataFormatException : Exception
    {
        public DataFormatException(string? message) : base(message) { }
    }
}
