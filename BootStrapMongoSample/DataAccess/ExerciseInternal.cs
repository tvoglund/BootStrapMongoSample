using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using System.Runtime.Serialization;
using System.Globalization;

namespace DataAccess
{

    public class ExerciseInternal
    {
        public ObjectId Id { get; set; }
        
        public string name { get; set; }
        public string date { get; set; }
        public string dateString { get; set; }     
        public int set { get; set; }
        public string weight { get; set; }
        public int repetitions { get; set; }
        public string type { get; set; }


        public static string CreateJsonDateString(DateTime? dt)
        {
            string dateString = "";
            if (dt != null)
            {
                DateTime d = (DateTime)dt;
                dateString = d.ToString("MMM dd yyyy hh:mm:ss", CultureInfo.InvariantCulture) + string.Format(" GMT{0:zz}00", dt);
            }
            return dateString;
        }
    }
}
