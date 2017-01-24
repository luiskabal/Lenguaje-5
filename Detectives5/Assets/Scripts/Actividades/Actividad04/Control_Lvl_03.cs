using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Control_Lvl_03 : BigMama
{

    public string[] messages;

    private BigBoss Master;
    private Assets_03 Assets;
    private int[] order;
    private string[] Combination_criminals;

    void Start()
    {
        Master = GetComponent<BigBoss>();
        Assets = GetComponent<Assets_03>();

        Randomize();
    }

    public override void RemoteStart()
    {
        Master.Comenzar();
        StartTheGame();
    }

    void Update()
    {
        //si hay limite de tiempo, revisar aca
        if (Master.CheckOverClock())
        {
            Master.ResetClock();
            Master.SuddenDeath();
        }
    }

    private void StartTheGame()
    {
        if (!Master.IsMusicPlaying())
            Master.PlayDefaultMusic();
        Master.SetMainMessage(messages[0]);

        Armador();
    }

    private void Randomize()
    {
        //Creación de orden de aparición de criminales
        int qty_combinations = Halp.factorial(6) / (Halp.factorial(3) * Halp.factorial(6 - 3));
        Combination_criminals = new string[qty_combinations];
        //Crear combinatoria
        MakeCombinations(3, 6, '/');
        //Desordenarla
        Halp.ShuffleArray(Combination_criminals);

        //Creación de orden de preguntas
        order = new int[Assets.GetPhrasesLength()];
        //Crear arreglo
        Halp.StartArray(order);
        //Desordenar arreglo de orden
        Halp.ShuffleArray(order);
    }

    private void MakeCombinations(int elements, int size, char separator)
    {
        int n = size;
        int k = elements;
        int i = 0;

        foreach (var combo in Combinations(k, n))
        {
            Combination_criminals[i] = combo[0].ToString() + separator + combo[1].ToString() + separator + combo[2].ToString();
            i++;
        }
    }

    private static IEnumerable<int[]> Combinations(int k, int n)
    {
        var result = new int[k];
        var stack = new Stack<int>();
        stack.Push(1);

        while (stack.Count > 0)
        {
            var index = stack.Count - 1;
            var value = stack.Pop();

            while (value <= n)
            {
                result[index++] = value++;
                stack.Push(value);
                if (index == k)
                {
                    yield return result;
                    break;
                }
            }
        }
    }

    private void Armador()
    {
        Debug.Log(Combination_criminals[Master.GetStarNum()]);
        string[] orderCriminals = Combination_criminals[Master.GetStarNum()].Split('/');

        int[] arrayOrder = { System.Convert.ToInt32(orderCriminals[0]) - 1,
                             System.Convert.ToInt32(orderCriminals[1]) - 1,
                             System.Convert.ToInt32(orderCriminals[2]) - 1
                             };

        Assets.SetCriminals(arrayOrder);
        Assets.SetCopWords(order[Master.GetStarNum()]);
        Assets.SetCriminalsWords(order[Master.GetStarNum()]);

        Assets.ShowCriminals();
        Assets.CriminalsTalk(1.5f);
        Assets.CopTalk(1);

        Assets.EnableButtons(true);
    }

    public void Analize(int option)
    {
        Assets.EnableButtons(false);

        if (Assets.GetGoodWord() == Assets.GetCriminalWord(option))
        {
            if (!Master.Good())
            {
                Assets.HideCriminals(2);
                Assets.CriminalsTalkOff(1);
                Assets.CopTalkOff(1);

                //New problem
                Invoke("Armador", 3);
            }
        }
        else
        {
            //Bad, Life taken
            Master.Bad();
            Invoke("ReEnableButtons", 1f);
        }
    }

    private void ReEnableButtons()
    {
        Assets.EnableButtons(true);
    }
}

