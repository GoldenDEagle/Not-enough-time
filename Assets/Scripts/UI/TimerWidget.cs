using Assets.Scripts.Data;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TimerWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private void Start()
        {
            SetTimer(GameSession.Instance.Data.RemainingTime);
        }

        void Update()
        {
            // Updates timer if game is active
            if (!GameSession.Instance.TimeIsRunning)
                return;

            SetTimer(GameSession.Instance.Data.RemainingTime);
        }

        private void SetTimer(float time)
        {
            int minutes = Mathf.FloorToInt(time / 60f);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);

            _timerText.text = niceTime;
        }
    }
}