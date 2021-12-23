
this.Access_Token = 0;



async function GetActivities(pageNumber) {

    await GetAuthToken();

    if (this.Access_Token != 0) {

        const activies_call = "https://www.strava.com/api/v3/athlete/activities?access_token=" + this.Access_Token + "&page=" + pageNumber + "&per_page=12";
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
            client_id: '73596',
            client_secret: 'e0e21c0dc48e6e8b32841e95c63da9d24f68bf2d',
            refresh_token: '6cae9e3ebc34ca50da8363b9c85431165c215f65',
            grant_type: 'refresh_token'
        })

    }).then(response => response.json())
        .then(response => this.Access_Token = response.access_token);
}