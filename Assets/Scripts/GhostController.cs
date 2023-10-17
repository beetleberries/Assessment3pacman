using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostController : MonoBehaviour
{
    public Ghost[] ghosts;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setstate()
    {
        foreach (Ghost ghost in ghosts)
        {
            //ghost.animator.set
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
