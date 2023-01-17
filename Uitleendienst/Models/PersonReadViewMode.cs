using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using Uitleendienst.Repositorys;

namespace Uitleendienst.Models
{
    internal class PersonReadViewMode : INotifyPropertyChanged
    {
        //property
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Coordinator _coordinator;
        private Person _person;
        private PersonRepository _personRepositroy;

        //cton
        public PersonReadViewMode(Coordinator coordinator, Person person)
        {
            _coordinator = coordinator;
            _person = person;
            ExecuteObjectCommand = new ActionCommand(DeleteAction);
            BackToMainCommand = new ActionCommand(BackToMainAction);
        }


        //parameters
        public ICommand ExecuteObjectCommand { get; set; }
        public ICommand BackToMainCommand { get; set; }
        public string ButtonContent { get { return "Verwijderen"; } }
        public bool IsEnabled { get { return false; } }
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
        
        public int Id
        {
            get { return _person.Id; }
            set
            {
                _person.Id = value;
                OnPropertyChanged();
            }
        }

        //methodes
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        
        private void DeleteAction()
        {
            LoanRecordRepository loanRecordRepository = new LoanRecordRepository();
            if (loanRecordRepository.GetAll().Where(x => x.Person == _person.Id && x.IsReturned == false).Count() > 0)
            {
                System.Windows.MessageBox.Show("Deze persoon heeft nog niet teruggebracht");
            }
            else
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Alle records van die ook zullen zijn verwijderen. Verwijderen?", "Andacht!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    _personRepositroy = new PersonRepository();
                    var loanRecordToDelete = loanRecordRepository.GetAll().Where(x => x.Person == _person.Id).Select(x => x.Id).ToList();
                    foreach (var item in loanRecordToDelete)
                    {
                        loanRecordRepository.Delete(item);
                    }
                    _personRepositroy.Delete(_person.Id);
                    BackToMainAction();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }

            }

        }

        private void BackToMainAction()
        {
            _coordinator.ShowMain();
        }
    }
}