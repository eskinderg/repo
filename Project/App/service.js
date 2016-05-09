﻿
project.service("projectService", function ($http, $q) {
        
        return ({
            addContent: addContent,
            getContent: getContent,
            getAllExpense: getAllExpense,
            getAllCategories: getAllCategories,
            getAllContents: getAllContents,
            getAllFolders: getAllFolders
        });


        function addContent(content) {
            var request = $http({
                method: "POST",
                url: "/api/content/add",
                data:
                    {
                        Title: content.Title,
                        XmlConfigId: content.XmlConfigId,
                        FolderId:content.FolderId,
                        Summary: content.Summary
                    }
            });
            return (request.then(handleSuccess, handleError));
        }


        function getContent(id) {
            var request = $http({
                method: "GET",
                url: "/api/content/" + id
            });
            return (request.then(handleSuccess, handleError));
        }


        function getAllExpense() {
            var request = $http({
                method: "GET",
                url: "/api/expenses"
            });
            return (request.then(handleSuccess, handleError));
        }

        function getAllCategories() {
            var request = $http({
                method: "GET",
                url: "/api/getallcategories"
            });
            return (request.then(handleSuccess, handleError));
        }

        function getAllContents() {
            var request = $http({
                method: "GET",
                url: "/api/contents"
            });
            return (request.then(handleSuccess, handleError));
        }

        function getAllFolders() {
            var request = $http({
                method: "GET",
                url: "/api/folders"
            });
            return (request.then(handleSuccess, handleError));
        }
        

        function handleError(response) {

            if (
                !angular.isObject(response.data) ||
                !response.data.message
                ) {
                return ($q.reject("error occurred."));
            }
            
            return ($q.reject(response.data.message));
        }

        function handleSuccess(response) {
            return (response.data);
        }
    }
);
