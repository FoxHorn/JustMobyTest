using UnityEngine;

[CreateAssetMenu(fileName = "OfferModel", menuName = "ScriptableObjects/SpawnOfferModelSO", order = 1)]
public class OfferModelSO : ScriptableObject
{
    [TextArea(1, 1)] public string title;
    [TextArea(3, 3)] public string description;
    public Item[] items;
    public float price;
    public float discountedPrice;
    public int imageId;
}