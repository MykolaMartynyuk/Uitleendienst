using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using Uitleendienst.Repositorys;

namespace Uitleendienst.Models
{
    internal class ItemCreateViewMode : INotifyPropertyChanged
    {
        //property
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Coordinator _coordinator;
        private ItemRepository itemRepository;
        private DateTime _purchasDate = DateTime.Now;
        private string _name;
        private string _description;
        private string _type;
        private double _price;
        private DateTime _timeSpan = DateTime.Now;
        private string _damage;
        private bool _isReserved;
        private string _id;


        //cton
        public ItemCreateViewMode(Coordinator coordinator)
        {
            _coordinator = coordinator;
            _id = null;
            ExecuteObjectCommand = new ActionCommand(CreateAction);
            BackToMainCommand = new ActionCommand(BackToMainAction);
        }


        //parameters
        public ICommand ExecuteObjectCommand { get; private set; }
        public ICommand BackToMainCommand { get; private set; }
        public string ButtonConten { get { return "Toevoegen"; } }
        public bool EnableToModify { get { return true; } }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }


        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        
        public DateTime PurchasDate
        {
            get
            {
                return _purchasDate;
            }
            set 
            {
                _purchasDate = value;
                OnPropertyChanged();
            }
        }


        public DateTime GuaranteeDate
        {
            get => _timeSpan;
            set
            {
                _timeSpan = value;
                OnPropertyChanged();
            }
        }

        public string Damage
        {
            get => _damage ;
            set
            {
                _damage = value;
                OnPropertyChanged();
            }
        }

        public bool IsReserved
        {
            get => _isReserved;
            set
            {
                _isReserved = value;
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
        private void CreateAction()
        {
            if(Name == null)
            {
                MessageBox.Show("Naam is niet ingevuld");
            }
            else
            {
                itemRepository = new ItemRepository();
                itemRepository.Create(new Item(Name, Price, Convert.ToInt32(Id), Type, Description, PurchasDate, GuaranteeDate, IsReserved));
                Name = null;
                Description = null;
                Type = null;
                Price = 0;
                Damage = null;
                IsReserved = false;
            }
        }
        private void BackToMainAction()
        {
            _coordinator.ShowMain();
        }
    }
    
}
