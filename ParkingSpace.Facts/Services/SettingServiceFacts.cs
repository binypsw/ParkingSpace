using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingSpace.Models;
using ParkingSpace.Services;

namespace ParkingSpace.Facts.Services {
  public class SettingServiceFacts {
    public class CurrentProperty {
      [Fact]
      public void FirstCall_CreateNewSetting() {
        using (var app = new App(testing: true)) {
          Assert.Equal(0, app.Settings.All().Count());

          var s = app.Settings.Current;

          Assert.NotNull(s);
          Assert.Equal(1, app.Settings.All().Count());
        }
      }

      [Fact]
      public void SecondCall_GetTheSameSetting() {
        using (var app = new App(testing: true)) {

          var s1 = app.Settings.Current;
          var s2 = app.Settings.Current;
          
          Assert.Same(s1, s2);
        }
      }
    }
  }
}
