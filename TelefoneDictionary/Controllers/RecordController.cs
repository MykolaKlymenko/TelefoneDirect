using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefoneDictionary.Models;
using Record = TelefoneDictionary.Models.Record;
using Group = TelefoneDictionary.Models.Enteties.Group;

namespace TelefoneDictionary.Controllers
{
    public class RecordController : Controller
    {
        private IRepository<Record> recordRepository = new RecordRepository();

        private IRepository<Group> groupRepository = new GroupRepository();

        private ILogger logger = new Logger();

        // GET: Record
        public ActionResult RecordList(int? groupPK)
        {
            var groupsList = groupRepository.Read();
            ViewBag.GroupPK = groupPK;
            ViewBag.GroupList = Helper.FillSelectionListGroup(groupsList);
            ViewBag.Records = ((RecordRepository)recordRepository).Read(groupPK.Value);
            ViewBag.IsAdmin = false;
            return View();
        }

        [HttpGet]
        public Record GetRecord(int RecordPK)
        { 
            var currentRecord = recordRepository.Read();
            return currentRecord.FirstOrDefault();
        }

        public void AddRecord(Record record)
        {
            recordRepository.Create(record);
            Response.Redirect("GroupList");
        }
    }
}