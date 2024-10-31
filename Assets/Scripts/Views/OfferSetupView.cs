using UnityEngine;
using TMPro;
using Zenject;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class OfferSetupView : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private Button plusButton, minusButton;
    [Space(10)]
    [SerializeField] private TMP_InputField titleText;
    [SerializeField] private TMP_InputField descriptionText;
    [SerializeField] private TextMeshProUGUI itemsCountText;
    [SerializeField] private TMP_InputField[] itemsQuantityText;
    [SerializeField] private TMP_Dropdown[] itemsDropdown;
    [SerializeField] private TMP_InputField offerPriceText;
    [SerializeField] private TMP_InputField discountPriceText;
    [SerializeField] private TMP_Dropdown offerImgDropdown;

    [Inject] private OfferSetupController _offerSetupController;

    public void ShowView()
    {
        _view.SetActive(true);
    }

    public void HideView()
    {
        _view.SetActive(false);
    }

    public void SetView(string title, string description, Item[] items, string price, string discountedPrice, int imageId)
    {
        titleText.text = title;
        descriptionText.text = description;
        UpdateItems(items);
        offerPriceText.text = price;
        discountPriceText.text = discountedPrice;
        offerImgDropdown.value = imageId;
    }

    public void UpdateItems(Item[] items)
    {
        itemsCountText.text = items.Length.ToString();
        for (int i = 0; i < items.Length; i++)
        {
            itemsDropdown[i].gameObject.SetActive(true);
            itemsQuantityText[i].text = items[i].quantity.ToString();
            itemsDropdown[i].value = items[i].icoID;
        }
        for (int i = items.Length; i < itemsDropdown.Length; i++)
        {
            itemsDropdown[i].gameObject.SetActive(false);
        }
        plusButton.interactable = items.Length != 6;
        minusButton.interactable = items.Length != 3;
    }

    public void QuantityInput(int id)
    {
        _offerSetupController.SetQuantity(id, itemsQuantityText[id].text.ToString());
    }

    public void ItemInput(int id)
    {
        _offerSetupController.SetItem(id, itemsDropdown[id].value);
    }
}