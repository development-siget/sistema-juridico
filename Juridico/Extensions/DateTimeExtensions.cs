using System;
using Juridico.Data;

namespace Juridico.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime AddWorkDays(this DateTime originalDate, int workDate, JuridicoDbContext context)
        {
            var tempDate = originalDate;
            while (workDate > 0)
            {
                tempDate = tempDate.AddDays(1);
                if (tempDate.DayOfWeek < DayOfWeek.Saturday && 
                    tempDate.DayOfWeek > DayOfWeek.Sunday)
                {
                    workDate--;
                }
            }
            return tempDate;
        }
    }
}