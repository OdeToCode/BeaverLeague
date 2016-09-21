using System;
using BeaverLeague.Core.Models;
using BeaverLeague.Data;
using BeaverLeague.Data.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace BeaverLeague.Tests.Data.Identity
{
    public class SecurityManagers
    {
        public SecurityManagers(Db<LeagueDb> db)
        {
            _db = db;
            _provider = new ServiceCollection()
                .AddIdentity<Golfer, Golfer>()              
                .Services.BuildServiceProvider();
                            
                                               
            UserManager = CreateGolferManager();
            SignInManager = CreateSignInManager();
        }

        private UserManager<Golfer> CreateGolferManager()
        {
            _store = new GolferStore(_db.NewContext());
            _options = Options.Create(new IdentityOptions());
            _lookup = new UpperInvariantLookupNormalizer();
            _errorDescriber = new IdentityErrorDescriber();
            _loggerFactory = new LoggerFactory();
            var hasher = new PasswordHasher<Golfer>();
            var userValidators = new[] { new UserValidator<Golfer>() };
            var passwordValidators = new[] { new PasswordValidator<Golfer>() };
    
            var logger = _loggerFactory.CreateLogger<UserManager<Golfer>>();
            var manager = new UserManager<Golfer>(_store, _options, hasher, userValidators,
                                passwordValidators, _lookup, _errorDescriber, _provider, logger);
            return manager;
        }

        private SignInManager<Golfer> CreateSignInManager()
        {
            var context = new DefaultHttpContext();
            context.Features.Set<IHttpAuthenticationFeature>(new HttpAuthenticationFeature() {  Handler = new FakeAuthenticationHandler() });
            var accessor = new HttpContextAccessor { HttpContext = context };
            var roleValidators = new[] {new RoleValidator<Golfer>()};
            var roleLogger = _loggerFactory.CreateLogger<RoleManager<Golfer>>();
            var roleManager = new RoleManager<Golfer>(new FakeRoleStore(), roleValidators, 
                                                      _lookup, _errorDescriber,
                                                      roleLogger, accessor);
            var claimsFactory = new UserClaimsPrincipalFactory<Golfer, Golfer>(UserManager, roleManager, _options);
            var logger = new LoggerFactory().CreateLogger<SignInManager<Golfer>>();
            var manager = new SignInManager<Golfer>(UserManager, accessor, claimsFactory, _options, logger);

            return manager;
        }

        public UserManager<Golfer> UserManager { get; protected set; }
        public SignInManager<Golfer> SignInManager { get; protected set; }

        private readonly Db<LeagueDb> _db;
        private readonly IServiceProvider _provider;
        private GolferStore _store;
        private IOptions<IdentityOptions> _options;
        private UpperInvariantLookupNormalizer _lookup;
        private IdentityErrorDescriber _errorDescriber;
        private ILoggerFactory _loggerFactory;
    }
}
