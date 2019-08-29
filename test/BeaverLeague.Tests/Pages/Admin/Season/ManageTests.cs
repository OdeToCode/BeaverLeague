using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using static BeaverLeague.Tests.Pages.Admin.Season.ManageTests;

namespace BeaverLeague.Tests.Pages.Admin.Season
{
    public class ManageTests : IClassFixture<ManageTestsWebFactory>
    {
        private readonly ManageTestsWebFactory factory;

        public ManageTests(ManageTestsWebFactory factory)
        {
            this.factory = factory;
        }

        [Fact]
        public void DisplaysCurrentSeasonName()
        {

        }

        public class ManageTestsWebFactory : BeaverLeagueWebFactory { }
    }
}
