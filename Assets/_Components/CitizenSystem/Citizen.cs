using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// [CreateAssetMenu(menuName = "Citizens/Citizen")]
public class Citizen : MonoBehaviour
{
    public string citizenName;

    public string state;

    public int endurance;

    public int strength;

    public int intel;

    public int cooking; 


    public float moveSpeed = 5f; // Hareket hızı

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal"); // Sağ veya sol ok tuşlarına basılınca -1, 0 veya 1 döndürür.

        Vector3 newPosition = transform.position + new Vector3(moveInput * moveSpeed * Time.deltaTime, 0, 0);

        if (moveInput < 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Karakteri sağa döndür
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Karakteri sola döndür
        }

        transform.position = newPosition;
    }


   


}
