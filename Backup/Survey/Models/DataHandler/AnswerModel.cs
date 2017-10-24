using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Survey.Models.DataHandler
{
    public class AnswerModel
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public int QuestionId { get; set; }
        public bool Checked { get; set; }
        public int Numbers { get; set; }
    
    }
}