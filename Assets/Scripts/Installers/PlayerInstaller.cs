using Assets.Scripts.Characters.Player;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        [SerializeField] private Transform _playerStartPosition;

        public override void InstallBindings()
        {
            PlayerController playerController = Container
                .InstantiatePrefabForComponent<PlayerController>(_playerPrefab, _playerStartPosition.position, Quaternion.identity, null);

            Container.Bind<PlayerController>()
                .FromInstance(playerController)
                .AsSingle();
        }
    }
}