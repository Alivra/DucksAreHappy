using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pokemon : MonoBehaviour
{
    public bool PlayPokemon = false;
    public bool HasWon = false;
    public int playerHealth = 50;
    public int PsyduckHealth = 50;

    public Text PlayerHealthText;
    public Text PsyduckHealthText;

    public Text BattleNarration;
    public Button TackleButton;
    public Button ThunderboltButton;

    private string LastMove;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHealthText.gameObject.SetActive(false);
        PsyduckHealthText.gameObject.SetActive(false);
        TackleButton.gameObject.SetActive(false);
        ThunderboltButton.gameObject.SetActive(false);
        BattleNarration.gameObject.SetActive(false);

        TackleButton.onClick.AddListener(OnTackleButtonPressed);
        ThunderboltButton.onClick.AddListener(OnThunderboltButtonPressed);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayPokemon)
        {
            PlayerHealthText.gameObject.SetActive(true);
            PsyduckHealthText.gameObject.SetActive(true);
            TackleButton.gameObject.SetActive(true);
            ThunderboltButton.gameObject.SetActive(true);
            BattleNarration.gameObject.SetActive(true);

        }
        if (PsyduckHealth <= 0)
        {
            HasWon = true;
            PlayerHealthText.gameObject.SetActive(false);
            PsyduckHealthText.gameObject.SetActive(false);
            TackleButton.gameObject.SetActive(false);
            ThunderboltButton.gameObject.SetActive(false);
            BattleNarration.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<SceneChanger>().LoadScene("Psyduck-Vision");

        }

        PlayerHealthText.text = "PlayerHealth: " + playerHealth;
        PsyduckHealthText.text = "PsyduckHealth: " + PsyduckHealth;
        BattleNarration.text = LastMove;
    }
    void spaceOut()
    {
        int num = Random.Range(1, 3);
        if (num == 1)
        {
            int number = Random.Range(1, 3);
            if (number == 1)
            {
                LastMove = LastMove + "\nPsyduck spaced out and healed 10 Health!";
                PsyduckHealth += 10;
            }
            else if (number == 2)
            {
                LastMove = LastMove + "\nPsyduck spaced out!";
            }
        }
        else if (num == 2)
        {
            WaterGun();
            LastMove = LastMove + "\nPsyduck used Water Gun for 10 dmg!";
        }
    }
    void WaterGun()
    {
        playerHealth -= 10;
    }
    void Tackle()
    {
        LastMove = "Player used Tackle for 20 dmg!";
        PsyduckHealth -= 20;
    }
    void Thunderbolt()
    {
        PsyduckHealth -= (30 * 2);
    }

    void OnTackleButtonPressed()
    {
        LastMove = "";
        Tackle();
        spaceOut();
    }
    void OnThunderboltButtonPressed()
    {
        LastMove = "Player used Thunderbolt!";
        Invoke(nameof(Thunderbolt), 1.5f); // Delay of 1.5 seconds
    }
}