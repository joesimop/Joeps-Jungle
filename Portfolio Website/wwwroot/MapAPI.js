coordinates = [];
center = [];
var map;
var mileMarker;
var travelMarker;

var AccessToken;

async function SetMapBoxCredentials(accessToken) {
    this.AccessToken = accessToken;
}

async function mapInit() {

    findCenter(coordinates)
    mapboxgl.accessToken = this.AccessToken;
    map = new mapboxgl.Map({
        container: 'map',
        center: center,
        zoom: 5,
        style: 'mapbox://styles/joesimop8/ckwf6rzp20obq14o0z2kn9f25'
    });

    map.on('load', () => {
        map.addSource('route', {
            'type': 'geojson',
            'data': {
                'type': 'Feature',
                'properties': {},
                'geometry': {
                    'type': 'LineString',
                    'coordinates': coordinates
                }
            }
        });
        map.addLayer({
            'id': 'route',
            'type': 'line',
            'source': 'route',
            'layout': {
                'line-join': 'round',
                'line-cap': 'round'
            },
            'paint': {
                'line-color': '#F09F2D',
                'line-width': 5
            }
        });

       
    });

    const bounds = new mapboxgl.LngLatBounds(
        coordinates[0],
        coordinates[0]
    );

    // Extend the 'LngLatBounds' to include every coordinate in the bounds result.
    for (const coord of coordinates) {
        bounds.extend(coord);
    }

    map.fitBounds(bounds, {
        padding: 20
    });
}

async function decode(str, precision) {
    coordinates = [];

    var index = 0,
        lat = 0,
        lng = 0,
        shift = 0,
        result = 0,
        byte = null,
        latitude_change,
        longitude_change,
        factor = Math.pow(10, Number.isInteger(precision) ? precision : 5);

    // Coordinates have variable length when encoded, so just keep
    // track of whether we've hit the end of the string. In each
    // loop iteration, a single coordinate is decoded.
    while (index < str.length) {

        // Reset shift, result, and byte
        byte = null;
        shift = 0;
        result = 0;

        do {
            byte = str.charCodeAt(index++) - 63;
            result |= (byte & 0x1f) << shift;
            shift += 5;
        } while (byte >= 0x20);

        latitude_change = ((result & 1) ? ~(result >> 1) : (result >> 1));

        shift = result = 0;

        do {
            byte = str.charCodeAt(index++) - 63;
            result |= (byte & 0x1f) << shift;
            shift += 5;
        } while (byte >= 0x20);

        longitude_change = ((result & 1) ? ~(result >> 1) : (result >> 1));

        lat += latitude_change;
        lng += longitude_change;

        coordinates.push([lng / factor, lat / factor]);
    }

    return coordinates.length;
};


function findCenter(coords) {
    lngValue = 0, latValue = 0;

    for (i = 0; i < coords.length; i++) {
        lngValue += coords[i][0];
        latValue += coords[i][1];
    }

    center = [lngValue / coords.length, latValue / coords.length]
}

async function addMarkerAtMile(milenumber, totalMiles) {

    if (mileMarker != null) { mileMarker.remove(); }

    var index = milenumber == totalMiles ? coordinates.length - 1 : (Math.round(coordinates.length / totalMiles)) * milenumber;

    if (milenumber <= totalMiles) {
        mileMarker = new mapboxgl.Marker()
            .setLngLat(coordinates[index])
            .addTo(map);
    }
}

async function removeMileMarker() {
    if (mileMarker != null) { mileMarker.remove(); }
    console.log("removed");
}

async function updateTravelMarker(sliderInput) {

    if (travelMarker != null) { travelMarker.remove(); }

    travelMarker = new mapboxgl.Marker()
        .setLngLat(coordinates[sliderInput.value])
        .addTo(map);

    return parseInt(sliderInput.value);
}

function distance(lat1, lon1, lat2, lon2) {
    var p = 0.017453292519943295;    // Math.PI / 180
    var c = Math.cos;
    var a = 0.5 - c((lat2 - lat1) * p) / 2 +
        c(lat1 * p) * c(lat2 * p) *
        (1 - c((lon2 - lon1) * p)) / 2;

    return 12742 * Math.asin(Math.sqrt(a)); // 2 * R; R = 6371 km
}

function CalculateDistance(sliderInput) {
    var totalDistance = 0;

    for (i = 0; i < sliderInput.value - 1; i++) {
        totalDistance += distance(coordinates[i][0], coordinates[i][1],
                                  coordinates[i + 1][0], coordinates[i + 1][1]);
    }
        console.log(totalDistance);

    return totalDistance;
}