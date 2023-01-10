using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image health;
    [SerializeField] private float delta;
    private float healthValue;
    private float currentHealth;
    private Pleer pleer;

    void Start()
    {
       //pleer = FindObjectOfType<Pleer>(); 
       pleer = Pleer.Instance;
       healthValue = pleer.Health.CurrentHealth / 100.0f;    
    }


    void Update()
    {
        currentHealth = pleer.Health.CurrentHealth / 100.0f;
        if (currentHealth > healthValue)
            healthValue += delta;
        if (currentHealth < healthValue)
            healthValue -= delta;   
        if (currentHealth < delta)
            healthValue = currentHealth;

        health.fillAmount = healthValue;
    }
}
