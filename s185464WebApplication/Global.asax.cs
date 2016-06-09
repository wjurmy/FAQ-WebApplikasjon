using System;
using System.Web.Http;
using s185464WebApplication.Models;

namespace s185464WebApplication
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            using (var entity = new FaqModel())
            {
                // add some questions
                entity.SubmittedQuestions.Add(new SubmittedQuestion()
                {
                    Name = "PCen oppdaterer seg ikke.",
                    CreatedDateTime = DateTime.Today,
                    UserEmail = "some@info.com",
                    QuestionText = "Helt umulig å oppdatere til nyeste version av Win8.",
                    Category = new Category()
                    {
                        Name = "Data"

                    },
                });

                // add some questions
                entity.SubmittedQuestions.Add(new SubmittedQuestion()
                {
                    Name = "Drålig Signal",
                    CreatedDateTime = DateTime.Today,
                    UserEmail = "Stev@job.com",
                    QuestionText = "Mobilen har ikke signal, gjelder iphone 6.",
                    Category = new Category()
                    {
                        Name = "Mobil"

                    },
                });

                // add some questions
                entity.SubmittedQuestions.Add(new SubmittedQuestion()
                {
                    Name = "TV slå seg ikke på.",
                    CreatedDateTime = DateTime.Today,
                    UserEmail = "Samsung@Korea.com",
                    QuestionText = "TVen får ikke inn strøm.",
                    Category = new Category()
                    {
                        Name = "TV og bilde"
                    },
                });

                // add some questions
                entity.SubmittedQuestions.Add(new SubmittedQuestion()
                {
                    Name = "Hva skjedde med Kodak?",
                    CreatedDateTime = DateTime.Today,
                    UserEmail = "Kodak@foto.com",
                    QuestionText = "Hva hendte med Kodak verdens ledende foto aparat produsent?",
                    Category = new Category()
                    {
                        Name = "Foto og video"

                    },
                });

                // add some questions
                entity.SubmittedQuestions.Add(new SubmittedQuestion()
                {
                    Name = "Varmepumpe lager lyd",
                    CreatedDateTime = DateTime.Today,
                    UserEmail = "Varme@pumpe.com",
                    QuestionText = "Er det vanlig med bråkende varme pumpe?",
                    Category = new Category()
                    {
                        Name = "Hjem og fritid"

                    },
                });

                // add some questions
                entity.SubmittedQuestions.Add(new SubmittedQuestion()
                {
                    Name = "Boss 25",
                    CreatedDateTime = DateTime.Today,
                    UserEmail = "Boss@bøss.com",
                    QuestionText = "Er den god?",
                    Category = new Category()
                    {
                        Name = "Lyd og hodetelefoner"

                    },
                });

                // add some questions
                entity.SubmittedQuestions.Add(new SubmittedQuestion()
                {
                    Name = "Hvordan betale?",
                    CreatedDateTime = DateTime.Today,
                    UserEmail = "test@gmail.com",
                    QuestionText = "Betanling går ikke gjennom.",
                    Category = new Category()
                    {
                        Name = "Betaling"

                    },
                });
                // add some questions
                entity.SubmittedQuestions.Add(new SubmittedQuestion()
                {
                    Name = "Leverings Tid",
                    CreatedDateTime = DateTime.Today,
                    UserEmail = "Leverings@Tid.com",
                    QuestionText = "Kan levering skje på kvelds tid?",
                    Category = new Category()
                    {
                        Name = "Service og Suport"

                    },
                });

                // add some questions
                entity.SubmittedQuestions.Add(new SubmittedQuestion()
                {
                    Name = "Fri Frakt?",
                    CreatedDateTime = DateTime.Today,
                    UserEmail = "test@gmail.com",
                    QuestionText = "Er det fri frakt når man bestiller over 10000 enheter?",
                    Category = new Category()
                    {
                        Name = "Leveringsinfo"

                    },
                });

                var res = entity.SaveChanges();
            }
        }
    }
}
