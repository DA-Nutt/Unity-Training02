using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityPickup : MonoBehaviour
{
    public AbilityTypes abiltyType;
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ActivateAbility();
            Destroy(gameObject);
        }
    }

    private void ActivateAbility()
    {
        player.abilities[abiltyType.GetHashCode()].SetActive(true);
    }
}
