using UnityEngine;
using UnityEngine.UI;

public class Assets_03 : MonoBehaviour
{
    public string[] Cop_Words;
    public string[] Criminal_Words;
    public string[] Good_Words;
    public Sprite[] Criminal_Faces;
    public Image[] Criminals;
    public Text Cop;
    public Animator Criminals_Actions;
    public Animator Cop_Actions;

	private string current_good_word;
	private string[] words;

    public void SetCriminals(int[] identity)
    {
        for (int i = 0; i < Criminals.Length; i++)
        {
            Criminals[i].sprite = Criminal_Faces[identity[i]];
        }
    }

    public void CopTalk()
    {
        Cop_Actions.SetTrigger("Talk");
    }

	public void CopTalk(float delay)
	{
		Invoke("CopTalk", delay);
	}

    public void CriminalsTalk()
    {
        Cop_Actions.SetTrigger("Talk");
    }

    public void CriminalsTalk(int delay)
    {
        Invoke("CriminalsTalk", delay);
    }

    public void ShowCriminals()
    {
        Criminals_Actions.SetTrigger("WALK");
    }

	public void ShowCriminals(float delay)
	{
		Invoke("ShowCriminals", delay);
	}

    public void SetCriminalsWords(int phrase)
    {
        words = Criminal_Words[phrase].Split('/');
        Halp.ShuffleArray(words);

        for (int i = 0; i < Criminals.Length; i++)
        {
            Criminals[i].GetComponentInChildren<Text>().text = words[i];
        }

		current_good_word = Good_Words[phrase];
    }

	public void SetCopWords(int phrase)
	{
		Cop.text = Cop_Words[phrase];
	}

	public int GetCriminalsLength()
	{
		return Criminals.Length;
	}

	public int GetPhrasesLength()
	{
		return Cop_Words.Length;
	}

	public string GetGoodWord()
	{
		return current_good_word;
	}

	public string GetCriminalWord(int index)
	{
		return words[index];
	}

	public void EnableButtons(bool enable)
	{
		for (int i = 0; i < Criminals.Length; i++)
		{
			Criminals[i].GetComponent<Button>().interactable = enable;
		}
	}
}
