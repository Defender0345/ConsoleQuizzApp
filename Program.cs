using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleQuizzApp
{
    internal class Program
    {
        public class Question
        {
            //public int Id { get; set; }
            public string QuestionText { get; set; }
            public string Answer { get; set; }
        }

        // Create AskQuestion method
        static string AskQuestion(Question question)
        {
            Console.WriteLine($"Question: {question.QuestionText}");
            Console.Write("Enter your answer: ");
            string userAnswer = Console.ReadLine();

            return userAnswer;
        }

        static void Main(string[] args)
        {
           // Issue with json file not loading to bin/debug file so had to manually copy it over for now

           // Create file directory path variable
           string jsonFilePath = Path.Combine(Directory.GetCurrentDirectory(), "questions.json");
           string jsonData = File.ReadAllText(jsonFilePath);

           // Deserialize the JSOB Object to work with said data
           List<Question> questions = JsonConvert.DeserializeObject<List<Question>>(jsonData);

            int score = 0;

            Console.WriteLine("For every correct answer, you get 1 point but you can lose 1 for every wrong answer!");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Hint: All questions only have numbers as answers");

            foreach (var question in questions)
            {
                string userAnswer = AskQuestion(question);

                if (userAnswer == question.Answer)
                {
                    Console.WriteLine("That is Correct! +1 Point");
                    score++;
                }
                else
                {
                    Console.WriteLine($"That is incorrect. -1 Point, the correct answer is {question.Answer}");
                    score--; 
                }
                Console.WriteLine("--------------------------");
                Console.WriteLine($"Current score is {score}");
                Console.WriteLine("--------------------------");
            }
        Console.WriteLine($"Final Score is {score}");
        Console.ReadLine();
        }
    }
}
