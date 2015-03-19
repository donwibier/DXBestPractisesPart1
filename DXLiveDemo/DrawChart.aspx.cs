using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Imaging;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraCharts;

namespace DXLiveDemo
{
	 public partial class DrawChart : System.Web.UI.Page
	 {
		  protected void Page_Load(object sender, EventArgs e)
		  {
				//DateTime startDate = DateTime.Parse(Request.QueryString["start"]);
				//DateTime endDate = DateTime.Parse(Request.QueryString["end"]);

				if (!String.IsNullOrEmpty(Request.QueryString["w"]))
					 RangeChartControl.Width = Unit.Parse(Request.QueryString["w"].ToString());
				if (!String.IsNullOrEmpty(Request.QueryString["h"]))
					 RangeChartControl.Height = Unit.Parse(Request.QueryString["h"].ToString());


				//RangeChartControl.DataSource = SalesProvider.GetRangeChartData(startDate, endDate).ToList();
				//RangeChartControl.DataBind();

				Response.ContentType = "image/png";
				Response.Clear();

				using (MemoryStream stream = new MemoryStream())
				{
					 ((IChartContainer)RangeChartControl).Chart.ExportToImage(stream, ImageFormat.Png);
					 stream.Position = 0;
					 stream.CopyTo(Response.OutputStream);
				}
		  }
	 }
}