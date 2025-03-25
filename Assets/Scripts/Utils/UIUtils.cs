using UnityEngine.UIElements;

public static class UIUtils
{
    const int DOUBLE_CLICK = 2;
    public static bool IsDoubleClick(ClickEvent clickEvent)
    {
        return clickEvent != null && clickEvent.clickCount >= DOUBLE_CLICK;
    }
}
