var driverLocation = [];
var schoolLocation = [];
var school;
var SAN_JOSE_COORDS = [-84.113677, 9.873099];
var lastQueryTime = 0;
var lastAtRestaurant = 0;
var keepTrack = [];
var currentSchedule = [];
var currentRoute = null;
var pointHopper = {};
var pause = true;
var speedFactor = 50;

// Add your access token
mapboxgl.accessToken = 'pk.eyJ1Ijoic3p1bmlnYWYiLCJhIjoiY2tlMXBpd3lxMDFtazJ4cXBtbTlqdGM1aSJ9.HYKB-SSvsP34UzUTi5rUbg';

// Initialize a map
var map = new mapboxgl.Map({
    container: 'map', // container id
    style: 'mapbox://styles/mapbox/light-v10', // stylesheet location
    center: SAN_JOSE_COORDS, // starting position
    zoom: 8 // starting zoom
});

// Create an empty GeoJSON feature collection for drop off locations
var dropoffs = turf.featureCollection([]);

// Create an empty GeoJSON feature collection, which will be used as the data source for the route before users add any new data
var nothing = turf.featureCollection([]);

map.on('load', function () {
    var marker = document.createElement('div');
    marker.classList = 'truck';

    // Create a circle layer
    function addSchoolToTheMap(school) {
        map.addLayer({
            id: 'school',
            type: 'circle',
            source: {
                data: school,
                type: 'geojson'
            },
            paint: {
                'circle-radius': 20,
                'circle-color': 'white',
                'circle-stroke-color': '#3887be',
                'circle-stroke-width': 3
            }
        });

    }

    map.addLayer({
        id: 'dropoffs-symbol',
        type: 'symbol',
        source: {
            data: dropoffs,
            type: 'geojson'
        },
        layout: {
            'icon-allow-overlap': true,
            'icon-ignore-placement': true,
            'icon-image': 'marker-15'
        }
    });

    map.addSource('route', {
        type: 'geojson',
        data: nothing
    });

    map.addLayer(
        {
            id: 'routeline-active',
            type: 'line',
            source: 'route',
            layout: {
                'line-join': 'round',
                'line-cap': 'round'
            },
            paint: {
                'line-color': '#3887be',
                'line-width': ['interpolate', ['linear'], ['zoom'], 12, 3, 22, 12]
            }
        },
        'waterway-label'
    );

    map.addLayer(
        {
            id: 'routearrows',
            type: 'symbol',
            source: 'route',
            layout: {
                'symbol-placement': 'line',
                'text-field': '▶',
                'text-size': [
                    'interpolate',
                    ['linear'],
                    ['zoom'],
                    12,
                    24,
                    22,
                    60
                ],
                'symbol-spacing': [
                    'interpolate',
                    ['linear'],
                    ['zoom'],
                    12,
                    30,
                    22,
                    160
                ],
                'text-keep-upright': false
            },
            paint: {
                'text-color': '#3887be',
                'text-halo-color': 'hsl(55, 11%, 96%)',
                'text-halo-width': 3
            }
        },
        'waterway-label'
    );


    function showAllStudentsOnMap() {

        arrayStudentsCoords = [];

        // GET ALL STUDENTS COORDINATES  --> arrayStudentsCoords  = getALLStudents();
        // GET SCHOOL COORDINATES  --> schoolLng , schoolLat

        schoolLng = -84.476083;   // SOBREESCRIBIR CON VALOR DINAMICO
        schoolLat = 10.091371;    // SOBREESCRIBIR CON VALOR DINAMICO


        // NOOOOO EDITAR 
        driverLocation = [schoolLng, schoolLat];
        schoolLocation = [schoolLng, schoolLat];

        truckMarker = new mapboxgl.Marker(marker)
            .setLngLat(schoolLocation)
            .addTo(map);

        school = turf.featureCollection([turf.point(schoolLocation)]);
        addSchoolToTheMap(school);

        map.flyTo({
            center: [
                schoolLng,
                schoolLat
            ],
            zoom: 15,
            essential: true
        });
        // NOOOOO EDITAR 

        student1 = {
            "lng": "-84.478519",
            "lat": "10.077919"
        }

        student2 = {
            "lng": "-84.466332",
            "lat": "10.063435"
        }

        student3 = {
            "lng": "-84.465950",
            "lat": "10.101958"
        }


        student4 = {
            "lng": "-84.472184",
            "lat": "10.105094"
        }

        arrayStudentsCoords.push(student1);
        arrayStudentsCoords.push(student2);
        arrayStudentsCoords.push(student3);
        arrayStudentsCoords.push(student4);


        // NOO EDITAR 
        arrayStudentsCoords.forEach(studentCoords => {
            newDropoff(studentCoords);
            updateDropoffs(dropoffs);
        });

        // NOO EDITAR 

    }

    //   showAllStudentsOnMap();

});

function newDropoff(coords) {
    // Store the clicked point as a new GeoJSON feature with
    // two properties: `orderTime` and `key`
    var pt = turf.point([coords.lng, coords.lat], {
        orderTime: Date.now(),
        key: Math.random()
    });
    dropoffs.features.push(pt);
    pointHopper[pt.properties.key] = pt;

    // Make a request to the Optimization API
    $.ajax({
        method: 'GET',
        url: assembleQueryURL()
    }).done(function (data) {
        // Create a GeoJSON feature collection
        var routeGeoJSON = turf.featureCollection([
            turf.feature(data.trips[0].geometry)
        ]);

        // If there is no route provided, reset
        if (!data.trips[0]) {
            routeGeoJSON = nothing;
        } else {
            // Update the `route` source by getting the route source
            // and setting the data equal to routeGeoJSON
            map.getSource('route').setData(routeGeoJSON);
        }

        //
        if (data.waypoints.length === 30) {
            window.alert(
                'Maximum number of points reached. Read more at docs.mapbox.com/api/navigation/#optimization.'
            );
        }
    });
}

function updateDropoffs(geojson) {
    map.getSource('dropoffs-symbol').setData(geojson);
}

// Here you'll specify all the parameters necessary for requesting a response from the Optimization API
function assembleQueryURL() {
    // Store the location of the truck in a variable called coordinates
    var coordinates = [driverLocation];
    var distributions = [];
    keepTrack = [driverLocation];

    // Create an array of GeoJSON feature collections for each point
    var restJobs = objectToArray(pointHopper);

    // If there are actually orders from this restaurant
    if (restJobs.length > 0) {
        // Check to see if the request was made after visiting the restaurant
        var needToPickUp =
            restJobs.filter(function (d, i) {
                return d.properties.orderTime > lastAtRestaurant;
            }).length > 0;

        // If the request was made after picking up from the restaurant,
        // Add the restaurant as an additional stop
        if (needToPickUp) {
            var restaurantIndex = coordinates.length;
            // Add the restaurant as a coordinate
            coordinates.push(schoolLocation);
            // push the restaurant itself into the array
            keepTrack.push(pointHopper.school);
        }

        restJobs.forEach(function (d, i) {
            // Add dropoff to list
            keepTrack.push(d);
            coordinates.push(d.geometry.coordinates);
            // if order not yet picked up, add a reroute
            if (needToPickUp && d.properties.orderTime > lastAtRestaurant) {
                distributions.push(
                    restaurantIndex + ',' + (coordinates.length - 1)
                );
            }
        });
    }

    // Set the profile to `driving`
    // Coordinates will include the current location of the truck,
    return (
        'https://api.mapbox.com/optimized-trips/v1/mapbox/driving/' +
        coordinates.join(';') +
        '?distributions=' +
        distributions.join(';') +
        '&overview=full&steps=true&geometries=geojson&source=first&access_token=' +
        mapboxgl.accessToken
    );
}

function objectToArray(obj) {
    var keys = Object.keys(obj);
    var routeGeoJSON = keys.map(function (key) {
        return obj[key];
    });
    return routeGeoJSON;
}