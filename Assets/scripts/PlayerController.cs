using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xRange;
    public float yRange;
    public GameObject Puck;
    public GameObject Blocky;
    //public int Score;
    public GameObject scoreText;
    public GameObject gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
        //score = 0;
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
            transform.position = new Vector2(transform.position.x, yRange);
        }

        if (transform.position.y < -yRange)
        {
            transform.position = new Vector2(transform.position.x, -yRange);
        }
    }

    
       
    

    // Update is called once per frame
    void Update()
    {

        //Instantiate(Puck, new Vector2(Random.Range(-xRange,xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
        //GameObject[] puckArray;
        //puckArray = GameObject.FindGameObjectsWithTag("Puck");
        //Debug.Log("Puck Count: " + puckArray.Length);


        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        print("moveHorizontal value: " + moveHorizontal);

        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveHorizontal,moveVertical);

        transform.Translate(movement * speed * Time.deltaTime);

            
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Blocky"))       
        {
            Destroy(other.gameObject);
            Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            //Score += 5;
            //Debug.Log("Your Score: " + Score);

            scoreText.GetComponent<ScoreKeeper>().scoreValue += 5;
            scoreText.GetComponent<ScoreKeeper>().UpdateScore();
        }


        if (other.gameObject.CompareTag("Puck"))
        {
            gameOverText.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void NewGame()
    {
     Debug.Log("Its a new game!");
        if (Input.GetKeyDown(KeyCode.N))
        {
            //Destroy all Pucks
            GameObject[] allPucks = GameObject.FindGameObjectsWithTag("Pucks");
            foreach (GameObject dude in allPucks)
                GameObject.Destroy(dude);
            //Destroy all Blocky's
            GameObject[] allBlockys = GameObject.FindGameObjectsWithTag("Blocky");
            foreach (GameObject dude in allBlockys)
                GameObject.Destroy(dude);

            transform.position = new Vector2(0, 0);
            Instantiate(Blocky, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            Instantiate(Puck, new Vector2(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange)), Quaternion.identity);
            gameOverText.SetActive(false);
            Time.timeScale = 1;

            //Set sscore to zero
            scoreText.GetComponent<ScoreKeeper>().scoreValue = 0;
            scoreText.GetComponent<ScoreKeeper>().UpdateScore();
            Debug.Log("score: " + scoreText.GetComponent<ScoreKeeper>().scoreValue);




        }
    }
}