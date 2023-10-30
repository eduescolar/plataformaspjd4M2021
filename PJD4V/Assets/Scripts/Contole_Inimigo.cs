using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Contole_Inimigo : MonoBehaviour
{
    
    public float moveSpeed;
    public Transform enemy;
    public Transform startPoint;
    public Transform endPoint;
    private int _direction = 1;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 target = currentMovementTarget();
        enemy.position = Vector2.Lerp(enemy.position, target, moveSpeed * Time.deltaTime);
        float distance = (target - (Vector2)enemy.position).magnitude;
        if (distance < 0.1f)
        {
            _direction *= -1;
        }
    }
    

    Vector2 currentMovementTarget()
    {
        if (_direction == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (enemy!=null && startPoint!=null && endPoint!=null)
        {
            Gizmos.DrawLine(enemy.transform.position, startPoint.position);
            Gizmos.DrawLine(enemy.transform.position, endPoint.position); 
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
