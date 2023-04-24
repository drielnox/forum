using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.WebControls;

namespace drielnox.Forum.Presetation.WebForms
{
    public class Global : HttpApplication
    {
        private readonly ForumContext _context;
        private readonly ILogger _logger;

        public Global()
            : base()
        {
            _logger = Logging.CreateLogger<Global>();
            _context = new ForumContext();
        }

        void Application_Start(object sender, EventArgs e)
        {
            _logger.LogInformation("Application started.");

            // Code that runs on application startup
            _context.Database.CreateIfNotExists();
        }
        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            _logger.LogInformation("Application end.");
        }
        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
        }
        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started
        }
        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.
        }
        public override void Dispose()
        {
            base.Dispose();

            _context?.Dispose();
        }
    }
}
