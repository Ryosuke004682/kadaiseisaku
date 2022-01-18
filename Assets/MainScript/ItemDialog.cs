using UnityEngine;

public class ItemDialog : MonoBehaviour
{
    [SerializeField] private int buttonNumber = 15;
    [SerializeField] private ItemButton itemButton;

    private ItemButton[] _itemButtons;

    private void Start()
    {
        gameObject.SetActive(false);
        for (var i = 0; i < buttonNumber - 1; i++)
        {
            Instantiate(itemButton , transform);
        }

        _itemButtons = GetComponentsInChildren<ItemButton>();

    }

    public void Toggle()
    {
        gameObject.SetActive(!gameObject.activeSelf);

        if (gameObject.activeSelf)
        {
            for (var i = 0; i < buttonNumber; i++)
            {
                _itemButtons[i].OwnedItem = OwnedItemsDate.Instance.OwnedItems
                    .Length > i ? OwnedItemsDate.Instance.OwnedItems[i] :
                    null;
            }
        }
    }

}
