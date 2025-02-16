// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PokemonGame : MonoBehaviour
// {
//     int playerHealth = 50;
//     int PsyduckHealth = 50;

//     public Button spaceOutButton;

//     public Button WaterGunButton;

//     public Button TackleButton;

//     public Button ThunderboltButton;
//     // Start is called before the first frame update
//     void Start()
//     {

//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (PsyduckHealth <= 0)
//         {
//             Debug.Log("You lose");
//         }
//     }
//     void spaceOut()
//     {
//         int num = Random.Range(1, 3);
//         if (num == 1)
//         {
//             PsyduckHealth -= 5;
//         }
//     }
//     void WaterGun()
//     {
//         playerHealth -= 10;
//     }
//     void Tackle()
//     {
//         PsyduckHealth -= 20;
//     }
//     void Thunderbolt()
//     {
//         PsyduckHealth -= (30*2);
//     }
// }
