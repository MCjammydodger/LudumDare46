using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.GetComponent<Projectile>() != null)
        {
            gameObject.SetActive(false);
        }
    }
}
