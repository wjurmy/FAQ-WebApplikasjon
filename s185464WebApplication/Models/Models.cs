using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace s185464WebApplication.Models
{
    
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public virtual ICollection<FaqItem> FaqItems { get; set; }

        [XmlIgnore]
        [IgnoreDataMember]
        public virtual ICollection<SubmittedQuestion> SubmittedQuestions { get; set; }
    }

    
    public class FaqItem
    {
        public int FaqItemId { get; set; }
        public string Name { get; set; }
        public string Question { get; set; }
        public int ViewCount { get; set; }
        
        public virtual ICollection<Answer> Answers { get; set; }
        public virtual Category Category { get; set; }
    }

    
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; }

        [XmlIgnore]
        [IgnoreDataMember] 
        public virtual FaqItem FaqItem { get; set; }
    }

    public class SubmittedQuestion
    {
        public int SubmittedQuestionId { get; set; }
        public string Name { get; set; }
        public string UserEmail { get; set; }
        public string QuestionText { get; set; }
        public string Answer { get; set; }
        public int ViewCount { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public virtual Category Category { get; set; }
    }

    public class FaqModel : DbContext
    {
        public FaqModel()
            : base("NyDatabase")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<FaqItem> FaqItems { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<SubmittedQuestion> SubmittedQuestions { get; set; }
    }
}