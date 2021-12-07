using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Text healthUI;
    private int currentHealth = 40;
    private int MaximumHealth = 100;

    // Start is called before the first frame update
    void Start()
    {
        healthUI.text = currentHealth.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        healthUI.text = currentHealth.ToString();
    }

    public int GetMaximumHealth()
    {
        return MaximumHealth;
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void AddHealth(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaximumHealth);
    }

    public void RemoveHealth(int amount)
    {
        
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, MaximumHealth);
        Debug.Log("Player lost health!! Current Health is: " + currentHealth);
    }

    public void SetFullHealth()
    {
        currentHealth = MaximumHealth;
    }
}
