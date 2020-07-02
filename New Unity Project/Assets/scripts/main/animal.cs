using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal : MonoBehaviour
{
    public bool start;
    Vector3 targetpos;
    // Start is called before the first frame update
    void Start()
    {
        start = false;
        targetpos.x = 66.11f;
        targetpos.y = 22.0f;

        targetpos.z = 44.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "ani" + Gamedata.str)
        {
            start = true;
        }

        if (start)
        {
            transform.localPosition = Vector3.MoveTowards(transform.position, targetpos, 10 * Time.deltaTime);
        }
    }
}
