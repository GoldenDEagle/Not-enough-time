using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.LevelManagement
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _sceneId;

        private LevelLoader _loader;

        [Inject]
        private void Construct(LevelLoader loader)
        {
            _loader = loader;
        }

        public void ExitLevel()
        {
            //var loader = FindObjectOfType<LevelLoader>();
            _loader.LoadLevel(_sceneId);
        }
    }
}