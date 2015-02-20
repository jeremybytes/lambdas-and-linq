using PeopleViewer.Library;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace PeopleViewer
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Fields

        private IEnumerable<Person> cachedPeople;
        private IEnumerable<Person> people;

        private bool dateFilterChecked;
        private int dateFilterStartYear = 1985;
        private int dateFilterEndYear = 2000;

        private bool nameFilterChecked;
        private string nameFilterValue = "John";

        private bool lastNameSortChecked;
        private bool firstNameSortChecked;
        private bool startDateSortChecked;
        private bool ratingSortChecked;

        #endregion

        #region Properties

        public IEnumerable<Person> People
        {
            get { return people; }
        }

        public bool DateFilterChecked
        {
            get { return dateFilterChecked; }
            set
            {
                if (dateFilterChecked == value)
                    return;
                dateFilterChecked = value;
                UpdateFilterAndSort();
            }
        }

        public int DateFilterStartYear
        {
            get { return dateFilterStartYear; }
            set
            {
                if (dateFilterStartYear == value)
                    return;
                dateFilterStartYear = value;
                UpdateFilterAndSort();
            }
        }

        public int DateFilterEndYear
        {
            get { return dateFilterEndYear; }
            set
            {
                if (dateFilterEndYear == value)
                    return;
                dateFilterEndYear = value;
                UpdateFilterAndSort();
            }
        }

        public bool NameFilterChecked
        {
            get { return nameFilterChecked; }
            set
            {
                if (nameFilterChecked == value)
                    return;
                nameFilterChecked = value;
                UpdateFilterAndSort();
            }
        }

        public string NameFilterValue
        {
            get { return nameFilterValue; }
            set
            {
                if (nameFilterValue == value)
                    return;
                nameFilterValue = value;
                UpdateFilterAndSort();
            }
        }

        public bool LastNameSortChecked
        {
            get { return lastNameSortChecked; }
            set
            {
                if (lastNameSortChecked == value)
                    return;
                if (value)
                {
                    UncheckAllSort();
                    lastNameSortChecked = value;
                    UpdateFilterAndSort();
                }
            }
        }

        public bool FirstNameSortChecked
        {
            get { return firstNameSortChecked; }
            set
            {
                if (firstNameSortChecked == value)
                    return;
                if (value)
                {
                    UncheckAllSort();
                    firstNameSortChecked = value;
                    UpdateFilterAndSort();
                }
            }
        }

        public bool StartDateSortChecked
        {
            get { return startDateSortChecked; }
            set
            {
                if (startDateSortChecked == value)
                    return;
                if (value)
                {
                    UncheckAllSort();
                    startDateSortChecked = value;
                    UpdateFilterAndSort();
                }
            }
        }

        public bool RatingSortChecked
        {
            get { return ratingSortChecked; }
            set
            {
                if (ratingSortChecked == value)
                    return;
                if (value)
                {
                    UncheckAllSort();
                    ratingSortChecked = value;
                    UpdateFilterAndSort();
                }
            }
        }

        #endregion

        #region Public Methods

        public void RefreshData()
        {
            var repository = new PeopleRepository();
            repository.GetPeopleCompleted += (s, e) =>
            {
                cachedPeople = e.Result;
                ResetFilters();
                UpdateFilterAndSort();
            };
            repository.GetPeopleAsync();
        }

        #endregion

        #region Private Methods

        private void ResetFilters()
        {
            UncheckAllSort();
            dateFilterChecked = false;
            nameFilterChecked = false;
            UpdateFilterAndSort();
        }

        private void UncheckAllSort()
        {
            lastNameSortChecked = false;
            firstNameSortChecked = false;
            startDateSortChecked = false;
            ratingSortChecked = false;
        }

        private void UpdateFilterAndSort()
        {
            people = cachedPeople;

            if (DateFilterChecked)
                people = people
                    .Where(p => p.StartDate.Year >= dateFilterStartYear)
                    .Where(p => p.StartDate.Year <= dateFilterEndYear);

            if (NameFilterChecked)
                people = people.Where(p => p.FirstName == nameFilterValue);

            if (lastNameSortChecked)
                people = people.OrderBy(p => p.LastName);

            if (firstNameSortChecked)
                people = people.OrderBy(p => p.FirstName).ThenBy(p => p.LastName);

            if (startDateSortChecked)
                people = people.OrderBy(p => p.StartDate);

            if (ratingSortChecked)
                people = people.OrderByDescending(p => p.Rating);

            RaisePropertyChanged();
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private void RaisePropertyChanged()
        {
            if (PropertyChanged != null)
            {
                foreach(var property in this.GetType().GetProperties().Where(p => !p.IsSpecialName))
                    PropertyChanged(this, new PropertyChangedEventArgs(property.Name));
            }
        }

        #endregion
    }
}
