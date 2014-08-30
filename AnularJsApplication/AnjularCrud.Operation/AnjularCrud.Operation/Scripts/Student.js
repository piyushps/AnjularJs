//var app = angular.module('app', []);
//app.controller('studentController', ['$scope', '$http', function ($scope, $http) {
//    $scope.loading = true;
//    $scope.addMode = false;

//    $http.get('/api/Student/').success(function (data) {
//        $scope.students = data;
//        $scope.loading = false;
//    })
//    .error(function () {
//        $scope.error("Error occured while loading data.");
//        $scope.loading = false;
//    });

//    $scope.toggleEdit = function () {
//        this.student.editMode = !this.student.editMode;
//    };
//    $scope.toggleAdd = function () {
//        $scope.addMode = !$scope.addMode;
//    }
//}]);

function studentController($scope, $http) {
    $scope.loading = true;
    $scope.addMode = false;

    $http.get('/api/Student/').success(function (data) {
        $scope.students = data;
        $scope.loading = false;
    })
    .error(function () {
        $scope.error("Error occured while loading data.");
        $scope.loading = false;
    });

    $scope.toggleEdit = function () {
        this.student.editMode = !this.student.editMode;
    };
    $scope.toggleAdd = function () {
        $scope.addMode = !$scope.addMode;
    };

    //Used to save a record after edit
    $scope.save = function () {
        alert("Edit");
        $scope.loading = true;
        var stu = this.student;
        alert(student);
        $http.put('/api/Student/', stu).success(function (data) {
            alert("Saved Successfully!!");
            student.editMode = false;
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Student! " + data;
            $scope.loading = false;

        });
    };

    //Used to add a new record
    $scope.add = function () {
        $scope.loading = true;
        $http.post('/api/Student/', this.newstudent).success(function (data) {
            alert("Added Successfully!!");
            $scope.addMode = false;
            $scope.student.push(data);
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Adding Student! " + data;
            $scope.loading = false;

        });
    };

    //Used to edit a record
    $scope.deletestudent = function () {
        $scope.loading = true;
        var studentid = this.student.Id;
        $http.delete('/api/Student/' + studentid).success(function (data) {
            alert("Deleted Successfully!!");
            $.each($scope.students, function (i) {
                if ($scope.students[i].Id === studentid) {
                    $scope.students.splice(i, 1);
                    return false;
                }
            });
            $scope.loading = false;
        }).error(function (data) {
            $scope.error = "An Error has occured while Saving Student! " + data;
            $scope.loading = false;

        });
    };
}
