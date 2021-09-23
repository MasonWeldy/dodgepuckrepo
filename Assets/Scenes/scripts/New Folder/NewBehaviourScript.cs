using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
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
            if (Input.GetKeyDown(KeyCode.D))
            {
                Debug.Log(Input.GetAxis("horizontial"));
                transform.Translate(Vector2.right * speed * Time.deltaTime);
            }
            
    }
}
