using System;
using System.Web.UI;
using drielnox.Forum.Business.Logic;
using drielnox.Forum.Transversal.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace drielnox.Forum.Presetation.WebForms.Forums
{
    public partial class ManageForums : Page
    {
        private readonly IServiceProvider _services;
        private readonly IForumManager _forumManager;

        public ManageForums()
        {
            _services = DIContainer.Build();
            _forumManager = _services.GetService<IForumManager>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("/Account/Login.aspx");
            }

            LoadForums();
        }

        /// <summary>
        /// display forums on webpage if login is granted
        /// </summary>
        protected void LoadForums()
        {
            var forums = _forumManager.ViewForums();
            grdForums.DataSource = forums;
            grdForums.DataBind();
        }

        private void HideError()
        {
            lblError.Visible = false;
        }

        private void ShowError(string message)
        {
            lblError.Visible = true;
            lblError.Text = $"Error: {message}";
        }
    }
}