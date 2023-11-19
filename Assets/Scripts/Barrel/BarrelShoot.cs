using System.Collections;
using Camera;
using Interfaces;
using UnityEngine;

public class BarrelShoot : MonoBehaviour, IShootable
{
    private ParticleSystem _barrelParticleSystem;
    private Rigidbody _rb;
    private float _knockbackForce = 500f;
    private float _secondsToDestroy = 2f;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _barrelParticleSystem = GetComponentInChildren<ParticleSystem>();
    }
    
    private IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_secondsToDestroy);
        _rb.velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    public void Shoot(RaycastHit hit)
    {
        _rb.AddForce(-hit.normal * _knockbackForce);
        _barrelParticleSystem.Play();
        StartCoroutine(CameraShake.Instance.ShakeCamera(.4f, .2f));


        StartCoroutine(Destroy());
    }
}
