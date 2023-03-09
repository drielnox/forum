﻿using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace OtadForum
{
    public class Global : HttpApplication
    {
        private readonly ForumContext _context;

        public Global()
            : base()
        {
            _context = new ForumContext();
        }

        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            if (!_context.Database.CanConnect())
            {
                throw new ApplicationException("The forum can't connect to database.");
            }

            //_context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown
            _context?.Dispose();
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
    }
}