using Assets.Scripts.LevelManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Installers
{
    public class BootstrapInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _levelLoader;

        public override void InstallBindings()
        {
            BindLoader();
        }

        private void BindLoader()
        {
            var loader = Container
                .InstantiatePrefabResourceForComponent<LevelLoader>("LevelLoader", Vector3.zero, Quaternion.identity, null);

            Container.Bind<LevelLoader>()
                .FromInstance(loader)
                .AsSingle();
        }
    }
}
