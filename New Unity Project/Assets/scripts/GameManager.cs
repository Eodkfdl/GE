using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    // 외부에서 싱글톤 오브젝트를 가져올때 사용할 프로퍼티
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance;// 외부에서 접근할 인스터스이름 
    
    public string str;
    public int day;
    public RawImage Cow, Sheep, Duck, Chicken;
    public TextMeshProUGUI Day;

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }
    }

    public void dead()
    {
        day += 1;
        Day.text = "Day -" + day;
    }
    //동물풀어줌
    public void Free(string name)
    {
        Gamedata.clear += 1;
        print(Gamedata.clear);
        switch (name)
        {
            case "cow":
                Cow.CrossFadeAlpha(0, 4, true);
                break;
            case "sheep":
                Sheep.CrossFadeAlpha(0, 4, true);
                break;
            case "duck":
                Duck.CrossFadeAlpha(0, 4, true);
                break;
            case "chicken":
                Chicken.CrossFadeAlpha(0, 4, true);
                break;
        }
       
    }
    private void Start()
    {
    }

    // 점수를 추가하고 UI 갱신
   
   //프레임마다 업데이트해줘야할것있으면여기다가.
    private void Update()
    {
    }

}