using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Portfolio_Website.Data;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace Portfolio_Website.Services;

public class MongoDBService
{

    private IMongoCollection<StravaActivity> _activitiesCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings)
    {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _activitiesCollection = database.GetCollection<StravaActivity>(mongoDBSettings.Value.CollectionName);
    }

    public async Task UpdateCollection(List<StravaActivity> activities)
    {
        await _activitiesCollection.InsertManyAsync(activities);
    }

    public async Task AddActivity(StravaActivity activity)
    {
        var Modifiers = new BsonDocument("_id", -1);
        await _activitiesCollection.InsertOneAsync(activity);
    }

    public async Task<List<StravaActivity>> GetActivties(int pageNumber)
    {
        int index = pageNumber * 9;

        var cursor = await _activitiesCollection.FindAsync(x => true);
        var aList = await cursor.ToListAsync();
        return aList.OrderByDescending(x => x.StartDate).ToList().GetRange(index, 9);

    }
}