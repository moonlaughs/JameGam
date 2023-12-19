using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescale : MonoBehaviour
{
    [SerializeField] GameObject Anvil;
    [SerializeField] GameObject Hand;
    Rigidbody rb;
    public bool isPickedUp;
    public bool isScaled;


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
            var ray = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
            if (isPickedUp == true && isScaled == false)
            {

            }
            else 
            {

            }
        }
    }

    void ScaleItem()
    {
        RaycastHit hit;
        if (Input.GetKeyDown("f"))
        {
            Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit);
            if (isPickedUp == true)
            {
                if (isScaled == true)
                {
                    Anvil.transform.localScale = new Vector3(1, 1, 1);
                    rb.mass = 5;
                    isScaled = false;
                }else
                {
                    Anvil.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                    rb.mass += 200;
                    isScaled = true;
                }
            }

        }
    }
}
