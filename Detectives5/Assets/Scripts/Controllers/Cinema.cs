using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Cinema : MonoBehaviour
{
    public GameObject leftImgContainer;
    public GameObject rightImgContainer;
    public Text textContainer;
    public Button nextButton;
    public Button skipButton;
    public GameObject wayLeftOut;
    public GameObject wayLeftIn;
    public GameObject wayRightOut;
    public GameObject wayRightIn;
    // --
    public Sprite[] theSprites;
    public Animator[] theAnimators;
    public string[] theText;
    public bool[] isLeft;
    // --
    public GameObject[] animatedUI;
    public GameObject scriptContainer;
    public float speed;
    // --
    private int maxLoop;
    private int currentLoop;
    private bool movementLock;
    private GameObject activeContainer;
    private Vector3 targetLoc;
    private Vector3 wayLocLeftOut;
    private Vector3 wayLocLeftIn;
    private Vector3 wayLocRightOut;
    private Vector3 wayLocRightIn;

    // Use this for initialization
    void Start ()
    {
        currentLoop = 0;
        //speed = 4.5f;
        movementLock = true;
        maxLoop = theSprites.Length-1;
        wayLocLeftOut = wayLeftOut.GetComponent<RectTransform>().position;
        wayLocLeftIn = wayLeftIn.GetComponent<RectTransform>().position;
        wayLocRightOut = wayRightOut.GetComponent<RectTransform>().position;
        wayLocRightIn = wayRightIn.GetComponent<RectTransform>().position;
        Invoke("TimedStart",1.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!movementLock)
        {
            DoMovement(activeContainer,targetLoc);
        }
	}

    private void DoMovement(GameObject movedObj, Vector3 targetPoint)
    {
        float step = speed * Time.deltaTime;
        //Debug.Log("moving");
        movedObj.GetComponent<RectTransform>().position = Vector3.MoveTowards(
                                                            movedObj.transform.position, 
                                                            targetPoint, 
                                                            step);
        if (movedObj.transform.position == targetPoint)
        {
            movementLock = true;
            //texto
            textContainer.text = theText[currentLoop];
            nextButton.GetComponent<Button>().interactable = true;
            skipButton.GetComponent<Button>().interactable = true;
            Debug.Log("Movement locked");
        }
    }

    private void TimedStart()
    {
        //determinar si entra imagen izq o derecha
        if (isLeft[0])
        {
            activeContainer = leftImgContainer;
            targetLoc = wayLocLeftIn;
        }
        else
        {
            activeContainer = rightImgContainer;
            targetLoc = wayLocRightIn;
        }            
        //imagen
        activeContainer.GetComponent<Image>().sprite = theSprites[0];
        //animator controller
        //activeContainer.GetComponent<Animator>().runtimeAnimatorController = theAnimators[0];
        //empieza a mover...
        movementLock = false;
    }

    public void NextStep()
    {
        Debug.Log("current:"+currentLoop+" max:"+maxLoop);
        if (currentLoop == maxLoop)
        {
            Debug.Log("ITS OVER!!!");
            FadeOut();
            return;
        }
        currentLoop++;
        nextButton.GetComponent<Button>().interactable = false;
        
        //revisar si el sprite es el mismo
        bool repeatedSprite = false;
        if (isLeft[currentLoop])
        {
            if (leftImgContainer.GetComponent<Image>().sprite == theSprites[currentLoop])
                repeatedSprite = true;
            
            //repetido asi que quitar y traer el nuevo
            if (!repeatedSprite)
                leftImgContainer.transform.position = wayLocLeftOut;

            activeContainer = leftImgContainer;
            targetLoc = wayLocLeftIn;
        }
        else
        {
            if (rightImgContainer.GetComponent<Image>().sprite == theSprites[currentLoop])
                repeatedSprite = true;

            //repetido asi que quitar y traer el nuevo
            if (!repeatedSprite)
                rightImgContainer.transform.position = wayLocRightOut;

            activeContainer = rightImgContainer;
            targetLoc = wayLocRightIn;        
        }

        //imagen
        activeContainer.GetComponent<Image>().sprite = theSprites[currentLoop];
        //animator controller
        //activeContainer.GetComponent<Animator>().runtimeAnimatorController = theAnimators[currentLoop];
        //empieza a mover...
        movementLock = false;
    }

    public void FadeOut()
    {
        Debug.Log("FADING OUT");
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        movementLock = true;
        canvasGroup.interactable = false;

        StartCoroutine( DoFadeOut() );
    }

    IEnumerator DoFadeOut()
    {
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();

        while (canvasGroup.alpha > 0)
        {
            canvasGroup.alpha -= Time.deltaTime / 0.3F;
            yield return null;
        }

        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;

        StartActivity();

        yield return null;
    }

    private void StartActivity()
    {
        //aqui van los Animators de los objetos ui que entran...
        for (int i = 0; i < animatedUI.Length; i++)
        {
            //animatedUI[i].GetComponent<Animator>().SetTrigger("");
        }

        scriptContainer.GetComponent<BigMama>().RemoteStart();

    } 



}