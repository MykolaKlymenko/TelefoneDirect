using System;
using System.Collections.Generic;
using System.Web.Mvc;
using TelefoneDictionary.Models;
using Group = TelefoneDictionary.Models.Enteties.Group;

namespace TelefoneDictionary.Controllers
{
    public class GroupController : Controller
    {
        private IRepository<Group> groupRepository = new GroupRepository();
        // GET: Group
        public ActionResult GroupList()
        {
            var groupsList = groupRepository.Read();
            ViewBag.GroupList= Helper.FillSelectionListGroup(groupsList);
            ViewBag.Groups = groupsList;
            ViewBag.IsAdmin = false;
            return View("TreeView");
        }

        public void AddGroup(Group grp)
        {
            groupRepository.Create(grp);
            Response.Redirect("GroupList");
        }

        public ActionResult Slider(int groupPK)
        {
            ViewBag.IsAdmin = false;
            var groupsList = groupRepository.Read();
            var selectedGroups = groupsList.FindAll(g=>g.ParentPk == groupPK ||g.GroupPK == groupPK);
            ViewBag.Groups = selectedGroups;
            return View("SliderView");
        }
    }
}