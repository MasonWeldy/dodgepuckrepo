using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int score = 7;
    public int speed = 10;
    // Start is called before the first frame update
    void Start()
    {


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