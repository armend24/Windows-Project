using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_Service
{
    interface IEmailService
    {
        Task SendEmailAsync(EmailData emailData);

    }
}
