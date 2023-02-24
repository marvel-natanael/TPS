using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Weapon
{
    public int damage { get; }
    public void Attack(int damage);
    public void Setup(Vector3 originShoot, Vector3 targetShoot);
}
