#Windows Service: Automated Email Sender

This project is a Windows Service built with C#, using technologies like Topshelf, Quartz.NET, NLog, and Dependency Injection.
It automates reading content from files and sending them as emails on a scheduled interval.

##Features
- it runs as a Windows Service (via Topshelf, which is a .NET library that makes it easy to create Windows services)
- schedules tasks using Quartz.NET (Quartz is a scheduling library, which in this case is used to schedule the email-sending task)
- send emails via SMTP (Simple Mail Transfer Protocol)
- reads from and cleans up data files
- safe email testing via Papercut SMTP (Papercut intercepts outgoing emails and saves them locally. This way, it's possible to test email functionalities.
- The emails can be accessed via Papercut's local UI.)
- uses NLog for structured logging and error tracking (NLog is used for logging the project and to help track the application's flow, erros and/or events.)

#ANYWAY. Now, about running the project locally, follow steps below:
##1. Prereq.:
Make sure you have the following installed on your machine:
- .NET SDK -> https://dotnet.microsoft.com/en-us/download
- Papercut SMTP -> https://github.com/ChangemakerStudios/Papercut-SMTP
- Visual Studio

##2. Clone the repository through cmd or gitbash idk
The command: 
        git clone https://github.com/armend24/Windows-Project.git
Then navigate to the project directory using the 'cd' command.

##3. Install Dependencies
Once you're inside the project folder, restore the NuGet packages (these are the external libraries the project uses, like NLog,
Quartz.NET etc.) by running: dotnet restore. 'dotnet restore' will check your .csproj files, it'll then download the required 
packages and it'll make sure you rproject has all it needs to compile and run.

##4. Before running the project also make sure that your appsettings.json file is properly configured.
If you too want to use Papercut, then ensure SMTP server is configured to connect to localhost and port 25.

##5. Running the project
To run the project locally, simply start it directly from the Visual Studio. Another alternative is running 
it from the command line using 'dotnet run'. 

##6. Testing email sending with Papercut
When you run the service, the emails that are "sent" via SMTP will be intercepted by Papercut and stored locally.
To see the emails:
1. Open the Papercut application
2. You should see the incoming emails in the Papercut UI, where they will be listed with their subject and sender information.
3. Click on any email to view its details (such as the body and attachments).
