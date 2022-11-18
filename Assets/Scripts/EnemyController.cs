using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int hitPoints;
    private int currentHP;

    private bool hitable=true;
    // Start is called before the first frame update
    void Start()
    {
        currentHP = hitPoints;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  /*  private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Shoot"))
        {
            hitPoints--;
            if (hitPoints<=0)
            {
                Destroy(this.gameObject);
            }
        }
    }
  */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Collider2D>().CompareTag("Shoot")&&hitable&&GameManager.gameStart)
        {
            currentHP--;
            GameManager.score++;
            collision.gameObject.GetComponent<Animator>().SetTrigger("hit");

            if (currentHP <= 0)
            {
                GameManager.score+=hitPoints;
                GameManager.destroyCounter++;
                hitable = false;

                if (CompareTag("EnemySpaceShip"))
                {
                    GetComponent<Animator>().SetTrigger("die");
                }
                else
                {
                    Destroy(this.gameObject);
                }
                
            }
        }
    }
}
