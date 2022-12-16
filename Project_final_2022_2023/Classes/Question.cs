using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_final_2022_2023.Classes
{
    internal class Question
    {
        public Question() { }

        public int QType { get; set; }
        public string QText { get; set; } 

        public Array QAnswers { get; set; }

        public Array QCorrectAns { get; set; }  

        public int QTimeLimit { get; set; } 

        public int QTimeRemaining { get; set; }

        public void OpenQuestion()
        {

        }
            
        public void CloseQuestion()
        {

        }

        public void CountdownQuestion()
        {

        }
    }
}
