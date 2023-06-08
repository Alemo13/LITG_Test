using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 5f;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;
    private PlayerManager playerManager;
    void Start()
    {
        cam = GetComponent<PlayerCamera>().cam;
        playerUI = GetComponent<PlayerUI>();
        playerManager = GetComponent<PlayerManager>();

    }
    void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask)){
            if(hitInfo.collider.GetComponent<Interactable>() != null){
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
                playerUI.UpdateText(interactable.promptMessage);
                if(playerManager.interact.triggered){
                    interactable.BaseInteract();
                }
            }
        }
    }
}
