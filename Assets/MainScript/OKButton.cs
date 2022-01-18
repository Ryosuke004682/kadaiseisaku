using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(Button))]
public class OKButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            AudioManager.Instance.Play("OK");
        });
    }
}
