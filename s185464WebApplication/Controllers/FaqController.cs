using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using s185464WebApplication.Models;

namespace s185464WebApplication.Controllers
{
    public class FaqController : ApiController
    {
        public ICollection<Category> GetAllCategories()
        {
            using (var entity = new FaqModel())
            {
                var cats = entity.Categories.ToList();
                return cats;
            }
        } 

        public ICollection<FaqItem> GetAllItems()
        {
            using (var entity = new FaqModel())
            {
                //for å vis loading process i anguler module
                Thread.Sleep(5000);//sleep 5 sec
                var faqs = entity.FaqItems.Include("Category").Include("Answers").ToList();

                
                return faqs;
            }
        }

        public bool SubmitFaq(SubmittedQuestion item)
        {
            try
            {
                using (var entity = new FaqModel())
                {
                    item.CreatedDateTime = DateTime.Now;
                    var cat = entity.Categories.FirstOrDefault(c => c.Name == item.Category.Name);
                    if (cat != null)
                    {
                        item.Category = cat;
                    }
                    entity.SubmittedQuestions.Add(item);
                    var res = entity.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool SubmitAnswer(SubmittedQuestion item)
        {
            try
            {
                using (var entity = new FaqModel())
                {
                    var question = entity.SubmittedQuestions.FirstOrDefault(q => q.SubmittedQuestionId == item.SubmittedQuestionId);
                    question.Answer = item.Answer;
                    var res = entity.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public ICollection<SubmittedQuestion> GetAllSubmittedQuestions()
        {
            using (var entity = new FaqModel())
            {
                var sqs = entity.SubmittedQuestions.Include("Category").ToList();
                return sqs;
            } 
        }

        public bool FaqViewCountAdd(SubmittedQuestion item)
        {
            try
            {
                using (var entity = new FaqModel())
                {
                    var fq = entity.SubmittedQuestions.FirstOrDefault(f => f.SubmittedQuestionId == item.SubmittedQuestionId);
                    fq.ViewCount++;

                    var res = entity.SaveChanges();
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

      
    }
}


