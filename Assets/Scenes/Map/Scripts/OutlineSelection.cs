using UnityEngine;

public class OutlineSelection : MonoBehaviour
{
    private Outline outline;
    public Camera mainCamera;

    private void Start()
    {
        outline = GetComponent<Outline>();
        // mainCamera = Camera.main;
    }

    private void Update()
    {
        if (Input.mousePosition.x >= 0 && Input.mousePosition.x <= Screen.width &&
            Input.mousePosition.y >= 0 && Input.mousePosition.y <= Screen.height)
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject)
                {
                    outline.enabled = true;
                }
                else
                {
                    outline.enabled = false;
                }
            }
            else
            {
                outline.enabled = false;
            }
        }
        else
        {
            outline.enabled = false;
        }
    }
}