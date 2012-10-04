using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class Collections
    {

        public CreateResponse CreateExercise(Models.Exercise exercise)
        {
            var resp = new CreateResponse();

            //set datetime
            exercise.date = DateTime.Now.ToString("s").Replace('T', ' ') + "UTC";
            DataAccess.DataAccess da = new DataAccess.DataAccess();
            da.CreateExerciseCollection(exercise);

            return resp;
        }
    }
}
