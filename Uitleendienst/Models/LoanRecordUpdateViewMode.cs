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
    internal class LoanRecordUpdateViewMode : INotifyPropertyChanged
    {
        //property
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Coordinator _coordinator;
        private LoanRecordRepository _loanRecordRepository;
        private ItemRepository _itemRepository;
        private PersonRepository _personRepository;
        private LoanRecord _loanRecord;
        private Item _selectedItem;
        private Person _selectedPerson;

        //cton
        public LoanRecordUpdateViewMode(Coordinator coordinator, LoanRecord loanRecord)
        {
            this._coordinator = coordinator;
            ExecuteObjectCommand = new ActionCommand(UpdateAction);
            BackToMainCommand = new ActionCommand(BackToMainAction);
            _loanRecord = loanRecord;
        }

        //parameters
        public ICommand ExecuteObjectCommand { get; private set; }
        public ICommand BackToMainCommand { get; private set; }
        public bool IsEnabled { get { return true; } }
        public string ButtonContent { get { return "Toepassen"; } }
        public int Id { get { return _loanRecord.Id; } }
        public string IdString
        {
            get { return $"ID: {_loanRecord.Id.ToString()}"; }
        }

        public Item SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                _selectedPerson = value;
                OnPropertyChanged();
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

        public List<Item> ItemList
        {
            get
            {
                _itemRepository = new ItemRepository();
                return _itemRepository.GetAll();
            }
        }

        public List<Person> PersonList
        {
            get
            {
                _personRepository = new PersonRepository();
                return _personRepository.GetAll();
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

        private void UpdateAction()
        {
            _loanRecordRepository = new LoanRecordRepository();
            _loanRecordRepository.Update(_loanRecord);
            BackToMainAction();
        }

        private void BackToMainAction()
        {
            _coordinator.ShowMain();
        }
    }

}
