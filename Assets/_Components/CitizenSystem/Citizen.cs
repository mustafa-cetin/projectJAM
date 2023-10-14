using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Citizens/Citizen")]
public class Citizen : ScriptableObject
{
    public string name;

    public string state;

    public int strengh;

    public int intel;

    public int dexterity; 

    public int luck;
}
