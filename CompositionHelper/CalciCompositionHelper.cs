using CalculateContract;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompositionHelper
{
    public class CalciCompositionHelper
    {
        [ImportMany]
        public System.Lazy<ICalculator,
            IDictionary<string,object>>[] CalciPlugins { get; set; }
                
        public void AssembleCalculatorComponents()
        {
            try
            {
                var catalog = new
                    AssemblyCatalog(Assembly.GetExecutingAssembly());
                var container = new CompositionContainer(catalog);
                container.ComposeParts(this);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int GetResult(int num1,int num2,string operationType)
        {
            int result = 0;
            foreach(var CalciPlugin in CalciPlugins)
            {
                if ((string)CalciPlugin.Metadata["CalciMetaData"] == operationType)
                {
                    result = CalciPlugin.Value.GetNumber(num1, num2);
                    break;
                }
            }
            return result;
        }
    }
}
