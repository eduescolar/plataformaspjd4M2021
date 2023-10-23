using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Contole_Inimigo : MonoBehaviour
{
    
    public float moveSpeed;
    public Transform player;
    public Transform startPoint;
    public Transform endPoint;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        if (player!=null && startPoint!=null && endPoint!=null)
        {
            Gizmos.DrawLine(player.transform.position, startPoint.position);
            Gizmos.DrawLine(player.transform.position, endPoint.position); //parou aquiiiiiS
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
        }
    }
}
