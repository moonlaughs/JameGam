using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillSanta : MonoBehaviour
{
    Rescale rescale; 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Santa") && rescale.isScaled)
        {
            SceneManager.LoadScene(3);
        }
    }
}
