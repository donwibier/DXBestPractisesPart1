<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bing.aspx.cs" Inherits="DXLiveDemo.Bing" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
	 <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	 <style>
	     #mapContainer {
	        position: absolute;
			width: 400px;
			height:400px;
	     }
	 </style>
</head>
<body>
    <form id="form1" runat="server">

		  <div id="mapContainer" data-latitude="51.9279722" data-longitude="4.4904063">
		  </div>

	 </form>
	 <script type="text/javascript" src="/Scripts/jquery-2.1.3.js"></script>
	 <script type="text/javascript" src="http://ecn.dev.virtualearth.net/mapcontrol/mapcontrol.ashx?v=7.0"></script>
	 <script src="/Scripts/Bing.js"></script>
</body>
</html>
