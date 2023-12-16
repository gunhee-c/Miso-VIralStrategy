using UnityEngine;
using UnityEngine.UI;
using System.Collections; // Needed for IEnumerator

public class ButtonTextChanger : MonoBehaviour
{
    public int disappearAfterClicks = 5;
    public float fadeDuration = 0.5f; // Duration of the fade in seconds

    private Button dialogueButton;
    private Text sentenceText;
    public static int clickCount = 0;
    public static int clickMaxCount = 16; //fix it if you change first dialogue
    //button could be half-transparent.



    void Start()
    {

        dialogueButton = GetComponent<Button>();
        sentenceText = transform.Find("sentence").GetComponent<Text>();

        // Set button color to half-transparent
        Color buttonColor = dialogueButton.GetComponent<Image>().color;
        dialogueButton.GetComponent<Image>().color = new Color(buttonColor.r, buttonColor.g, buttonColor.b, 0.5f);

        // Initially hide the text
        sentenceText.color = new Color(sentenceText.color.r, sentenceText.color.g, sentenceText.color.b, 0);
    
    }


    public void ChangeTextAndCheckButton()
    {
        clickCount++;

        // Make the text visible after the first click
        if (clickCount == 1)
        {
            sentenceText.color = new Color(sentenceText.color.r, sentenceText.color.g, sentenceText.color.b, 1);
        }

        // Update the text
        if (ButtonTester.count==0){
            sentenceText.text = Dialogue1[clickCount-1];
            clickMaxCount = Dialogue1.Length;
        }
        if (ButtonTester.count == 1){
            sentenceText.text = Dialogue2[clickCount-1];
            clickMaxCount = Dialogue2.Length;
        }
        if (ButtonTester.count == 2){
            sentenceText.text = Dialogue3[clickCount-1];
            clickMaxCount = Dialogue3.Length;
        }
        if (ButtonTester.count == 3){
            sentenceText.text = Dialogue4[clickCount-1];
            clickMaxCount = Dialogue4.Length;
        }
        if (ButtonTester.count == 4){
            sentenceText.text = Dialogue5[clickCount-1];
            clickMaxCount = Dialogue5.Length;
        }
        if (ButtonTester.count == 5){
            sentenceText.text = Dialogue6[clickCount-1];
            clickMaxCount = Dialogue6.Length;
        }
        if (ButtonTester.count == 6){
            sentenceText.text = Dialogue7[clickCount-1];
            clickMaxCount = Dialogue7.Length;
        }
        // Update the button text to show the current count

        // Start fading and disable the button if the click count reaches the specified threshold
        if (clickCount >= clickMaxCount)
        {
            StartCoroutine(FadeOut());
        }
    }

    // Fade out the button
    IEnumerator FadeOut()
    {
        CanvasGroup canvasGroup = dialogueButton.GetComponent<CanvasGroup>();
        if (canvasGroup == null)
        {
            canvasGroup = dialogueButton.gameObject.AddComponent<CanvasGroup>();
        }

        float startAlpha = canvasGroup.alpha;
        float endTime = Time.time + fadeDuration;

        while (Time.time < endTime)
        {
            float elapsed = Time.time - (endTime - fadeDuration);
            canvasGroup.alpha = Mathf.Lerp(startAlpha, 0, elapsed / fadeDuration);
            yield return null;
        }

        canvasGroup.alpha = 0;
        dialogueButton.gameObject.SetActive(false);
    }
    private string[][] Dialogue = new string[][] {
        Dialogue1, Dialogue2, Dialogue3, Dialogue4, Dialogue5, Dialogue6, Dialogue7
    };
    private static string[] Dialogue1 = new string[] { 
"수현: \"이번주 일요일 9시에 유명 유튜버 [뜨악띠]씨와 러스트 방송 합니다 많이 놀러와주세요~\"",
"유튜브를 키자마자 내 열성팬 출신 동료인 수현이의 유튜브 채널 커뮤니티가 보인다.\n이젠 수현님이 아닐까? 싶기도 하다.",
"친구였으니 축하하지만.. 한켠으로는 배가 아프다. \n나한테 음악을 배우던 친구가 나를 확 추월해버렸으니, 당연한게 아닐까..",
"수현이도 잘하는 친구지만, 쇼츠 바이럴빨로 뜬게 99%니까..",
"수현이의 공연을 찍은 누군가의 짧은 영상에 사람들은 처음에는 수현이의 팬들을 놀렸지만, 어느새 수현이의 가창력이 대단하다고 서서히 충성팬이 되어버린 것이다.", 
"인간미도 확실한 애였으니까. 물론 나도 수현이가 좋아.",  
"인생에는 세 번의 기회가 주어진다 하지 않았나, \n여기저기 도전하보니 공개 오디션 본선에 진출하게 되었고, 무대에 내 팔로워들과 같이 설 수 있는 기회가 생겼다.", 
"내 열성팬들의 화려한 댄싱을 같이 한다면?", 
"유명세가 되었든, 악명이 생기든 지금보다는 훨씬 낫겠다는 생각이 들었다.",
"팬들을 팔아먹는게 아니냐고? \n수 년간 함께해온 애들이기에 그들은 마음의 준비가 되어있다..",
"나 역시, 잘 안된다 해도 한 번쯤 사고를 거하게 쳐본다면..", 
"그래도 여태까지 한 활동의 의미를 찾을 수 있지 않을까?",
"나: \"다들 화이팅!\"",
"팬들: \"화이팅!!!!!\"",
"XXX양의 바이럴 대작전, 시작합니다!",
""
        };  
private static string[] Dialogue2 = new string[] { 
    "PD: \"이렇게 하셔도 괜찮을까요? 그림이 썩 이쁘진 않네요..\"",
    "분명히 다들 잘한거 같은데.. 카메라로 돌려보니 영 꼴이 아니다.",
    "다들 웃고 있지만, 사실 난 걱정이 가득하다. 이래도 되는걸까?",
    ""
};

private static string[] Dialogue3 = new string[] { 
    "PD: \"오 그림 좋네요~ 최종 리허설도 이대로만 가면 좋을거에요..\"",
    "나: \"....\"",
    "나: \"알겠습니다!\"",
    ""
};
private static string[] Dialogue4 = new string[] { 
    "PD: \"고민이 많으신거 같은데.. 다음 리허설 까지는 확실히 마음을 정해주시면 좋겠어요.\"",
    "나: \"....\"",
    "나: \"알겠습니다!\"",
    ""
};
private static string[] Dialogue5 = new string[] { 
    "절도있는 안무, 미친 가창력. 역시 나는 재능있고, 이건 진짜 기회였어.",
"노래 부르는 것도 이젠 10년정도 했으니, 본선에 가뿐히 진출했다.",
"결국 어떻게 4강까지 진출해봤지만, 거기까지가 내 한계였다.",
"그래도 부르고 싶은만큼 다 불렀어.",
"팬들은 기대만큼은 아니지만 이전보다 많이 늘어났다.",
"동료들 사이 내 존재감도 확실히 늘어났다.",
"하지만 그 때 제외했던 팬들에게서 느껴지는 조금의 어색함이 내 마음을 아프게한다.",
"성공하기 위해선 어쩔 수 없었던 거니까.. 어쩔 수 없었어.",
"하지만 점점 발걸음이 뜸해지는 기존 팬들을 생각하면 마음이 아프다.",
"System: 성공의 정도를 걸은 수현이.. 하지만 이것이 최선의 정답이었을까요?",
""
};
private static string[] Dialogue6 = new string[] { 
"결국에는 쳐내야 할 팬을 쳐내지 못했다. 청중은 침묵했고, 바로 탈락했다.",
"리허설도 엉망이었는데, 모두가 떨었던 실전은 그야말로 대참사였다.",
"우리의 추한 안무는 유튜브 쇼츠는 물론 다양한 커뮤니티와 포탈 사이트에 움짤로 퍼져버렸다.",
"제목: \"23년도 물품보관소(오타쿠춤) 신작.gif\", 나와 팬들에 대한 조롱이 가득하다.",
"\"이정도면 그래도 내 서브컬쳐 아이돌 인생의 화려한 마무리 아닐까?\" 하고 방송을 켰다.",
"키자마자 수많은 악성 실시간 댓글들이 가득하다. 각오했으니 괜찮다.",
"그래도 이런 관심을 받을 기회는 흔하지 않기에 최대한 재밌게 방송했고, 내 마음이 통했는지 메뚜기떼들은 생각보다 오래 남아있었다.",
"이것도 하나의 관심? 기회? 희망이 아닐까? 이게 맞나?",
"유튜브 채널 X에서는 화제의 미소양에 대한 인터뷰를 해보고 싶다고 연락이 왔다..",
"연예탭은 아니라 사건사고탭이라고 한다.",
"팬들은 \"위기를 기회로@@@@\" 하면서 지금의 사태를 헤쳐나가기 위해 자신의 일처럼 나서고 있다.\n내 팬들이 언제부터 이리 쓸모있었지? 새삼스러운 고마움이다.",
"서브컬쳐 하꼬의 삶이 어쩌다 이렇게 흥미진진했던걸까?\n오늘도 나는 부쩍 많아진 나에 대한 언급을 보며 밤을 지샌다.",
""
};
private static string[] Dialogue7 = new string[] { 
    "최종 리허설 때 틀린 팬들을 쳐 냈는데, 마음이 약해져서 모두를 쳐내진 못했다.",
"결국 긴장한 팬들은 본 무대에서 더 실수했고, 청중은 침묵했고, 바로 탈락했다.",
"공연이 애매하게 망한 나는 바이럴거리도 되지 않았다.",
"결국에는 후회만 남는다.. 다 쳐내거나 모두를 끌어안고 갔어야 했는데,",
"인생에서 가장 중요할 수 있는 순간에 강단이 부족했다.",
""
};


}
