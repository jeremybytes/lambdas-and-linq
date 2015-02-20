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
                    PersonListBox.ItemsSource = repoArgs.Result;
                    if (selectedPerson != null)
                        foreach (Person person in PersonListBox.Items)
                            if (person.LastName == selectedPerson.LastName &&
                                person.FirstName == selectedPerson.FirstName)
                            {
                                PersonListBox.SelectedItem = person;
                            }
                };
            repository.GetPeopleAsync();
            //selectedPerson = null;
        }

        //void repository_GetPeopleCompleted(object sender, GetPeopleCompletedEventArgs e)
        //{
        //    PersonListBox.ItemsSource = e.Result;
        //}
    }
}
