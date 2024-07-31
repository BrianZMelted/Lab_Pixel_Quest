using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int bulletDamage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Death")
        {
        other.gameObject.GetComponent<WalkingEnemyController>().TakeDamage(bulletDamage);
        Destroy(gameObject);
        }
    }
}
