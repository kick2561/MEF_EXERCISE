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
    [ExportMetadata("CalciMetaData", "Subtract")]
    public class Subtract : ICalculator
    {
        public int GetNumber(int num1, int num2)
        {
            return num1 - num2;
        }
    }
}
