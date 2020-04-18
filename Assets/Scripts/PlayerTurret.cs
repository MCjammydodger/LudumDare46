using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurret : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }
    private void OnGUI()
    {
        if (PlayerManager.instance.currentVehicle == playerMovement && !TimeController.instance.IsGameTimePaused())
        {
            Vector2 mousePos = Event.current.mousePosition;
            Ray ray = cam.ScreenPointToRay(new Vector3(mousePos.x, cam.pixelHeight - mousePos.y, 0));
            RaycastHit hit;
            Physics.Raycast(ray, out hit, 100f);
            Vector3 targetPoint = hit.point;
            targetPoint.y = transform.position.y;
            transform.rotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
        }
    }
    private void Update()
    {
        
    }
}
