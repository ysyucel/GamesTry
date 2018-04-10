using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using LitJson;

public class Game1 : MonoBehaviour {

    /* -----------------Game Level Parameters--------------------*/
    public int[] OPTIMUMQUESTIONCOUNT = new int[] { 28, 30, 32, 34, 36, 38, 40, 44, 48, 52, 60, 68, 80 };
    public float[] DISPLAYTIME = new float[] { 1, 1, 1, 1, 1, 0.5f, 0.5f, 0.5f, 0.5f, 0.5f };
    public int[] VIEWIMAGECOUNT = new int[] { 2, 2, 2, 3, 3, 3, 3, 4, 4, 4 };
    public int[] TOTALVIEWCOUNT = new int[] { 3, 5, 7, 7, 8, 9, 10, 11, 13, 15 };
    public int TOTALIMAGECOUNT = 4;
    public int[] IMAGELOCATIONTYPE = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1 };
    public int[] HORIZONTAL = new int[] { 1, 1, 1, 1, 1, 1, 1, 2, 2, 2};
    public int[] VERTICAL = new int[] { 2, 2, 2, 3, 3, 3, 3, 2, 2, 2 };
    /*----------------------------------------------------------*/

    /*-----------------Constants--------------------*/
    public int GAMEID = 1;
    public int INCREMENTTIME1 = 500;
    public int INCREMENTTIME = 250;
    public int TIMERMOD = 4;
    public int MAXIMGSIZE = 500;
    public int MAXCOUNTDOWNFONTSIZE = 160;
    /*---------------------------------------------*/

    public int score = 0;
    public int accuracy = 0;
    public int speed = 0;
    public int correctCount = 0;
    public int wrongCount = 0;
    public int optimumQuestionCount = 0;
    public int questionIndex = 0;
    public int timerMax = 0;

    public int unitTimer = 0;
    public int unitScore = 0;
    public int widthTimer = 0;
    public int widthScore = 0;
    /*
var wrongSound                  = null;
var correctSound                = null;
var gameInstruction             = null;
var gameName					= null;
var Timer						= null;
    */

    public string yonerge1 = null;
    public string yonerge2 = null;

    public int levelHorizontal             = 0;
    public int levelVertical               = 0;
    public int levelViewImageCount         = 0;
    public int levelTotalViewCount         = 0;
    public int levelImageLocationType      = 0;
    public float levelDisplayTime          = 0.0f;

    public int tmpIndex                    = 0;
    public int tickCount1                  = 0;

    //public int count                       = 0;
    public int answer                      = 0;
    //public int imageIndisControl           = new Array(TOTALIMAGECOUNT);
    public int imageId                     = 0;
    public bool locked                     = true;
    public int state                       = -1;
    public int loadedImgCount              = 0;
    public int divCount                    = 0;
    public int divId                       = 0;

    public int deviceWidth                 = 0;
    public int deviceHeight                = 0;
    public int imgSize                     = 0;
    public int marginSize                  = 0;
    public string subDirectory             = "";
    public int gameScreen                  = 0;
    public bool paused                     = false;

    public int questionIndexBar            = 0;
    public int questionCountBar            = 0;
    

    ///////////////////////////////////yavuz
    public GameObject[] dummyObject = new GameObject[9];
    public GameObject buttonPrefab, buttonPrefabBottomBar;
    public GameObject pauseScreen, pauseButtonImage, timerSprite, countDownText, gameBoard, trueGameObject, falseGameObject, coinPrefab, topBarCoin;
    public Sprite pauseImage, playImage;
    public Text timerText, gameNameTopBar, gameNamePauseMenu, pauseMenuInstruction, instructionText, scoreText;
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
    public float imageSize = 0;
    public GameObject[] elements;
    public GameObject audioSourceGame;
    public int activeBoardCount, trueAnswerCount;
    public bool isButtonClickable = false;
    private RectTransform rt;
    public int level = 1;
    public int boxCount = 0;
    public GameObject timerSound;
    public Sprite openWindow, closeWindow,correctSprite,wrongSprite;
    public GameObject[] windows;
    public Sprite[] gameImageSpriteList = new Sprite[4];


    public int count = 0;
    public int rndmNumber;
    public int[] locationList = new int[15];
    public int[] imageNumber = new int[4] { 0, 0, 0, 0 };
    public int maxNumber = 0;
    public int maxNumberIndex = 0;
    public bool isMaxSame = false;

    // Use this for initialization
    void Start()
    {


        optimumQuestionCount = OPTIMUMQUESTIONCOUNT[level - 1];
        levelTotalViewCount = TOTALVIEWCOUNT[level - 1];
        levelViewImageCount = VIEWIMAGECOUNT[level - 1];
        levelImageLocationType = IMAGELOCATIONTYPE[level - 1];
        levelHorizontal = HORIZONTAL[level - 1];
        levelVertical = VERTICAL[level - 1];
        levelDisplayTime = DISPLAYTIME[level - 1];
        int imageCount = levelViewImageCount;
        
        imageCount--;
        for (int i = 1; i < 5; i++)
        {
            if (i > levelViewImageCount)
            {
                dummyObject[i-1].SetActive(false);
            }
        }
        rt = (RectTransform)gameBoard.transform;
        boxCount = levelHorizontal * levelVertical;
        paused = true;
        if (boxCount != 4)
        {
            gameBoard.GetComponent<GridLayoutGroup>().constraintCount = 1;
            cellsize = rt.rect.height / boxCount;

            gameBoard.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellsize, cellsize * 1.02f);
            imageSize = cellsize * (96f / 173f);
            if (boxCount == 2)
            {
                cellsize = (rt.rect.height / boxCount)*0.7f;
                gameBoard.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellsize, cellsize * 1.02f);
                imageSize = cellsize * (96f / 173f);
            }
        }
        else
        {
            gameBoard.GetComponent<GridLayoutGroup>().constraintCount = 2;
            cellsize = rt.rect.width / 2;
            imageSize = cellsize * (102f / 159f);
            gameBoard.GetComponent<GridLayoutGroup>().cellSize = new Vector2(cellsize, cellsize * (53f / 46f));
        }
        trueAnswerCount = 0;
        boxCount = levelHorizontal * levelVertical;
        activeBoardCount = boxCount;

        RectTransform objectRectTransform = elements[0].GetComponent<RectTransform>();
        objectRectTransform.sizeDelta = new Vector2(imageSize, imageSize);

        RectTransform objectRectTransform1 = elements[1].GetComponent<RectTransform>();
        objectRectTransform1.sizeDelta = new Vector2(imageSize, imageSize);

        RectTransform objectRectTransform2 = elements[2].GetComponent<RectTransform>();
        objectRectTransform2.sizeDelta = new Vector2(imageSize, imageSize);

        RectTransform objectRectTransform3 = elements[3].GetComponent<RectTransform>();
        objectRectTransform3.sizeDelta = new Vector2(imageSize, imageSize);

        StartCoroutine("countDown");
        //readJson();
        //audioSourceGame.GetComponent<SoundPlayer>().playStartSound();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (delayTextUpdate == 30)
        {
            delayTextUpdate = 0;
            timerText.text = ((int)leftTime).ToString();
        }
        delayTextUpdate++;
        timerSprite.GetComponent<Image>().fillAmount = (float)leftTime / (float)maxTime;
        if (leftTime < 0.1f)
        {

            loadGameSummary();
        }
        
    }


    //Pause Menu Aktif Deaktif Toggle
    public void pauseGame()
    {
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
    public void loadGameSummary()
    {
        //sendScore();
        //Application.LoadLevel("Index");
        Application.LoadLevel("Game1");
    }
    //Restart ve Quit Game
    public void changeSceneInGame(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
    public void readJson()
    {

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
        

    }
    public IEnumerator countDown()
    {
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
    public IEnumerator createBoard()
    {

        yield return new WaitForSeconds(0.1f);
       
        isButtonClickable = true;
        paused = false;
        StartCoroutine("newQuestion", true);
    }

    

    public void buttonActionElement(int x)
    {
        Debug.Log(x);
        int lowest = x;
        int selected = 0;
        
        audioSourceGame.GetComponent<SoundPlayer>().playCorrectSound();
        trueAnswer(selected);

    }


    public void wrongAnswer(int selected)
    {

        StartCoroutine("wrongQuestion");
    }
    public void trueAnswer(int selected)
    {
       

        GameObject go = Instantiate(coinPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        go.transform.parent = GameObject.Find("Canvas").transform;
        go.transform.position = new Vector3(elements[selected].transform.position.x, elements[selected].transform.position.y, elements[selected].transform.position.z);
        go.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        go.transform.GetChild(0).localScale = new Vector3(1.0f, 1.0f, 1.0f);

        
    }
    //
    public void setNumber()
    {
        for (int i = 0; i < boxCount; i++)
        {
        }
    }
    //sayi daha once secildi mi kontrolu yapilir
    public bool nmbrControl(int value)
    {
        return true;

    }
    public IEnumerator buttonDisapper(GameObject selectedButton)
    {
        selectedButton.GetComponent<Animator>().SetBool("isDisappear", true);
        yield return new WaitForSeconds(0.01f);
    }
    public IEnumerator newQuestion(bool isTrue)
    {
        isButtonClickable = false;
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < boxCount; i++)
        {
            elements[i].GetComponent<Animator>().SetBool("coming", false);
            windows[i].GetComponent<Animator>().SetBool("open", false);
            elements[i].GetComponent<Animator>().SetBool("return", false);
            windows[i].GetComponent<Animator>().SetBool("close", false);
        }

        bool existInList = false;
        int[] listPath = new int[4];
        int[] listShowCount = new int[4];
        //kullanıcağımız image listesi
        for (int i = 0; i < 4; )
        {
            listPath[i] = Random.Range(1, 5);
            for (int j = 0; j < i; j++) {
                if (listPath[j] == listPath[i]) {
                    existInList = true;
                }
            }
            if (!existInList)
            {
                i++;
            }
            else {
                existInList = false;
            }
        }

        Debug.Log(listPath[0].ToString() + listPath[1].ToString() + listPath[2].ToString() + listPath[3].ToString());
        if (IMAGELOCATIONTYPE[level] == 0) {
            imageSetter();
            
        }
        Debug.Log(listPath[0].ToString()+listPath[1].ToString()+listPath[2].ToString()+listPath[3].ToString());

        if (IMAGELOCATIONTYPE[level] == 1)
        {
            imageSetter();
        }








        count = 0;
        Debug.Log("boxCount: " + boxCount);
        for (int i = 0;  count < TOTALVIEWCOUNT[level-1]; i++)
        {
             rndmNumber = Random.Range(0, boxCount);

             elements[rndmNumber].GetComponent<Image>().sprite = gameImageSpriteList[listPath[rndmNumber]-1];


             windows[rndmNumber].GetComponent<Animator>().SetBool("open", true);
            yield return new WaitForSeconds(0.2f);
            windows[rndmNumber].GetComponent<Animator>().SetBool("open", false);
            elements[rndmNumber].GetComponent<Animator>().SetBool("coming", true);
            yield return new WaitForSeconds(0.3f+DISPLAYTIME[level - 1]);
            elements[rndmNumber].GetComponent<Animator>().SetBool("coming", false);
            elements[rndmNumber].GetComponent<Animator>().SetBool("return", true);
            windows[rndmNumber].GetComponent<Animator>().SetBool("close", true);
            yield return new WaitForSeconds(0.3f);
            elements[rndmNumber].GetComponent<Animator>().SetBool("return", false);
            windows[rndmNumber].GetComponent<Animator>().SetBool("close", false);
            
            yield return new WaitForSeconds(0.3f);
            count++;
        }
        for (int i = 0; i < boxCount; i++) {
            elements[i].GetComponent<Image>().sprite = gameImageSpriteList[listPath[i]-1];
            windows[i].GetComponent<Animator>().SetBool("open", true);
        }
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < boxCount; i++)
        {
            elements[i].GetComponent<Animator>().SetBool("coming", true);
        }

        isButtonClickable = true;
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
    public void buttonHandler(int buttonIndex) {
        if (isButtonClickable)
        {
            isButtonClickable = false;
            for (int i = 0; i < boxCount; i++)
            {

                elements[i].GetComponent<Animator>().SetBool("coming", false);
                windows[i].GetComponent<Animator>().SetBool("open", false);
                elements[i].GetComponent<Animator>().SetBool("return", true);
                windows[i].GetComponent<Animator>().SetBool("close", true);

            }
            if (maxNumberIndex == buttonIndex)
            {
                audioSourceGame.GetComponent<SoundPlayer>().playCorrectSound();
                trueAnswer(buttonIndex);

            }
            StartCoroutine("newQuestion", false);
        }
    }
    public void scoreIncreaser()
    {
        Debug.Log("scoreIncreaser Game1");
        topBarCoin.GetComponent<Image>().fillAmount = (float)score / (float)100;
        Debug.Log(score / 100);
        score += 100 / OPTIMUMQUESTIONCOUNT[userLevel];
        scoreText.text = score.ToString();
    }
    
    //update rate servis
    public void sendScore()
    {
        string urlGetTraining = "http://test.mentalup.net/MentalUpWebService/service.asmx/writeScore?callback=scoreWritten&username=ysyucel&password=123456&catid=2&gameid=45&maxlevel=10&level=1&score=50&accuracy=0&averageanswertime=0&fromdailytraining=0&correctcount=10&wrongcount=2";
        Application.OpenURL(urlGetTraining);
    }
    public void imageSetter() {
        for (int i = 0; i < 4; i++)
        {
            elements[i].GetComponent<Image>().sprite = gameImageSpriteList[i];
        }
        Debug.Log("haha");
        imageCountSetter();
    }
    public void imageCountSetter() {
        for (int i = 0; i < boxCount;i++ )
        {
            imageNumber[i] = 0;
        }
        for (int i = 0; i < TOTALVIEWCOUNT[level - 1]; i++)
        {
            rndmNumber = Random.Range(0, boxCount);
            locationList[i] = rndmNumber;
            imageNumber[rndmNumber]++;
        }
        Debug.Log(imageNumber[0].ToString() + imageNumber[1].ToString() + imageNumber[2].ToString() + imageNumber[3].ToString());
        for (int i = 0; i < boxCount; i++)
        {
            if (i == 0) {
                maxNumber = imageNumber[i];
                maxNumberIndex = 0;
            }
            else if (imageNumber[i] > maxNumber)
            {
                maxNumber = imageNumber[i];
                maxNumberIndex = i;
            }

            if (imageNumber[i] == 0) {
                isMaxSame = true;
            }
        }
        Debug.Log(imageNumber[0].ToString() + imageNumber[1].ToString());
        for (int i = 0; i < boxCount; i++)
        {
            if (maxNumberIndex != i)
            {
                if (imageNumber[maxNumberIndex] == imageNumber[i])
                {
                    isMaxSame = true;
                }
            }
        }
        if (isMaxSame == true)
        {
            Debug.Log("Unsuccess");
            isMaxSame = false;
            imageCountSetter();
            return;
        }
        else {
            Debug.Log("success");
        }
    }
  
}


