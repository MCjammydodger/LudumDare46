using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    private bool activated = false;

    public Vector3 targetPosition;

    public float lerpSpeed = 1;

    private Vector3 startPosition;

    public float lerpValue = 0;

    public bool IsActivated()
    {
        return activated;
    }
    public void Activate()
    {
        activated = true;
    }
    private void Start()
    {
        activated = false;
        startPosition = transform.localPosition;
    }
    private void Update()
    {
        if(activated)
        {
            lerpValue += lerpSpeed * Time.deltaTime;
        }

        transform.localPosition = Vector3.Lerp(startPosition, targetPosition, lerpValue);
    }
}
