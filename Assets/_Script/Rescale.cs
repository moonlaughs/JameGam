using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescale : MonoBehaviour
{
    [SerializeField] GameObject Anvil;
    [SerializeField] Transform Hand;
    Rigidbody rb;
    public bool isPickedUp;
    public bool isScaled = false;
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
            if (isPickedUp)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit) && isScaled)
                {
                    Anvil.transform.localScale = new Vector3(20, 150, 75);
                    rb.mass = 5;
                    isScaled = false;
                }else if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit) && isHolding == false)
                {
                    Anvil.transform.localScale = new Vector3(40, 300, 150);
                    rb.mass += 200;
                    isScaled = true;
                }
            }

        }
    }
}
