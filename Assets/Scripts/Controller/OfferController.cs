using UnityEngine;
using UnityEngine.Events;
using Zenject;

public class OfferController : MonoBehaviour
{
    [Inject] OfferModel _offerModel;
    [Inject] OfferView _offerView;
    [Inject] GameController _gameController;

    //ѕросто пример использовани€ событий
    public UnityAction OnPurchaseAction;

    public void Init()
    {
        _offerView.SetupView(_offerModel.title, _offerModel.description, _offerModel.items, _offerModel.price, _offerModel.discountedPrice, _offerModel.imageId);
        _offerView.ShowView();
    }

    public void ButtonBuy()
    {
        _offerView.HideView();
        OnPurchaseAction?.Invoke();
    }
}
