using UnityEngine;
using System.Collections;
using System.IO;
public class EtapasController : MonoBehaviour {

    public string fileName;
    public int levels;

    private ArrayList blocked;
    private string filePath;
    private bool isOpen;
    
    public void Awake()
    {
        DontDestroyOnLoad(this);

        if (FindObjectsOfType(GetType()).Length > 1)
        {
            Destroy(gameObject);
        }
    }

    public void OpenFile()
    {
        blocked = new ArrayList();
        filePath = Application.persistentDataPath;
        isOpen = false;

        //armar el file path
        filePath = Application.persistentDataPath + "/" + fileName;
        Debug.Log("EtapaSaver: Este es el PATH: " + filePath);

        try
        {
            if (!File.Exists(filePath))
            {
                //si no existe el archivo, lo creamos
                Debug.Log("EtapaSaver: Archivo no encontrado! Creando...");

                //agrega los niveles
                for (int i = 0; i < levels; i++)
                {
                    NewEntry(i, false);
                }

                //guardar el archivo recien creado
                SaveFile();
                LoadFile();

                isOpen = true;
            }
            else
            {
                //cargar datos desde el archivo
                Debug.Log("EtapaSaver: Archivo Existe! Loading!");
                LoadFile();
            }
        }
        catch (System.Exception e)
        {
            Debug.Log(e);
        }
    }

    public void SaveFile()
    {
        Debug.Log("EtapaSaver: Saving the data to " + filePath);
        // Copies the elements of the ArrayList to a string array.
        string[] blockArray = (string[])blocked.ToArray(typeof(string));
        File.WriteAllLines(filePath, blockArray);
    }

    public void LoadFile()
    {
        Debug.Log("EtapaSaver: Reading Save Data " + filePath);
        string[] ireadthis = File.ReadAllLines(filePath);
        blocked.Clear();

        for (int i = 0; i < ireadthis.Length; i++)
        {
            blocked.Add(ireadthis[i]);
            //Debug.Log (ireadthis[i]);
        }

        isOpen = true;
    }

    public void EditEntry(int index, bool block)
    {
        string newEntry = (block) ? "true" : "false";

        blocked[index] = newEntry;

        SaveFile();
    }

    public void NewEntry(int index, bool block)
    {
        //recordar que es base 0!!
        index = index - 1;
        string newEntry = (block) ? "true" : "false";

        if (blocked.Count > index)
        {
            // DELETE THIS D:
            //blocked[index] = newEntry;
        }
        else
        {
            blocked.Add(newEntry);
        }
        //Debug.Log("Running newEntry en index "+index+" con valor "+ newEntry);
    }

    public ArrayList GetSaveData()
    {
        return blocked;
    }

    public bool CheckFile()
    {
        filePath = Application.persistentDataPath + "/" + fileName;

        return File.Exists(filePath);
    }

    public bool FileIsOpen()
    {
        return isOpen;
    }

    public int GetDataSize()
    {
        return blocked.Count;
    }

    public void ChangeFileName(string param)
    {
        fileName = param;
    }

}