using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JuegoOrdenarPalabras : MonoBehaviour
{
    public TMP_Text palabraDesordenadaText;
    public TMP_InputField inputField;
    public TMP_Text feedbackText;
    public List<string> palabrasParaOrdenar;
    
    private string palabraCorrecta;
    private List<string> palabrasDesordenadas;
    private List<string> palabrasOrdenadas;

    void Start()
    {
        IniciarJuego();
        palabrasParaOrdenar.Add("parque");
        palabrasParaOrdenar.Add("peluche");
        palabrasParaOrdenar.Add("regalo");
    }

    void IniciarJuego()
    {
        // Escoge una palabra aleatoria de la lista
        palabraCorrecta = palabrasParaOrdenar[Random.Range(0, palabrasParaOrdenar.Count)];

        // Desordena las letras de la palabra
        palabrasDesordenadas = DesordenarPalabra(palabraCorrecta);

        // Muestra la palabra desordenada en la interfaz de usuario
        palabraDesordenadaText.text = string.Join(" ", palabrasDesordenadas.ToArray());

        // Inicializa la lista de palabras ordenadas
        palabrasOrdenadas = new List<string>();

        // Limpia el feedback
       // feedbackText.text = "";
    }

    List<string> DesordenarPalabra(string palabra)
    {
        List<string> letras = new List<string>(palabra.Length);
        foreach (char letra in palabra)
        {
            letras.Add(letra.ToString());
        }

        // Desordena las letras de la palabra
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
            feedbackText.text = "¡Correcto! Has ordenado la palabra correctamente.";
            
            // Agrega la palabra ordenada a la lista
            palabrasOrdenadas.Add(palabraCorrecta);

            // Puedes agregar aquí lógica adicional si quieres pasar al siguiente nivel, por ejemplo.
            IniciarJuego();
        }
        else
        {
            feedbackText.text = "Incorrecto. Inténtalo de nuevo.";
        }

        // Limpia el campo de entrada
        inputField.text = "";
    }
}
