using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using TelefoneDictionary.Models.Enteties;

namespace TelefoneDictionary.Models
{
    public class GroupRepository:IRepository<Group>
    {
        private SqlConnection connection = new SqlConnection(
            WebConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        
        public void Create(Group entety)
        {
            using (var telDictContext = new TelephoneDictionarryDataContext())
            {
                var test = Helper.ConvertFromGroupToUGroup(entety);
                telDictContext.GetTable<UniversalGroup>().InsertOnSubmit(test);
                telDictContext.SubmitChanges();
            }
        }

        public List<Group> Read()
        {
            SqlDataReader rdr = null;
            List<Group> grpTree = new List<Group>();

            SqlCommand cmd = new SqlCommand("select * from universalGroup",connection);
            try
            {
                connection.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    var tmpGroup = new Group()
                    {
                        name = (string) rdr["name"],
                        GroupPK = (int)rdr["groupPk"],
                        LeaderFK = rdr.IsDBNull(3) ? 0 : (int)rdr["LeaderFK"],
                        ParentPk = rdr.IsDBNull(2) ? 0:(int)rdr["parentPk"],
                        Photo = rdr.IsDBNull(4) ? string.Empty:(string)rdr["photo"],
                        children = new List<Group>()
                    };
                    grpTree.Add(tmpGroup);
                }
            }
            catch (SqlException)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            Helper.CreateTree(grpTree);
            return grpTree;
        }

        public void Update(Group entety)
        {
        
        }

        public void Delete(Group entety)
        {
        
        }

        public Group GetByPK(int key)
        {
            return null;
        }
    }
}