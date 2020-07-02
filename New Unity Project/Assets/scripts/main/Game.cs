using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class Game : MonoBehaviour
{
    public RawImage cow,sheep,duck, chicken;
    public TextMeshProUGUI Day;
    [SerializeField] float gamestatus;
    public int clear;
    public GameObject temp;
    // Start is called before the first frame update
    void Start()
    {
        clear = 0;
            gamestatus = 0;
            cow.CrossFadeAlpha(1, 4, true);
    }
    
    // Update is called once per frame
    void Update()
    {
        //이에스시키누르면종료
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if(Gamedata.str != null)
        {
            temp = GameObject.Find("ani" + Gamedata.str);
            
        }

        if (Gamedata.str=="cow")
        {
            Gamedata.cown = 1;
            clear += 1;
            Gamedata.str = "";
            cow.CrossFadeAlpha(0, 4, true);
        }
        if (Gamedata.str == "duck")
        {

            duck.CrossFadeAlpha(0, 4, true);
            Gamedata.duckn = 1;
            clear += 1;
            Gamedata.str = "";
        }
        if (Gamedata.str == "sheep")
        {

            sheep.CrossFadeAlpha(0, 4, true);
            Gamedata.sheepn = 1;
            clear += 1;
            Gamedata.str = "";
        }
        if (Gamedata.str == "chicken")
        {

            chicken.CrossFadeAlpha(0, 4, true);
            Gamedata.chickenn = 1;
            clear += 1;
            Gamedata.str = "";
        }
       

        if (clear >3)//이겼을때
        {
            SceneManager.LoadScene("3");
        }
    }
}
