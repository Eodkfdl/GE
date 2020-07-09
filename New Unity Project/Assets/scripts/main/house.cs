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
    
    private void OnTriggerEnter(Collider collision)
    {
        // 부딛히는 collision을 가진 객체의 태그가 "Player Missile"일 경우
        if (collision.CompareTag("Player"))
        {
        print(gameObject.name);
            hitnum += 1;
            //hitnum 만큼 부딪혔다면 해당 동물의 울음소리와함께 문이열리는소리를 낸다
            if (hitnum == 2)
            {
                GameManager.instance.str = gameObject.name;
                GameManager.instance.Free(gameObject.name);
            }

        }
    }

    
              // Update is called once per frame
       
}
