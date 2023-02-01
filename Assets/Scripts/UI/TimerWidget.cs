using Assets.Scripts.Data;
using Assets.Scripts.TimeManipulation;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TimerWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private void OnEnable()
        {
            ModifyTimeAmount.OnTotalTimeChanged += UpdateTimerView;
        }

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
            _timerText.text = TimeConverter.FormattedTime(time);
        }

        private void UpdateTimerView()
        {
            if (GameSession.Instance.TimeIsRunning)
                return;
            SetTimer(GameSession.Instance.Data.RemainingTime);
        }

        private void OnDisable()
        {
            ModifyTimeAmount.OnTotalTimeChanged -= UpdateTimerView;
        }
    }
}