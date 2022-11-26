using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField]
    Camera mainCamera;

    [SerializeField]
    float amountToZoom = 10f;

    [SerializeField]
    float zoomInSensitivity = .5f;

    float originalZoom;
    float originalXSensitivity;
    float originalYSensitivity;
    RigidbodyFirstPersonController mainController;

    void Start()
    {
        mainController = GetComponent<RigidbodyFirstPersonController>();
        originalZoom = mainCamera.fieldOfView;
        originalXSensitivity = mainController.mouseLook.XSensitivity;
        originalYSensitivity = mainController.mouseLook.YSensitivity;
    }

    void Update()
    {
        Zoom();
    }

    public void Zoom()
    {
        if (Input.GetMouseButton(1))
        {
            mainCamera.fieldOfView = amountToZoom;
            mainController.mouseLook.XSensitivity = zoomInSensitivity;
            mainController.mouseLook.YSensitivity = zoomInSensitivity;
        }
        else
        {
            mainCamera.fieldOfView = originalZoom;
            mainController.mouseLook.XSensitivity = originalXSensitivity;
            mainController.mouseLook.YSensitivity = originalYSensitivity;
        }
    }
}
