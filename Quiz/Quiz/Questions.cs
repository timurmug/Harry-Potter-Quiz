using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz
{
    public class QuestionV1
    {
        public string question { get; private set; }
        public string correct { get; private set; }
        public string[] answeres { get; private set; }
        public QuestionV1(string q,string a1, string a2, string a3, string a4)
        {
            question = q;
            correct = a1;
            answeres = new string[4] { a1, a2, a3, a4 };
        }
    }

    public class QuestionV2
    {
        public string question { get; private set; }
        public string answer { get; private set; }
        public string imageSource { get; private set; }
        public QuestionV2(string q, string a, string s)
        {
            question = q;
            answer = a;
            imageSource=s;
        }
    }

    public class QuestionV4
    {
        public string question { get; private set; }
        public string answer { get; private set; }
        public QuestionV4(string q, string a)
        {
            question = q;
            answer = a;
        }
    }

    public class QuestionV5
    {
        public string question { get; private set; }
        public string correct { get; private set; }
        public string[] answeres { get; private set; }
        string[] halfansweres { get; set; }
        public QuestionV5(string q, string a1, string a2, string a3, string a4, 
            string a5, string a6, string a7, string a8)
        {
            question = q;
            correct = a1;
            answeres = new string[8] { a1, a2, a3, a4 , a5, a6 ,a7, a8};
            halfansweres = new string[4] { a1, a2, a3 ,a4};
        }

        public string[] deletehalfAnswers()
        {
            return halfansweres;
        }
    }

    public class QuestionV6
    {
        public string question { get; private set; }
        public bool IsItTrue { get; private set; }
        public QuestionV6(string q, bool t)
        {
            question = q;
            IsItTrue = t;
        }
    }
}
