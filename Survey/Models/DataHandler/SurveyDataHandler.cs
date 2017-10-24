using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Survey.Models;
 
namespace Survey.Models.DataHandler
{
    public class SurveyDataHandler
    {

        private surveyEF _SurveyDb;

        public SurveyModel GetAllQuestion(int id)
        {
            var result = new SurveyModel();
             
            var resultQ = new List<QuestionModel>();
            using (_SurveyDb = new surveyEF())
            {
                var s = _SurveyDb.sps_QAforSurvey(id).ToList<sps_QAforSurvey_Result>();
                var questions = s.Select(d => d.QuestionId).Distinct();
                foreach (var q in questions)
                {
                    var individualQ = (from obj in s
                                       where obj.QuestionId == q
                                       select new QuestionModel
                                       {
                                           QuestionId = q,
                                           Text = obj.Text,
                                           SurveyId = obj.SurveyId,
                                           AnswerChoice =0,
                                           Answers = new List<AnswerModel>() 
                                       }).FirstOrDefault();

                    var ansInModel = (from obj in s
                                      where obj.QuestionId == q
                                      select new AnswerModel
                                      {
                                           AnswerId= obj.AnswerId,
                                          Text = obj.Text1 ,
                                           QuestionId = q ,
                                            Numbers=0,
                                            Checked =  false,
                                            
                                      }).ToList<AnswerModel>();

                    individualQ.Answers.AddRange(ansInModel);
                    resultQ.Add(individualQ);
                }
                 
            }
            result.Questions = new List<QuestionModel>();
            result.Questions.AddRange(resultQ);
            result.SurveyId = 1;
            return result;
        }

        public int Save(SurveyModel data)
        {
            var result = 0;
            try
            {
                data.Questions.ForEach(p =>
                {
                    var Tkr = new Taker() { AnswerID = p.AnswerChoice, QuestionID = p.QuestionId };
                    using (_SurveyDb = new surveyEF())
                    {
                        _SurveyDb.Takers.Add(Tkr);
                        _SurveyDb.SaveChanges();
                    }
                    
                });

                result = 1;   
            }
            catch
            {
                 
            }
            return result;
        }

        public SurveyModel GetDashboarData(int id)
        {
            var survey= GetAllQuestion(id);
            using (_SurveyDb = new surveyEF())
            {
                var s = _SurveyDb.sps_graphData().ToList<sps_graphData_Result >();
                survey.Questions.ForEach(q => q.Answers.ForEach(ans =>
                {
                    ans.Numbers = s.Where(o => o.AnswerID == ans.AnswerId).Select(p => p.numbers.Value).FirstOrDefault();
                }));

                s.ForEach(p =>
                {
                    if (p.AnswerID == 0)
                    {
                        foreach (var d in survey.Questions)
                        {
                            if (d.QuestionId == p.QuestionID)
                            {
                                d.Answers.Add(new AnswerModel() { AnswerId = 0, Numbers = p.numbers.Value  ,Text ="Did not answer"});
                            }
                        }
                    }

                });

                survey.Questions .ForEach (p=>p.ChartData =string.Empty );


            }
            return survey;
        }
         
    }
}