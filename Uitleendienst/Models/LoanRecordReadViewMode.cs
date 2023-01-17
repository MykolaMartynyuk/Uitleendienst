using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Uitleendienst.Repositorys;

namespace Uitleendienst.Models
{
    internal class LoanRecordReadViewMode : INotifyPropertyChanged
    {
        //property
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Coordinator _coordinator;
        private LoanRecordRepository _loanRecordReposiroty;
        private LoanRecord _loanRecord;
        private ItemRepository _itemRepository;
        private PersonRepository _personRepository;
        private Item _item;
        private Person _person;


        //cton
        public LoanRecordReadViewMode(Coordinator coordinator, LoanRecord loanRecord)
        {
            this._coordinator = coordinator;
            _loanRecord = loanRecord;
            _itemRepository = new ItemRepository();
            _personRepository = new PersonRepository();
            ExecuteObjectCommand = new ActionCommand(DeleteAction);
            BackToMainCommand = new ActionCommand(BackToMainAction);
        }

        public ICommand ExecuteObjectCommand { get; private set; }
        public ICommand BackToMainCommand { get; private set; }
        public bool IsEnabled { get { return false; } }
        public string ButtonContent { get { return "Verwijderen"; } }
        public int Id
        {
            get { return _loanRecord.Id; }
        }
        public string IdString
        {
            get { return $"ID: {_loanRecord.Id.ToString()}"; }
        }

        public Item SelectedItem
        {
            get { return _itemRepository.GetById( _loanRecord.Item); }
            set
            {
                
                //if (_itemRepository.GetById(_loanRecord.Item.Id)) return;
                _item = value;
                OnPropertyChanged("CurrentItem");
            }
        }

        public Person SelectedPerson
        {
            get { return _personRepository.GetById(_loanRecord.Person) ; }
            set
            {
                //if (_loanRecord.Person == value) return;
                _person = value;
                OnPropertyChanged("CurrentItem");
            }
        }

        public DateTime LoanDate
        {
            get { return _loanRecord.DateLoan; }
            set
            {
                _loanRecord.DateLoan = value;
                OnPropertyChanged();
            }
        }
        public DateTime ReturnDate
        {
            get { return _loanRecord.DateReturn; }
            set
            {
                _loanRecord.DateReturn = value;
                OnPropertyChanged();
            }
        }

        public bool Returned
        {
            get { return _loanRecord.IsReturned; }
            set
            {
                _loanRecord.IsReturned = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Item> ItemList
        {
            get
            {
                _itemRepository = new ItemRepository();
                return new ObservableCollection<Item>(_itemRepository.GetAll());
            }
        }

        public ObservableCollection<Person> PersonList
        {
            get
            {
                _personRepository = new PersonRepository();
                return new ObservableCollection<Person>(_personRepository.GetAll());
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
            _loanRecordReposiroty = new LoanRecordRepository();
            _loanRecordReposiroty.Delete(_loanRecord.Id);
            BackToMainAction();
        }

        private void BackToMainAction()
        {
            _coordinator.ShowMain();
        }
    }

}
