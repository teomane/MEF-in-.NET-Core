using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseOperation
{
    public interface IOperation
    {
        int Operate(int left, int right);
    }

    public class IOperationData
    {
        // IOperationData is metadata and it must be conrete class not an abstract or interface

        public Char Symbol { get; set; } // this property must be writable and public.
    }
}
