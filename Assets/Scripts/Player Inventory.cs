using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private List<PlayerWeapon> weapons;

    public List<PlayerWeapon> Weapons
    {
        get { return weapons; }
    }

    // Start is called before the first frame update
    void Start()
    {
        weapons = new List<PlayerWeapon>();
    }

    public void AddWeapon(PlayerWeapon weapon)
    {
        weapons.Add(weapon);
    }

    public void RemoveWeapon(int index)
    {
        weapons.RemoveAt(index);
    }

    public PlayerWeapon GetWeapon(int index)
    {
        return weapons[index];
    }

    public void RemoveDurability(float upperBound)
    {
        weapons.RemoveAll((weapon) => {
            return weapon.Durability <= upperBound;
        });
    }
}
