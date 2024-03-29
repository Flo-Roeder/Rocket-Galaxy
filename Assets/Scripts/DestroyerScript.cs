using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Astro"))
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().EndGame();
            GameObject.Find("AstroText").GetComponent<CanvasGroup>().alpha=1;
        }
    }
}
