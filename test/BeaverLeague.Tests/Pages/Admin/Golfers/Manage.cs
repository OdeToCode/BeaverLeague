using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BeaverLeague.Tests.Pages.Admin.Golfers
{
    public class Manage
    {

        [Fact]
        public void GactoriesHaveDifferentNames()
        {
            Assert.NotEqual(new ManageWebFactory1().Name, new ManageWebFactory2().Name);
        }

        public class ManageWebFactory1 : BeaverLeagueWebFactory { }
        public class ManageWebFactory2 : BeaverLeagueWebFactory { }
    }
}
