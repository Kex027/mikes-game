using System;
using System.Collections;
using System.Collections.Generic;
using Camera;
using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cameraText;

    private void FixedUpdate()
    {
        cameraText.text = "cam: " + CameraSwitch.Instance.GetCurrentCamera();
    }
}
