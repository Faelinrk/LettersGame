using Builders;
using GameSettings;
using UnityEngine;
using View;
using Zenject;

namespace Installers
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private CellObject _cellPrefab;
        [SerializeField] private CommonSettings _gameSettings;
        public override void InstallBindings()
        {
            Container.Bind<CommonSettings>().FromScriptableObject(_gameSettings).AsCached();
            Container.Bind<CellObject>().FromComponentOn(_cellPrefab.gameObject).AsCached();
            Container.Bind<AreaBuilder>().AsSingle();
            Container.Bind<CellFactory>().AsSingle();
            Container.Bind<RuleCorrector>().AsSingle().NonLazy();
        }
    }
}