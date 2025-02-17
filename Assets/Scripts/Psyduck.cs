using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Psyduck : MonoBehaviour
{
    public TextPrinter PsyduckIntro;

    public TextPrinter Quest;
    public TextPrinter GoAway;

    public Button C1;//battle
    public Button C2;//leave

    bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        PsyduckIntro.gameObject.SetActive(false);
        Quest.gameObject.SetActive(false);
        GoAway.gameObject.SetActive(false);

        C1.gameObject.SetActive(false);
        C2.gameObject.SetActive(false);

        C1.onClick.AddListener(OnC1Pressed);
        C2.onClick.AddListener(OnC2Pressed);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {
            PsyduckIntro.gameObject.SetActive(true);
            SetTextPrinterVisible(PsyduckIntro);
            Quest.gameObject.SetActive(true);
            SetTextPrinterVisible(Quest);
            Pokemon check = gameObject.GetComponent<Pokemon>();
            if (check.HasWon == false)
            {
                C1.gameObject.SetActive(true);
            }
            C2.gameObject.SetActive(true);
        }
        // Connect to playerstats and if has 3 catapillers or fakes
        // C4.gameObject.SetActive(true);
        // adjust morality stat
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("enter");
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("exit");
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
        HideAllTextPrinters();
        C1.gameObject.SetActive(false);
        C2.gameObject.SetActive(false);
    }

    void OnC1Pressed()
    {
        HideAllTextPrinters();
        C1.gameObject.SetActive(false);
        C2.gameObject.SetActive(false);
        Pokemon connection = gameObject.GetComponent<Pokemon>();
        connection.PlayPokemon = true;
    }

    void OnC2Pressed()
    {
        HideAllTextPrinters();
        GoAway.gameObject.SetActive(true);
        SetTextPrinterVisible(GoAway);
    }

    void SetTextPrinterVisible(TextPrinter textPrinter)
    {
        CanvasGroup canvasGroup = GetOrAddCanvasGroup(textPrinter);
        canvasGroup.alpha = 1;  // Fully visible
        canvasGroup.blocksRaycasts = true; // Ensure it can interact with UI
    }

    void SetTextPrinterInvisible(TextPrinter textPrinter)
    {
        CanvasGroup canvasGroup = GetOrAddCanvasGroup(textPrinter);
        canvasGroup.alpha = 0;  // Fully invisible
        canvasGroup.blocksRaycasts = false; // Prevents interaction
    }

    void HideAllTextPrinters()
    {
        foreach (TextPrinter textPrinter in new[] { PsyduckIntro, Quest, GoAway })
        {
            SetTextPrinterInvisible(textPrinter);
        }
    }

    CanvasGroup GetOrAddCanvasGroup(TextPrinter textPrinter)
    {
        CanvasGroup canvasGroup = textPrinter.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = textPrinter.gameObject.AddComponent<CanvasGroup>();
        }
        return canvasGroup;
    }

}