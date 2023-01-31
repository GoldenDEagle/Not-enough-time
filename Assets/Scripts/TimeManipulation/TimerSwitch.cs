using Assets.Scripts.Data;
using UnityEngine;

namespace Assets.Scripts.TimeManipulation
{
    public class TimerSwitch : MonoBehaviour
    {
        public void Switch(bool enabled)
        {

            GameSession.Instance.SwitchTimer(enabled);

        }
    }
}