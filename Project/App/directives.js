
project.directive("currency", function () {
    return {
        restrict: "A",
        require: "ngModel",

        link: function (scope, element, attributes, ngModel) {
                ngModel.$validators.currency = function (modelValue) {
                    var currencyExp = /^\s*(\-|\+)?(\d+|(\d*(\.\d*)))\s*$/;
                    return (currencyExp.test(modelValue));
                }
        }
    };
});


project.directive("integer", function () {
    return {
        restrict: "A",
        require: "ngModel",

        link: function (scope, element, attributes, ngModel) {
                ngModel.$validators.integer = function (modelValue) {
                    var integerExp = /^[0-9]*$/gm;
                    return (integerExp.test(modelValue));
                }
        }
    };
});

