using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{

    #region Variables
    public float lifetime = 5.0f;
    #endregion  

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime); //'gameobject' with a lowercase 'g' refers to self, or the gameobject this script is attached to
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }

}
