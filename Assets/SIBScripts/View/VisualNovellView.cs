using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class VisualNovellView : MonoBehaviour
{
    public VisualNovellSO visualNovelSO;

    [SerializeField]
    private TextMeshProUGUI characterName;
    [SerializeField]
    private TextMeshProUGUI mainText;
    [SerializeField]
    private TextMeshProUGUI commentText;
    [SerializeField]
    private Image leftSprite;
    [SerializeField]
    private Image rightSprite;
    

    void Start()
    {
        SetupNovel();
    }

    void SetupNovel()
    {
        characterName.text = visualNovelSO.characterName;
        mainText.text = visualNovelSO.text;
        commentText.text = visualNovelSO.textComment;

        leftSprite.color = Color.white;
        rightSprite.color = Color.white;
        leftSprite.sprite = visualNovelSO.leftSprite;
        rightSprite.sprite = visualNovelSO.rightSprite;
        if (visualNovelSO.leftSprite == null)
        {
            leftSprite.color = Color.clear;
        }
        if (visualNovelSO.rightSprite == null)
        {
            rightSprite.color = Color.clear;
        }
    }

    public void LoadNewScene()
    {
        PrefabLoader.LoadPrefab(visualNovelSO.nextScene);
    }
}
