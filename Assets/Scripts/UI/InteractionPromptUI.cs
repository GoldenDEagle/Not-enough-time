using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class InteractionPromptUI : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _promptText;

        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
            gameObject.SetActive(false);
        }

        private void LateUpdate()
        {
            var rotation = Camera.main.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.forward, rotation * Vector3.up);
        }

        public void ShowPrompt(string prompt)
        {
            gameObject.SetActive(true);
            _promptText.text = prompt;
        }
    }
}