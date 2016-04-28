
//Parent Controller
project.controller('FormSubmitController', function ($scope,expenseService) {

    $scope.categories = [];

    expenseService.getAllCategories().then(function (result) {
        $scope.categories = result;
    });

    $scope.formSubmit = function (expense) {

        expenseService.addExpense(expense).then($scope.$broadcast('submitted', expense));
        
        $scope.expense = [];        //clear Form After Submission

        $scope.expenseform.$setPristine();

    }
});


//Child Controller
project.controller('ExpenseGridController', function ($scope, expenseService ) {

    $scope.expenses = [];
    

    expenseService.getAllExpense().then(function (result) {
        
        $scope.expenses = result;
        
    });


    $scope.gridOptions = {
        data: 'expenses',
        multiSelect: false,
        selectedItems: $scope.mySelections,
        enableCellEdit: true,
        enableColumnResize: true,
        showFooter: true,

            columnDefs:
            [
                
                { field: 'Date', displayName: 'Date'},
                { field: 'Description', displayName: 'Description'},
                { field: 'Category.Name', displayName: 'Category' },
                { field: 'Category.SubCategory.Name', displayName: 'SubCategory'},
                { field: 'Amount', displayName: 'Amount' }
                
            ]
    }


    $scope.$on('submitted', function (event, expense)
    {
        $scope.row = angular.copy(expense);
        $scope.expenses.push($scope.row); //Updating the grid view
        $scope.expense = [];
    });
    
});



