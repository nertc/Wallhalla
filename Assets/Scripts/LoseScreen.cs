using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : MonoBehaviour
{
    public float fadeSpeed = 0.4f;
    public GameObject player;
    private bool isFadeOut = false;
    private bool isFadeIn = false;
    private float fadeOutIn = 0;
    private bool hasFadeIn = false;
    private RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        fadeOutIn = 1.5f;
        isFadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, Screen.height / 2.5f);
        rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, Screen.height);
        if (isFadeOut)
        {
            fadeOut();
        }
        if (isFadeIn)
        {
            fadeIn();
        }
        if (!isFadeIn && !isFadeOut && !hasFadeIn)
        {
            rect.anchoredPosition = new Vector2(0, -Screen.height);
        }

        if (!hasFadeIn && !player)
        {
            isFadeIn = true;
            hasFadeIn = true;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void fadeOut()
    {
        if (fadeOutIn > 0)
        {
            fadeOutIn -= Time.deltaTime;
            return;
        }

        if (-rect.anchoredPosition.y >= Screen.height)
        {
            isFadeOut = false;
            return;
        }

        rect.anchoredPosition = new Vector2(0, rect.anchoredPosition.y - Screen.height * fadeSpeed * Time.deltaTime);
    }

    private void fadeIn()
    {
        if (rect.anchoredPosition.y == 0)
        {
            isFadeIn = false;
            return;
        }

        rect.anchoredPosition = new Vector2(0, Mathf.Min(0, rect.anchoredPosition.y + Screen.height * fadeSpeed * Time.deltaTime));
    }
}
