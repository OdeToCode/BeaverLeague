using System;
using System.Threading;
using System.Threading.Tasks;
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
                            
                                               
            GolferManager = CreateGolferManager();
            GolferSignInManager = CreateSignInManager();
        }

        private GolferManager CreateGolferManager()
        {
            _store = new GolferStore(_db.NewContext());
            _options = Options.Create(new IdentityOptions());
            _lookup = new UpperInvariantLookupNormalizer();
            _errorDescriber = new IdentityErrorDescriber();
            _loggerFactory = new LoggerFactory();
            var hasher = new PasswordHasher<Golfer>();
            var userValidators = new[] { new UserValidator<Golfer>() };
            var passwordValidators = new[] { new PasswordValidator<Golfer>() };
    
            var logger = _loggerFactory.CreateLogger<GolferManager>();
            var manager = new GolferManager(_store, _options, hasher, userValidators,
                                passwordValidators, _lookup, _errorDescriber, _provider, logger);
            return manager;
        }

        private GolferSignInManager CreateSignInManager()
        {
            var context = new DefaultHttpContext();
            context.Features.Set<IHttpAuthenticationFeature>(new HttpAuthenticationFeature() {  Handler = new FakeAuthenticationHandler() });
            var accessor = new HttpContextAccessor { HttpContext = context };
            var roleValidators = new[] {new RoleValidator<Golfer>()};
            var roleLogger = _loggerFactory.CreateLogger<RoleManager<Golfer>>();
            var roleManager = new RoleManager<Golfer>(new FakeRoleStore(), roleValidators, 
                                                      _lookup, _errorDescriber,
                                                      roleLogger, accessor);
            var claimsFactory = new UserClaimsPrincipalFactory<Golfer, Golfer>(GolferManager, roleManager, _options);
            var logger = new LoggerFactory().CreateLogger<SignInManager<Golfer>>();
            var manager = new GolferSignInManager(GolferManager, accessor, claimsFactory, _options, logger);

            return manager;
        }

        public GolferManager GolferManager { get; protected set; }
        public GolferSignInManager GolferSignInManager { get; protected set; }

        private readonly Db<LeagueDb> _db;
        private readonly IServiceProvider _provider;
        private GolferStore _store;
        private IOptions<IdentityOptions> _options;
        private UpperInvariantLookupNormalizer _lookup;
        private IdentityErrorDescriber _errorDescriber;
        private ILoggerFactory _loggerFactory;
    }

    class FakeAuthenticationHandler : IAuthenticationHandler
    {
        public void GetDescriptions(DescribeSchemesContext context)
        {
            throw new NotImplementedException();
        }

        public Task AuthenticateAsync(AuthenticateContext context)
        {
            context.NotAuthenticated();
            return Task.FromResult(0);
        }

        public Task ChallengeAsync(ChallengeContext context)
        {
            throw new NotImplementedException();
        }

        public Task SignInAsync(SignInContext context)
        {
            context.Accept();
            return Task.FromResult(0);
        }

        public Task SignOutAsync(SignOutContext context)
        {
            throw new NotImplementedException();
        }
    }

    class FakeRoleStore : IRoleStore<Golfer>
    {
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> CreateAsync(Golfer role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(Golfer role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(Golfer role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(Golfer role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(Golfer role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetRoleNameAsync(Golfer role, string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(Golfer role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(Golfer role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Golfer> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<Golfer> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
