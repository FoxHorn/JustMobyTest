using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

public class GameView : MonoBehaviour
{
    [SerializeField] private GameObject purchasingVFXPrefab;
    [SerializeField] private float vfxTimeDelay;

    [Inject] OfferController offerController;

    private void OnEnable()
    {
        offerController.OnPurchaseAction += OnPurchase;
    }

    private void OnDisable()
    {
        offerController.OnPurchaseAction -= OnPurchase;
    }


    //Просто пример использования UniTask
    private async void OnPurchase()
    {
        GameObject vfx = Instantiate(purchasingVFXPrefab);
        await UniTask.Delay((int)(vfxTimeDelay * 1000));
        Destroy(vfx);
    }
}
