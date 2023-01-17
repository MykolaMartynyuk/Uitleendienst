using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Uitleendienst.Repositorys;
using System.Windows;
using Uitleendienst.ObjectClass;
using System.Windows.Media;

namespace Uitleendienst
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        //property
        readonly Coordinator _coordinator;
        private UitleendienstDb _db = new UitleendienstDb();
        private PersonRepository _personRepository;
        private ItemRepository _itemRepository;
        private LoanRecordRepository _loanRecordRepository;
        private bool _listVisability = false;
        private ObservableCollection<IObject> _listToShow = new ObservableCollection<IObject>();
        private IObject _selectedObject;
        private Type _typeToShow;
        private SolidColorBrush _buttonItemSelected = new SolidColorBrush(Colors.SteelBlue);
        private SolidColorBrush _buttonPersonSelected = new SolidColorBrush(Colors.SteelBlue);
        private SolidColorBrush _buttonLoanRecordSelected = new SolidColorBrush(Colors.LightBlue);

        //constructor
        public MainViewModel(Coordinator coordinator)
        {
            this._coordinator = coordinator;
            _typeToShow = typeof(LoanRecord);
            _loanRecordRepository = new LoanRecordRepository(_db);
            AddObjectCommand = new ActionCommand(AddObjectAction);
            UpdateObjectCommand = new ActionCommand(UpdateObjectAction);
            ReadObjectCommand = new ActionCommand(ReadObjectAction);
            ShowItemsCommand = new ActionCommand(ShowItemsAction);
            ShowLoansCommand = new ActionCommand(ShowLoansAction);
            ShowPersonsCommand = new ActionCommand(ShowPersonsAction);
            _listToShow = new ObservableCollection<IObject>(_loanRecordRepository.GetAll());
        }


        //parameters
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand AddObjectCommand { get; private set; }
        public ICommand UpdateObjectCommand { get; private set; }
        public ICommand ReadObjectCommand { get; private set; }
        public ICommand ShowItemsCommand { get; private set; }
        public ICommand ShowLoansCommand { get; private set; }
        public ICommand ShowPersonsCommand { get; private set; }



        public SolidColorBrush ButtonItemSelectedColor
        {
            get { return _buttonItemSelected; }
            set
            {
                _buttonItemSelected = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush ButtonPersonSelectedColor
        {
            get { return _buttonPersonSelected; }
            set
            {
                _buttonPersonSelected = value;
                OnPropertyChanged();
            }
        }

        public SolidColorBrush ButtonLoanRecordSelectedColor
        {
            get { return _buttonLoanRecordSelected; }
            set
            {
                _buttonLoanRecordSelected = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<IObject> ListToShow
            {
            get { return _listToShow; }
                set
                {
                    _listToShow = value;
                    OnPropertyChanged();
                }   
            }

        

        public IObject SelectedObject
        {
            get { return _selectedObject; }
            set
            {
                _selectedObject = value;
                OnPropertyChanged();
            }
        }

        public bool ListVisabilyty
        {
            get { return _listVisability; }
            private set
            {
                _listVisability = value;
                OnPropertyChanged();
            }
        }

        //public Item SelectedItems
        //{
        //    get { return _selectedItems; }
        //    set
        //    {
        //        _selectedItems = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public LoanRecord SelectedLoans
        //{
        //    get { return _selectedLoans; }
        //    set
        //    {
        //        _selectedLoans = value;
        //        OnPropertyChanged();
        //    }
        //}

        //public PersonRepository personRepository
        //{
        //    get { return _personRepository; }
        //    set
        //    {
        //        _personRepository = new PersonRepository(_db);
        //        OnPropertyChanged();
        //    }
        //}


        // functies
        private void OnPropertyChanged([CallerMemberName] string property = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public void AddObjectAction()
        {
            
            if (_typeToShow == typeof(Item))
            {
                _coordinator.ShowItemCreate();
            }
            else if (_typeToShow == typeof(Person))
            {
                _coordinator.ShowPersonCreate();
            }
            else if (_typeToShow == typeof(LoanRecord))
            {
                _coordinator.ShowLoanRecordCreate();
            }
            
        }
        public void UpdateObjectAction()
        {
            if (_selectedObject != null)
            {
                if (_selectedObject is Person)
                {
                    _coordinator.ShowPersonUpdate((Person)_selectedObject);
                }
                else if (_selectedObject is Item)
                {
                    _coordinator.ShowItemUpdate((Item)_selectedObject);
                }
                else if (_selectedObject is LoanRecord)
                {
                    _coordinator.ShowLoanRecordUpdate((LoanRecord)_selectedObject);
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een item");
            }
        }
        public void ReadObjectAction()
        {
            if (_selectedObject != null)
            {
                if (_selectedObject is Person)
                {
                    _coordinator.ShowPersonRead((Person)_selectedObject);
                }
                else if (_selectedObject is Item)
                {
                    _coordinator.ShowItemRead((Item)_selectedObject);
                }
                else if (_selectedObject is LoanRecord)
                {
                    _coordinator.ShowLoanRecordRead((LoanRecord)_selectedObject);
                }
            }
            else
            {
                MessageBox.Show("Selecteer eerst een item");
            }
        }
        
        public void ShowItemsAction()
        {
            ListToShow?.Clear();
            ButtonItemSelectedColor = new SolidColorBrush(Colors.LightBlue);
            ButtonPersonSelectedColor = new SolidColorBrush(Colors.SteelBlue);
            ButtonLoanRecordSelectedColor = new SolidColorBrush(Colors.SteelBlue);
            _typeToShow = typeof(Item);
            _itemRepository = new ItemRepository(_db);
            foreach (Item item in _itemRepository.GetAll())
            {
                ListToShow.Add(item);
            }
        }
        public void ShowLoansAction()
        {
            ListToShow?.Clear();
            ButtonLoanRecordSelectedColor = new SolidColorBrush(Colors.LightBlue);
            ButtonPersonSelectedColor = new SolidColorBrush(Colors.SteelBlue);
            ButtonItemSelectedColor = new SolidColorBrush(Colors.SteelBlue);
            _typeToShow = typeof(LoanRecord);
            _loanRecordRepository = new LoanRecordRepository(_db);
            foreach (LoanRecord loan in _loanRecordRepository.GetAll())
            {
                ListToShow.Add(loan);
            }
        }

        public void ShowPersonsAction()
        {
            _typeToShow = typeof(Person);
            ButtonPersonSelectedColor = new SolidColorBrush(Colors.LightBlue);
            ButtonLoanRecordSelectedColor = new SolidColorBrush(Colors.SteelBlue);
            ButtonItemSelectedColor = new SolidColorBrush(Colors.SteelBlue);
            ListToShow?.Clear();
            _personRepository = new PersonRepository(_db);
            foreach (Person person in _personRepository.GetAll())
            {
                ListToShow.Add(person);
            }
        }

    }
}
