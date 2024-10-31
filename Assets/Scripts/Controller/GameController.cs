using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    [Inject] private OfferSetupController _offerSetupController;

    public void ButtonOffer()
    {
        _offerSetupController.Init();
    }
}
