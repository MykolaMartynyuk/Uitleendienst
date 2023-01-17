using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uitleendienst.ObjectClass;

namespace Uitleendienst
{
    public class Item : IObject
    {

        //parameters
        //private string _name;
        //private int _quantity;
        //private double _price;
        //private int _id;
        //private string _type;
        //private string _description;
        //private DateTime _purchasDate;
        //private TimeSpan _guaranteeDate;
        //private string _damage;
        //private bool _isReserved;


        //constructor
        //public Item(string name, int quantity, double price, int id, string type, string description, DateTime purchasDate, TimeSpan guaranteeDate)
        //{
        //    _name = name;
        //    _quantity = quantity;
        //    _price = price;
        //    _id = id;
        //    _type = type;
        //    _description = description;
        //    _purchasDate = purchasDate;
        //    _guaranteeDate = guaranteeDate;
        //}

        public Item(string name, double price, int id, string type, string description, DateTime purchasDate, DateTime guaranteeDate , bool reserv)
        {
            Name = name;
            Price = price;
            Id = id;
            Type = type;
            Description= description;
            PurchasDate= purchasDate;
            GuaranteeDate = guaranteeDate;
            IsReserved = reserv;
        }
        public Item(string name, double price, int id, string type, string description, string damage, DateTime purchasDate, DateTime guaranteeDate, bool reserv)
        {
            Name = name;
            Price = price;
            Id = id;
            Type = type;
            Description = description;
            PurchasDate = purchasDate;
            GuaranteeDate = guaranteeDate;
            IsReserved = reserv;
            Damage = damage;
        }

        public Item()
        {

        }

        //properties
        //public string Name
        //{
        //    get { return _name; }
        //    set { _name = value; }
        //}
        //public int Quantity
        //{
        //    get { return _quantity; }
        //    set { _quantity = value; }
        //}
        //public double Price
        //{
        //    get { return _price; }
        //    set { _price = value; }
        //}

        //[Key]
        //[Index(IsUnique = true)]
        //public int Id
        //{
        //    get { return _id; }
        //    set { _id = value; }
        //}
        //public string Type
        //{
        //    get { return _type; }
        //    set { _type = value; }
        //}
        //public string Description
        //{
        //    get { return _description; }
        //    set { _description = value; }
        //}
        //public DateTime PurchasDate
        //{
        //    get { return _purchasDate; }
        //    set { _purchasDate = value; }
        //}
        //public TimeSpan GuaranteeDate
        //{
        //    get { return _guaranteeDate; }
        //    set { _guaranteeDate = value; }
        //}
        //public string Damage
        //{
        //    get { return _damage; }
        //    set { _damage = value; }
        //}
        //public bool IsReserved
        //{
        //    get { return _isReserved; }
        //    set { _isReserved = value; }
        //}
        [StringLength(450)]
        public string Name { get; set; }
        public double Price { get; set; }

        [Key]
        [Index(IsUnique = true)]
        public int Id { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public DateTime PurchasDate { get; set; }
        public DateTime GuaranteeDate { get; set; }
        public string Damage { get; set; }
        public bool IsReserved { get; set; }

        public string AsString { get { return ToString(); } }

        public override string ToString()
        {
            return $"ID: {Id}, Naam: {Name}";
        }
    }
}
