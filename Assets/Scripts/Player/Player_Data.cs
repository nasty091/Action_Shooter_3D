using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

[System.Serializable]
public class Player_Data
{
    public float[] position;
    public int health;
    public Mission mission;
    public List<Weapon_Data> weaponDatas;
    public List<Weapon> weaponSlots;
    public Weapon currentWeapon;
    public Transform lastLevelPart;
}
