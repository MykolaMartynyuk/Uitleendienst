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
    internal class LoanRecordCreateViewMode : INotifyPropertyChanged
    {
        //property
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Coordinator _coordinator;
        private LoanRecordRepository _loanRecordReposiroty;
        private ItemRepository _itemRepository;
        private PersonRepository _personRepository;
        private Item _selectedItem;
        private Person _selectedPerson;
        private DateTime _loanDate = DateTime.Now;
        private DateTime _returnDate = DateTime.Now;
        private bool _returned = false;


        //cton
        public LoanRecordCreateViewMode(Coordinator coordinator)
        {
            this._coordinator = coordinator;
            ExecuteObjectCommand = new ActionCommand(CreateAction);
            BackToMainCommand = new ActionCommand(BackToMainAction);
        }

        //parameters
        public ICommand ExecuteObjectCommand { get; private set; }
        public ICommand BackToMainCommand { get; private set; }
        public bool IsEnabled { get { return true; } }
        public string ButtonContent { get { return "Toevoegen"; } }
        public int Id { get; set; }

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
            get { return _loanDate; }
            set
            {
                _loanDate = value;
                OnPropertyChanged();
            }
        }
        public DateTime ReturnDate
        {
            get { return _returnDate; }
            set
            {
                _returnDate = value;
                OnPropertyChanged();
            }
        }

        public bool Returned
        {
            get { return false; }
            set
            {
                _returned = false;
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

        private void CreateAction()
        {
            if (SelectedItem == null || SelectedPerson == null)
            {
                MessageBox.Show("Gelieve een item en een persoon te selecteren");
            }
            else
            {
                _loanRecordReposiroty = new LoanRecordRepository();
                _loanRecordReposiroty.Create(new LoanRecord(SelectedItem.Id, ReturnDate, Id, SelectedPerson.Id));
            }
        }

        private void BackToMainAction()
        {
            _coordinator.ShowMain();
        }
    }

}
