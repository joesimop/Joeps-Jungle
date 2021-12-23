var APIKey = "8bfe656eef112e39b95f86b68791c224";
var SharedSecret = "c47bcc7b350f1606813e2cfc8d69c3ca";

async function GetPlayedTracksDuringActivity(from, to) {
    const activity_call = "https://ws.audioscrobbler.com/2.0/?method=user.getrecenttracks&user=joe_simop&api_key=8bfe656eef112e39b95f86b68791c224&format=json&from=" + from + "&to=" + to;
    var response = await fetch(activity_call);
    var jsonResponse = await response.json();
    var returnString = await JSON.stringify(jsonResponse);
    return returnString;
}

async function GetTrackDuration(artist, track) {
    console.log(track, artist);
    const activity_call = "https://ws.audioscrobbler.com/2.0/?method=track.getInfo&api_key=8bfe656eef112e39b95f86b68791c224&format=json&artist=" + artist + "&track=" + track + "&autocorrect=1";
    console.log(activity_call)
    var response = await fetch(activity_call);
    var jsonResponse = await response.json();

    if (jsonResponse.track.duration == undefined) {
        return 0;
    }
    return parseInt(jsonResponse.track.duration);
}