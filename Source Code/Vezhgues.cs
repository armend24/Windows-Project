using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Service
{
    [DisallowConcurrentExecution]
    public class Vezhgues : IJob
    {

        private readonly IProgramManager _manageri;
        public Vezhgues(IProgramManager manageri)
        {
            _manageri = manageri;
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await _manageri.RunAsync();
        }
    }
}
