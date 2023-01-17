using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uitleendienst.Repositorys
{
    internal class LoanRecordRepository
    {
        readonly UitleendienstDb _db = new UitleendienstDb();

        public LoanRecordRepository(UitleendienstDb db)
        {
            this._db = db;
        }
        
        public LoanRecordRepository()
        {
            _ = _db.LoanRecords.ToList();
        }

        public void Create(LoanRecord loanRecord)
        {
            _db.LoanRecords.Add(loanRecord);
            _db.SaveChanges();
        }

        public void Update(LoanRecord loanRecord)
        {
            Delete(loanRecord.Id);
            Create(loanRecord);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            LoanRecord loanRecord = GetById(id);
            _db.LoanRecords.Remove(loanRecord);
            _db.SaveChanges();
        }

        public LoanRecord GetById(int id)
        {
            return _db.LoanRecords.Find(id);
        }

        public List<LoanRecord> GetAll()
        {
            return _db.LoanRecords.ToList();
        }
    }
}
