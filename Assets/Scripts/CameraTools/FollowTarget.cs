using Assets.Scripts.Characters.Player;
using Cinemachine;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.CameraTools
{
    public class FollowTarget : MonoBehaviour
    {
        private Transform _targetToFollow;
        private CinemachineFreeLook _cinemachineCamera;

        [Inject]
        private void Construct(PlayerController playerController)
        {
            _targetToFollow = playerController.transform;
        }

        private void Awake()
        {
            _cinemachineCamera = GetComponent<CinemachineFreeLook>();
        }

        private void Start()
        {
            _cinemachineCamera.Follow = _targetToFollow;
            _cinemachineCamera.LookAt = _targetToFollow;
        }
    }
}