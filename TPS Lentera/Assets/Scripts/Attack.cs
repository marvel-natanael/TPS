using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public void DoAttack(Vector3 origin, Vector3 target)
    {
        Weapon weapon = GetComponentInChildren<Weapon>();
        if(weapon != null)
        {
            weapon.Setup(origin, target);
            weapon.Attack(weapon.damage);
        }
    }
    public void DoAttack() { }
}
