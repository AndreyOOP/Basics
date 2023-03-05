using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp_Samples.Sample3
{
    public class DisposePattern : IDisposable
    {
        private bool disposed = false;

        ~DisposePattern()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            // Dispose of managed & unmanaged resources.
            Dispose(true);
            // Suppress finalization. No need to call implicitly finalization becuase of explicit Dispose
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            // should be false when called from a finalizer
            // true when called from the Dispose
            // it is true when deterministically called and false when non-deterministically called
            if (disposing)
            {
                // TODO: dispose managed state (managed objects).
                // Managed objects that implement IDisposable (cascade dispose)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
            // TODO: set large fields to null.
            // The implementer is responsible for ensuring that the false path doesn't interact with
            // managed objects that may have been disposed

            disposed = true;

            // for base class - if(!disposed) base.Dispose(disposing);
        }
    }
}
