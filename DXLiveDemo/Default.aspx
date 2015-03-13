

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DXLiveDemo.Default" %>

<%@ Register Assembly="DevExpress.XtraCharts.v14.2.Web, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>

<%@ Register assembly="DevExpress.XtraCharts.v14.2, Version=14.2.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.XtraCharts" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
		  <dxchartsui:WebChartControl ID="WebChartControl1" runat="server" CrosshairEnabled="True" DataSourceID="SqlDataSource1" Height="365px" OnPreRender="WebChartControl1_PreRender" PaletteName="Yellow Orange" Width="709px">
				<diagramserializable>
					 <cc1:XYDiagram>
						  <axisx visibleinpanesserializable="-1">
						  </axisx>
						  <axisy visibleinpanesserializable="-1">
						  </axisy>
					 </cc1:XYDiagram>
				</diagramserializable>
				<seriesserializable>
					 <cc1:Series ArgumentDataMember="ProductName" ArgumentScaleType="Qualitative" Name="Units In Stock" ValueDataMembersSerializable="UnitsInStock">
						  <datafilters>
								<cc1:DataFilter ColumnName="CategoryID" DataType="System.Int32" InvariantValueSerializable="4" />
						  </datafilters>
					 </cc1:Series>
					 <cc1:Series ArgumentDataMember="ProductName" ArgumentScaleType="Qualitative" Name="Units On Order" ValueDataMembersSerializable="UnitsOnOrder">
						  <datafilters>
								<cc1:DataFilter ColumnName="CategoryID" DataType="System.Int32" InvariantValueSerializable="4" />
						  </datafilters>
					 </cc1:Series>
				</seriesserializable>
		  </dxchartsui:WebChartControl>    
    	 <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindDBConnectionString %>" SelectCommand="SELECT [ProductName], [CategoryID], [UnitsInStock], [UnitsOnOrder] FROM [Products]"></asp:SqlDataSource>
		  <br />
		  <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Select" TypeName="DXLiveDemo.Data.ProductsDatasource"></asp:ObjectDataSource>
		  <dxchartsui:WebChartControl ID="WebChartControl2" runat="server" CrosshairEnabled="True" DataSourceID="ObjectDataSource1" Height="259px" OnPreRender="WebChartControl1_PreRender" SeriesDataMember="SeriesName" Width="726px">
				<diagramserializable>
					 <cc1:XYDiagram>
						  <axisx visibleinpanesserializable="-1">
						  </axisx>
						  <axisy visibleinpanesserializable="-1">
						  </axisy>
					 </cc1:XYDiagram>
				</diagramserializable>
				<seriestemplate argumentdatamember="ProductName" argumentscaletype="Qualitative" valuedatamembersserializable="Number">
					 <datafilters>
						  <cc1:DataFilter ColumnName="CategoryID" DataType="System.Int32" InvariantValueSerializable="4" />
					 </datafilters>
				</seriestemplate>
		  </dxchartsui:WebChartControl>
    </div>
    </form>
</body>
</html>
