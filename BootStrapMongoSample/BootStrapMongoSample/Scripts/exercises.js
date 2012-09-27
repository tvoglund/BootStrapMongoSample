function loadExercisesTable() 
{

    var workUrl = 'http://localhost/Personal/Services/Records.svc/Exercises/Flexigrid/filter1';
    var homeUrl = '';

    $("#flexigrid").flexigrid({
        url: workUrl,
        method: 'GET',
        dataType: 'json',
        colModel: [
                        { display: 'Date', name: 'date', width: 180, sortable: true, align: 'left' },
		                { display: 'Name', name: 'name', width: 140, sortable: true, align: 'center' },
                        { display: 'Set', name: 'setNumber', width: 60, sortable: true, align: 'center' },
                        { display: 'Weight', name: 'weight', width: 60, sortable: true, align: 'center' },
		                { display: 'Reps', name: 'repetitions', width: 60, sortable: true, align: 'center' },
                        { display: 'Muscle Group', name: 'type', width: 60, sortable: true, align: 'center' },
                        { display: 'Id', name: 'Id', width: 60, sortable: true, align: 'center', hide: true }
		                ],
        //	                buttons : [
        //		                {name: 'Add', bclass: 'add', onpress : test},
        //		                {name: 'Delete', bclass: 'delete', onpress : test},
        //		                {separator: true}
        //		                ],
        searchitems: [
		                { display: 'Name', name: 'name' },
		                { display: 'Date', name: 'date', isdefault: true }
		                ],
        sortname: "iso",
        sortorder: "asc",
        usepager: true,
        title: 'Workout Results',
        useRp: true,
        rp: 15,
        showTableToggleBtn: true,
        width: 700,
        height: 200
    });

}

function createExercise(exercise) 
{
    var input =
        {
            "exercise":
            {
                "name": exercise.name,
                "set": exercise.setNum
            }
        };

    input = JSON.stringify(exercise);

    //This works!!!
    //        input = JSON.stringify({
    //            "name": exercise.name,
    //            "set": exercise.setNum
    //        });

    $.ajax({
        type: 'POST',
        url: "http://localhost/Personal/Services/Records.svc/Exercise",
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        data: input,
        success: function (result) {
            alert('success');
            //processThis(result);
        },
        error: function (err) {
            alert(err);
        }
    });
}

function udpateExercise(exercise) {
    
        input = JSON.stringify(exercise);

    $.ajax({
            type: 'PUT',
            url: "http://localhost/Personal/Services/Records.svc/Exercise",
            dataType: 'json',
            contentType: "application/json; charset=utf-8",
            data: input,
            success: function (result) {
                alert('success');
                //processThis(result);
            },
            error: function (err) {
                alert(err);
            }
        });
    }

    function deleteExercise(id) {

        //input = JSON.stringify(exercise);

        $.ajax({
            type: 'DELETE',
            url: "http://localhost/Personal/Services/Records.svc/Exercise/" + id,
            success: function (result) {
                alert('success');
                //processThis(result);
            },
            error: function (err) {
                alert(err);
            }
        });
    }