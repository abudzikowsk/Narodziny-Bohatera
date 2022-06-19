using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public string name;
    public int exp = 0;


    public Character()
    {
        name = "Nieprzypisana";
    }

    public Character(string name)
    {
        this.name = name;
    }


    public virtual void PrintStatsInfo()
    {
        Debug.LogFormat("Bohater: {0} - doświadczenie - {1}", name, exp);
    }


    private void Reset()
    {
        this.name = "Nieprzypisana";
        this.exp = 0;
    }
}

public struct Weapon
{

    public string name;
    public int damage;

    public Weapon (string name, int damage)
    {
        this.name = name;
        this.damage = damage;
    }

    public void PrintWeaponStats()
    {
        Debug.LogFormat("Broń: {0} - Siła rażenia: {1}", name, damage);
    }

}

public class Paladin: Character
{
    public Weapon weapon;
    public Paladin(string name, Weapon weapon): base(name)
    {
        this.weapon = weapon;
    }

    public override void PrintStatsInfo()
    {
        Debug.LogFormat("Hej, {0} - weź swoją broń: {1}!", name, weapon.name);
    }
}