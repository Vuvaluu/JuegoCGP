using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class JuegoOrdenarPalabras : MonoBehaviour
{
    public TMP_Text palabraDesordenadaText;
    public TMP_InputField inputField;
    public TMP_Text feedbackText;
    public TextMeshProUGUI timeText, timeText2;
    
    [SerializeField] List<string> palabrasParaOrdenar;
    
    private string palabraCorrecta;
    private List<string> palabrasDesordenadas;
    private List<string> palabrasOrdenadas;
    private float timeRemaining = 70;
    private int wordCount;

    void Start()
    {
        IniciarJuego();
        palabrasParaOrdenar.Add("apple");
        palabrasParaOrdenar.Add("house");
        palabrasParaOrdenar.Add("dream");
        palabrasParaOrdenar.Add("car");
        palabrasParaOrdenar.Add("friend");
        palabrasParaOrdenar.Add("music");
        palabrasParaOrdenar.Add("sunshine");
        palabrasParaOrdenar.Add("adventure");
        palabrasParaOrdenar.Add("book");
        palabrasParaOrdenar.Add("ocean");
        palabrasParaOrdenar.Add("cake");
        palabrasParaOrdenar.Add("table");
        palabrasParaOrdenar.Add("chair");
        palabrasParaOrdenar.Add("pen");
        palabrasParaOrdenar.Add("phone");
        palabrasParaOrdenar.Add("computer");
        palabrasParaOrdenar.Add("window");
        palabrasParaOrdenar.Add("door");
        palabrasParaOrdenar.Add("clock");
        palabrasParaOrdenar.Add("bag");
        palabrasParaOrdenar.Add("red");
        palabrasParaOrdenar.Add("monday");
        palabrasParaOrdenar.Add("father");
        palabrasParaOrdenar.Add("orange");
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            TimerText();
        }
        else
        {
            timeRemaining = 0;
            TimerText();
        }
    }

    void IniciarJuego()
    {
        palabraCorrecta = palabrasParaOrdenar[Random.Range(0, palabrasParaOrdenar.Count)];
        palabrasDesordenadas = DesordenarPalabra(palabraCorrecta);
        palabraDesordenadaText.text = string.Join(" ", palabrasDesordenadas.ToArray());
        palabrasOrdenadas = new List<string>();
    }

    List<string> DesordenarPalabra(string palabra)
    {
        List<string> letras = new List<string>(palabra.Length);
        foreach (char letra in palabra)
        {
            letras.Add(letra.ToString());
        }
        
        for (int i = 0; i < letras.Count; i++)
        {
            string temp = letras[i];
            int randomIndex = Random.Range(i, letras.Count);
            letras[i] = letras[randomIndex];
            letras[randomIndex] = temp;
        }

        return letras;
    }

    public void VerificarRespuesta()
    {
        string respuesta = inputField.text;
        if (respuesta.Equals(palabraCorrecta))
        {
            IniciarJuego();
            wordCount++;
            palabrasOrdenadas.Add(palabraCorrecta);
            feedbackText.text = "Correcto!";

        }
        else
        {
            feedbackText.text = "Incorrecto";
        }
        
        inputField.text = "";

        if (wordCount == 10)
        {
            SceneManager.LoadScene("Win");
        }
    }
    
    public void TimerText()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timeText2.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        
        if (timeRemaining == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        
    }
}
