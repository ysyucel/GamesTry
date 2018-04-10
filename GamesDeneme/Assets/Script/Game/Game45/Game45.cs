using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using LitJson;
public class Game45 : MonoBehaviour {



   /* -----------------Game Level Parameters--------------------*/
public int[] OPTIMUMQUESTIONCOUNT         = new int[]{28, 30, 32, 34, 36, 38, 40, 44, 48, 52, 60, 68, 80};
public int[]  MAXNUMBER                   = new int[]{10, 10, 20, 20, 30, 30, 40, 40, 50, 50, 50, 50, 50};

public int[]  ROWCOUNT                    = new int[]{2,  2,  2,  2,  3,  3,  3,  3,  3,  3,  3,  3,  3};
public int[]  COLUMNCOUNT                 = new int[]{2,  2,  2,  2,  2,  2,  2,  2,  3,  3,  3,  3,  3};

public int[]  ROWCOUNTPART2               = new int[]{3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3,  3};
public int[]  COLUMNCOUNTPART2            = new int[]{2,  2,  2,  2,  2,  2,  3,  3,  3,  3,  3,  3,  3};
public int[] COLUMNTEMP = new int[13];
public int[] ROWTEMP = new int[13];

public int[]  QUESTIONTYPE                = new int[]{0,  0,  1,  1,  0,  1,  0,  1,  0,  1,  0,  1,  0};
/*----------------------------------------------------------*/

/*-----------------Constants--------------------*/
public int GAMEID                      = 45;
public int INCREMENTTIME               = 250;
public int TOTALTIME                   = 60;
public int TIMERMOD                    = 4;
public int TIMERMAX                    = 240;
public int WAITTIME                    = 500;
public int MAXBOXSIZE                  = 150;
public int MAXCOUNTDOWNFONTSIZE        = 160;
/*---------------------------------------------*/

public int score                       = 0;
public int accuracy                    = 0;
public int speed                       = 0;
public int correctCount                = 0;
public int wrongCount                  = 0;
public int optimumQuestionCount        = 0;
public int questionIndex               = 0;

public int unitTimer                   = 0;
public int unitScore                   = 0;
public int widthTimer                  = 0;
public int widthScore                  = 0;
    /*
var wrongSound                  = null;
var correctSound                = null;
var gameInstruction             = null;
var gameName					= null;
var Timer						= null;
    */
public string yonerge1                    = null;
public string yonerge2                    = null;
public int tickCount                   = 0;
public int tmpIndex                    = 0;
public int rndmNumber                  = 0;
public int innerCorrectCount           = 0;
public int x                           = 0;
public int id                          = 0;
public int questiontype                = 0;
public int[] nmbrcontrolarray          = new int[30];
//public char charcontrolarray[]       = new char[30];
public int[] rndmArray                 = new int[30];
public int[]  rndmArrayIndis           = new int[30];
//public int[]  rndmArrayChar          = new Array(30);
public int rowcount                    = 0;
public int columncount                 = 0;
//public Color[] colors                      = new Color[]{3cb64a, 43aabd, 475eab, 4aa1d9, 4dc7e6, 5b5ca9, 70bf45, aa5c75, ac4a7d, cc3d3c, e4c74f, ed3e41, eea63f};
public int boxCount = 0;
public bool optimumMiddleControl        = true;
public bool locked = false;
public bool paused = false;
public int timerIsActive = 0;

public int deviceWidth = 0;
public int deviceHeight = 0;
public int maxBoxCount = 0;
public int imgSize = 0;
public int boxSize = 0;
public int gameScreen = 0;
public bool stopPlay = false;

    ///////////////////////////////////yavuz
public GameObject[] dummyObject = new GameObject[9];
public GameObject buttonPrefab,buttonPrefabBottomBar;
public GameObject pauseScreen, pauseButtonImage, timerSprite, countDownText,gameBoard,trueGameObject,falseGameObject,coinPrefab,topBarCoin;
public Sprite pauseImage, playImage;
public Text timerText, gameNameTopBar,gameNamePauseMenu,pauseMenuInstruction,instructionText,scoreText;
public float maxTime = 60.0f;
public float leftTime = 60.0f;
public int delayTextUpdate = 30;
public static JsonData jsonGame;
public string path = "";
public string content = "";
public bool isReady = false;
public bool timerSoundPlaying = false;
public int userLevel = 0;
public float cellsize = 100;
public GameObject[] elements,elementsBottom;
public int activeBoardCount,trueAnswerCount;
public bool isButtonClickable = false;
private RectTransform rt;
public GameObject timerSound;
	// Use this for initialization
	void Start () {
        GameObject.Find("AudioSourceGameObject").GetComponent<SoundPlayer>().playStartSound();
        if (QUESTIONTYPE[userLevel] == 0)
        {
            questiontype = 0;
        }
        if (QUESTIONTYPE[userLevel] == 1)
        {
            questiontype = 1;
        }
        rt = (RectTransform)gameBoard.transform;
        COLUMNTEMP = COLUMNCOUNT;
        ROWTEMP = ROWCOUNT;
        boxCount = COLUMNTEMP[userLevel] * ROWTEMP[userLevel];
        //elements = new GameObject[9];
        elementsBottom = new GameObject[9];
        paused = true;
        readJson();
	}
	
	// Update is called once per frame
	void Update () {
        if (!paused) {
            leftTime -= Time.deltaTime;
        }
        if (delayTextUpdate == 30) {
            delayTextUpdate = 0;
            timerText.text=((int)leftTime).ToString();
        }
        delayTextUpdate++;
        timerSprite.GetComponent<Image>().fillAmount = (float)leftTime/(float)maxTime;
        if (leftTime < 0.1f) {

            loadGameSummary();
        }
        if (leftTime < 7.1f)
        {
            timerSound.SetActive(true);
            timerSoundPlaying = true;
        }
	}


    //Pause Menu Aktif Deaktif Toggle
    public void pauseGame() {
        if (isReady)
        {
            if (paused)
            {
                if (timerSoundPlaying)
                {
                    timerSound.GetComponent<SoundPlayer>().resumeTimerSound();
                }
                pauseScreen.SetActive(false);
                pauseButtonImage.GetComponent<Image>().sprite = pauseImage;
                paused = false;
            }
            else
            {
                if (timerSoundPlaying)
                {
                    timerSound.GetComponent<SoundPlayer>().pauseTimerSound();
                }
                pauseScreen.SetActive(true);
                pauseButtonImage.GetComponent<Image>().sprite = playImage;
                paused = true;
            }
        }
    
    }

    //Successfull game finish return Game Summary
    public void loadGameSummary() {
        //sendScore();
        //Application.LoadLevel("Index");
        Application.LoadLevel("Game45");
    }
    //Restart ve Quit Game
    public void changeSceneInGame(string sceneName) {
        Application.LoadLevel(sceneName);
    }
    public void readJson() {
            
            /*path = "GameResource/"+"Game45"+"/"+"tr"+".min";
            TextAsset txt = Resources.Load<TextAsset>(path);
            content = txt.text;
            Debug.Log(txt);
            jsonGame = JsonMapper.ToObject(content);
            if (questiontype == 0)
            {
                instructionText.text = jsonGame["yonerge1"].ToString();
            }
            if (questiontype == 1)
            {
                instructionText.text = jsonGame["yonerge2"].ToString();
            }
            gameNameTopBar.text = jsonGame["gameName"].ToString().ToUpper();
            gameNamePauseMenu.text = jsonGame["gameName"].ToString().ToUpper();
            pauseMenuInstruction.text = jsonGame["gameInstruction"].ToString();*/
            StartCoroutine("countDown");
            
    }
    public IEnumerator countDown() {
        yield return new WaitForSeconds(1.0f);
        countDownText.GetComponent<Text>().text = "3";
        yield return new WaitForSeconds(1.0f);
        countDownText.GetComponent<Text>().text = "2";
        yield return new WaitForSeconds(1.0f);
        countDownText.GetComponent<Text>().text = "1";
        yield return new WaitForSeconds(1.0f);
        countDownText.SetActive(false);
        gameBoard.SetActive(true);
        StartCoroutine("createBoard");
        paused = false;
        isReady = true;
    }
    public IEnumerator createBoard() {
        if (elements[0] != null)
        {
            for (int i = boxCount-1; i >-1; i--)
            {
                if (elements[i] != null)
                {
                    elements[i].GetComponent<Animator>().SetBool("isDisappear", true);
                    yield return new WaitForSeconds(0.2f);
                    //Destroy(elements[i]);
                    elements[i].SetActive(false);
                }
            }
            
        }
            gameBoard.GetComponent<GridLayoutGroup>().constraintCount = COLUMNTEMP[userLevel];
        trueAnswerCount = 0;
        boxCount = COLUMNTEMP[userLevel] * ROWTEMP[userLevel];
        activeBoardCount = boxCount;
        cellsize = rt.rect.height / ROWTEMP[userLevel];
        if (cellsize > rt.rect.width / COLUMNTEMP[userLevel])
        {
            cellsize = rt.rect.width / COLUMNTEMP[userLevel];
        }
        gameBoard.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellsize, cellsize);
        rndmnmbr();
        for (int i = 0; i < 9; i++) {
            if (i < boxCount)
            {
                dummyObject[i].SetActive(true);
            }
            else {
                dummyObject[i].SetActive(false);
            }
        }
        for (int i = 0; i < boxCount; i++)
        {
            dummyObject[i].SetActive(false);
            //yield return new WaitForSeconds(0.1f);
            //elements[i] = Instantiate(buttonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;

            elements[i].SetActive(true);
            elements[i].GetComponent<Game45Button>().done = false;
            //elements[i].transform.parent = GameObject.Find("GameBoard").transform;
            Debug.Log(i);
            elements[i].GetComponent<Animator>().SetBool("isDisappear", false);
            //elements[i].transform.SetSiblingIndex(i);
            elements[i].transform.GetChild(0).GetComponent<Text>().text = rndmArray[i].ToString();
        }
        bottomBarSet();
        isButtonClickable = true;

        paused = false;
    }

    //kutu sayisi kadar rastgele sayi uretilir
    public void rndmnmbr () {
        System.Array.Clear(rndmArray, 0, rndmArray.Length);
        for (int i = 0; i < boxCount; i++) {
            rndmNumber = Random.Range( 0, MAXNUMBER[userLevel]);
            while (!nmbrControl(rndmNumber)) {
                rndmNumber = Random.Range( 0, MAXNUMBER[userLevel]);
            }
            rndmArray[i] = rndmNumber;

        }
        //setNumber();
    }

    public void buttonActionElement(int x) {
        Debug.Log(x);
        int lowest = x;
        int selected=0;
        for (int i = 0; i < boxCount; i++) {
            if (questiontype == 0)
            {
                if (rndmArray[i] < lowest)
                {
                    wrongAnswer(selected);

                    GameObject.Find("AudioSourceGameObject").GetComponent<SoundPlayer>().playWrongSound();
                    return;
                }
                else if (rndmArray[i] == lowest)
                {
                    selected = i;
                }
            }
            else {
                if (rndmArray[i] > lowest)
                {
                    wrongAnswer(selected);
                    GameObject.Find("AudioSourceGameObject").GetComponent<SoundPlayer>().playWrongSound();
                    return;
                }
                else if (rndmArray[i] == lowest)
                {
                    selected = i;
                }
            }
        }
        GameObject.Find("AudioSourceGameObject").GetComponent<SoundPlayer>().playCorrectSound();
        trueAnswer(selected);

    }


    public void wrongAnswer(int selected) {

        StartCoroutine("wrongQuestion");
    }
    public void trueAnswer(int selected)
    {
        elementsBottom[trueAnswerCount] = Instantiate(buttonPrefabBottomBar, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        elementsBottom[trueAnswerCount].transform.parent = GameObject.Find("AnswerList").transform.GetChild(trueAnswerCount).transform;
        elementsBottom[trueAnswerCount].GetComponent<RectTransform>().sizeDelta = new Vector2(GameObject.Find("AnswerList").transform.GetChild(trueAnswerCount).GetComponent<RectTransform>().rect.height,GameObject.Find("AnswerList").transform.GetChild(trueAnswerCount).GetComponent<RectTransform>().rect.width);
        elementsBottom[trueAnswerCount].GetComponent<RectTransform>().position = new Vector3(GameObject.Find("AnswerList").transform.GetChild(trueAnswerCount).GetComponent<RectTransform>().position.x, GameObject.Find("AnswerList").transform.GetChild(trueAnswerCount).GetComponent<RectTransform>().position.y, GameObject.Find("AnswerList").transform.GetChild(trueAnswerCount).GetComponent<RectTransform>().position.z);
        
        elementsBottom[trueAnswerCount].transform.GetChild(0).GetComponent<Text>().text = rndmArray[selected].ToString();

        GameObject go=Instantiate(coinPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.position = new Vector3(elements[selected].transform.position.x, elements[selected].transform.position.y, elements[selected].transform.position.z);
        go.transform.localScale = new Vector3(1.0f,1.0f, 1.0f);
        go.transform.GetChild(0).localScale = new Vector3(1.0f, 1.0f, 1.0f);
        Debug.Log(go.transform.position);
        Debug.Log(elements[selected].transform.position);
        StartCoroutine("buttonDisapper", elements[selected]);
        if (questiontype == 0)
        {
            rndmArray[selected] = 999;
        }
        else {
            rndmArray[selected] = -1;
        }
        trueAnswerCount++;

        
        if (trueAnswerCount == activeBoardCount)
        {
            paused = true;
            if (score < 50)
            {
                COLUMNTEMP = COLUMNCOUNT;
                ROWTEMP = ROWCOUNT;
            }
            else
            {
                COLUMNTEMP = COLUMNCOUNTPART2;
                ROWTEMP = ROWCOUNTPART2;
            }

            StartCoroutine("newQuestion", true);
            
        }
    }
    //
    public void setNumber() { 
        for (int i = 0; i < boxCount; i++) {
            elements[i].transform.GetChild(0).GetComponent<Text>().text = rndmArray[i].ToString();
        }
    }
    //sayi daha once secildi mi kontrolu yapilir
    public bool nmbrControl (int value) {

        int index = System.Array.IndexOf(rndmArray, value);
        if (index == -1) { return true; }
        else { return false; }
        
    }
    public IEnumerator buttonDisapper(GameObject selectedButton) {
        selectedButton.GetComponent<Animator>().SetBool("isDisappear", true);
        yield return new WaitForSeconds(0.01f);
    }
    public IEnumerator newQuestion(bool isTrue)
    {
        yield return new WaitForSeconds(0.2f);
        GameObject.Find("AnswerList").GetComponent<Animator>().SetBool("isDisappaer", true);
        yield return new WaitForSeconds(0.2f);
        GameObject.Find("AnswerList").GetComponent<Animator>().SetBool("isDisappaer", false);

        for (int i = boxCount - 1; i > -1; i--)
        {
            if (elementsBottom[i] != null)
            {
                Destroy(elementsBottom[i]);
            }
        }
        isButtonClickable = false;
        
        if (isTrue)
        {
            trueGameObject.SetActive(false);
            trueGameObject.SetActive(true);
        }
        yield return new WaitForSeconds(0.1f);
        StartCoroutine("createBoard");
    }
    public IEnumerator wrongQuestion()
    {
        paused = true;
        falseGameObject.SetActive(false);
        falseGameObject.SetActive(true);
        isButtonClickable = false;
        for (int i = boxCount - 1; i > -1; i--)
        {
            if (elements[i] != null)
            {
                elements[i].GetComponent<Animator>().SetBool("isDisappear", true);
                //yield return new WaitForSeconds(0.1f);
                
                
            }
        }

        yield return new WaitForSeconds(0.4f);
        for (int i = boxCount - 1; i > -1; i--)
        {
                elements[i].SetActive(false);
                dummyObject[i].SetActive(true);
        }
        StartCoroutine("newQuestion", false);
    }
    public void scoreIncreaser() {
        topBarCoin.GetComponent<Image>().fillAmount = (float)score / (float)100;
        Debug.Log(score / 100);
        score += 100 / OPTIMUMQUESTIONCOUNT[userLevel];
        scoreText.text = score.ToString();
    }
    public void bottomBarSet() {
        if (boxCount == 4) {
            GameObject.Find("AnswerList").GetComponent<GridLayoutGroup>().cellSize = new Vector2( 40.0f,40.0f);
        }
        if (boxCount == 6)
        {
            GameObject.Find("AnswerList").GetComponent<GridLayoutGroup>().cellSize = new Vector2(35.0f, 35.0f);
        }
        if (boxCount == 9)
        {
            GameObject.Find("AnswerList").GetComponent<GridLayoutGroup>().cellSize = new Vector2(26.0f, 40.0f);
        }
        for(int i=0; i<9;i++){
            if(i<boxCount){
                GameObject.Find("AnswerList").transform.GetChild(i).gameObject.SetActive(true);
                
            }
            else{
                GameObject.Find("AnswerList").transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    //update rate servis
    public void sendScore()
    {
        string urlGetTraining = "http://test.mentalup.net/MentalUpWebService/service.asmx/writeScore?callback=scoreWritten&username=ysyucel&password=123456&catid=2&gameid=45&maxlevel=10&level=1&score=50&accuracy=0&averageanswertime=0&fromdailytraining=0&correctcount=10&wrongcount=2";
        Application.OpenURL(urlGetTraining);
    }
}

