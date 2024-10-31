using System;

public class OfferModel
{
    public string title;
    public string description;
    public Item[] items;
    public float price;
    public float discountedPrice;
    public int imageId;

    public void SetModel(OfferModelSO so)
    {
        Item[] newItems = new Item[so.items.Length];
        Array.Copy(so.items, newItems, so.items.Length);

        title = so.title;
        description = so.description;
        items = newItems;
        price = so.price;
        discountedPrice = so.discountedPrice;
        imageId = so.imageId;
    }

    public bool TryAddItem()
    {
        if (items.Length < 6)
        {
            Array.Resize(ref items, items.Length + 1);
            return true;
        }
        else return false;
    }

    public bool TryRemoveItem()
    {
        if (items.Length > 3)
        {
            Array.Resize(ref items, items.Length - 1);
            return true;
        }
        else return false;
    }
}

[Serializable]
public struct Item
{
    public int quantity;
    public int icoID;
}