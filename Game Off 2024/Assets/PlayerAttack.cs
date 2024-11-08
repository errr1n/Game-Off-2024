using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField] private Animator _animator;

    [SerializeField] public float meleeSpeed;

    [SerializeField] private float damage;

    float timeUntilMelee;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(timeUntilMelee <= 0f)
        {
            if(Input.GetMouseButtonDown(0))
            {
                // Debug.Log("CLICKED");
                _animator.SetTrigger("Attack");
                timeUntilMelee = meleeSpeed;
            } 
        }
        timeUntilMelee -= Time.deltaTime;
        // Debug.Log("ELSE TIME " + timeUntilMelee);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            // other.GetComponent<Enemy>().TakeDamage(damage);
            Debug.Log("Enemy hit");
        }
    }
}
