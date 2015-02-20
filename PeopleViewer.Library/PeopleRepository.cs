using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleViewer.Library
{
    public class PeopleRepository
    {
        public void GetPeopleAsync()
        {
            var worker = new BackgroundWorker();
            worker.DoWork += (s, e) =>
            {
                e.Result = GetPeople();
            };
            worker.RunWorkerCompleted += (s, e) =>
            {
                var people = (List<Person>)e.Result;
                OnGetPeopleCompleted(new GetPeopleCompletedEventArgs(people));
            };
            worker.RunWorkerAsync();
        }

        public event EventHandler<GetPeopleCompletedEventArgs> GetPeopleCompleted;

        protected virtual void OnGetPeopleCompleted(GetPeopleCompletedEventArgs e)
        {
            EventHandler<GetPeopleCompletedEventArgs> handler = GetPeopleCompleted;

            if (handler != null)
                handler(this, e);
        }

        private IEnumerable<Person> GetPeople()
        {
            var people = new List<Person>
            {
                new Person() { FirstName="John", LastName="Koenig",
                    StartDate = DateTime.Parse("10/17/1975"), Rating=6 },
                new Person() { FirstName="Dylan", LastName="Hunt", 
                    StartDate = DateTime.Parse("10/02/2000"), Rating=8 },
                new Person() { FirstName="John", LastName="Crichton", 
                    StartDate = DateTime.Parse("03/19/1999"), Rating=7 },
                new Person() { FirstName="Dave", LastName="Lister", 
                    StartDate = DateTime.Parse("02/15/1988"), Rating=9 },
                new Person() { FirstName="John", LastName="Sheridan", 
                    StartDate = DateTime.Parse("01/26/1994"), Rating=6 },
                new Person() { FirstName="Dante", LastName="Montana", 
                    StartDate = DateTime.Parse("11/01/2000"), Rating=5 },
                new Person() { FirstName="Isaac", LastName="Gampu", 
                    StartDate = DateTime.Parse("09/10/1977"), Rating=4 }
            };
            return people;

        }
    }

    public class GetPeopleCompletedEventArgs : EventArgs
    {
        public IEnumerable<Person> Result { get; set; }

        public GetPeopleCompletedEventArgs(IEnumerable<Person> people)
        {
            Result = people;
        }
    }
}
