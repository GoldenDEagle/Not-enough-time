using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.TimeManipulation
{
    public class TimerSwitch : MonoBehaviour
    {
        public void Switch()
        {
            if (GameSession.Instance.TimeIsRunning)
                GameSession.Instance.SwitchTimer(false);
            else
            {
                GameSession.Instance.SwitchTimer(true);
            }
        }
    }
}