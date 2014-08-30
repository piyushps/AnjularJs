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
    }
}