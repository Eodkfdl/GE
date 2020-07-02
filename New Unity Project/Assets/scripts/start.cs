using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class start : MonoBehaviour
{
    public TextMeshProUGUI notice;
    // Start is called before the first frame update
    void Start()
    {
        notice.alpha = 0;
        Gamedata.chickenn = 0;
        Gamedata.cown = 0;
        Gamedata.duckn = 0;
        Gamedata.sheepn = 0;
        Gamedata.str="";
        Gamedata.Gamestatus = 0;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        notice.alpha += Time.deltaTime/2;
        if (notice.alpha > 0.9)
        {
            notice.alpha = 0;
        }
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("2");
            //다음씬으로 넘어가는 호출해주자
        }
    }
}
