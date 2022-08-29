var ClientId;
var ClientSecret;
var Authorization;
var Access_Token;
var redirect_uri = "https://localhost:44391/running"

function SetSpotifyCredentials(clientId, clientSecret, authorizationType) {
    this.ClientId = clientId;
    this.ClientSecret = clientSecret;
    this.Authorization = authorizationType;
}

//Note: Authorization is the encoded base64 string. the original is ClientId + : + ClientSecret. Postman generated it. Just remeber its encoded.

async function GetRefresh_Token(){
    let myHeaders = new Headers();
    myHeaders.append("Authorization", this.Authorization);
    myHeaders.append("Content-Type", "application/x-www-form-urlencoded");

    var urlencoded = new URLSearchParams();
    urlencoded.append("grant_type", "client_credentials");

    const requestOptions = {
        method: 'GET',
        headers: myHeaders,
        body: urlencoded,
        redirect: 'follow'
    }
        
    let res = await fetch("https://accounts.spotify.com/authorize?", requestOptions);
    res = await res.json();
    Access_Token = res.access_token;
}

async function AuthorizeSpotify() {

    var scope = 'user-read-private user-read-email user-read-recently-played';

    var url = 'https://accounts.spotify.com/authorize';
    url += '?response_type=token';
    url += '&client_id=' + encodeURIComponent(this.ClientId);
    url += '&scope=' + scope;
    url += '&redirect_uri=' + encodeURIComponent(redirect_uri);
    window.location.href = url;
}


function SetCodeFromUrl() {
    var hash = window.location.hash;
    var index = hash.indexOf("=") + 1;
    Access_Token = "";
    while (hash[index] != "&") {
        Access_Token += hash[index];
        index++;
    }
}

async function getRecentlyPlayedTracks(fromTime) {
    var getrecentlyplayedurl = "https://api.spotify.com/v1/me/player/recently-played";

    if (fromTime != 0) {
        console.log(fromTime);
        getrecentlyplayedurl += "?after=" + fromTime;
    }

    let myHeaders = new Headers();
    myHeaders.append("Authorization", "Bearer " + Access_Token);
    const requestOptions = {
        method: 'GET',
        headers: myHeaders,
    }

    let res = await fetch(getrecentlyplayedurl, requestOptions);
    res = await res.json();
    console.log(res.items);
    var returnString = await JSON.stringify(res.items);
    return returnString;
}