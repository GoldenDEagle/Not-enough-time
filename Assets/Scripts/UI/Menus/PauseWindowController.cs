using Assets.Scripts.Data;
using Assets.Scripts.LevelManagement;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Menus
{
    public class PauseWindowController : MonoBehaviour
    {
        private float _defaultTimeScale;

        private LevelLoader _loader;

        [Inject]
        private void Construct(LevelLoader loader)
        {
            _loader = loader;
        }

        private void Start()
        {
            _defaultTimeScale = Time.timeScale;
            Time.timeScale = 0f;
            Cursor.visible = true;
            GameSession.Instance.SwitchTimer(false);
        }

        public void OnContinue()
        {
            Cursor.visible = false;
            Time.timeScale = _defaultTimeScale;
            GameSession.Instance.SwitchTimer(true);
            Destroy(gameObject);
        }

        public void OnRestart()
        {
            Cursor.visible = false;
            Time.timeScale = _defaultTimeScale;
            GameSession.Instance.ResetTimer();
            //var loader = FindObjectOfType<LevelLoader>();
            _loader.LoadLevel("ApartmentKit");
        }

        public void OnExit()
        {
            Time.timeScale = _defaultTimeScale;
            //var loader = FindObjectOfType<LevelLoader>();
            _loader.LoadLevel("MainMenu");
            Destroy(gameObject);
        }
    }
}