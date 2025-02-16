using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class talk : MonoBehaviour
{
     public TextPrinter DarwinIntro;
     public TextPrinter Quest;
     public TextPrinter Credentials;
     public TextPrinter AmnesiaInfo;
     public TextPrinter GoAway;

     public Button C1;
     public Button C2;
     public Button C3;
     public Button C4;

     bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        DarwinIntro.gameObject.SetActive(false);
        Quest.gameObject.SetActive(false);
        Credentials.gameObject.SetActive(false);
        AmnesiaInfo.gameObject.SetActive(false);
        GoAway.gameObject.SetActive(false);
        
        C1.gameObject.SetActive(false);
        C2.gameObject.SetActive(false);
        C3.gameObject.SetActive(false);
        C4.gameObject.SetActive(false);

        C1.onClick.AddListener(OnC1Pressed);
        C2.onClick.AddListener(OnC2Pressed);
        C3.onClick.AddListener(OnC3Pressed);
        C4.onClick.AddListener(OnC4Pressed);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange && Input.GetKeyDown(KeyCode.Space))
        {
            DarwinIntro.gameObject.SetActive(true);
            C1.gameObject.SetActive(true);
            C2.gameObject.SetActive(true);
            C3.gameObject.SetActive(true);
        }
        // Connect to playerstats and if has 3 catapillers or fakes
        // C4.gameObject.SetActive(true);
        // adjust morality stat
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    
    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    void OnC1Pressed()
    {
        HideAllTextPrinters();
        Quest.gameObject.SetActive(true);
        SetTextPrinterVisible(Quest);
    }

    void OnC2Pressed()
    {
        HideAllTextPrinters();
        GoAway.gameObject.SetActive(true);
        SetTextPrinterVisible(GoAway);
    }

    void OnC3Pressed()
    {
        HideAllTextPrinters();
        Credentials.gameObject.SetActive(true);
        SetTextPrinterVisible(Credentials);
    }

    void OnC4Pressed()
    {
        HideAllTextPrinters();
        AmnesiaInfo.gameObject.SetActive(true);
        SetTextPrinterVisible(AmnesiaInfo);
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
    foreach (TextPrinter textPrinter in new[] { DarwinIntro, Quest, Credentials, AmnesiaInfo, GoAway })
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
