// Write your JavaScript code.
function getLocation(address){
    $.getJSON("https://maps.googleapis.com/maps/api/geocode/json?key=AIzaSyBN6yVbqbZ6scp6Adi2LrgikRClbeRA0Sw&address="+address, function(data, status, xhr){
        for(let a of data.results){
            if(a.formatted_address == address){
                console.log(a);
            }
        }
        console.log(data);
    });
}