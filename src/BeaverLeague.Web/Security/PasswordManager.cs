using System;
using BeaverLeague.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace BeaverLeague.Web.Security
{
    public class PasswordManager
    {
        public PasswordManager()
        {
            _hasher = new PasswordHasher<Golfer>();
        }

        public Golfer SetPassword(Golfer golfer, string password)
        {
            golfer.PasswordHash = _hasher.HashPassword(golfer, password);     
            return golfer;
        }

        public bool VerifyPassword(Golfer golfer, string password)
        {
            var result = _hasher.VerifyHashedPassword(golfer, golfer.PasswordHash, password);
            if (result == PasswordVerificationResult.SuccessRehashNeeded)
            {
                throw new Exception("Password rehash needed");
            }
            if (result == PasswordVerificationResult.Success)
            {
                return true;
            }
            return false;
        }

        private IPasswordHasher<Golfer> _hasher;
    }
}
