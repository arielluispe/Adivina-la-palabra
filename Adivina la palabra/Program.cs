using System;

namespace Adivina_la_palabra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // La palabra secreta
            string word = "casa";

            // El número máximo de intentos permitidos
            int maxAttempts = 5;

            // La palabra con guiones bajos en lugar de letras (_ _ _ _)
            string wordWithUnderscores = string.Empty;
            for (int i = 0; i < word.Length; i++)
            {
                wordWithUnderscores += "_ ";
            }

            // Bucle del juego
            for (int i = 0; i < maxAttempts; i++)
            {
                // Pide al usuario que adivine una letra
                Console.WriteLine("Adivina una letra de la palabra secreta: " + wordWithUnderscores);
                char guess = char.Parse(Console.ReadLine());

                // Comprueba si la letra se encuentra en la palabra
                bool isCorrectGuess = false;
                for (int j = 0; j < word.Length; j++)
                {
                    if (word[j] == guess)
                    {
                        // Sustituye el guión bajo por la letra adivinada
                        wordWithUnderscores = wordWithUnderscores.Remove(j * 2, 1).Insert(j * 2, guess.ToString());
                        isCorrectGuess = true;
                    }
                }

                // Si la letra no se encuentra en la palabra, se reduce el número de intentos restantes
                if (!isCorrectGuess)
                {
                    maxAttempts--;
                    Console.WriteLine("Lo siento, esa letra no se encuentra en la palabra. Te quedan " + maxAttempts + " intentos.");
                }

                // Si se han adivinado todas las letras, se termina el juego
                if (!wordWithUnderscores.Contains("_"))
                {
                    Console.WriteLine("¡Enhorabuena, has adivinado la palabra secreta!");
                    break;
                }
            }
        }
    }
}
