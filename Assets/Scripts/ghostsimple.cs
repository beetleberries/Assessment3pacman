using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ghostsimple : MonoBehaviour
{

    public Animator animator;
    private int counter;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(time());
    }


    IEnumerator time(){
        while (true)
        {
            counter = (counter + 1) % 7;
            if (counter == 1 || counter == 2 || counter == 3 || counter == 4)
            {
                Vector3 scale = transform.localScale;
                scale.x *= -1;
                transform.localScale = scale;
            }
            yield return new WaitForSeconds(3);
        }
    }

    // Update is called once per frame
    void Update()
    {

        
        //counter = (counter + 1) % 6;
        animator.SetInteger("next", counter);
    }
}
