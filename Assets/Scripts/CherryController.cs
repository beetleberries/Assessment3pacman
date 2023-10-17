using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryController : MonoBehaviour
{
    private Vector2 screencenter = new Vector2(14f,-13f);
    public GameObject cherry;
    private GameObject currentcherry;
    private Vector2 cherrystart;
    private float instatiatetimer = 9f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        instatiatetimer += Time.deltaTime;
        if (instatiatetimer > 10)
        {
            instatiatetimer = 0;
            SpawnCherry();
        }
        if (currentcherry == null) return;
        currentcherry.transform.position = Vector3.Lerp(cherrystart + screencenter, screencenter + cherrystart * -1, instatiatetimer / 10f);
    }

    private void SpawnCherry()
    {
        Destroy(currentcherry);
        cherrystart = Random.insideUnitCircle.normalized * 40f;
        currentcherry = Instantiate(cherry, cherrystart, Quaternion.identity);
    }


}
