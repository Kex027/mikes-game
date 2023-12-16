using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Camera
{
    public class CameraShake : MonoBehaviour
    {
        public static CameraShake Instance { get; private set; }
        private void Awake() 
        {
            if (Instance != null && Instance != this) 
            { 
                Destroy(this); 
            } 
            else 
            { 
                Instance = this;
            }
        }
        
        public IEnumerator ShakeCamera(float duration, float strength)
        {
            Vector3 startingPosition = transform.localPosition;
            
            float elapsed = 0f;
// tu powinien byc float x i y 
            while (elapsed < duration)
            {
                float x = Random.Range(1f, -1f) * strength; //a tu tylko przypisanie
                float y = Random.Range(1f, -1f) * strength;

                transform.localPosition = new Vector3(startingPosition.x + x, startingPosition.y + y, startingPosition.z);

                elapsed += Time.deltaTime;
                
                yield return null;
            }

            transform.localPosition = startingPosition;
        }
    }
}