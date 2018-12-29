using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParkingPalServ.Models
{
    public class DataRepository
    {
        private DataDataContext db = new DataDataContext();

        public IQueryable<data> GetAllDatas()
        {
            return db.datas;
        }
        public data GetData(int id)
        {
            return db.datas.SingleOrDefault(d => d.DataID == id);
        }

        public void Add(data data)
        {
            db.datas.InsertOnSubmit(data);
        }
        public void Delete(data data)
        {
            db.datas.DeleteOnSubmit(data);
        }
        public void Update(data data)
        {
            data d = GetData(1);
            d.Total = data.Total;
            d.Open = data.Open;
            d.OpenH = data.OpenH;
            d.Occupied = data.Occupied;
            d.OccupiedH = data.OccupiedH;
            d.RecordedDate = data.RecordedDate;
        }

        public void Save()
        {
            db.SubmitChanges();
        }
    }
}