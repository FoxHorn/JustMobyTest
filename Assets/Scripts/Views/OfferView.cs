using System.Diagnostics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OfferView : MonoBehaviour
{
    [SerializeField] private GameObject _view;
    [SerializeField] private Sprite[] itemSprites;
    [SerializeField] private Sprite[] offerSprites;
    [Space(10)]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private Image[] itemsImage;
    [SerializeField] private TextMeshProUGUI[] itemsQuantityText;
    [SerializeField] private TextMeshProUGUI offerPriceText;
    [SerializeField] private GameObject discountPercentObject;
    [SerializeField] private TextMeshProUGUI discountPercentText;
    [SerializeField] private Image offerImage;

    private float GetDiscountPercent(float price, float discountPrice)
    {
        if (discountPrice == 0) return 100f;
        else return -((price - discountPrice) / price * 100);
    }

    public void ShowView()
    {
        _view.SetActive(true);
    }

    public void HideView()
    {
        _view.SetActive(false);
    }

    public void SetupView(string title, string description, Item[] items, float price, float discountedPrice, int imageId)
    {
        titleText.text = title;
        descriptionText.text = description;

        foreach (Image itemImage in itemsImage)
        {
            itemImage.gameObject.SetActive(false);
        }

        switch (items.Length)
        {
            case 4:
                itemsImage[0].gameObject.SetActive(true);
                itemsImage[0].sprite = itemSprites[items[0].icoID];
                itemsQuantityText[0].text = items[0].quantity.ToString();
                itemsImage[1].gameObject.SetActive(true);
                itemsImage[1].sprite = itemSprites[items[1].icoID];
                itemsQuantityText[1].text = items[1].quantity.ToString();
                itemsImage[3].gameObject.SetActive(true);
                itemsImage[3].sprite = itemSprites[items[2].icoID];
                itemsQuantityText[3].text = items[2].quantity.ToString();
                itemsImage[4].gameObject.SetActive(true);
                itemsImage[4].sprite = itemSprites[items[3].icoID];
                itemsQuantityText[4].text = items[3].quantity.ToString();
                break;
            default:
                for (int i = 0; i < items.Length; i++)
                {
                    itemsImage[i].gameObject.SetActive(true);
                    itemsImage[i].sprite = itemSprites[items[i].icoID];
                    itemsQuantityText[i].text = items[i].quantity.ToString();
                }
                break;
        }

        if (price == discountedPrice)
        {
            discountPercentObject.SetActive(false);
            offerPriceText.text = "$" + price.ToString("0.00");
        }
        else
        {
            float percent = GetDiscountPercent(price, discountedPrice);
            discountPercentObject.SetActive(true);
            discountPercentText.text = (percent > 0 ? "+" : "") + percent.ToString("0") + "%";
            offerPriceText.text = "$" + discountedPrice.ToString("0.00") + "<br>" + "<size=18><s>$ " + price + "</s></size>";
        }
    }
}
