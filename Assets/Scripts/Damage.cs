using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    //public Character characterController;
    public Animator anim;
    public byte layer;
    public byte health;
    public byte damageValue;

    public void OnTriggerEnter(Collider other) 
    {
        anim = other.GetComponentInParent<Animator>();
        if(other.gameObject.layer == layer /*&& anim.GetBool("Attack")*/)
        {
            health -= damageValue;
        }
    }
    void Update()
    {
        
    }
}
