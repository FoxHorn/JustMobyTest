using UnityEngine;
using Cysharp.Threading.Tasks;

public class DelayDestroyer : MonoBehaviour
{
    [SerializeField] private float timeDelay;

    private void Start()
    {
        DestroyObjectAfterDelay();
    }

   private async void DestroyObjectAfterDelay()
    {
        await UniTask.Delay((int)(timeDelay * 1000));
        Destroy(gameObject);
    }
}