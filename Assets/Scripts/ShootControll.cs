using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootControll : MonoBehaviour
{

    public float moveSpeed;
    public float exhaustTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new(transform.position.x, transform.position.y+ Time.deltaTime * moveSpeed,0);
        DestroyAfterTime();
    }

    void DestroyAfterTime()
    {
        if (exhaustTime<=0)
        {
            Destroy(this.gameObject);
        }
        else
        {
            exhaustTime -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ShootDestroyer"))
        {
            Destroy(this.gameObject);
        }
    }
}
