using System;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    private Camera camera;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldSpaceClick = camera.ScreenToWorldPoint(Input.mousePosition);

            Collider2D[] colliders = Physics2D.OverlapPointAll(worldSpaceClick);
            foreach (Collider2D collider in colliders)
            {
                collider.GetComponent<IClickable>()?.CustomOnMouseDown();
            }
        }
    }
}
