using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections;


public class PlayerView : MonoBehaviour
{
    public PlayerSO playerSO;

    [SerializeField]
    private RectTransform spriteRect;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private float moveSpeed = 50f;

    [SerializeField]
    private float jumpAmplitude = 10f;
    [SerializeField]
    private float jumpMagnitude = 0.1f;

    [SerializeField]
    private TextMeshProUGUI objCountText;

    [SerializeField]
    private string objCountTextPrefix;
    [SerializeField]
    private string objCountTextPostfix;

    [SerializeField]
    Transform playerInitPose;

    [SerializeField]
    private TextMeshProUGUI tooltipText;

    [SerializeField]
    private GameObject lastScenePrefab;

    private float initTransformY;

    public string currentCollider = "";
    private bool isObjectGrabbed = false;

    public int integerPart = 0;
    public int decimalPart = 0;

    void Start()
    {
        Setup();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = jumpAmplitude * (float)Math.Sin((double)transform.position.x * jumpMagnitude);
        Vector3 movement = new Vector3(horizontal, 0, 0) * moveSpeed * Time.deltaTime;


        Quaternion tmpRotation;
        if (horizontal < 0)
        {
            tmpRotation = spriteRect.transform.rotation;
            tmpRotation.y = 180;
            spriteRect.transform.rotation = tmpRotation;
        }
        else if (horizontal > 0)
        {
            tmpRotation = spriteRect.transform.rotation;
            tmpRotation.y = 0;
            spriteRect.transform.rotation = tmpRotation;
        }
        transform.Translate(movement);

        Vector3 tmpPose = transform.position;
        tmpPose.y = initTransformY + vertical;
        transform.position = tmpPose;

        CheckInteract();
    }

    private void Setup()
    {
        initTransformY = transform.position.y;
        spriteRenderer.sprite = playerSO.activeSprite;
        UpdateCountText();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentCollider = other.name;
    }

    void OnTriggerExit2D(Collider2D other)
    {
        currentCollider = "";
    }

    private void CheckInteract()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log($"Current: {currentCollider}");
            if (currentCollider == "Tree")
            {
                GrabApple();
            }

            if (currentCollider == "TreePrincess")
            {
                GrabApplePrincess();
                isObjectGrabbed = false;
            }

            if (currentCollider == "Box")
            {
                DropApple();
            }

            if (currentCollider == "Princess")
            {
                isObjectGrabbed = false;
                GivePrincess();
            }
        }
    }

    public void GrabApple()
    {
        isObjectGrabbed = true;
        spriteRenderer.sprite = playerSO.withAppleSprite;
    }

    private void GrabApplePrincess()
    {
        isObjectGrabbed = true;
        spriteRenderer.sprite = playerSO.withAppleSprite;
        integerPart += 1;
        UpdateCountText();
    }

    private void GivePrincess()
    {
        isObjectGrabbed = false;
        spriteRenderer.sprite = playerSO.activeSprite;
        ShowPrincessTooltip();

        integerPart = 0;
        decimalPart = 0;
        MoveToInitPose();
        UpdateCountText();
    }

    private void ShowPrincessTooltip()
    {
        if ((integerPart <= 3)&&(decimalPart == 0))
        {
            tooltipText.text = integerPart.ToString() + " яблока - это Мало";
        }
        else if ((integerPart >= 4))
        {
            tooltipText.text = integerPart.ToString() + " яблока - это много";
        }else
        {
            PrefabLoader.LoadPrefab(lastScenePrefab);
        }
    }

    private void DropApple()
    {
        if (!isObjectGrabbed)
        {
            return;
        }
        isObjectGrabbed = false;
        spriteRenderer.sprite = playerSO.activeSprite;
        integerPart += 1;
        UpdateCountText();
    }

    public void UpdateCountText()
    {
        if (objCountText == null)
        {
            return;
        }
        if (decimalPart == 0)
        {
            objCountText.text = objCountTextPrefix + integerPart.ToString() + objCountTextPostfix;
        }
        else
        {
            objCountText.text = objCountTextPrefix + integerPart.ToString() + "." + decimalPart.ToString() + objCountTextPostfix;
        }
    }

    public void ChangeScale()
    {
        StartCoroutine(ChangeScaleRoutine());
    }

    public IEnumerator ChangeScaleRoutine()
    {
        yield return new WaitForSeconds(0.5f);

        float scaleval = integerPart;
        float decimalPartSmall = 0f;
        for (int i = decimalPart; i != 0; i = i / 10)
        {
            decimalPartSmall = (float)i % 10;
        }
        scaleval = scaleval + decimalPartSmall / 10;
        Debug.Log($"Scale: {scaleval}");

        if (scaleval < 1f)
        {
            scaleval = 1f;
        }
        if (scaleval > 2.5f)
        {
            scaleval = 2.5f;
        }

        transform.localScale = new Vector3(scaleval, scaleval, scaleval);

        yield return null;
    }

    public void MoveToInitPose()
    {
        Vector3 tmpPose = playerInitPose.position;
        transform.position = tmpPose;
    }
}