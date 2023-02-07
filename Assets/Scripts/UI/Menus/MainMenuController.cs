using Assets.Scripts.Data;
using Assets.Scripts.LevelManagement;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.Menus
{
    public class MainMenuController : MonoBehaviour
    {
        private LevelLoader _loader;

        [Inject]
        private void Construct(LevelLoader loader)
        {
            _loader = loader;
        }

        private void Start()
        {
            if (GameSession.Instance.gameObject != null)
                Destroy(GameSession.Instance.gameObject);
        }

        public void OnPlayPressed()
        {
            //var loader = FindObjectOfType<LevelLoader>();

            _loader.LoadLevel("ApartmentKit");
        }

        public void OnExit()
        {
            Application.Quit();

#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
    }
}
