using MenuApp.Core.Entities;
using System.Collections.Generic;

namespace MenuApp.Services.QuestionService
{
    public interface IQuestionService
    {
        List<Contact> ShowActiveQuestions();
        List<Contact> ShowQuestions();
        Contact AnswerTheQuestion(int id);
        void ChangeActivityQuestion(int id);
        Contact ShowDetailsQuestion(int id);
        void Contact(Contact contact);

    }
}
