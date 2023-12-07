using UnityEngine;

public class ClickableBox : MonoBehaviour, IClickable
{
    public void CustomOnMouseDown()
    {
        print($"I ({gameObject.name}) was clicked");
    }
}
