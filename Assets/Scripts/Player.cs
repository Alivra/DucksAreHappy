using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    // for movement
    public float moveSpeed;
    public Text HUD;
    public int CaterpillersCollected = 0;
    public int fakeCaterpillersCollected = 0;
    public bool hasSeed = false;

    public bool DarwinQuestStarted = false;

    public bool JamesPondQuestStarted = false;
    public double luck;
    public int morality;
    float xInput, yInput;

    public Button open;
    public Button close;

    // Start is called before the first frame update
    void Start()
    {
        luck = 0.1 * Random.Range(1, 11);
        morality = 50;
        open.gameObject.SetActive(false);
        close.gameObject.SetActive(false);
        open.onClick.AddListener(OnOpen);
        close.onClick.AddListener(OnClose);
    }

    // Update is called once per frame
    void Update()
    {
        if (DarwinQuestStarted)
        {
            HUD.text = "Caterpillers Collected: " + CaterpillersCollected + "/3" + "\nFake Caterpillers Collected: " + fakeCaterpillersCollected + "/1";
        }
        else
        {
            HUD.text = "";
        }
        if (JamesPondQuestStarted)
        {
            int number = 0;
            if (hasSeed)
            {
                number = 1;
            }
            HUD.text = "Find Golden Seed for James Pond: " + number + "/1";
        }
        else
        {
            HUD.text = "";
        }

    }

    private void FixedUpdate()
    {
        // define the axes
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player collides with an enemy from above
        if (collision.gameObject.CompareTag("Caterpiller"))
        {
            CaterpillersCollected++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("fakeCaterpillar"))
        {
            fakeCaterpillersCollected++;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("seed"))
        {
            hasSeed = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            open.gameObject.SetActive(true);
            close.gameObject.SetActive(true);
        }
    }

    void OnClose()
    {
        open.gameObject.SetActive(false);
        close.gameObject.SetActive(false);
        
        double score = luck * morality;
        if (score <30)  
        {
            //shredded (inclusive)
        }
        else if (score > 30 && score < 50)
        {
            //walk away
        }
        else if (score > 50)
        {
            //eat poacher
        }
    }

    void OnOpen()
    {
        open.gameObject.SetActive(false);
        close.gameObject.SetActive(false);

        double score = luck * morality;
        if (score <30)
        {
            //shredded (exclusive)
        }
        else {
            //walk away
        }
    }

}
