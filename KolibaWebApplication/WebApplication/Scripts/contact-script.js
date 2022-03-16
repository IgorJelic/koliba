////$(document).ready(() => {
////});

// Initialize and add the map
function initMap() {
    // The location of Uluru
    const uluru1 = { lat: 45.248660, lng: 19.848740 };
    const uluru2 = { lat: 45.256860, lng: 19.811910 };
    // The map, centered at Uluru
    const map1 = new google.maps.Map(document.getElementById("map1"), {
        zoom: 15,
        center: uluru1,
    });
    // The marker, positioned at Uluru
    const marker = new google.maps.Marker({
        position: uluru1,
        map: map1,
    });

    // The map, centered at Uluru
    const map2 = new google.maps.Map(document.getElementById("map2"), {
        zoom: 15,
        center: uluru2,
    });
    // The marker, positioned at Uluru
    const marker2 = new google.maps.Marker({
        position: uluru2,
        map: map2,
    });
}