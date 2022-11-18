using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontroll : MonoBehaviour
{

    public GameObject shoot;
    public float shootDelay;
    private float shootCounter;
    // Start is called before the first frame update
    void Start()
    {
        shootCounter = shootDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gameStart)
        {
        PlayerMove();
        Shoot();

        }
    }

    private void Shoot()
    {
        if (shootCounter <= 0)
        {
            GameObject.Instantiate(shoot,transform.position,Quaternion.Euler(0,0,90));
            shootCounter = shootDelay;
        }
        else
        {
            shootCounter -= Time.deltaTime;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy")|| collision.collider.CompareTag("EnemySpaceShip"))
        {
            //  Destroy(this.gameObject); //later end the Game
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Astro"))
        {
            Destroy(collision.gameObject);
            GameManager.score += 50;
            GameManager.destroyCounter++;
        }   
    }

    private void PlayerMove()
    {
        // transform.position = Camera.main.ScreenToWorldPoint(new(Input.mousePosition.x,Input.mousePosition.y,10));

/*
        float posX = Input.mousePosition.x;
        float posY = Input.mousePosition.y;

        transform.position = Camera.main.ScreenToWorldPoint(new(posX,posY,10));
*/
        var pos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        pos.x = Mathf.Clamp(pos.x, 0.03f, 0.97f);
        pos.y = Mathf.Clamp(pos.y, 0.03f, 0.97f);
        transform.position = Camera.main.ViewportToWorldPoint(new(pos.x,pos.y,10));
    }
}
