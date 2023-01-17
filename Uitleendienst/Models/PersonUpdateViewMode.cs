using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Uitleendienst.Repositorys;

namespace Uitleendienst.Models
{
    internal class PersonUpdateViewMode : INotifyPropertyChanged
    {
        //property
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Coordinator _coordinator;
        Person _person;
        private PersonRepository _personRepositroy;

        //cton
        public PersonUpdateViewMode(Coordinator coordinator, Person person)
        {
            _coordinator = coordinator;
            _person = person;
            ExecuteObjectCommand = new ActionCommand(UpdateAction);
            BackToMainCommand = new ActionCommand(BackToMainAction);
        }


        //parameters
        public ICommand ExecuteObjectCommand { get; set; }
        public ICommand BackToMainCommand { get; set; }
        public string ButtonContent { get { return "Toepassen"; } }
        public bool IsEnabled { get { return true; } }
        public string IdString
        {
            get { return $"ID: {_person.Id.ToString()}"; }
        }
        public string FirstName
        {
            get { return _person.FirstName; }
            set
            {
                _person.FirstName = value;
                OnPropertyChanged();
            }
        }
        public string LastName
        {
            get { return _person.LastName; }
            set
            {
                _person.LastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _person.Email; }
            set
            {
                _person.Email = value;
                OnPropertyChanged();
            }
        }

        public int Id { get { return _person.Id; } }

        //methodes
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private void UpdateAction()
        {
            _personRepositroy = new PersonRepository();
            _personRepositroy.Update(_person);
            BackToMainAction();

        }

        private void BackToMainAction()
        {
            _coordinator.ShowMain();
        }
    }

}
