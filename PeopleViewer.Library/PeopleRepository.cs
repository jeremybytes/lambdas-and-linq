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
                    StartDate = new DateTime(1975, 10, 17), Rating=6 },
                new Person() { FirstName="Dylan", LastName="Hunt", 
                    StartDate = new DateTime(2000, 10, 2), Rating=8 },
                new Person() { FirstName="John", LastName="Crichton", 
                    StartDate = new DateTime(1999, 3, 19), Rating=7 },
                new Person() { FirstName="Dave", LastName="Lister", 
                    StartDate = new DateTime(1988, 2, 15), Rating=9 },
                new Person() { FirstName="John", LastName="Sheridan", 
                    StartDate = new DateTime(1994, 1, 26), Rating=6 },
                new Person() { FirstName="Dante", LastName="Montana", 
                    StartDate = new DateTime(2000, 11, 1), Rating=5 },
                new Person() { FirstName="Isaac", LastName="Gampu", 
                    StartDate = new DateTime(1977, 9, 10), Rating=4 }
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
