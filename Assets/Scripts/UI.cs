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
// powinienes subskrybowac do eventa w starcie i tak zmeinaic