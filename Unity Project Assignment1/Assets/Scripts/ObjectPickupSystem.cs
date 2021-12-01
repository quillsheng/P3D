using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPickupSystem : MonoBehaviour
{
    public Transform objectHolder;

    public float pickUpRange;
    public LayerMask pickUpLayer;

    private GameObject currentObject;
    private Rigidbody currentObjectRb;
    private void Update()
    {
        PickUp();
    }

    private void PickUp()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, pickUpRange, pickUpLayer))
        {
            if (Input.GetKeyDown(KeyCode.P)){
                currentObject = hitInfo.collider.gameObject;
                currentObjectRb = currentObject.GetComponent<Rigidbody>();

                currentObject.transform.parent = objectHolder;
                currentObject.transform.localPosition = Vector3.zero;
                currentObject.transform.localEulerAngles = Vector3.zero;

                foreach (Collider collider in currentObject.GetComponents<Collider>())
                {
                    collider.enabled = false;
                }
                foreach (Collider collider in currentObject.GetComponentsInChildren<Collider>())
                {
                    collider.enabled = false;
                }

                currentObjectRb.isKinematic = true;
            }

        }
    }

}
