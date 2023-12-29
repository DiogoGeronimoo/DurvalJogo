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

    // Update is called once per frame
    void Update()
    {
        atacando = Input.GetKeyDown("Z");

        if (atacando == true)
        {
            Ataque();

        }

    }

    void Ataque()
    {
        anim.SetTrigger("Attack");
    }
}
