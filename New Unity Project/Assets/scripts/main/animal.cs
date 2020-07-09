using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animal : MonoBehaviour
{
    public int start;
    Vector3 targetpos;
    GameObject temp;
    public int speed;
    public float rotspeed;
    Quaternion targetRot;
    // Start is called before the first frame update
    void Start()
    {
        start = 0;
        temp = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.name == "ani" + GameManager.instance.str&&start==0)//해당 오브젝트의 움직임시작
        {
           start = 1;
           temp  = GameObject.Find("player").transform.GetChild(Gamedata.clear).gameObject;//플레이어를 따라 다닐 위치를 불러온다
        }

        if (start>0)
        {
            targetpos = temp.transform.position;//지속적으로 움직이는 플레이어에따라 해당 타겟을 따라다닌다.
          
            transform.localPosition = Vector3.MoveTowards(transform.position, targetpos, speed * Time.deltaTime);
            
            //해당 오브젝트의 로테이션정보를 불러와 그만큼 애니멀도 돌려준다.
            targetRot = temp.transform.rotation; 
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, rotspeed * Time.deltaTime);

            
        }
    }
}
