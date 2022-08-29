var ClientId;
var ClientSecret;
var ClientToken;
this.Access_Token = 0;

async function SetStravaCredentials(clientId, clientSecret, clientToken) {
    this.ClientId = clientId;
    this.ClientSecret = clientSecret;
    this.ClientToken = clientToken;
}

async function GetActivities(pageNumber) {

    await GetAuthToken();
    
    if (this.Access_Token != 0) {

        const activies_call = "https://www.strava.com/api/v3/athlete/activities?access_token=" + this.Access_Token + "&page=" + pageNumber + "&per_page=9";
        var response = await fetch(activies_call);
        var jsonResponse = await response.json();
        var returnString = await JSON.stringify(jsonResponse);
        return returnString;
    }
    return "";

}

async function GetActivity(id) {

    if (this.Access_Token != 0) {
        const activity_call = "https://www.strava.com/api/v3/activities/" + id + "?access_token=" + this.Access_Token;
        var response = await fetch(activity_call);
        var jsonResponse = await response.json();
        var returnString = await JSON.stringify(jsonResponse);
        return returnString;
    }
    return "";

}

async function GetAuthToken() {
    const Refresh_Link = "https://www.strava.com/oauth/token"

    await fetch(Refresh_Link, {
        method: 'post',
        headers: {
            'Accept': 'application/json, text/plain, */*',
            'Content-Type': 'application/json'
        },

        body: JSON.stringify({
            client_id: this.ClientId,
            client_secret: this.ClientSecret,
            refresh_token: this.ClientToken,
            grant_type: 'refresh_token'
        })

    }).then(response => response.json())
        .then(response => this.Access_Token = response.access_token);
}