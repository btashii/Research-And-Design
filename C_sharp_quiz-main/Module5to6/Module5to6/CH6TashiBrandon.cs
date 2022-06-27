using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module5to6
{

    class Program
    {
        /* README Documentation:
             * Name: Brandon Tashi  
             * University: Embry-Riddle Aeronautical University 
             * Description: Multiple choice math quiz that allows second attempts for each question. Keeps track of wrong questions and calculates score of the quiz. 
             * Last Modified: 2/16/21
             * Status: Complete 
             */

        /* 
         * Notes:
         * Answers will be stored as char type variables. The answer in answerBank correlate to the questions in questionBank by index. 
         * The booleans in isUserCorrectForQuestions correlates to the questionBank by index as well. 
         * Methods were used to refactor the code. Each method is now called in the main method, where all the arrays are housed. The information in the main method is passed through the takeUserInput and takeUserInputTwo. 
         */
        static void ShowQuizIntro() //Introduces the quiz to the user
        {
            Console.WriteLine("Welcome to the math multiple choice quiz! You will get two attempts at each question, if needed. Answers that are not not multiple choice letters A, B, C or D will be penalized on the second attempt.");
            Console.WriteLine("Please press Enter to start the quiz. Good luck!");
            Console.ReadLine();
        }

        static void ShowQuestionsRoundOne(string[] questionBank, char[] answerBank, bool[] isUserCorrectForQuestions) //Method for first round of questions
        {

            int indexOne = -1; //Index counter to keep track of the questions/answers. 
            foreach (string question in questionBank) //New local variable "answer" declared in for-each loop. It is a string type as the array answerBank is also string type. 
            {
                indexOne++;
                Console.WriteLine(question);
                while (true) //While loop used to allow user to re-input a response if an error other than a wrong answer occurs, such as formatting or a different letter from A, B, C or D. 
                {
                    try //Try-Catch statement throws a formatting error if user inputs a sentence or word. 
                    {
                        string userInput = Console.ReadLine();
                        char userInputParsed = char.ToLower(char.Parse(userInput)); //Parses the user input and lower cases the letter. 
                        if (userInputParsed == 'a' || userInputParsed == 'b' || userInputParsed == 'c' || userInputParsed == 'd') //Throws an error if user does not input a multiple choice letter. 
                        {
                            if (userInputParsed != answerBank[indexOne]) //Check to see if the parsed, lowercased user input is not equal to the answer for the question. 
                            {
                                isUserCorrectForQuestions[indexOne] = false; //Alters the boolean value in array so that the program knows which question the user got the question wrong.
                                Console.WriteLine("Incorrect Answer. You get a second chance later!");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Correct answer!");
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error! You didn't enter a correct letter. You can only choose A, B, C or D! Try again."); //The program will mark out of range letter answers wrong.
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error! You didn't enter a letter! Try again."); //The program will mark incorrectly formatted answers wrong.
                    }
                }
            }
        }

        static void ShowQuestionsRoundTwo(string[] questionBank, char[] answerBank, bool[] isUserCorrectForQuestions) //Method for second round of questions 
        {
            int indexTwo = -1; //Index counter 
            int quizScore = 10;

            foreach (bool b in isUserCorrectForQuestions) //Checks the bool value to see which question the user got wrong. If the user gets the question wrong, it will grab the index of that question and display it again. 
            {
                indexTwo++;
                if (!b)
                {
                    Console.WriteLine(questionBank[indexTwo]); //grab index of where that FALSE value occurs in the isUserCorrectForQuestions array and use that index in questionArray and answerArray 
                    while (true)
                    {
                        try
                        {
                            string userInput = Console.ReadLine();
                            char userInputParsed = char.ToLower(char.Parse(userInput));
                            if (userInputParsed == 'a' || userInputParsed == 'b' || userInputParsed == 'c' || userInputParsed == 'd')
                            {
                                if (userInputParsed != answerBank[indexTwo])
                                {
                                    isUserCorrectForQuestions[indexTwo] = false;
                                    Console.WriteLine("Incorrect answer; one point deducted. The answer was {0}.", answerBank[indexTwo]);
                                    quizScore--;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Correct answer!");
                                    break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error! You didn't enter a correct letter. You can only choose A, B, C or D! Try again.");
                            }
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Error! You didn't enter a letter! Try again.");
                        }
                    }
                }
            }
            Console.WriteLine("Congratulations! You've finished the quiz. Your score is {0} out of 10. Press Enter to exit!", quizScore);
            Console.ReadLine();

        }


        static void Main()
        {
            /* 
             * Notes:
             * Answers will be stored as char type variables. The answer in answerBank correlate to the questions in questionBank by index. 
             * The booleans in isUserCorrectForQuestions correlates to the questionBank by index as well. 
             */
            string[] questionBank = {
            "Q1: What is 1+1? The possible answer choices: A) 1 B) 2 C) 3 D) 4",
            "Q2: What is 2+10? The possible answer choices: A) 12 B) 2 C) e^x D) -12",
            "Q3: What is the definite integral of cos(x) with respect to x from 0 to 1? The possible answer choices: A) sin(1) B) cos(1) C) 3 D) 4",
            "Q4: What is 1 times 1? The possible answer choices: A) 5 B) 2 C) 3 D) 1",
            "Q5: What is 36 times 8? The possible answer choices: A) 288 B) 200 C) 323 D) 1",
            "Q6: What are the first three digits of pi? The possible answer choices: A) 5.141 B) 3.141 C) 3.14 D) 1.22",
            "Q7: What is 0 divided by the derivative of e^x? The possible answer choices: A) 5 B) 2 C) 3 D) 0",
            "Q8: What is 50 divided by 5? The possible answer choices: A) 5 B) 10 C) 30 D) 20",
            "Q9: What is 3 times 40? The possible answer choices: A) 120 B) 10 C) 30 D) 200",
            "Q10: What is 180 divided by 2? The possible answer choices: A) 10 B) 12 C) 90 D) 200",
            };

            char[] answerBank = { 'b', 'a', 'a', 'd', 'a', 'c', 'd', 'b', 'a', 'c' };

            bool[] isUserCorrectForQuestions = { true, true, true, true, true, true, true, true, true, true };  //Stores whether the answers are correct as booleans for future usage. Default values all set to true.  
            
            //Executes first round of questions with parameters, and then the second round of questions with parameters afterwards. 
            ShowQuizIntro();
            ShowQuestionsRoundOne(questionBank, answerBank, isUserCorrectForQuestions); 
            ShowQuestionsRoundTwo(questionBank, answerBank, isUserCorrectForQuestions); 
        }
    }
}
