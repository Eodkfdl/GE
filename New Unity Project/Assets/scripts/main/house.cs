using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class house : MonoBehaviour
{
    private int hitnum;
    // Start is called before the first frame update
    void Start()
    {
        hitnum = 0;
    }
    private void OnTriggerExit(Collider collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Player Missile"일 경우
        if (collision.CompareTag("Player"))
        {
        print(gameObject.name);
            hitnum += 1;
            if (hitnum > 3)
            {
                Gamedata.str = gameObject.name;
            }

        }
    }

    
              // Update is called once per frame
        void Update()
    {
    }
}
