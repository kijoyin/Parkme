////function initialize() {
////    var service = new google.maps.places.AutocompleteService();
////    service.getQueryPredictions({ input: 'brisbane' }, callback);
////}

////function callback(predictions, status) {
////    if (status != google.maps.places.PlacesServiceStatus.OK) {
////        alert(status);
////        return;
////    }

////    var results = document.getElementById('results');

////    for (var i = 0, prediction; prediction = predictions[i]; i++) {
////        results.innerHTML += '<li>' + prediction.description + '</li>';
////    }
////}

////google.maps.event.addDomListener(window, 'load', initialize);
///**
// * Author: Richard Willis - badsyntax.co
// * Example here:  http://demos.badsyntax.co/places-search-bootstrap/example.html
// *
// * Please note: This is not a reliable method of geocoding the address. Using the 
// * PlacesService is a much better approach. View the example above for an example 
// * of using the PlacesService to geocode the address.
// */
//$(document).ready(function () {
//    var service = new google.maps.places.AutocompleteService();
//    var geocoder = new google.maps.Geocoder();

//    $('#typeahead').typeahead({
//        hint: true,
//        highlight: true,
//        minLength: 1
//    },  
//    {
//        source: 
//        }
//    }
//    });
//});

function get_location() {
    if (Modernizr.geolocation) {
        navigator.geolocation.getCurrentPosition(showdefault);
    } else {
        // no native support; maybe try a fallback?
    }
}
function showdefault(position) {
    var latitude = position.coords.latitude;
    var longitude = position.coords.longitude;
    getFormattedLatlong(latitude, longitude);
}

$(document).ready(function () {
    var addressPicker = new AddressPicker();
    $('#address').typeahead(null, {
        displayKey: 'description',
        source: addressPicker.ttAdapter()
    });
    $('#currentLocation').click(function (e) {
        e.preventDefault();
        get_location();
    });0
});


function getFormattedLatlong(_lat, _long) {
    var geocoder = new google.maps.Geocoder();
    var lat = parseFloat(_lat);
    var lng = parseFloat(_long);
    var latlng = new google.maps.LatLng(lat, lng);
    geocoder.geocode({ 'latLng': latlng }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            if (results[1]) {
                $('#address').val(results[1].formatted_address);
            }
        } else {
            alert("Geocoder failed due to: " + status);
        }
    });
}