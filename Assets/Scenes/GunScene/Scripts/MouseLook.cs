using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 290f;
    public Transform playerBody;
    public Transform weapon;
    float xRotation = 0f;

    public bool isAbleToInteract;
    public Image Interaction;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        isAbleToInteract = false;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        weapon.localRotation = Quaternion.Euler(weapon.localRotation.x, 90f, xRotation);
        weapon.localPosition.Set(weapon.localPosition.x, xRotation, weapon.localPosition.z);

        UpdateHighlights();

        playerBody.Rotate(Vector3.up * mouseX);
    }

    void UpdateHighlights()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.collider.tag == "Selectable")
            {
                isAbleToInteract = true;
                UpdateInstance(hit.collider, null, true);
            }
            else
            {
                isAbleToInteract = false;
                var objects = GameObject.FindGameObjectsWithTag("Selectable");
                foreach(var item in objects)
                {
                    UpdateInstance(null, item, false);
                }
                Interaction.fillAmount = 0;
            }
        }
    }

    void UpdateInstance(Collider collider, GameObject item, bool Selected)
    {
        if(item != null || collider != null)
        {
            if((item != null && item.GetComponent<InstanceData>().Name == "Plank")
            || (collider != null && collider.GetComponent<InstanceData>().Name == "Plank"))
            {
                if(Selected)
                {
                    collider.GetComponent<Outline>().enabled = true;
                    collider.GetComponent<Highlight>()?.ToggleHighlight(true);
                    collider.GetComponent<RemovePlank>().enabled = true;
                    collider.GetComponent<TitleHandler>().Scaling = true;
                }
                else
                {
                    item.GetComponent<Outline>().enabled = false;
                    item.GetComponent<Highlight>()?.ToggleHighlight(false);
                    item.GetComponent<RemovePlank>().enabled = false;
                    item.GetComponent<TitleHandler>().Scaling = false;
                }
            }
        } 
    }
}
