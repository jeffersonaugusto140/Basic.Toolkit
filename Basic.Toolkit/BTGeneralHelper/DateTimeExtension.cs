using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Formata para dd/MM/yyyy.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDDMMYYYY(this DateTime? dateTime)
        {
            if (dateTime == null)
                return "";
            return dateTime.Value.ToString("dd/MM/yyyy");
        }
        
        /// <summary>
        /// Muda o horário para 23:59:59
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime RoundTo235959(this DateTime dateTime)
        {
            return dateTime.Round(new TimeSpan(0, 23, 59, 59));
        }

        /// <summary>
        /// Muda o horário para 00:00:00
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime RoundTo000000(this DateTime dateTime)
        {
            return dateTime.Round(new TimeSpan(0, 0, 0, 0));
        }

        /// <summary>
        /// Muda horário conforme TimeSpan informado.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public static DateTime Round(this DateTime dateTime, TimeSpan timeSpan)
        {
            return dateTime.AddTicks(timeSpan.Ticks - dateTime.TimeOfDay.Ticks);
        }
    }
}
