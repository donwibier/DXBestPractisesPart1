<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SparkControl.aspx.cs" Inherits="DXLiveDemo.SparkControl" %>

<%@ Register Assembly="DevExpress.XtraCharts.v14.2.Web, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register Assembly="DevExpress.XtraCharts.v14.2, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
	 <title></title>
</head>
<body>
	 <form id="form1" runat="server">
		  <div>
				<div class="rangeControlLayout">
					 <div style="float: left;">
						  <dx:ASPxButton ID="LeftShiftButton" runat="server" CssClass="rangeControlButton leftShift" AutoPostBack="false" Text="<">
						  </dx:ASPxButton>
					 </div>
					 <div class="trackBarWrapper" style="float: left;">
						  

						  <dx:ASPxImage ID="chart" runat="server" Width="800px" Height="82px" ImageUrl="~/DrawChart.aspx?w=800&h=82"></dx:ASPxImage>
						  <dx:ASPxTrackBar ID="ASPxTrackBar1" runat="server" Height="82px" Width="800px"></dx:ASPxTrackBar>
					 </div>
					 <div style="float: left;">
						  <dx:ASPxButton ID="RightShiftButton" runat="server" CssClass="rangeControlButton rightShift" AutoPostBack="false" Text=">">
						  </dx:ASPxButton>
					 </div>
				</div>
		  </div>
	 </form>
</body>
</html>
