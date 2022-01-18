using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Item : MonoBehaviour
{
   public enum ItemType
    {
        wood,
        storn,
        ThrowAxe
    }
    [SerializeField] private ItemType type;

    public void Initialize()
    {
        var colliderCache = GetComponent<Collider>();
        colliderCache.enabled = false;

        var transformCache = transform;
        var dropPsition = transform.localPosition +
            new Vector3(Random.Range(-1f, 1), 0, Random.Range(
                -1f, 1f));

        transformCache.DOLocalMove(dropPsition,0.5f);

        var defaultScene = transformCache.localScale;

        transformCache.localScale = Vector3.zero;

        transformCache.DOScale(defaultScene, 0.5f).SetEase
            (Ease.OutBounce).OnComplete(() => 
            {
                colliderCache.enabled = true;
            });
    }
    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        OwnedItemsDate.Instance.Add(type);
        OwnedItemsDate.Instance.Save();
        foreach (var item in OwnedItemsDate.Instance.OwnedItems)
        {
            Debug.Log(item.Type + "を"　+ item.Number + "個所持");
        }
        Destroy(gameObject);
    }

}
