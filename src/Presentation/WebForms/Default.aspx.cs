using Microsoft.Extensions.Logging;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;

namespace drielnox.Forum.Presetation.WebForms
{
    public partial class Default : Page
    {
        private readonly ILogger _logger;

        public Default()
        {
            _logger = Logging.CreateLogger<Default>();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LoadLastFiveDiscussions();
            LoadLastFiveComments();

            if (!IsPostBack)
            {
                try
                {
                    // Obtener el tamaño del contenedor HTML
                    int containerWidth = int.Parse(chartContainerWidth.Value);
                    int containerHeight = int.Parse(chartContainerHeight.Value);

                    // Establecer el tamaño del control Chart
                    chrtCategoryDistribution.Width = containerWidth;
                    chrtCategoryDistribution.Height = containerHeight;
                }
                catch (FormatException fex)
                {
                    // Manejar la excepción de conversión fallida
                    _logger.LogError(fex, "Hubo un error al ajustar la dimensiones del grafico.");

                    // Establecer un ancho y altura predeterminados para el control Chart
                    chrtCategoryDistribution.Width = 600;
                    chrtCategoryDistribution.Height = 400;
                }
            }

            LoadCategoryDistribution();
        }

        private void LoadCategoryDistribution()
        {
            using (var ctx = new ForumContext())
            {
                var chartValues = ctx.Categories
                    .Select(x => new
                    {
                        CategoryName = x.Name,
                        DiscussionCount = x.RelatedDiscussions.Count
                    })
                    .ToList();

                chrtCategoryDistribution.DataSource = chartValues;
                chrtCategoryDistribution.DataBind();
            }
        }

        private void LoadLastFiveComments()
        {
            try
            {
                using (var ctx = new ForumContext())
                {
                    var lastFiveComments = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .SelectMany(x => x.Comments)
                        .OrderByDescending(x => x.CreatedAt)
                        .Take(5)
                        .ToList();

                    rLastFiveComments.DataSource = lastFiveComments;
                    rLastFiveComments.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LoadLastFiveDiscussions()
        {
            try
            {
                using (var ctx = new ForumContext())
                {
                    var lastFiveDiscussions = ctx.Forums
                        .SelectMany(x => x.Discussions)
                        .OrderByDescending(x => x.CreatedAt)
                        .Take(5)
                        .ToList();

                    rLastFiveDiscussions.DataSource = lastFiveDiscussions;
                    rLastFiveDiscussions.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
