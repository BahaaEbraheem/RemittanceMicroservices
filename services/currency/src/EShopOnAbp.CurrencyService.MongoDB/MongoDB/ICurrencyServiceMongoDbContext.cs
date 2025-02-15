﻿using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace EShopOnAbp.CurrencyService.MongoDB;

[ConnectionStringName(CurrencyServiceDbProperties.ConnectionStringName)]
public interface ICurrencyServiceMongoDbContext : IAbpMongoDbContext
{
    /* Define mongo collections here. Example:
     * IMongoCollection<Question> Questions { get; }
     */
}
