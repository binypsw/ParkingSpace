using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingSpace.Services.Core {
  public static class SystemTime {
    public static Func<DateTime> Now = () => DateTime.Now;
    public static void SetDateTime(DateTime datetimeNow) {
      Now = () => datetimeNow;
    }

    public static void ResetNow(DateTime datetimeNow) {
      Now = () => DateTime.Now;
    }
  }
}
