using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.Models.DataHandler
{
    public class QuestionModel
    {
        public int QuestionId { get; set; }
        public int SurveyId { get; set; }
        public string Text { get; set; }
        public int AnswerChoice { get; set; }
        public List <AnswerModel > Answers {get;set;}
        public string ChartData { get; set; }
    }
}