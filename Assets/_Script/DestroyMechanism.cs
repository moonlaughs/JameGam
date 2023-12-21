using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject Anvil;
    [SerializeField] Transform Hand;
    Rigidbody rb;
    public bool isHolding = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = Anvil.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LiftItem();
    }

    // main method + isTrigger = true on collider component on Santa object
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Santa"))
        {
            Destroy(other.gameObject);
        }
    }

    // borrowed logic
    void LiftItem()
    {
        RaycastHit hit;
        if (Input.GetKeyDown("e"))
        {
            if (isHolding == false)
            {
                Anvil.transform.SetParent(Hand);
                rb.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
                rb.isKinematic = true;
                isHolding = true;
            }
            else
            {
                Anvil.transform.SetParent(null);
                rb.isKinematic = false;
                isHolding = false;
            }
        }
    }
}
