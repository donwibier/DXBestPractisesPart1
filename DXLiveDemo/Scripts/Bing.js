$(function () {
	 "use strict";

	 window.createMap = function (elem) {
	 	 var mapOptions = {
	 	 	 credentials: "AnMJdYqC3az-cgwpS9im_Awk29CiAomCig8AJJyq7DgBv0LU3zoQBAOEp3Zxh5nx", // Credentials 
	 	 	 center: new Microsoft.Maps.Location($(elem).data("latitude"), $(elem).data("longitude")),
	 	 	 mapTypeId: Microsoft.Maps.MapTypeId.road,
	 	 	 zoom: 9,
	 	 	 showScalebar: true,
	 	 	 showMapTypeSelector: true,
	 	 	 disableKeyboardInput: true
	 	 }
	 	 var map = new Microsoft.Maps.Map($(elem)[0], mapOptions);
	 	 var center = map.getCenter();
	 	 var pin = new Microsoft.Maps.Pushpin(center);
	 	 map.entities.push(pin);
	 };

	 window.createMaps = function () {
	 	 $("*[data-latitude][data-longitude]").each(function () {
	 	 	 createMap($(this))
	 	 });
	 }

	 window.createMaps();
});