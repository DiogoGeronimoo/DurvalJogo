using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ataquePlayer : MonoBehaviour
{
    private bool atacando;
    public Animator anim;
    public Transform ataquePoint;
    public float ataqueRanger = 0.5f;
    public LayerMask enemyLayers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Ataque()
    {
        anim.SetTrigger("Attack");
    }
}
