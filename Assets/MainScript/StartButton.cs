using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class StartButton : MonoBehaviour
{
    private void Start()
    {
        var button = GetComponent<Button>();
        button.onClick.AddListener(() =>
        {

            SceneManager.LoadScene("Main");
        });

    }
}
