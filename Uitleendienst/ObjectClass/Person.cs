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
    public class Person : IObject
    {
        //parameters
        private string _firstName;
        private string _lastName;
        private string _email;
        private int _iD;
        UitleendienstDb uitleendienstDb = new UitleendienstDb();
        
        //constructor
        public Person(string firstName, string lastName, string email)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
        }

        public Person()
        {
            
        }

        //properties
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        [Key]
        [Index(IsUnique = true)]
        public int Id
        {
            get { return _iD; }
            set { _iD = value; }
        }

        public string AsString { get { return ToString(); } }

        public override string ToString()
        {
            return $"{_firstName} {_lastName}";
        }

    }
}
