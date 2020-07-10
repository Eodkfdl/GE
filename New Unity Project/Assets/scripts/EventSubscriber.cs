using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EventSubscriber : MonoBehaviour
{
    public Button startButton;
    public Button endButton;
    private float startTime = 0f;
    private bool isPressedStart = false;

    // Start is called before the first frame update
    void Start()
    {
        //startButton = GetComponent<Button>();
        //endButton = GetComponent<Button>();
        //// 스타트 버튼이 클릭되었을 때 유니티 메서드 호출
        startButton.onClick.AddListener(OnClickedStart);
        endButton.onClick.AddListener(OnClickedExit);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressedStart)
        {
            startTime += Time.deltaTime * 3f;
            if(startTime >= 3.5f)
            {
                SceneManager.LoadScene("2");
            }
        }
    }

    //
    private void OnClickedStart()
    {
        // loadScene();
        isPressedStart = true;
    }
    private void OnClickedExit()
    {
        Application.Quit();
    }

}
