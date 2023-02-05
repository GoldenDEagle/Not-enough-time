using Assets.Scripts.LevelManagement;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Assets.Scripts.UI.Menus
{
    public class EndGameWindowController : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private TextMeshProUGUI _titlesText;
        [SerializeField] private CanvasGroup _exitButton;

        private void OnEnable()
        {
            Cursor.visible = true;
            Sequence sequence = DOTween.Sequence();
            sequence.Append(_background.DOFade(1f, 2f))
                .Append(_titlesText.DOFade(1f, 2f))
                .AppendInterval(2f)
                .Append(_exitButton.DOFade(1f, 2f));
        }

        public void OnExit()
        {
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel("MainMenu");
        }
    }
}