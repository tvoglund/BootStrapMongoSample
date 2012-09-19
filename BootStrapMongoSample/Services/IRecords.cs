using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using Models;

namespace Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IRecords" in both code and config file together.
    [ServiceContract]
    public interface IRecords
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Exercises/Flexigrid", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        FlexigridObject DoWork();

        [OperationContract]
        [WebGet(UriTemplate = "Exercises/Flexigrid/{filter}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        FlexigridObject GetRecords(string filter);

        [OperationContract]
        [WebGet(UriTemplate = "/Exercises", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Exercise> GetAllExercises();


        [OperationContract]
        [WebGet(UriTemplate = "/Exercises/ForGraph/{graphType}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<PieResponse> GetRecordsForGraph(string graphType);
    }
}
