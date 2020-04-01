using CalculateContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositionHelper
{
    [Export(typeof(ICalculator))]
    [ExportMetadata("CalciMetaData", "Multiply")]
    public class Multiply : ICalculator
    {
        public int GetNumber(int num1, int num2)
        {
            return num1 * num2;
        }
    }
}
