using PeopleViewer.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Person selectedPerson = PersonListBox.SelectedItem as Person;

            var repository = new PeopleRepository();
            repository.GetPeopleCompleted +=
                (repoSender, repoArgs) =>
                {
                    PersonListBox.ItemsSource = AddSort(AddFilters(repoArgs.Result));
                    if (selectedPerson != null)
                        PersonListBox.SelectedItem =
                            PersonListBox.Items.OfType<Person>().SingleOrDefault(
                                p => p.FirstName == selectedPerson.FirstName &&
                                    p.LastName == selectedPerson.LastName
                            );
                };
            repository.GetPeopleAsync();
            //selectedPerson = null;
        }

        private IEnumerable<Person> AddFilters(IEnumerable<Person> data)
        {
            int startYear = Int32.Parse(StartDateTextBox.Text);
            int endYear = Int32.Parse(EndDateTextBox.Text);

            if (DateFilterCheckBox.IsChecked.Value)
                data = data
                    .Where(p => p.StartDate.Year >= startYear)
                    .Where(p => p.StartDate.Year <= endYear);

            if (NameFilterCheckBox.IsChecked.Value)
                data = data.Where(p => p.FirstName == NameTextBox.Text);

            return data;
        }

        private IOrderedEnumerable<Person> AddSort(IEnumerable<Person> data)
        {
            if (LastNameSortButton.IsChecked.Value)
                return data.OrderBy(p => p.LastName);

            if (FirstNameSortButton.IsChecked.Value)
                return data.OrderBy(p => p.FirstName).ThenBy(p => p.LastName);

            if (DateSortButton.IsChecked.Value)
                return data.OrderBy(p => p.StartDate);

            if (RatingSortButton.IsChecked.Value)
                return data.OrderByDescending(p => p.Rating);

            return data.OrderBy(p => p.LastName);
        }

        //void repository_GetPeopleCompleted(object sender, GetPeopleCompletedEventArgs e)
        //{
        //    PersonListBox.ItemsSource = e.Result;
        //}
    }
}
