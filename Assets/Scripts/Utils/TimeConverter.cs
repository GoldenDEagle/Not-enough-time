using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    public class TimeConverter
    {
        // returns time in 00:00
        public static string FormattedTime(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            return formattedTime;
        }
    }
}