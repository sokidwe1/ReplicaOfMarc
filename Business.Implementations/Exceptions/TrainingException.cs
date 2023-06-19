using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations.Exceptions
{
    public class TrainingException :  Exception
    {
        public string Code { get; set; }

        public TrainingException(string code, string message):base(message) 
        {
            Code = code;
        }
    }
}
