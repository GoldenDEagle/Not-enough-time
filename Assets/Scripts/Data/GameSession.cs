using Assets.Scripts.LevelManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Data
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;

        // runs if game is active
        public bool _timeIsRunning = false;

        public static GameSession Instance { get; private set; }

        // destroyed items storage
        private readonly List<string> _removedItems = new List<string>();

        public PlayerData Data => _data;
        public bool TimeIsRunning => _timeIsRunning;

        private LevelLoader _loader;

        [Inject]
        private void Construct(LevelLoader loader)
        {
            _loader = loader;
        }

        private void Awake()
        {
            if (Instance != null)
            {
                Cursor.visible = false;
                LoadHUD();
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
                Instance = this;

                Cursor.visible = false;
                LoadHUD();
            }
        }

        private void Update()
        {
            // Count time if game is active
            if (!_timeIsRunning) return;

            _data.RemainingTime -= Time.deltaTime;
            if (_data.RemainingTime <= 0f)
            {
                SwitchTimer(false);
                ResetTimer();
                //var loader = FindObjectOfType<LevelLoader>();
                _loader.LoadLevel("ApartmentKit");
            }
        }

        // Switch game state
        public void SwitchTimer(bool isRunning)
        {
            _timeIsRunning = isRunning;
        }

        private void LoadHUD()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        public void ResetTimer()
        {
            _data.RemainingTime = _data.TotalTime;
        }

        public void StoreDestructionState(string itemId)
        {
            if (!_removedItems.Contains(itemId))
                _removedItems.Add(itemId);
        }

        public bool RestoreDestructionState(string itemId)
        {
            return _removedItems.Contains(itemId);
        }
    }
}