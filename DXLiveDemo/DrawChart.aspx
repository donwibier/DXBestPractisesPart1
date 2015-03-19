<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DrawChart.aspx.cs" Inherits="DXLiveDemo.DrawChart" %>
<%@ OutputCache Duration="86400" VaryByParam="w;h;" %>

<%@ Register Assembly="DevExpress.XtraCharts.v14.2.Web, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register Assembly="DevExpress.XtraCharts.v14.2, Version=14.2.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts" TagPrefix="cc1" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
		  <dxchartsui:WebChartControl ID="RangeChartControl" runat="server" SeriesDataMember="SeriesName"
				CrosshairEnabled="False" Height="82px" Width="800px" BackColor="Transparent">
				<padding bottom="0" left="0" right="0" top="0" />
				<borderoptions visibility="False" />
				<diagramserializable>
									 <cc1:SwiftPlotDiagram>
										  <axisx visibleinpanesserializable="-1" color="Transparent" Visibility="False" alignment="Far">
												<tickmarks minorvisible="False" visible="False" />
												<label visible="False">
												</label>
												<numericscaleoptions autogrid="False" customgridalignment="0.02" gridalignment="Custom" gridspacing="25" />
										  </axisx>
										  <axisy visibleinpanesserializable="-1" color="Transparent" Visibility="False" alignment="Far">
												<tickmarks minorvisible="False" visible="False" />
												<label visible="False">
												</label>
												<visualrange autosidemargins="False" sidemarginsvalue="0" />
												<wholerange alwaysshowzerolevel="False" AutoSideMargins="False" SideMarginsValue="0" />
												<gridlines visible="False">
												</gridlines>
												<numericscaleoptions autogrid="False" gridspacing="0.5" />
										  </axisy>
										  <margins bottom="0" left="0" right="0" top="6" />
										  <defaultpane backcolor="Transparent" bordervisible="False" sizeinpixels="50" sizemode="UseSizeInPixels">
										  </defaultpane>
									 </cc1:SwiftPlotDiagram>
								</diagramserializable>
				<fillstyle fillmode="Empty"></fillstyle>
				<legend visibility="False"></legend>
				<seriesserializable>
									 <cc1:Series LabelsVisibility="False" Name="Series 4">
										  <points>
												<cc1:SeriesPoint ArgumentSerializable="1" Values="1">
												</cc1:SeriesPoint>
												<cc1:SeriesPoint ArgumentSerializable="2" Values="5">
												</cc1:SeriesPoint>
												<cc1:SeriesPoint ArgumentSerializable="3" Values="6">
												</cc1:SeriesPoint>
												<cc1:SeriesPoint ArgumentSerializable="4" Values="10">
												</cc1:SeriesPoint>
												<cc1:SeriesPoint ArgumentSerializable="5" Values="8">
												</cc1:SeriesPoint>
												<cc1:SeriesPoint ArgumentSerializable="6" Values="7">
												</cc1:SeriesPoint>
												<cc1:SeriesPoint ArgumentSerializable="7" Values="10">
												</cc1:SeriesPoint>
												<cc1:SeriesPoint ArgumentSerializable="8" Values="4">
												</cc1:SeriesPoint>
												<cc1:SeriesPoint ArgumentSerializable="9" Values="2">
												</cc1:SeriesPoint>
										  </points>
										  <viewserializable>
												<cc1:SwiftPlotSeriesView>
													 <linestyle thickness="2" />
												</cc1:SwiftPlotSeriesView>
										  </viewserializable>
									 </cc1:Series>
								</seriesserializable>
				<seriestemplate>
									 <viewserializable>
										  <cc1:SwiftPlotSeriesView>
												<linestyle thickness="2" />
										  </cc1:SwiftPlotSeriesView>
									 </viewserializable>
								</seriestemplate>
		  </dxchartsui:WebChartControl>  

    </form>
</body>
</html>
