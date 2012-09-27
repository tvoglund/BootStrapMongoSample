
/**************************
* Application
**************************/
//application with namespace of Workout
var Workout = Em.Application.create({
    organizer: 'Andy',
    totalReviews: 0,
    ready: function () {
        //alert('Ember sucks');
    }
});

/**************************
* Models
**************************/

Workout.Exercise = Em.Object.extend({
    date: null,
    name: null,
    setNumber: 0,
    weight: null,
    repetitions: 0,
    type: null
});

/**************************
* Views
**************************/

/**************************
* Controllers
**************************/

Workout.workoutController = Em.ArrayController.create({
    content: [],
    init: function () {
        $.ajax({
            type: 'GET',
            url: "http://localhost/Personal/Services/Records.svc/Exercises",
            success: function (result) {
                processThis(result);
            },
            error: function (err) {
                alert(err);
            }
        }); 
    }
});




function processThis(results) {
    Workout.workoutController.set('content', results);
}