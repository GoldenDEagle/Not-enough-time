using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.LevelManagement
{
    public class ExitLevelComponent : MonoBehaviour
    {
        [SerializeField] private string _sceneId;

        public void ExitLevel()
        {
            var loader = FindObjectOfType<LevelLoader>();
            loader.LoadLevel(_sceneId);
        }
    }
}