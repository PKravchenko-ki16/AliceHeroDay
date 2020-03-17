using System;
using System.Collections.Generic;
using System.Text;

namespace AliceHeroDay.Model.ActivationWords
{
    public class Management
    {
        public string[] WordsActivators { get; set; }
        public AnswerManagement Answers { get; set; }
        public bool IsEnd { get; set; }
    }
}
