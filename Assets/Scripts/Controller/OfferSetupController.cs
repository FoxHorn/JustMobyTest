using System;
using UnityEngine;
using Zenject;

public class OfferSetupController : MonoBehaviour
{
    [SerializeField] private OfferModelSO defaultOffer1, defaultOffer2;

    [Inject] private OfferModel _offerModel;
    [Inject] private OfferSetupView _offerSetupView;
    [Inject] private OfferController _offerController;

    private bool isCurrentPresetFirst = true;

    public void Init()
    {
        SetupViewWithOffer1();
        _offerSetupView.ShowView();
    }

    public void SetTitle(string title)
    {
        _offerModel.title = title;
    }

    public void SetDescription(string description)
    {
        _offerModel.description = description;
    }

    public void SetQuantity(int id, string quantity)
    {
        if (!int.TryParse(quantity, out int quantityCount)) quantityCount = 0;
        _offerModel.items[id].quantity = quantityCount;
    }

    public void SetItem(int id, int icoID)
    {
        _offerModel.items[id].icoID = icoID;
    }

    public void SetOfferPrice(string price)
    {
        if (!int.TryParse(price, out int priceCount)) priceCount = 0;
        _offerModel.price = priceCount;
    }

    public void SetDiscountPrice(string dicount)
    {
        if (!int.TryParse(dicount, out int dicountPrice)) dicountPrice = 0;
        _offerModel.discountedPrice = dicountPrice;
    }

    public void SetOfferImg(int imgID)
    {
        _offerModel.imageId = imgID;
    }

    public void SetupViewWithOffer1()
    {
        _offerModel.SetModel(defaultOffer1);

        Item[] newItems = new Item[defaultOffer1.items.Length];
        Array.Copy(defaultOffer1.items, newItems, defaultOffer1.items.Length);

        _offerSetupView.SetView(defaultOffer1.title, defaultOffer1.description, newItems, defaultOffer1.price.ToString(), defaultOffer1.discountedPrice.ToString(), defaultOffer1.imageId);
        isCurrentPresetFirst = true;
    }

    public void SetupViewWithOffer2()
    {
        _offerModel.SetModel(defaultOffer2);

        Item[] newItems = new Item[defaultOffer2.items.Length];
        Array.Copy(defaultOffer2.items, newItems, defaultOffer2.items.Length);

        _offerSetupView.SetView(defaultOffer2.title, defaultOffer2.description, newItems, defaultOffer2.price.ToString(), defaultOffer2.discountedPrice.ToString(), defaultOffer2.imageId);
        isCurrentPresetFirst = false;
    }

    public void ButtonItemAdd()
    {
        if (_offerModel.TryAddItem()) _offerSetupView.UpdateItems(_offerModel.items);
    }

    public void ButtonItemRemove()
    {
        if (_offerModel.TryRemoveItem()) _offerSetupView.UpdateItems(_offerModel.items);
    }

    public void ButtonReset()
    {
        if (isCurrentPresetFirst) SetupViewWithOffer1();
        else SetupViewWithOffer2();
    }

    public void ButtonNext()
    {
        _offerSetupView.HideView();
        _offerController.Init();
    }
}