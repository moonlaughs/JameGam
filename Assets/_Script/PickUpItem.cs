using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public bool isPickedUp;

    public bool getIsPickedUp()
    {
        return isPickedUp;
    }

    private void OnTriggerEnter(Collider other)
    {
        isPickedUp = true;
        Destroy(gameObject);
    }
}
