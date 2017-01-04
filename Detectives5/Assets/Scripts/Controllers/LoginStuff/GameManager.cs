using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public enum GameState { NullState, Intro, MainMenu, Game }
    //public PirataEtapasScript etapasScript { get; set; }
    //public GenerateWord generateWord { get; set; }
    //public GenerateSentence generateSentence { get; set; }
    public int etapaActual { get; set; }
    public PlayerStatistics playerState { get; set; }
    public GameState gameState { get; private set; }

    void Awake()
    {
        if (instance == null) //if not, set instance to this
            instance = this;
        else if (instance != this) //If instance already exists and it's not this:
            Destroy(gameObject); //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);

        /*etapasScript = GetComponent<PirataEtapasScript>();
        if (etapasScript == null)
            Debug.Log("GameManager: ITS SUPER NULL, MAN!!" + gameObject.name);
        etapasScript.readJson();*/

        //generateWord = GetComponent<GenerateWord>();
        //generateWord.loadSyllables();

        //generateSentence = GetComponent<GenerateSentence>();
        //generateSentence.loadSentences();

        playerState = new PlayerStatistics();
        playerState.points = 0.0f;
        playerState.etapaActual = 1;
        playerState.lastDateTime = System.DateTime.Now;
        Debug.Log("GameManager: " + System.DateTime.Now);
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
        OnStateChange();
    }

    void OnStateChange()
    {
        Debug.Log("GameManager: Game State: " + gameState);
        if (gameState == GameState.Intro)
        {
            //etapasScript.loadEtapasInScene();
        }
    }
}