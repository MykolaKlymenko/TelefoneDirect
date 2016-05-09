using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelefoneDictionary.Models.Enteties;

namespace TelefoneDictionary.Models
{
    public class RecordRepository:IRepository<Record>
    {
        public void Create(Record entety)
        {
            using (var telDictContext = new TelephoneDictionarryDataContext())
            {
                telDictContext.GetTable<Record>().InsertOnSubmit(entety);
                telDictContext.SubmitChanges();
            }
        }

        public List<ViewRecord> Read(int groupPK)
        {
            List<ViewRecord> viewRecords = null;
            using (var telDictContext = new TelephoneDictionarryDataContext())
            {
                var parentPK = (from g in telDictContext.UniversalGroups 
                                where g.groupPk == groupPK 
                                select g.parentPk).FirstOrDefault();

                var records  = (from r in telDictContext.Records
                           join i in telDictContext.infos
                           on r.RecordPK equals i.RecordFK into recInfo
                           join gr in telDictContext.GroupRecords
                           on r.RecordPK equals gr.RecordFK into groupRec
                           from rec in recInfo.DefaultIfEmpty()
                           from grrec in groupRec.DefaultIfEmpty()
                                where grrec.GroupPK == groupPK || grrec.GroupPK == parentPK
                           select r).ToList<Record>();
                viewRecords = records.ConvertAll(r=>Helper.ConvertFromRecordToVewRecord(r));
            }
            return viewRecords;
        }

        public List<Record> Read()
        {
            return null;
        }

        public void Update(Record entety)
        { 
        
        }

        public Record GetByPK(int key)
        {
            return null;
        }

        public void Delete(Record entety)
        { 
        
        }
    }
}