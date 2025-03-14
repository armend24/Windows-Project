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

        public ProgramManager(ILogger<ProgramManager> logger, IEmailService emailService, IFileHandler fileHandler)
        {
            _logger = logger;
            _emailService = emailService;
            _fileHandler = fileHandler;
        }
        public async Task RunAsync()
        {
            try
            {
                foreach (var item in _fileHandler.ReadContent())
                {
                    await _emailService.SendEmailAsync(new EmailData { 
                        Body = item, 
                        Subject = $"Report {DateTime.Now:yyyy-MM-dd HH:mm:ss}", 
                        ToEmail = "hello@gmail.com", 
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
