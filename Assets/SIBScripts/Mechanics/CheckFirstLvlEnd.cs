using UnityEngine;

public class CheckFirstLvlEnd : MonoBehaviour
{
    [SerializeField]
    PlayerView playerView;
    [SerializeField]
    GameObject trueEndingPrefab;
    [SerializeField]
    GameObject QEndingPrefab;


    private bool isQPressed = false;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {

            SetQPressed();

        }

        CheckTrueLvl();
    }

    public void SetQPressed()
    {
        isQPressed = true;
    }

    void CheckTrueLvl()
    {
        if (playerView.integerPart < 15)
        {
            return;
        }

        if (isQPressed == false)
        {
            Debug.Log("TrueEnding");
            PrefabLoader.LoadPrefab(trueEndingPrefab);
        }
        else
        {
            Debug.Log("QEnding");
            PrefabLoader.LoadPrefab(QEndingPrefab);
        }
    }
}
