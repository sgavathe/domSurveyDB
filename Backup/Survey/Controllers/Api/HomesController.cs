using Survey.Models.DataHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
 
namespace Survey.Controllers.Api
{
    public class HomesController : ApiController
    {

        private SurveyDataHandler _SurveyHandler;

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public SurveyModel Get(int id)
        {
            _SurveyHandler = new SurveyDataHandler();
            return _SurveyHandler.GetAllQuestion(id);
        }

        // POST api/<controller>
        public void Post(SurveyModel value)
        {

            _SurveyHandler = new SurveyDataHandler();
              _SurveyHandler.Save(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
 
    }
}
