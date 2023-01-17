using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Uitleendienst.Repositorys;

namespace Uitleendienst.Models
{
    internal class PersonCreateViewMode : INotifyPropertyChanged
    {
        //property
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Coordinator _coordinator;
        private PersonRepository _personRepositroy;
        private string _firstName;
        private string _lastName;
        private string _email;

        //cton
        public PersonCreateViewMode(Coordinator coordinator)
        {
            _coordinator = coordinator;
            ExecuteObjectCommand = new ActionCommand(CreateAction);
            BackToMainCommand = new ActionCommand(BackToMainAction);
        }


        //parameters
        public bool IsEnabled { get { return true; } }
        public string ButtonContent { get { return "Toevoegen"; } }
        public ICommand ExecuteObjectCommand { get; private set; }
        public ICommand BackToMainCommand { get; private set; }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public int Id { get; set; }

        //methodes
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void CreateAction()
        {
            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName))
            {
                MessageBox.Show("Vul voornaam en achternaam in");
            }
            else
            {
                _personRepositroy = new PersonRepository();
                _personRepositroy.Create(new Person(FirstName, LastName, Email));
                FirstName = "";
                LastName = "";
                Email = "";
            }
        }

        private void BackToMainAction()
        {
            _coordinator.ShowMain();
        }
    }
}

