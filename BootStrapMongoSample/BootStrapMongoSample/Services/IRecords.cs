using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Web;
using Models;
using Common;

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
        [WebGet(UriTemplate = "Exercises/Flexigrid?page={page}&rp={rp}&sortname={sortname}&sortorder={sortorder}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        FlexigridObject GetRecords(string page, string rp, string sortname, string sortorder);

        [OperationContract]
        [WebGet(UriTemplate = "/Exercises", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Exercise> GetAllExercises();

        [OperationContract]
        [WebGet(UriTemplate = "/Exercises/ForGraph/{graphType}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<PieResponse> GetRecordsForGraph(string graphType);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Exercise", Method = "POST", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        CreateResponse CreateExercise(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Exercise", Method = "PUT", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        UpdateResponse UpdateExercise(Exercise exercise);

        [OperationContract]
        [WebInvoke(UriTemplate = "/Exercise/{id}", Method = "DELETE", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        DeleteResponse DeleteExercise(string id);
    }
}
