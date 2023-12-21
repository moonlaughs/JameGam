using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescale : MonoBehaviour
{
    [SerializeField] GameObject Anvil;
    [SerializeField] Transform Hand;
    Rigidbody rb;
    public bool isPickedUp;
    public bool isScaled;
    public bool isHolding;


    private void Start()
    {
        rb = Anvil.GetComponent<Rigidbody>();
    }

    void Update()
    {
        LiftItem();
        ScaleItem();
    }

    private void OnTriggerEnter(Collider other)
    {
        isPickedUp = true;
        if (other.CompareTag("PickUp"))
        {
            Destroy(other.gameObject);
        }
    }

    void LiftItem()
    {
        RaycastHit hit;
        if (Input.GetKeyDown("e"))
        {
            if (isPickedUp && isScaled == false && isHolding == false && Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit))
            {
                Anvil.transform.SetParent(Hand);
                rb.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                rb.isKinematic = true;
                isHolding = true;
            }
            else if (isHolding == true)
            {
                Debug.Log("penus");
                Anvil.transform.SetParent(null);
                rb.isKinematic = false;
                isHolding = false;
            }
        }
    }

    void ScaleItem()
    {
        RaycastHit hit;
        if (Input.GetKeyDown("f"))
        {
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
            if (isPickedUp)
            {
                if (isScaled)
                {
                    Anvil.transform.localScale = new Vector3(1, 1, 1);
                    rb.mass = 5;
                    isScaled = false;
                }else if (isHolding == false)
                {
                    Anvil.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    rb.mass += 200;
                    isScaled = true;
                }
            }

        }
    }
}
