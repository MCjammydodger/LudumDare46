using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public PlayerMovement playerMovement;

    public Projectile projectile;
    public float reloadTime = 1.0f;
    public float projectileVelocity = 10.0f;
    public Transform barrel;

    private float timeSinceShot;
    private Camera cam;
    private Vector3 targetPoint;

    private void Start()
    {
        cam = Camera.main;
        timeSinceShot = reloadTime;
    }
    private void OnGUI()
    {
        if (PlayerManager.instance.currentVehicle == playerMovement && !TimeController.instance.IsGameTimePaused())
        {
            Vector2 mousePos = Event.current.mousePosition;
            Ray ray = cam.ScreenPointToRay(new Vector3(mousePos.x, cam.pixelHeight - mousePos.y, 0));
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100f);
            targetPoint = hit.point;
            targetPoint.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
        }
    }
    private void Update()
    {
        if(Input.GetButton("Fire1") && timeSinceShot > reloadTime && PlayerManager.instance.currentVehicle == playerMovement && !TimeController.instance.IsGameTimePaused())
        {
            timeSinceShot = 0;
            Fire(targetPoint);
        }
        timeSinceShot += Time.deltaTime;
    }

    private void Fire(Vector3 target)
    {
        //float v = projectileVelocity;
        //float x = target.x - transform.position.x;
        //float y = target.y - transform.position.y;
        //float g = Physics.gravity.y;

        //float sqrt = Mathf.Sqrt(v * v * v * v - (g * ((g * x * x) + (2 * y * v * v))));
        //float angle = Mathf.Atan(((v * v) + sqrt) / (g * x));

        //Vector3 launchDir = target - barrel.position;
        //launchDir.y = 90 / angle;

        Vector3 launchDir = target - barrel.position;

        projectile.transform.position = barrel.position;
        projectile.gameObject.SetActive(true);
        projectile.Launch(launchDir.normalized, projectileVelocity);
    }
}
