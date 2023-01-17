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
    internal class ItemReadViewMode : INotifyPropertyChanged
    {
        //property
        public event PropertyChangedEventHandler PropertyChanged;
        readonly Coordinator _coordinator;
        private ItemRepository itemRepository;
        private Item _item;
        
        
        //cton
        public ItemReadViewMode(Coordinator coordinator, Item item)
        {
            _coordinator = coordinator;
            _item = item;
            ExecuteObjectCommand = new ActionCommand(DeleteAction);
            BackToMainCommand = new ActionCommand(BackToMainAction);
        }
        

        //parameters
        public ICommand ExecuteObjectCommand { get; private set; }
        public ICommand BackToMainCommand { get; private set; }
        public string ButtonConten { get { return "Verwijder"; } }
        public bool EnableToModify { get { return false; } }

        public string Name
        {
            get { return _item.Name; }
            set
            {
                _item.Name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _item.Description; }
            set
            {
                _item.Description = value;
                OnPropertyChanged();
            }
        }

        public string Category
        {
            get { return _item.Type; }
            set
            {
                _item.Type = value;
                OnPropertyChanged();
            }
        }

        public int Id
        {
            get { return _item.Id; }
            set
            {
                _item.Id = value;
                OnPropertyChanged();
            }
        }

        public string IdString
        {
            get { return $"ID: {_item.Id.ToString()}"; }
        }



        public double Price
        {
            get { return _item.Price; }
            set
            {
                _item.Price = value;
                OnPropertyChanged();
            }
        }
        
        public DateTime PurchasDate
        {
            get { return _item.PurchasDate; }
            set
            {
                _item.PurchasDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime GuaranteeDate
        {
            get { return _item.GuaranteeDate; }
            set
            {
                _item.GuaranteeDate = value;
                OnPropertyChanged();
            }
        }

        public string Damage
        {
            get { return _item.Damage; }
            set
            {
                _item.Damage = value;
                OnPropertyChanged();
            }
        }

        public bool IsReserved
        {
            get { return _item.IsReserved; }
            set
            {
                _item.IsReserved = value;
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
            if (loanRecordRepository.GetAll().Where(x => x.Item == _item.Id && x.IsReturned == false).Count() > 0)
            {
                System.Windows.MessageBox.Show("Item is nog niet teruggebracht");
            }
            else
            {
                DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Alle recorden van die item ook zullen verwijderen zijn. Verwijderen?", "Andacht!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    itemRepository = new ItemRepository();
                    var loanRecordToDelete = loanRecordRepository.GetAll().Where(x => x.Item == _item.Id).Select(x => x.Id).ToList();
                    foreach (var item in loanRecordToDelete)
                    {
                        loanRecordRepository.Delete(item);
                    }
                    itemRepository.Delete(_item.Id);
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
