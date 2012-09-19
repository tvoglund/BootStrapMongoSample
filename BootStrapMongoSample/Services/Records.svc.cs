using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Models;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Records" in code, svc and config file together.
    public class Records : IRecords
    {
        public FlexigridObject DoWork()
        {
            FlexigridObject fo = new FlexigridObject();

            Common.GetCollections gc = new Common.GetCollections();
            var exercises = gc.GetAllExercises();
            fo.page = "1";
            fo.total = exercises.Count().ToString();
            fo.rows = new List<Exercise>();
            fo.rows = exercises;

            return fo;
        }

        public List<Exercise> GetAllExercises()
        {
            Common.GetCollections gc = new Common.GetCollections();
            return gc.GetAllExercises();
        }

        public FlexigridObject GetRecords(string filter)
        {
            FlexigridObject fo = new FlexigridObject();

            Common.GetCollections gc = new Common.GetCollections();
            var exercises = gc.GetAllExercises();
            fo.page = "1";
            fo.total = exercises.Count().ToString();
            fo.rows = new List<Exercise>();
            fo.rows = exercises;

            return fo;
        }

        public List<PieResponse> GetRecordsForGraph(string graphType)
        {
            Common.GetCollections gc = new Common.GetCollections();
            
            return gc.GetAllExercisesForGraph(graphType);
        }
    }
}
