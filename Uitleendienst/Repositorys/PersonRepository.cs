using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uitleendienst.Repositorys
{
    internal class PersonRepository
    {
        UitleendienstDb _db = new UitleendienstDb();

        public PersonRepository(UitleendienstDb db)
        {
            this._db = db;
        }

        public PersonRepository()
        {
            _ = _db.Persons.ToList();
        }

        public List<Person> GetAll()
        {
            return _db.Persons.ToList();
        }

        public Person GetById(int id)
        {
            return _db.Persons.Find(id);
        }

        public int Create(Person person)
        {
            _db.Persons.Add(person);
            _db.SaveChanges();
            return person.Id;
        }

        public void Update(Person person)
        {
            Delete(person.Id);
            Create(person);
        }

        public void Delete(int id)
        {
            Person person = _db.Persons.Find(id);
            _db.Persons.Remove(person);
            _db.SaveChanges();
        }
    }
}
