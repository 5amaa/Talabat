using Talabat.Core.Entities;
using Talabat.Core.Repository;
using StackExchange.Redis;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace Talabat.Repository.Repository
{
    public class BasketRepository : IBasketRepository
    {
        // 1- install Redis in Core layer cause it will used in the caching (StackExchange.Redis) 
        //Inject Redis Pakage from IConnectionMultiplexer
        //Redis is a dictionary(Key Value Pair) so any get any create must to use the key (id) and the value(Json) 

        private readonly IDatabase _database;
        public BasketRepository(IConnectionMultiplexer redis)
        {
            //gwa el redis GetDatabase to get his database 
            _database= redis.GetDatabase();
        }
        public async Task<bool> DeleteBasketAsync(string basketId)
        {
            //KeyDeleteAsync() deh btrag3 bool
            return await _database.KeyDeleteAsync(basketId);
            
        }

        public async Task<CustomerBasket?> GetBasketAsync(string basketId)
        {
            /// Returns the values of all specified keys.
            var basket = await _database.StringGetAsync(basketId);
            return basket.IsNull ?  null:  JsonSerializer.Deserialize<CustomerBasket>(basket);

        }

        public async Task<CustomerBasket?> UpdateBasket(CustomerBasket basket)
        {
            /// Set key to hold the string value. If key already holds a value, it is overwritten, regardless of its type.
            /// Task<bool> StringSetAsync(RedisKey key, RedisValue value, TimeSpan? expiry = null)
           var createdOrUpdated = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), TimeSpan.FromDays(1));
            return createdOrUpdated? await GetBasketAsync(basket.Id): null;
        }
    }
}
