using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyoncl: MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Destroy(obj: gameObject);
            Destroy(other.gameObject);


        

    }
}
