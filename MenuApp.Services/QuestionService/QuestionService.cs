using System;
using System.Collections.Generic;
using System.Linq;
using MenuApp.Core.Entities;

namespace MenuApp.Services.QuestionService
{
    public class QuestionService : BaseService, IQuestionService
    {
        public QuestionService(IDataContext dataContext) : base(dataContext)
        {

        }

        public Contact AnswerTheQuestion(int id)
        {
            throw new NotImplementedException();
        }
        public void ChangeActivityQuestion(int id)
        {
            var question = _dataContext.All<Contact>().First(x => x.Id == id);
            if(question.IsActive)
            {
                question.IsActive = false;
            }
            else
            {
                question.IsActive = true;
            }
        }

        public void Contact(Contact contact)
        {
            _dataContext.Add<Contact>(contact);
            _dataContext.SaveChanges();
        }

        public List<Contact> ShowActiveQuestions()
        {
            return _dataContext.All<Contact>().Where(x => x.IsActive ).ToList();
        }
        public Contact ShowDetailsQuestion(int id)
        {
            return _dataContext.All<Contact>().First(x => x.Id == id);
        }
        public List<Contact> ShowQuestions()
        {
            return _dataContext.All<Contact>().ToList();
        }
    }
}
