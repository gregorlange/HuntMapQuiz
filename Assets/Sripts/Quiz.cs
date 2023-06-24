using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour
{
    
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Score")]
    [SerializeField] TextMeshProUGUI scoreText;

    [Header("Answers")]
    [SerializeField] GameObject[] answerButtons;

    [Header("Menu")]
    [SerializeField] GameObject[] menuButtons;

    bool hasActiveQuestion = false;

    int maxSore = 16;
    int currentScore = 0;


    void Start()
    {
        scoreText.text = currentScore + " / " + maxSore;
        SetActiveMenuButtons();
    }

    
    void Update()
    {

        scoreText.text = currentScore + " / " + maxSore;

        if(!hasActiveQuestion)
        {
            GetNextQuestion();
            hasActiveQuestion = true;
        }
    }

    public void OnAnswerSelected(int index)
    {
        DisplayAnswer(index);
    }

    public void DisplayAnswer(int index)
    {
        Image buttonImage = answerButtons[index].GetComponent<Image>();
        Image correctButtonImage = answerButtons[currentQuestion.GetAnswerIndex()].GetComponent<Image>();
        
        Button clickedButton = answerButtons[index].GetComponent<Button>();
        Button correctButton = answerButtons[currentQuestion.GetAnswerIndex()].GetComponent<Button>();


        if(index == currentQuestion.GetAnswerIndex())
        {
            buttonImage.color = new Color32(50, 168, 82, 50);
            clickedButton.interactable = false;
            currentScore++;
            GetNextQuestion();
        }
        else
        {
            correctButtonImage.color = new Color32(168, 70, 50, 50);
            correctButton.interactable = false;
            GetNextQuestion();
        }
    }

    void GetNextQuestion()
    {
        if(questions.Count > 0)
        {
            GetRandomQuestion();
            DisplayQuestion();
        }
        else
        {
            scoreText.color = new Color32(50, 168, 82, 255);
        }
    }

    void GetRandomQuestion()
    {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        if(questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    private void DisplayQuestion()
    {
        questionText.text = "Where is " + currentQuestion.GetCompundName() + "?";
    }

    public void OnReplayLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnApplicationQuit() 
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }

    public void SetActiveMenuButtons()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        Debug.Log("Index = " + activeScene.buildIndex);
        int sceneIndex = activeScene.buildIndex - 1;
        Button activeSceneButton = menuButtons[sceneIndex].GetComponent<Button>();

        activeSceneButton.interactable = false;
        Debug.Log("Button " + activeSceneButton.name + " interactability is " + activeSceneButton.IsInteractable());

    }

    public void OnLoadDeSalle()
    {
        SceneManager.LoadScene("DeSalle");
    }

    public void OnLoadLawson()
    {
        SceneManager.LoadScene("Lawson");
    }

    public void OnLoadStillwater()
    {
        SceneManager.LoadScene("Bayou");
    }

}
