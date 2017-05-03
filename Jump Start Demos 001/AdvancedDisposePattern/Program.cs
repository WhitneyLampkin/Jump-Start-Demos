using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedDisposePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var demo = new AdvancedDemo();

            demo.Dispose();
        }
    }

    public class AdvancedDemo : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // release managed resources
            }
            //release unmanagedresources
        }

        ~AdvancedDemo()
        {
            Dispose(false);
        }
    }
}
