using System;
using System.Collections.Generic;
using BeaverLeague.Core.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BeaverLeague.Data.Identity
{
    public class GolferManager : UserManager<Golfer>
    {
        public GolferManager(IUserStore<Golfer> store,
                             IOptions<IdentityOptions> optionsAccessor, 
                             IPasswordHasher<Golfer> passwordHasher, 
                             IEnumerable<IUserValidator<Golfer>> userValidators, 
                             IEnumerable<IPasswordValidator<Golfer>> passwordValidators, 
                             ILookupNormalizer keyNormalizer, 
                             IdentityErrorDescriber errors, 
                             IServiceProvider services, 
                             ILogger<UserManager<Golfer>> logger) 
            : base(store, optionsAccessor, passwordHasher, userValidators, 
                  passwordValidators, keyNormalizer, errors, services, logger)
        {

        }
    }
}
