using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xRange;
    public float yRange;
    // Start is called before the first frame update
    void Start()
    {


    }   

    private void LateUpdate()
    {

        if (transform.position.x > xRange)
        {
            transform.position = new Vector2(xRange, transform.position.y);
        }

        if(transform.position.x < -xRange)
        {
            transform.position = new Vector2(-xRange, transform.position.y);
        }


        if (transform.position.y > yRange)
        {
            transform.position = new Vector2(yRange, transform.position.y);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(-yRange, transform.position.y);
        }
    }

    
       


    

    // Update is called once per frame
    void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        Debug.Log(moveHorizontal);

        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);

            
    }
}