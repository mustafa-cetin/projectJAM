using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CitizenGenerator : MonoBehaviour
{

    public Citizen citizenObject;
    
    public List<Citizen> citizens;

    private void defineCitizen(){

        Citizen citizen = Instantiate(citizenObject);
        
        citizen.state = "Idle";
        citizen.citizenName = GenerateRandomName();
        citizen.strength = Random.Range(1,11);
        citizen.intel = Random.Range(1,11);
        citizen.cooking = Random.Range(1,11);
        citizen.endurance = Random.Range(1,11);
        
        citizens.Add(citizen);

    }


    private string[] names = { "John", "Jane", "Bob", "Lisa", "Mike", "Anna", "Alex", "Ella", "Paul", "Mara" };

    private string GenerateRandomName()
    {
        int randomIndex = Random.Range(0, names.Length);
        string randomName = names[randomIndex];

        if (randomName.Length >= 4)
        {
            int startIndex = Random.Range(0, randomName.Length - 4);
            return randomName.Substring(startIndex, 4);
        }

        return randomName;
    }

    void Start(){
        for(int i=0;i<5;i++){
            defineCitizen();
        }
    }
}
