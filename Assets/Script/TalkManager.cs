using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    public GameObject portal;
    public GameObject joystick;

    // Start is called before the first frame update
    void Start()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "  아내 : \n  아들이 좀비에 감염되었어요.", 
            "  듣기로는 기사마을에도 감염된 사람이 있다는데\n  거기서 아들을 되돌릴 수 있는 방법이 있지 않을까요?" });
        talkData.Add(2000, new string[] {"  기사대장 : \n  어서오시게. " ,"  주인공 : \n 안녕하세요 대장님. \n  혹시 이 마을에도 좀비가 된 사람이 있나요?", 
            "  기사대장 : \n  있지. 두명이나.","  주인공 : \n  혹시 그렇다면 그들을 치료할 수 있는 방법도 아시나요?", 
            "  기사대장 : \n  아쉽게도 우리도 치료방법을 잘 알진 못한다네.\n  다만 엘프들이 약초에 능해서 그들에게\n  가서 물어본다면 뭔가 있지않을까 하고 짐작하고있을뿐."
        , "  기사대장 : \n  지금 우리마을도 사정이 넉넉치 못해서\n  엘프마을에 연락을 취할 수 없지만\n  만약 그들을 만난다면 우리마을도 도와줄 수 있겠나?"});
        talkData.Add(2001, new string[] { "  마을 주민 :\n  젠장 좀비들이 벌써 마을까지 침입해오고있어.\n  이대로 가다간 우리 모두 좀비가 될거야." });
        talkData.Add(2002, new string[] { "  마을 주민 :\n  조만간 식량이 다 떨어져버릴거야.\n  조만간 겨울이 찾아올텐데." });
        talkData.Add(2100, new string[] { "  엘프 장로 : \n  보다시피 우리마을은 아직 좀비의 위협에서 잘 버텨내고있다네.\n  듣자 하니 좀비가 된 사람을 되돌리려는것 같은데", 
            "  우리도 아직은 좀비를 되돌릴 방법은 알지 못하네,\n  그저 좀비의 발생지로 추정되는 연구소를 조사하면 뭔가 알 수 있지않을까 라고 생각할 뿐",
            "  다만 우리도 여력을 남겨놔야하니 도움을 줄 순 없네. 미안하네", "  주인공 : \n  아닙니다. 이런 도움을 주신것만으로 감사할따름입니다. \n  엘프마을에도 평화가 오기를 바라겠습니다.",
            "  엘프 장로 :\n  던전으로 향하는 길은 마을의 오른쪽 위에 있네.\n  부디 원하는 것을 얻을 수 있으면 좋겠군." });
        talkData.Add(2101, new string[] { "  엘프 주민 : \n  이 좀비들은 대체 어디서 튀어나오는거야. \n  지긋지긋하네" });
        talkData.Add(2102, new string[] { "  엘프 주민 : \n  장로님 조만간 겨울이 올겁니다. 저희도 슬슬 대책을 생각해야 할것같습니다." });
        talkData.Add(2103, new string[] { "  엘프 수비대장 : \n  그쪽 목책 좀더 보강하고! 이쪽은, 무기는 잘 정비되어가고 있나?","  주인공 : \n  안녕하십니까",
            "  엘프 수비대장 : \n  누구지? 이곳에 외지인이 들어오는경우는 별로 없는데.\n  용건이 무엇이지?","  주인공 :\n  저는 여행자입니다.\n  아들이 좀비에 물려 그 치료법을 찾으려고 여행을 하고있습니다.",
            "  엘프 수비대장 : \n  그런가.\n  장로님께 보고를 드릴테니 잠시 이곳에서 대기할 수 있도록.","  잠시 후","  엘프 수비대장 :\n  장로님이 데려오라고 하시는군.\n  이 윗길로 올라가면 되네."});
        talkData.Add(2700, new string[] { "  안내판 :\n  3가지의 문 중 정답인 문을 찾아서 들어갈 것 \n  틀린문으로 들어갈 경우 처음으로 돌아오게됨" });
        talkData.Add(2900, new string[] {"  주인공 :\n  당신은?", "  연구원 : \n  당신은 아마 이 연구소가 좀비의 발생지로 알고있겠지.\n  하지만 아니오.", 
            "  연구원 :\n 다만 우리는 누구보다 빨리 좀비바이러스에 대해서 알게 된 것 뿐이고\n  그 해결책을 찾기위해 지금껏 연구하는 중이오", 
            "  치료제는 얼마전에 개발이 끝났소.\n  이걸가지고 아래에 있는 스위치를 작동시켜보시오." });
        talkData.Add(3000, new string[] { "  스위치가 작동되었다. 이상한 포탈이 생겼는데?" });
    }

    public string getTalk(int id, int talkIndex)
    {
        if(talkIndex == 0)
        {
            joystick.SetActive(false);
        }
        if (talkIndex == talkData[id].Length)
        {
            joystick.SetActive(true);
            return null;
        }
        else
        {
            return talkData[id][talkIndex];
        }
    }
}
