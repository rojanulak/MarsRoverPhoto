using System;

namespace MarsRover.Core
{
    public static class DateTimeExtension
    {

        public static DateTime ParseDateTime(string date)
        {
            return !DateTime.TryParse(date, out var result) ? DateTime.MinValue : result;
        }

    }
}
