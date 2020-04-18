using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public GameObject intact;
    public GameObject destroyed;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<Projectile>() != null)
        {
            intact.SetActive(false);
            destroyed.SetActive(true);
        }
    }
}
