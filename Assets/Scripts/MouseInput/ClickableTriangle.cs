using UnityEngine;

public class ClickableTriangle : MonoBehaviour, IClickable
{
    public void CustomOnMouseDown()
    {
        print($"I ({gameObject.name}) was clicked");
    }
}
