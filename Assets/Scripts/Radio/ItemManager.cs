using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument ItemSelector;

    [SerializeField]
    private List<ItemSetting> ItemSettings = new();
    
    void Awake()
    {
        var listView = ItemSelector.rootVisualElement.Q<ListView>();

        // 選択するデータの指定
        listView.itemsSource = ItemSettings;

        // リストの要素作成時の処理
        listView.makeItem = () => {
            var button = new RadioButton();
            // Radioボタンにussのクラスを追加
            button.AddToClassList(ItemSetting.ButtonClassName);
            return button;
        };

        // 要素の対応
        listView.bindItem = (e, i) => {
            RadioButton button = e as RadioButton;
            button.label = ItemSettings[i].Name;
            button.style.backgroundImage = ItemSettings[i].Icon;
        };

    }
}
