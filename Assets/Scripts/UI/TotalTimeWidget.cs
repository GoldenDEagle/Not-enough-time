using Assets.Scripts.Data;
using Assets.Scripts.TimeManipulation;
using Assets.Scripts.Utils;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class TotalTimeWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textTime;

        private void OnEnable()
        {
            ModifyTimeAmount.OnTotalTimeChanged += UpdateView;
        }

        private void Start ()
        {
            UpdateView();
        }

        private void UpdateView()
        {
            float time = GameSession.Instance.Data.TotalTime;

            _textTime.text = TimeConverter.FormattedTime(time);
        }

        private void OnDisable()
        {
            ModifyTimeAmount.OnTotalTimeChanged -= UpdateView;
        }
    }
}