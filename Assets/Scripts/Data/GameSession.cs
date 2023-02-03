using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Data
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;

        // runs if game is active
        private bool _timeIsRunning = false;

        public static GameSession Instance { get; private set; }

        // destroyed items storage
        private readonly List<string> _removedItems = new List<string>();

        public PlayerData Data => _data;
        public bool TimeIsRunning => _timeIsRunning;


        private void Awake()
        {
            if (Instance != null)
            {
                LoadHUD();
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
                Instance = this;

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
                _data.RemainingTime = _data.TotalTime;
                SceneManager.LoadScene("ApartmentKit");
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