using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Rigidbody rb;
    public ParticleSystem explosion;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    public void Launch(Vector3 direction, float velocity)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.AddForce(direction * velocity, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        explosion.transform.position = transform.position;
        explosion.gameObject.SetActive(true);
        explosion.Play();
    }
}
