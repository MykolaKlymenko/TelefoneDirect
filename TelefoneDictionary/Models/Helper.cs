using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelefoneDictionary.Models.Enteties;

namespace TelefoneDictionary.Models
{
    public static class Helper
    {
        #region Constant 

        private const string DELIMITATOR = ",";

        #endregion

        #region TreeParser

        public static void CreateTree(List<Group> grp)
        {
            foreach (var node in grp)
            {
                if (node.ParentPk != 0)
                {
                    grp.Find(g => Convert.ToInt32(g.GroupPK) == node.ParentPk).children.Add(node);
                }
            }
        }

        #endregion

        #region GroupParser

        public static Group ConvertFromUGroupToGroup(UniversalGroup ugr)
        {
            return new Group()
            {
                GroupPK = ugr.groupPk,
                ParentPk = ugr.parentPk
            };
        }

        public static UniversalGroup ConvertFromGroupToUGroup(Group grp)
        {
            return new UniversalGroup()
            {
                parentPk = grp.ParentPk,
                name = grp.name
            };
        }

        #endregion

        #region SelectListParser
        
        public static List<SelectListItem> FillSelectionListGroup(List<Group> grps)
        {
            var selList = new List<SelectListItem>();
            foreach (var grp in grps)
            {
                selList.Add(new SelectListItem()
                {
                    Value = grp.GroupPK+"",
                    Text = grp.name
                });
            }
            return selList;
        }

        #endregion

        #region RecordParser

        public static ViewRecord ConvertFromRecordToVewRecord(Record rec)
        {
            string phone = "";
            string email = "";
            foreach (var tel in rec.infos)
            {
                phone+=tel.Phone+DELIMITATOR;
            }
            
            foreach (var tel in rec.infos)
            {
                email+=tel.EMail+DELIMITATOR;
            }

            return new ViewRecord()
            {
                Name = rec.Name,
                Phone = phone,
                EMail = email,
                Photo = rec.Photo,
                Position = rec.Position
            };
        }
        
        #endregion
    }
}