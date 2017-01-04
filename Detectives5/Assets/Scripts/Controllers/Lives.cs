using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour {

    public Text livesText;

	private int currentLives;
	private int maxLives;

	// Use this for initialization
	void Start () 
	{
		
    }
	
	public bool TakeLife() 
	{
        currentLives = currentLives - 1;

        if (currentLives <= 0)
        {
            currentLives = 0;
            livesText.text = "x " + Halp.cambioUnidades(currentLives);
            return true;
        }
        else
        {
            //ANIMATOR ??
            //gameObject.GetComponent<Animator>().SetTrigger("LifeOn");
            livesText.text = "x " + Halp.cambioUnidades(currentLives);
            return false;
        }  
    }

	public void GainLife (int lifeRestored)
	{
        if (currentLives < maxLives)
        {
            for (int i = 0; i < lifeRestored; i++)
            {
                //ANIMATOR ??
                //gameObject.GetComponent<Animator>().SetTrigger("LifeOn");
            }

            currentLives++;
        }

        livesText.text = "x " + Halp.cambioUnidades(currentLives);
    }


	public void RestoreAllLife(bool instant)
	{
        currentLives = maxLives;
        livesText.text = "x" + Halp.cambioUnidades(currentLives);
    }

	public int GetRemaining()
	{
		return currentLives;
	}
	
    public void SetLives(int lives, int personaje)
    {
        currentLives = lives;
        maxLives = lives;

        livesText.text = "x" + Halp.cambioUnidades(currentLives);
    }
}
