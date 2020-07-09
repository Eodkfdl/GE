﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Behavior : MonoBehaviour
{
    
    public float speed = 2.0f;
    private Rigidbody rigid;
    Vector3 dir;
    Vector3 dirXZ ;
    Quaternion targetRot ;
    void Awake()
    {

        rigid = GetComponent<Rigidbody>();

    }

    public bool Run(Vector3 targetPos)
    {
        // 이동하고자하는 좌표 값과 현재 내 위치의 차이를 구한다.
        float dis = Vector3.Distance(transform.position, targetPos);
        if (dis != 0) // 차이가 아직 있다면
        {
            // 캐릭터를 이동시킨다.
            targetPos.y = transform.position.y;
            transform.localPosition = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            //SetAnim(PlayerAnim.ANIM_WALK); // 걷기 애니메이션 처리
            return true;
        }
        return false;

    }

    public void Turn(Vector3 targetPos)
    {
        
        // 캐릭터를 이동하고자 하는 좌표값 방향으로 회전시킨다
         dir = targetPos - transform.position;
         dirXZ = new Vector3(dir.x, 0, dir.z);
        if(dirXZ.magnitude>0)
         targetRot = Quaternion.LookRotation(dirXZ);
        if (dirXZ.x<0.001 || dirXZ.z < 0.001)
        {
            dirXZ = new Vector3(0, 0, 0);
        }
        if (Vector3.Distance(transform.position, targetPos) > 0.2f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRot, 550.0f * Time.deltaTime);
          
        }
    }
}