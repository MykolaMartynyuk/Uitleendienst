using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Uitleendienst.Repositorys
{
    public interface IItemRepository
    {
        List<Item> GetAll();
        Item GetById(int id);
        void Create(Item item);
        void Update(int i, Item item);
        void Delete(int id);
    }
    internal class ItemRepository : IItemRepository
    {
        UitleendienstDb _db = new UitleendienstDb();
        public ItemRepository(UitleendienstDb _db)
        {
            this._db = _db;
        }
        public ItemRepository()
        {
            _ = _db.Items.ToList();
        }
        public List<Item> GetAll()
        {
            return _db.Items.ToList();
        }
        
        public Item GetById(int id)
        {
            return _db.Items.First(i => i.Id == id);
        }

        public void Create(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
        }

        public void Update(int i, Item item) // _db.Items.Update(item); lukt niet en _db.Entry(item).State = EntityState.Modified; ook lukt niet 
        {
            Delete(i);
            Create(item);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            Item item = _db.Items.First(i => i.Id == id);
            _db.Items.Remove(item);
            _db.SaveChanges();
        }
    }
}
