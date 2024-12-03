using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class GameManagerCat : MonoBehaviour
{
    [HeaderAttribute(" Score variables")]
    
    public TextMeshProUGUI scoreText;
    [SerializeField] EnemySpawner spawner;
     [SerializeField] int _toEnd;

    [SerializeField] private GameScore gameScore;
    [HeaderAttribute(" Score ID")]
    int score;
    public int user_id = 0; // ID del usuario
    private string scoreUrl = "http://localhost/insert_cat.php";

    [SerializeField] GameObject _gameOver;

    public void ReceiveID(string id)
    {
        Debug.Log("ReceiveID called with id: " + id);
        if (int.TryParse(id, out int parsedId))
        {
            user_id = parsedId;
            Debug.Log("Received user ID: " + user_id);
        }
        else
        {
            Debug.LogError("Invalid user ID received: " + id);
        }
    }
    public class GameScore
    {
        public int user_id;
        public int score_space;
    }
    private void Awake()
    {
        gameScore = new GameScore();
        gameScore.user_id = 0;
        gameScore.score_space = 0;
    }
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _gameOver.SetActive(false);
    }
    public void InsertScore()
    {
        StartCoroutine(InsertScoreCoroutine());
    }

    private IEnumerator InsertScoreCoroutine()
    {
        string jsonString = JsonUtility.ToJson(gameScore);
        UnityWebRequest request = new UnityWebRequest(scoreUrl, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(jsonString);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError("Error al insertar el mejor tiempo: " + request.error);
        }
        else
        {

            string responseText = request.downloadHandler.text;
            ServerResponseCard response = JsonUtility.FromJson<ServerResponseCard>(responseText);

            if (response.message == "Cat score inserted successfully")
            {
                Debug.Log("puntaje agregao");
            }
            else
            {
                Debug.LogError("puntaje nave fallao: " + response.message);
            }
        }
    }
    public void SetUserID()
    {
        gameScore.user_id = user_id;
        Debug.Log("User ID set to: " + gameScore.user_id);
    }

    public void SetSpaceScore(int score)
    {

        gameScore.score_space = score;
        Debug.Log("Score set to: " + gameScore.score_space);
    }
    void OnEnable()
    {
        Enemy.OnClickedGhost += CurrentScore;
    }
    private void OnDisable()
    {
        Enemy.OnClickedGhost -= CurrentScore;
    }
    private void Update()
    {
        scoreText.text = "Score: " + score;
        OnOver();
    }
    public void CurrentScore(int numb)
    {
        score = score + numb;
  
    }
    private void OnOver()
    {
        _toEnd = spawner.Getquantity();
       
        if (_toEnd >= 50)
        {
            _gameOver.SetActive(true);
           
            Time.timeScale = 0f;
        }
       
        
    }
    private IEnumerator RestartGameCoroutine()
    {
        SetUserID();
        SetSpaceScore(score);
        if (score >= 0)
        {
            InsertScore(); // Guarda el puntaje
        }
        else
        {
            Debug.Log("puntaje invalido");
        }

        yield return new WaitForSecondsRealtime(1); // Espera un momento para asegurarte de que se guarde
        Time.timeScale = 1f;
        string sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }
    public void RestartGame()
    {
        StartCoroutine(RestartGameCoroutine());

        //InsertScore();
        //Time.timeScale = 1f;
        //string sceneName = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(sceneName);
    }


}
[System.Serializable]
public class ServerResponseCard
{
    public string message;
}

