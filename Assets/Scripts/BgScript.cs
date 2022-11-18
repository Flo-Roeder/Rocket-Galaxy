using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScript : MonoBehaviour
{
    public GameObject bgImage;

    private float yThreshhold = -5.6f;
    private float moveTop = 3 * 3.5f;
    public static float moveSpeed; // -level from GameManager
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new(0,transform.position.y+ (moveSpeed * Time.deltaTime*0.1f), 0);
        if (transform.position.y<=yThreshhold)
        {
            Vector3 newTrans =new (0,transform.position.y+ moveTop,0);
            Instantiate(bgImage, newTrans,Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
