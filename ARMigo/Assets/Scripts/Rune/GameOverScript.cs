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

public class GameOverScript : MonoBehaviour
{
    public Text endPoint;

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
    public GameObject scoreElement;
    public Transform scoreboardContent;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("FROM OTHER SCENE SCORE TEST : " + Timer.score);
        endPoint.text = Timer.score.ToString() + " POINTS";

        auth = FirebaseAuth.DefaultInstance;
        DBreference = FirebaseDatabase.DefaultInstance.RootReference;

        // Firebase.Auth.FirebaseUser user = auth.CurrentUser;
        User = auth.CurrentUser;

        scoreFields = Timer.score;
        username = User.DisplayName;

        StartCoroutine(UpdateUsernameDatabase(username));

        StartCoroutine(UpdateScores(scoreFields));

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


}
