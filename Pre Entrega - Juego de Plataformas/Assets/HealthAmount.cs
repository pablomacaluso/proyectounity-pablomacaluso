using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthAmount : MonoBehaviour
{
    public int healAmount;
    public bool isFullHeal;

    private void OnTriggerEnter(Collider other) 
    {
        if (other.tag == "Player")
        {
            Destroy(gameObject);

            if(isFullHeal)
            {
                HealthManager.instance.ResetHealth();
            }else
            {
                HealthManager.instance.AddHealth(healAmount);    
            }
        }
    }

}
