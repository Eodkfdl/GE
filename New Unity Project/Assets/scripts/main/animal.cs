using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal : MonoBehaviour
{
    public int start;
    Vector3 targetpos;
    GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        start = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "ani" + Gamedata.str)
        {
            start = 1;
           temp  = GameObject.Find("player").transform.GetChild(Gamedata.clear).gameObject;
        }

        if (start>0)
        {
            targetpos = temp.transform.position;
   
            transform.localPosition = Vector3.MoveTowards(transform.position, targetpos, 10 * Time.deltaTime);
        }
    }
}
