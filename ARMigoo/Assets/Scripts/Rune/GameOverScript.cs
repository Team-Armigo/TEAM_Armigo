using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using Firebase.Extensions;
using TMPro;
using System.Linq;

public class GameOverScript : MonoBehaviour
{
    //public Text endPoint;

    // Firebase variables
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser User;
    public DatabaseReference DBreference;

    // User Data variables
    [Header("UserData")]
    public int scoreFields;
    public string username;
    public int number;
    public GameObject scoreElement;
    public Transform scoreboardContent;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FROM OTHER SCENE SCORE TEST : " + Timer.score);
        //endPoint.text = Timer.score.ToString() + " POINTS";

        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;

        // Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        User = auth.CurrentUser;

        scoreFields = Timer.score;
        username = User.DisplayName;

        StartCoroutine(UpdateUsernameDatabase(username));

        StartCoroutine(UpdateScores(scoreFields));

        StartCoroutine(LoadUserData());

        StartCoroutine(LoadScoreboardData());
    }




    private IEnumerator UpdateUsernameDatabase(string _username)
    {
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("username").SetValueAsync(_username);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }

        else
        {
            // Database username is now updated
        }
    }

    private IEnumerator UpdateScores(int _scores)
    {
        var DBTask = DBreference.Child("users").Child(User.UserId).Child("scores").SetValueAsync(_scores);

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }

        else
        {
            // scores are now updated
        }

    }

    private IEnumerator LoadUserData()
    {
        var DBTask = DBreference.Child("users").Child(User.UserId).GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }

        else if (DBTask.Result.Value != null)
        {
            // Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            //scoreFields = snapshot.Child("scores").Value.ToString();
            //username = snapshot.Child("username").Value.ToString();
        }
    }

    private IEnumerator LoadScoreboardData()
    {
        var DBTask = DBreference.Child("users").OrderByChild("scores").GetValueAsync();

        yield return new WaitUntil(predicate: () => DBTask.IsCompleted);

        if (DBTask.Exception != null)
        {
            Debug.LogWarning(message: $"Failed to register task with {DBTask.Exception}");
        }

        else
        {
            // Data has been retrieved
            DataSnapshot snapshot = DBTask.Result;

            // Destroy any existing scoreboard elements
            foreach (Transform child in scoreboardContent.transform)
            {
                Destroy(child.gameObject);
            }

            number = 0;

            // Loop through every users UID
            foreach (DataSnapshot childSnapshot in snapshot.Children.Reverse<DataSnapshot>())
            {
                username = childSnapshot.Child("username").Value.ToString();
                scoreFields = int.Parse(childSnapshot.Child("scores").Value.ToString());
                number += 1;

                // Instantiate new scoreboard elements
                GameObject scoreboardElement = Instantiate(scoreElement, scoreboardContent);
                scoreboardElement.GetComponent<ScoreElement>().NewScoreElement(username, scoreFields, number);
            }

            // Go to scoreboard screen
            UIManager.instance.ScoreboardScreen();
        }
    }

}
