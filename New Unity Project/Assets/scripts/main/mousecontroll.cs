using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class mousecontroll : MonoBehaviour
{
    public float rotateSpeed = 10.0f;// 마우스 회전속도
    public float camwalkspeed = 10.0f;
    public float camdis = 5.0f;
    public float zoomSpeed = 15.0f;
    private Vector3 temp;
    private Behavior behavior; // 캐릭터의 행동 스크립트
    private Camera mainCamera; // 메인 카메라
    private Vector3 targetPos; // 캐릭터의 이동 타겟 위치
    private float runtime;
    private void Zoom()
    {
        float distance = Input.GetAxis("Mouse ScrollWheel") * -1 * zoomSpeed;
        if (distance!=0)
        {
            mainCamera.fieldOfView += distance;
        }
        if(mainCamera.fieldOfView > 80)
        {
            mainCamera.fieldOfView = 80;

        }
        if (mainCamera.fieldOfView < 20)
        {
            mainCamera.fieldOfView = 20;
        }
    }

    void Start()
    {
        behavior = GetComponent<Behavior>();
        mainCamera = GameObject.Find("Main Camera").GetComponent<Camera>();
        targetPos = transform.position;
        temp = transform.position;
    }

    void Update()
    {
        temp = transform.position;
        temp.y = mainCamera.transform.position.y;
        if (Vector3.Distance(temp, mainCamera.transform.position) >= camdis  )
        {    
            mainCamera.transform.localPosition = Vector3.MoveTowards(mainCamera.transform.position, temp, camwalkspeed * Time.deltaTime);
            
            }
        else
        {

            
        }
        Zoom();
        // 마우스 입력을 받았 을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스로 찍은 위치의 좌표 값을 가져온다
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10000f))
            {
                targetPos = hit.point;
                runtime = 3;
            }
          
        }
        if (Input.GetMouseButtonDown(2))
        {
            SceneManager.LoadScene("3");
        }
        // 캐릭터가 움직이고 있다면
        
        if (
            behavior.Run(targetPos))
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
