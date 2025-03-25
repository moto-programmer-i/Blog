using UnityEngine;
using UnityEngine.UIElements;

public class DoubleClick : MonoBehaviour
{
    const string DOUBLE_CLICK_BUTTON_NAME = "double-click-button";
    [SerializeField]
    private UIDocument document;

    void Awake()
    {
        var doubleClickButton = document.rootVisualElement.Q<Button>(DOUBLE_CLICK_BUTTON_NAME);
        doubleClickButton.RegisterCallback<ClickEvent>(e => {

            // ダブルクリック時
            if (UIUtils.IsDoubleClick(e)) {
                Debug.Log("ダブルクリック");
            }
        });
    }
}
