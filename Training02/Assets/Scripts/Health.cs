using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region Variables
    public int maxHealth;
    public int currentHealth;
    public UnitTypes targetType; 
    #endregion

    public void ChangeHealth(int value) 
    {
        currentHealth = currentHealth + value; // Health goes up if value is + or health goes down if value is -
        CheckHealth();
    }

    void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            switch (targetType)
            {
                case UnitTypes.Enemy:
                    if (gameObject.CompareTag("Enemy"))
                    {
                        FindObjectOfType<Score>().EarnPoints(100);
                        Destroy(gameObject);
                    }
                    break;

                case UnitTypes.Player:
                    if (gameObject.CompareTag("Player"))
                    {
                        FindObjectOfType<GameManager>().EndGame();
                        gameObject.SetActive(false);
                    }
                    break; 

                case UnitTypes.Obstacle:
                    if (gameObject.CompareTag("Obstacle"))
                    {
                        Destroy(gameObject);
                    }
                    break;
            }
        }
    }
}
