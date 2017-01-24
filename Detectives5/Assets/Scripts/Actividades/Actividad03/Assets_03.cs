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
    public Animator Curtain;
    public Animator Cop_Actions;
    public Animator[] Criminal_Text;
    public Animator Cop_Text;

	private string current_good_word;
	private string[] words;

    //ANIMACIONES
    public void CopTalk()
    {
        Cop_Text.SetTrigger("ON");
    }

	public void CopTalk(float delay)
	{
		Invoke("CopTalk", delay);
	}

    public void CopTalkOff()
    {
        Cop_Text.SetTrigger("OFF");
    }

	public void CopTalkOff(float delay)
	{
		Invoke("CopTalkOff", delay);
	}

    public void CriminalsTalk()
    {
        for (int i = 0; i < Criminal_Text.Length; i++)
        {
            Criminal_Text[i].SetTrigger("ON");
        }
    }

    public void CriminalsTalk(float delay)
    {
        Invoke("CriminalsTalk", delay);
    }

    public void CriminalsTalkOff()
    {
        for (int i = 0; i < Criminal_Text.Length; i++)
        {
            Criminal_Text[i].SetTrigger("OFF");
        }
    }

    public void CriminalsTalkOff(float delay)
    {
        Invoke("CriminalsTalkOff", delay);
    }

    public void ShowCriminals()
    {
        Curtain.SetTrigger("ON");
    }

	public void ShowCriminals(float delay)
	{
		Invoke("ShowCriminals", delay);
	}

    public void HideCriminals()
    {
        Curtain.SetTrigger("OFF");
    }

	public void HideCriminals(float delay)
	{
		Invoke("HideCriminals", delay);
	}

    //FIN ANIMACIONES

    public void SetCriminals(int[] identity)
    {
        for (int i = 0; i < Criminals.Length; i++)
        {
            Criminals[i].sprite = Criminal_Faces[identity[i]];
        }
    }

    public void SetCriminalsWords(int phrase)
    {
        words = Criminal_Words[phrase].Split('/');
        Halp.ShuffleArray(words);

        for (int i = 0; i < Criminals.Length; i++)
        {
            Criminal_Text[i].GetComponentInChildren<Text>().text = words[i];
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
			Criminal_Text[i].GetComponent<Button>().interactable = enable;
		}
	}
}
