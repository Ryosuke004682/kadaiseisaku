using System;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Button))]

public class ItemButton : MonoBehaviour
{
    public OwnedItemsDate.OwnedItem OwnedItem
    {
        get
        {
            return _ownedItem;
        }
        set
        {
            _ownedItem = value;
            //アイテムを割り当てられたかどうかでアイテム画像や取得個数の表示を切り替える

            var isEmpty = null == _ownedItem;
            image.gameObject.SetActive(!isEmpty);
            number.gameObject.SetActive(!isEmpty);
            _button.interactable = !isEmpty;

            if (!isEmpty)
            {
                image.sprite = itemSprites.First(x => x.itemType == _ownedItem
                .Type).sprite;
                number.text = "" + _ownedItem.Number;
            }
        }
    }
    //各アイテム用の画像を指定するフィールド
    [SerializeField] private ItemTypeSpriteMap[] itemSprites;
    [SerializeField] private Image image;
    [SerializeField] private Text number;

    private Button _button;
    private OwnedItemsDate.OwnedItem _ownedItem;

    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        //TODO ボタンを押したときの処理
    }

    [Serializable]
    public class ItemTypeSpriteMap
    {
        public Item.ItemType itemType;
        public Sprite sprite;
    }


}
