using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public float maxHP;
    public float HP;
    public void IncrementHP(float amout)
    {
        HP = Mathf.Clamp(HP+amout, 0, maxHP);
    }
}
