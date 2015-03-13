using DevExpress.XtraCharts.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DXLiveDemo
{
	 public partial class Default : System.Web.UI.Page
	 {
		  protected void Page_Load(object sender, EventArgs e)
		  {

		  }

		  protected void WebChartControl1_PreRender(object sender, EventArgs e)
		  {
				((WebChartControl)sender).ApplyMyConfig("Units In Stock");
		  }
	 }
}