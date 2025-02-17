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
    public bool DarwinQuestFinished = false;


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
        HUD.gameObject.SetActive(false);

        open.onClick.AddListener(OnOpen);
        close.onClick.AddListener(OnClose);
    }

    // Update is called once per frame
    void Update()
    {
        if (DarwinQuestStarted)
        {
            HUD.gameObject.SetActive(true);
        }
        else if (DarwinQuestFinished)
        {
            HUD.gameObject.SetActive(false);
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
        if (score < 25)
        {
            //shredded (inclusive)
            gameObject.GetComponent<SceneChanger>().LoadScene("shredI");
        }
        else if (score >= 25 && score < 45)
        {
            //walk away
            gameObject.GetComponent<SceneChanger>().LoadScene("Leave");
        }
        else if (score >= 45)
        {
            //eat poacher
            gameObject.GetComponent<SceneChanger>().LoadScene("Eat");
        }
    }

    void OnOpen()
    {
        open.gameObject.SetActive(false);
        close.gameObject.SetActive(false);

        Debug.Log("Open");

        double score = luck * morality;
        if (score < 25)
        {
            //shredded (exclusive)
            gameObject.GetComponent<SceneChanger>().LoadScene("shredE");
        }
        else
        {
            Debug.Log("Entered if else");
            //walk away
            gameObject.GetComponent<SceneChanger>().LoadScene("Leave");
        }
    }

}
