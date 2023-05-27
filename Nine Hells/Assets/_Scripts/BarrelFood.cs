using UnityEngine;
using DG.Tweening;

public class BarrelFood : MonoBehaviour
{

    [SerializeField] float health = 3;
    [SerializeField] GameObject food;

    void Start()
    {
        if(food)food.SetActive(false);    
    }
    public void TakeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            if(food)food.SetActive(true);
            gameObject.SetActive(false);
        }
        else transform.DOShakeScale(0.5f);
    }
}
