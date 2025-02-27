using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument itemSelector;

    [SerializeField]
    private List<ItemSetting> itemSettings = new();

    private ScrollView view;
    
    void Awake()
    {
        view = itemSelector.rootVisualElement.Q<ScrollView>();
        
        // ラジオボタンを初期化
        var radioButtonGroup = itemSelector.rootVisualElement.Q<RadioButtonGroup>();
        radioButtonGroup.choices = itemSettings.ConvertAll(item => item.Name);
        radioButtonGroup.value = 0;

        // 選択時のイベント
        radioButtonGroup.RegisterCallback<ChangeEvent<int>>((e) =>
        {
            radioButtonGroup.value = e.newValue;

            // 選択されたら非表示に
            // view.style.display = DisplayStyle.None;
        });

        // ラジオボタンの設定
        var radioButtons = radioButtonGroup.Children();
        for (int i = 0; i < itemSettings.Count; ++i) {
            var radioButton = radioButtons.ElementAt(i) as RadioButton;
            radioButton.style.backgroundImage = itemSettings[i].Icon;
        }
    }
}
