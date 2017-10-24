using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.Models.DataHandler
{
    public class SurveyModel
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public List<QuestionModel> Questions { get; set; }

    }
}