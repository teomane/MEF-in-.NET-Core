using System;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading.Tasks;

namespace ExtendedOperation
{
    [Export(typeof(BaseOperation.IOperation))] //takes contract
    [ExportMetadata("Symbol", '+')] //takes metadata, params: name_of_property, value
    public class Add : BaseOperation.IOperation
    {
        public int Operate(int left, int right)
        {
            return left + right;
        }
    }
}
