using UnityEngine;
using Zenject;

public class ZenjectInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<OfferModel>().AsSingle();
        Container.Bind<GameView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<GameController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<OfferSetupView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<OfferSetupController>().FromComponentInHierarchy().AsSingle();
        Container.Bind<OfferView>().FromComponentInHierarchy().AsSingle();
        Container.Bind<OfferController>().FromComponentInHierarchy().AsSingle();
    }
}
