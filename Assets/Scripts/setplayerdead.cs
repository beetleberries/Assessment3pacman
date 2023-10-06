using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setplayerdead : MonoBehaviour
{

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator.SetTrigger("died");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
