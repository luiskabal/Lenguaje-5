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
        int qty_combinations = Halp.factorial(8) / (Halp.factorial(3) * Halp.factorial(8 - 3));
        Combination_criminals = new string[qty_combinations];
        //Crear combinatoria
        MakeCombinations(3, 8, '/');
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
        string[] orderCriminals = Combination_criminals[Master.GetStarNum()].Split('/');

        int[] arrayOrder = { System.Convert.ToInt32(orderCriminals[0]),
                             System.Convert.ToInt32(orderCriminals[1]),
                             System.Convert.ToInt32(orderCriminals[2])
                             };

        Assets.SetCopWords(order[Master.GetStarNum()]);
        Assets.SetCriminals(arrayOrder);

        Assets.ShowCriminals();
        Assets.CriminalsTalk();
        Assets.CopTalk();

        Assets.EnableButtons(true);
    }

    public void Analize(int option)
    {
        Assets.EnableButtons(false);

        if (Assets.GetGoodWord() == Assets.GetCriminalWord(option))
        {
            if (!Master.Good())
            {
                //New problem
                Invoke("Armador", 2);
            }
        }
        else
        {
            //Bad, Life taken
            Master.Bad();
            Assets.EnableButtons(true);
        }
    }
}

