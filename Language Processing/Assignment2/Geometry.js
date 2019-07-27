function initMap() {var map = new google.maps.Map(document.getElementById('map'), {zoom: 3,center: {lat: 39.936769, lng:-8.112379}});
map.data.add({geometry: new google.maps.Data.Point({lat: 37.771999, lng: -122.213997})});
var fl=new google.maps.Polyline({ path:[{ lat : 37.771999 , lng : -122.213997 },
{ lat : 21.291000 , lng : -157.820999 },
{ lat : -18.142000 , lng : 178.431000 },
{ lat : -27.466999 , lng : 153.026993 },
],geodesic: true,strokeColor: '#FF0000', strokeOpacity: 1.0,strokeWeight: 2}); fl.setMap(map);map.data.add({geometry: new google.maps.Data.Polygon([[{ lat : -32.363998 , lng : 153.207001 },
{ lat : -35.363998 , lng : 153.207001 },
{ lat : -35.363998 , lng : 158.207001 },
{ lat : -32.363998 , lng : 158.207001 },
],[{ lat : -33.363998 , lng : 154.207001 },
{ lat : -34.363998 , lng : 154.207001 },
{ lat : -34.363998 , lng : 155.207001 },
{ lat : -33.363998 , lng : 155.207001 },
],[{ lat : -33.363998 , lng : 156.207001 },
{ lat : -34.363998 , lng : 156.207001 },
{ lat : -34.363998 , lng : 157.207001 },
{ lat : -33.633999 , lng : 157.207001 },
]])})}