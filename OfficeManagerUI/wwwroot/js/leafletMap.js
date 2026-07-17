window.showLeafletMap = (elementId, locations) => {
    const map = L.map(elementId);

    const bounds = L.latLngBounds([]);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 19
    }).addTo(map);

    let firstMarker = null;

    // Add markers
    locations.forEach(loc => {
        const marker = L.marker([loc.lat, loc.lng]).addTo(map);
        if (loc.popup) marker.bindPopup(loc.popup);

        if (!firstMarker) firstMarker = marker;

        bounds.extend([loc.lat, loc.lng]);
    });

    // Fit map to all markers
    map.fitBounds(bounds);

    // Open popup AFTER the map has finished moving
    if (firstMarker) {
        firstMarker.openPopup();
    }

    // Optional: force a specific zoom after fitting
    map.setZoom(14);
};