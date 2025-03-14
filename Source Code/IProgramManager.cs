using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Service
{
    public interface IProgramManager
    {
        Task RunAsync();
    }
}
