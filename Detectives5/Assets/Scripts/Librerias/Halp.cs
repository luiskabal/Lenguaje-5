using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public enum Level { LevelA, LevelB, LevelC };

public class Halp : MonoBehaviour
{

    public static string cambioUnidades(int numeroNumero)
    {
        if (numeroNumero == 0)
        {
            return "0";
        }
        else if (numeroNumero < 10)
        {
            return "0" + numeroNumero;
        }
        else
        {
            if (numeroNumero >= 1000)
            {
                string numeroCambiado = numeroNumero.ToString("#,0");
                numeroCambiado = numeroCambiado.Replace(",", ".");
                return numeroCambiado;
            }
            else
            {
                return numeroNumero.ToString();
            }
        }
    }

    public static string cambioUnidades(int numeroNumero, bool doublezero)
    {
        if (numeroNumero == 0 && doublezero)
        {
            return "00";
        }
        else if (numeroNumero == 0 && !doublezero)
        {
            return "0";
        }
        else if (numeroNumero < 10)
        {
            return "0" + numeroNumero;
        }
        else
        {
            if (numeroNumero >= 1000)
            {
                string numeroCambiado = numeroNumero.ToString("#,0");
                numeroCambiado = numeroCambiado.Replace(",", ".");
                return numeroCambiado;
            }
            else
            {
                return numeroNumero.ToString();
            }
        }
    }

    public static int[] StartArray(int[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = i;
        }

        return arr;
    }

    //crea un array de ints y lo mezcla
    //puede incluir o no un 0
    public static int[] BuildRandomIntArray(int size, bool includezero)
    {
        int[] theArray = new int[size];

        if (includezero)
        {
            for (int i = 0; i < size; i++)
            {
                //Debug.Log("Created Element " + i);
                theArray[i] = i;
            }
        }
        else
        {
            for (int i = 1; i < size + 1; i++)
            {
                //Debug.Log("Created Element " + i);
                theArray[i - 1] = i;
            }
        }

        ShuffleArray(theArray);

        return theArray;
    }

    //ordena array ascendiente
    //o al descendiente con el bool
    public static int[] OrderArray(int[] array, bool reverse)
    {
        if (reverse)
        {
            Array.Sort<int>(array,
            delegate (int a, int b)
            {
                return b - a; //Normal compare is a-b
            });
        }
        else
        {
            Array.Sort(array);
        }

        return array;
    }

    //Desordena un arreglo
    public static void ShuffleArray<T>(T[] arr)
    {
        for (int i = arr.Length - 1; i > 0; i--)
        {
            int r = UnityEngine.Random.Range(0, i + 1);
            T tmp = arr[i];
            arr[i] = arr[r];
            arr[r] = tmp;
        }
    }

    //Crea distractores junto al numero objetivo
    public static int[] CreateDistractors(int[] arr, int target, int tolerance)
    {
        List<int> VerificationList = new List<int>();
        VerificationList.Add(target);

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                arr[i] = target;
            }
            else if (i != 0)
            {
                int number = UnityEngine.Random.Range(target - tolerance, target + tolerance);

                while (VerificationList.Contains(number) || number < 1)
                {
                    number = UnityEngine.Random.Range(target - tolerance, target + tolerance);
                }

                VerificationList.Add(number);
                arr[i] = number;
            }
        }

        ShuffleArray(arr);
        return arr;
    }

    public static int[] CreateDistractorsNotPrime(int[] arr, int target, int tolerance)
    {
        List<int> VerificationList = new List<int>();
        VerificationList.Add(target);

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                arr[i] = target;
            }
            else if (i != 0)
            {
                int number = UnityEngine.Random.Range(target - tolerance, target + tolerance);

                while (VerificationList.Contains(number) || number < 1)
                {
                    number = UnityEngine.Random.Range(target - tolerance, target + tolerance);

                    if (IsPrime(number))
                    {
                        number = 0;
                        tolerance++;
                    }
                }

                VerificationList.Add(number);
                arr[i] = number;
            }
        }

        ShuffleArray(arr);
        return arr;
    }

    public static int[] GetDivisores(int numero, int desde, int hasta)
    {
        List<int> listaDivisores = new List<int>();

        for (int i = desde; i <= hasta; i++)
        {
            if (numero % i == 0)
                listaDivisores.Add(i);
        }

        int[] divisores = new int[listaDivisores.Count];

        for (int i = 0; i < divisores.Length; i++)
        {
            divisores[i] = listaDivisores[i];
        }

        return divisores;
    }

    public static int ConvertToInt(String input)
    {
        // Replace everything that is no a digit.
        String inputCleaned = Regex.Replace(input, "[^0-9]", "");

        int value = 0;

        // Tries to parse the int, returns false on failure.
        if (int.TryParse(inputCleaned, out value))
        {
            // The result from parsing can be safely returned.
            return value;
        }

        return 0; // Or any other default value.
    }

    public static bool IsPrime(int number)
    {
        if (number < 2) return false;
        if (number % 2 == 0) return (number == 2);
        int root = (int)Math.Sqrt((double)number);
        for (int i = 3; i <= root; i += 2)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    //borra line endings de un string
    public static string RemoveLineEndings(string value)
    {
        if (String.IsNullOrEmpty(value))
        {
            return value;
        }
        string lineSeparator = ((char)0x2028).ToString();
        string paragraphSeparator = ((char)0x2029).ToString();

        return value.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
    }

    public static int factorial(int number)
    {
        int fact = 1;
        
        for (int i = 1; i <= number; i++)
        {
            fact *= i;
        }
        
        return fact;
    }

}
