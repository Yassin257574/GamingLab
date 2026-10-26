using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingSaw : EnemyController
{
    public Transform player;

    void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, maxSpeed * Time.deltaTime);
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }
        else if (other.tag == "Wall")
        {
            Flip();
        }
    }
}