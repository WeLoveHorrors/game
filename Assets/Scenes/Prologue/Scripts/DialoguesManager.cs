using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class DialoguesManager : MonoBehaviour
{
    public List<Dialogue> Dialogues;
    public List<TMP_Text> Answears;
    public TMP_Text Question;
    public GameObject AnswearsPanel;

    public bool isTextRendered = false;

    
    private float TextIndex = 0;
    private int CurrentDialogue = 0;
    private string TextGoal = "";
    private bool needToReply = false;
    private bool isFading = false;

    void Start()
    {
        Dialogues = new List<Dialogue>();
        // Dialogues.Add(new Dialogue("Док: Марті.."));
        // Dialogues.Add(new Dialogue("Док: Марті, ти мене чуєш?"));
        // Dialogues.Add(new Dialogue("Док: В нас проблеми, Марті", new List<Tuple<string, string>>(){ new Tuple<string, string>("Що коїться, Док?", "Док: Я ледве встиг тебе врятувати, як в нас пройшла сутичка з тими бандитами."), new Tuple<string, string>("Де ми?", "Док: На нас напали, бо я вкрав пляшечку львівського. Тебе вирубили, я ледве встиг нас з тобою врятувати.."), new Tuple<string, string>("Куди ми летимо?", "Док: В цьому і проблема.. Коли ми намагалися втікти, то пошкодили наш пристрій для подорожів у часі..") }));
        // Dialogues.Add(new Dialogue("Марті: Я зовсім нічого не розумію, Док.."));
        // Dialogues.Add(new Dialogue("Док: Прибор внаслідок ураження почав вибивати помилки у розрахунках, Марті, це дуже погано.."));
        // Dialogues.Add(new Dialogue("Док: Ти.. Ти розумієш, що це значить, Марті?", new List<Tuple<string, string>>(){new Tuple<string, string>("Ні..","Док: Ми в халепі, Марті.."),new Tuple<string, string>("Ми в халепі, Док?","Док: Так, Марті, прилад може вийти з ладу з хвилини на хвилину.."), new Tuple<string, string>("Пошкодження дуже серйозні?","Док: Я не можу оцінити ступінь ураження, але з виду нас може відправити не туди, куди виставлений час подорожі..")}));
        // Dialogues.Add(new Dialogue("Марті: Я зовсім нічого не розумію, Док.."));
        // Dialogues.Add(new Dialogue("Марті: Дідько, ну й халепа.."));

        // Dialogues.Add(new Dialogue("Док: мяяу?", new List<Tuple<string, string>>(){
        //     new Tuple<string, string>("Мяяу", "Док: Хто мяукаэ?"), 
        //     new Tuple<string, string>(":3", "Док: O_o"), 
        //     new Tuple<string, string>("Мяяяяяяу", "Док: мяяяяяяяяяяяяяяяяяяу")}));
        
        Dialogues.Add(new Dialogue("Док: Агов!"));
        Dialogues.Add(new Dialogue("Док: Марті, ти мене чуєш? Ти прийшов до тями?", new List<Tuple<string, string>>(){
            new Tuple<string, string>("Так, я тебе чую. Що коїться, Док?", "Док: У нас проблеми, Марті... Я ледве встиг тебе врятувати," + 
            "як в нас пройшла сутичка з тими бандитами."), 
            new Tuple<string, string>("Я... Я зовсім нічого не пам'ятаю. Де ми?", "На нас напали, бо я вкрав пляшечку львівського. Тебе" + 
            "вдарили по голові, і ти знепритомнів. Тому мені прийшлося тягнути тебе на спині, із-за цього я не встиг забрати більшість наших речей."), 
            new Tuple<string, string>("Ти знову щось вкрав?!", "В цьому і проблема... Я зараз тестую збільшений бак для палива, тому, " + 
            "через те, що на нас напали, я не встиг дозаправити Делоріан.")}));
        Dialogues.Add(new Dialogue("Марті: А чого ти мене не попередив про це? Я зовсім нічого не розумію, Док..."));
        Dialogues.Add(new Dialogue("Док: Ну, не було часу на це... Також, коли вони намагалися нас догнати, то обстріляли машину. Бідний Делоріан.."));
        Dialogues.Add(new Dialogue("Док: Прибор внаслідок ураження почав вибивати помилки у розрахунках.. Марті, це дуже погано.."));
        Dialogues.Add(new Dialogue("Док: Ти.. Ти розумієш, що це значить, Марті?", new List<Tuple<string, string>>(){
            new Tuple<string, string>("Ні, Док..", "Док: Ми в халепі, Марті.."), 
            new Tuple<string, string>("Ми в халепі, Док? Наскільки все погано?", "Так, Марті, прилад може вийти з ладу з хвилини на хвилину.."), 
            new Tuple<string, string>("Пошкодження дуже серйозні?", "Я не можу оцінити ступінь ураження, але з виду нас може відправити" + 
            " не туди, куди виставлений час подорожі..")}));
        Dialogues.Add(new Dialogue("Док: Я навіть не уявляю куди нас може відправити.."));
        Dialogues.Add(new Dialogue("Док: Тому, слухай мене уважно, Марті..."));
        Dialogues.Add(new Dialogue("Марті: Так, Док?"));
        Dialogues.Add(new Dialogue("Док: У тебе в ногах зараз знаходиться автомат, це моя нова розробка."));
        Dialogues.Add(new Dialogue("Док: Так як він працює по іншій системі, то кулі замінювати не потрібно."));
        Dialogues.Add(new Dialogue("Док: Також, коли ми ще були у лабораторії, я тайкома замінив твоє взуття на інше, воно дозволяє пом'якшити" + 
        " падіння з висоти."));
        Dialogues.Add(new Dialogue("Док: В такому випадку, навіть якщо нас розділить, чого не повинно статися, ти зможеш себе захистити. І ще.."));
        Dialogues.Add(new Dialogue("Док: Якщо це все-таки станеться, обов'язково знайди мене."));
        Dialogues.Add(new Dialogue("Марті: Я зовсім нічого не розумію, Док.."));
        Dialogues.Add(new Dialogue("Марті: Чому на панелі приладів усе почало блимати?"));
        Dialogues.Add(new Dialogue("Док: Ні.. Я цього і очікував.. Тримайся, Марті!!"));
        Dialogues.Add(new Dialogue("Марті: Щ..?"));

        SetDialogues();
        AnswearsPanel.SetActive(false);
    }

    void Update()
    {
        if(!isTextRendered)
        {
            if(TextIndex < TextGoal.Length)
            {
                Question.text = TextGoal.Substring(0, (int)(TextIndex+= 25f * Time.deltaTime));
            }
            else
            {
                isTextRendered = true;

                if(needToReply && Dialogues[CurrentDialogue].hasAnswears)
                {
                    Invoke("UnlockPanel", 1.5f);
                }
                else
                {
                    Invoke("RunNext", 4f);
                }
            }
        }
        
        if(isFading)
        {
            if(Question.color.a > 0)
            {
                Question.color -= new Color(0,0,0, 12f * Time.deltaTime);
            }
            else
            {
                Question.gameObject.SetActive(false);
            }
        }
    }

    private void SetDialogues()
    {
        TextIndex = 0;
        if(Dialogues[CurrentDialogue].hasAnswears)
        {
            int AnswearIndex = 0;
            Answears.ForEach(x=> x.text = Dialogues[CurrentDialogue].AnswearsAndReplies[AnswearIndex++].Item1);
            needToReply = true;
        }
        Question.text = "";
        TextGoal = Dialogues[CurrentDialogue].Question;
    }

    private void UnlockPanel()
    {
        AnswearsPanel.SetActive(true);
        AnswearsPanel.GetComponent<Animator>().Play("AnswearsShow", 0, 0);
        Time.timeScale = 0.5f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    private void RunNext()
    {
        if(CurrentDialogue < Dialogues.Count - 1)
        {
            TextIndex = 0;
            CurrentDialogue++;

            isTextRendered = false;
            // needToReply = true;
            SetDialogues();

            if(CurrentDialogue == 3)
            {
                GetComponent<ButtonsHandler>().HandleButton1();
            }
            else if(CurrentDialogue == 5)
            {
                GetComponent<ButtonsHandler>().HandleButton5();
            }
            else if(CurrentDialogue == 7)
            {
                GetComponent<ButtonsHandler>().HandleButton2();
            }
            else if(CurrentDialogue == 9)
            {
                GetComponent<ButtonsHandler>().HandleButton4();
            }
            else if(CurrentDialogue == 12)
            {
                GetComponent<ButtonsHandler>().HandleButton3();
            }
            else if(CurrentDialogue == 14)
            {
                GetComponent<ButtonsHandler>().HandleButton6();
            }
            else if(CurrentDialogue == 16)
            {
                GetComponent<CarHandler>().HandleCar();
            }
        }
        else
        {
            isFading = true;
        }
    }

    public void AnswearToQuestion(int number)
    {
        needToReply = false;
        TextIndex = 0;
        AnswearsPanel.SetActive(false);
        isTextRendered = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;

        TextGoal = Dialogues[CurrentDialogue].AnswearsAndReplies[number].Item2;
        // Invoke("RunNext", 4f);
        // Question.text = 
        // Question.text
    }
}
