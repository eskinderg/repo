﻿
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

