
//Parent Controller
project.controller('FormSubmitController', function ($scope,projectService) {

    $scope.folders = [];

    projectService.getAllFolders().then(function (result) {
        $scope.folders = result;
    });

    $scope.formSubmit = function (content) {
        //alert('sssss');
        projectService.addContent(content).then($scope.$broadcast('submitted', content));
        
        $scope.content = [];        //clear Form After Submission

        $scope.contentform.$setPristine();

    }
});


//Child Controller
project.controller('ExpenseGridController', function ($scope, projectService ) {

    $scope.contents = [];
    

    projectService.getAllContents().then(function (result) {
        
        $scope.contents = result;
        
    });


    $scope.gridOptions = {
        data: 'contents',
        multiSelect: false,
        selectedItems: $scope.mySelections,
        enableCellEdit: true,
        enableColumnResize: true,
        showFooter: true,

            columnDefs:
            [

                { field: 'Id', displayName: 'Content ID'},
                { field: 'Title', displayName: 'Title'},
                { field: 'XmlConfigId', displayName: 'XmlConfigId' },
                { field: 'Summary', displayName: 'Summary' },
                { field: 'Folder.Name', displayName: 'Folder' }
                
            ]
    }


    $scope.$on('submitted', function (event, content)
    {
        $scope.row = angular.copy(content);
        $scope.contents.push($scope.row); //Updating the grid view
        $scope.content = [];
    });
    
});



