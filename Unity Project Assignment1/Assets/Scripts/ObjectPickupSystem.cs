using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ObjectPickupSystem : MonoBehaviour
{
    public Transform objectHolder;

    public float pickUpRange;
    public LayerMask pickUpLayer;

    private GameObject currentObject;
    private Rigidbody currentObjectRb;

    private float currentThrowForce;
    public float maxThrowForce;
    public float throwForceIncreaseSpeed;

    public TextMeshProUGUI pickUpText;

    public Slider throwBar;

    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
        throwBar.gameObject.SetActive(false);
        throwBar.maxValue = maxThrowForce;
    }
    private void Update()
    {
        PickUp();
        Throw();
    }

    private void PickUp()
    {
        if(currentObject != null)
        {
            return;
        }

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, pickUpRange, pickUpLayer))
        {
            pickUpText.gameObject.SetActive(true);
            pickUpText.text = hitInfo.collider.gameObject.name;

            if (Input.GetKeyDown(KeyCode.E)){
                currentObject = hitInfo.collider.gameObject;
                currentObjectRb = currentObject.GetComponent<Rigidbody>();

                currentObject.transform.parent = objectHolder;
                currentObject.transform.localPosition = Vector3.zero;
                currentObject.transform.localEulerAngles = Vector3.zero;

                foreach (Collider collider in currentObject.GetComponents<Collider>())
                {
                    collider.enabled = false;
                }
                //foreach (Collider collider in currentObject.GetComponentsInChildren<Collider>())
                //{
                //    collider.enabled = false;
                //}

                currentObjectRb.isKinematic = true;
            }

        }
        else
        {
            pickUpText.gameObject.SetActive(false);
            pickUpText.text = "";
        }
    }

    private void Throw()
    {
        if (currentObject == null)
        {
            return;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            throwBar.gameObject.SetActive(true);

            if(currentThrowForce <= maxThrowForce)
            {
                currentThrowForce += throwForceIncreaseSpeed * Time.deltaTime;
                throwBar.value = currentThrowForce;
            }
        }

        if (currentThrowForce > maxThrowForce)
        {
            currentThrowForce = maxThrowForce;
        }

        if (Input.GetKeyUp(KeyCode.Q))
        {
            currentObject.transform.parent = null;

            currentObjectRb.isKinematic = false;
            currentObjectRb.AddForce(currentObject.transform.forward * currentThrowForce, ForceMode.Impulse);

            foreach (Collider collider in currentObject.GetComponents<Collider>())
            {
                collider.enabled = true;
            }
            //foreach (Collider collider in currentObject.GetComponentsInChildren<Collider>())
            //{
            //    collider.enabled = true;
            //}

            currentObject = null;
            currentObjectRb = null;

            currentThrowForce = 0;
            throwBar.value = 0;
            throwBar.gameObject.SetActive(false);
        }
    }

}
