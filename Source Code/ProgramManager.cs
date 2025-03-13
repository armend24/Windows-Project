using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Service
{
    class ProgramManager : IProgramManager
    {

        private readonly ILogger<ProgramManager> _logger;
        private readonly IEmailService _emailService;
        private readonly IFileHandler _fileHandler;

        public async Task BejPunen()
        {
            try
            {
                foreach (var item in _fileHandler.ReadContent())
                {
                    await _emailService.SendEmailAsync(new EmailData { 
                        Body = item, 
                        Subject = "test", 
                        ToEmail = "hellohello2406@gmail.com", 
                        ToName = "Armend" 
                    });
                }

                _fileHandler.DeleteFiles();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Something went wrong...");
                throw;
            }
        }
    }
}
