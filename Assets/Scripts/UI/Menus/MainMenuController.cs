using Assets.Scripts.Data;
using Assets.Scripts.LevelManagement;
using UnityEngine;

namespace Assets.Scripts.UI.Menus
{
    public class MainMenuController : MonoBehaviour
    {
        private void Start()
        {
            if (GameSession.Instance.gameObject != null)
                Destroy(GameSession.Instance.gameObject);
        }

        public void OnPlayPressed()
        {
            var loader = FindObjectOfType<LevelLoader>();

            loader.LoadLevel("ApartmentKit");
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
