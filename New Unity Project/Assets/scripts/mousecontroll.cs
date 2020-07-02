﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousecontroll : MonoBehaviour
{
    private Behavior behavior; // 캐릭터의 행동 스크립트
    private Camera mainCamera; // 메인 카메라
    private Vector3 targetPos; // 캐릭터의 이동 타겟 위치

    void Start()
    {
        behavior = GetComponent<Behavior>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        targetPos = transform.position;
    }

    void Update()
    {
        // 마우스 입력을 받았 을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스로 찍은 위치의 좌표 값을 가져온다
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                targetPos = hit.point;
            }
        }

        // 캐릭터가 움직이고 있다면
        if (behavior.Run(targetPos))
        {
            // 회전도 같이 시켜준다
            behavior.Turn(targetPos);
        }
        else
        {
            // 캐릭터 애니메이션(정지 상태)
           // behavior.SetAnim(PlayerAnim.ANIM_IDLE);
        }

    }
}
