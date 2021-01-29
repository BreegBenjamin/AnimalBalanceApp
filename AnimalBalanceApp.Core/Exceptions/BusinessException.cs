using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalBalanceApp.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {

        }
        public BusinessException(string message) : base(message)
        {

        }
    }
    public class  ParameterException : Exception
    {
        public ParameterException()
        {

        }
        public ParameterException(string message) : base(message)
        {
                
        }
    }
}
