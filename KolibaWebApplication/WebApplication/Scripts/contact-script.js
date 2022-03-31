////$(document).ready(() => {
////});

const WORK_START= 7;
const WORK_END_WEEKDAY = 17;
const WORK_END_SATURDAY = 15;


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

function CheckOpenClosed() {

    const d = new Date();
    let day = d.getDay();
    let hours = d.getHours();
    //let minutes = d.getMinutes;

    if (day < 6) {
        if (day < 5) {
            if (hours > WORK_START && hours < WORK_END_WEEKDAY) {
                KolibaOpen();
            }
            else {
                KolibaClosed();
            }
        }
        else {
            if (hours > WORK_START && hours < WORK_END_SATURDAY) {
                KolibaOpen();
            }
            else {
                KolibaClosed();
            }
        }
    }
    else {
        KolibaClosed();
    }
}

function KolibaOpen() {
    let elements = document.querySelectorAll('.open-closed-div');

    elements.forEach((el) => {
        el.classList.remove('koliba-closed');
        el.classList.add('koliba-open');

        el.innerText = "Open";
    });
}

function KolibaClosed() {
    let elements = document.querySelectorAll('.open-closed-div');

    elements.forEach((el) => {
        el.classList.remove('koliba-open');
        el.classList.add('koliba-closed');

        el.innerText = "Closed";
    });
}

setTimeout(CheckOpenClosed, 100);
//CheckOpenClosed();