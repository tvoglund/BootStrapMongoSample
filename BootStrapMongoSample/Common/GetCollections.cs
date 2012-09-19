using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Models;

namespace Common
{
    public class GetCollections
    {
        public List<Exercise> GetAllExercises()
        {
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            
            var returnList = da.GetExerciseCollection();
            
            return returnList;
        }

        public List<PieResponse> GetAllExercisesForGraph(string graphType)
        {
            var returnData = new List<PieResponse>();

            DataAccess.DataAccess da = new DataAccess.DataAccess();

            var returnList = da.GetExerciseCollection();
            var totalCount = returnList.Count;
            var nalCount = returnList.Where(x => x.type == "n/a").ToList<Exercise>().Count;
            totalCount = totalCount - nalCount;

            //todo:  tv move this list to database
            List<string> mylist = new List<string>();
            mylist.Add("chest"); mylist.Add("back"); mylist.Add("tricep");
            mylist.Add("cardio"); mylist.Add("legs"); mylist.Add("bicep");
            mylist.Add("abs"); mylist.Add("Shoulders"); mylist.Add("n/a");

            var val = 0;
            foreach (var prop in mylist)
            {
                if (!prop.Equals("n/a"))
                {
                    val = returnList.Where(x => x.type == prop).ToList<Exercise>().Count;
                    var stringValue = (Convert.ToDecimal(val) / Convert.ToDecimal(totalCount))* 100;
                    returnData.Add(new PieResponse(prop, stringValue));
                }
            }

            return returnData;
        }

    }
}
