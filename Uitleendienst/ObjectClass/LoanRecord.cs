using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uitleendienst.ObjectClass;
using Uitleendienst.Repositorys;

namespace Uitleendienst
{
    public class LoanRecord : IObject
    {
        //parameters
        private int _item;
        //private DateTime _dateLoan;
        //private DateTime _dateReturn;
        //private bool _isReturned;
        //private int _id;
        private int _person;

        //constructor
        public LoanRecord(int itemId,  DateTime dateReturn, int id, int personId)
        {
            ItemRepository itemrepository = new ItemRepository();
            Item = itemId;
            DateLoan = DateTime.Now;
            DateReturn = dateReturn;
            Person = personId;
        }

        public LoanRecord()
        {
            
        }
        
        //properties
        public int Item
        {
            get { return _item; }
            set { _item = value; }
        }
        public DateTime DateLoan { get; set; }
        public DateTime DateReturn { get; set; }
        public bool IsReturned { get; set; }

        [Key]
        [Index(IsUnique = true)]
        public int Id { get; set; }
        public int Person
        {
            get { return _person; }
            set { _person = value; }
        }

        public string AsString { get { return ToString(); } }

        public override string ToString()
        {
            return $"Id: {Id}, Uitleening datum: {DateLoan.ToString("MM / dd / yyyy")} Verwacht terug: {DateReturn.ToString("MM / dd / yyyy")} Ontvangen:  {IsReturned}";
        }
    }
}
