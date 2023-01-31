using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Data
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;

        private bool _timeIsRunning = false;

        public static GameSession Instance { get; private set; }

        public PlayerData Data => _data;
        public bool TimeIsRunning => _timeIsRunning;


        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
                Instance = this;
            }
        }

        private void Update()
        {
            // Count time if game is active
            if (!_timeIsRunning) return;

            _data.RemainingTime -= Time.deltaTime;
        }

        // Switch game state
        public void SwitchTimer(bool isRunning)
        {
            _timeIsRunning = isRunning;
        }
    }
}