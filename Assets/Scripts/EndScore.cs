using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScore : MonoBehaviour {
    [SerializeField]
    private TextMesh _scoreGui = null;

    public int score;
    // Use this for initialization
    void Start () {
        _scoreGui.text = PlayerPrefs.GetInt("highscore").ToString();
	}

    private void OnMouseDown()
    {
        SceneManager.LoadScene("JTest");
    }
}
