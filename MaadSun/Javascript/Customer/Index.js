$(document).ready(function () {
    $('.bxslider').bxSlider({
    });
   // initialize();
});

//function initialize() {
//    var Lat = 35.705194;
//    var Lng = 51.384685;
    
//    var myCenter = new google.maps.LatLng(Lat, Lng);
//    var mapProp = {
//        center: myCenter,
//        zoom: 16,
//        mapTypeId: google.maps.MapTypeId.ROADMAP,
//        disableDefaultUI: true
//    };
//    var map = new google.maps.Map($("#googleMap")[0], mapProp);
//    var marker = new google.maps.Marker
//                       ({
//                           map: map,
//                           position: myCenter
//                       });
//    marker.setMap(map);
//    marker.setVisible(true);

//    var styleOptions = {
//        name: "Dummy Style"
//    };

//    var MAP_STYLE = [
//        {
//            featureType: "road",
//            elementType: "all",
//            stylers: [
//                { visibility: "on" }
//            ]
//        }];
    
//    var mapType = new google.maps.StyledMapType(MAP_STYLE, styleOptions);
//    map.mapTypes.set("Dummy Style", mapType);
//    map.setMapTypeId("Dummy Style");

        
//}
////google.maps.event.addDomListener(window, 'load', initialize);