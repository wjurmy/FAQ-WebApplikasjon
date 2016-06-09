

var FaqController = function ($scope, $http, $location) {

    $scope.models = {
        helloController: "Jeg er 'faq' kontroller",
        email: "",
        category: { name: "" },
        question: "",
        name: "",
    };

    $scope.IsLoading = false;
    $scope.FilterCriteria = "";
    $scope.oneAtATime = true;
    $scope.isOpen = false;

    //Teller funksjon
    var lastOpenedFaqId = -1;
    $scope.opened = function (group, i) {
       
        if (lastOpenedFaqId != i) {
            lastOpenedFaqId = i;

            $http.post(
                    '/api/faq/FaqViewCountAdd', {
                        SubmittedQuestionId: group.SubmittedQuestionId
                    }).success(function (data) {
                    }).error(function () { alert("Erorr"); });
        } else {
            // it means we closed this item
            lastOpenedFaqId = -1;
        }
    };
    /////////////////////////////

    // Hent alle faq
    if ($location.$$path == '/faq') {
        $scope.IsLoading = true;

        // Hent alle faq
        $scope.faqItems = [];
        $http.get('/api/faq/GetAllSubmittedQuestions')
            .then(function (result) {
                $scope.subquestions = result.data;
                $scope.IsLoading = false;
            });
    };

    // hent alle kategorier
    $scope.categories = [];
    $http.get('/api/faq/GetAllCategories')
        .then(function (result) {
            $scope.categories = result.data;
        });

    // hent alle innsendte spørsmåler
    $scope.subquestions = [];
    $http.get('/api/faq/GetAllSubmittedQuestions')
        .then(function (result) {
            $scope.subquestions = result.data;
        });

    $scope.addQuestion = function () {
        $http.post(
                '/api/faq/SubmitFaq', {
                    UserEmail: $scope.models.email,
                    Name: $scope.models.name,
                    category: $scope.models.category,
                    QuestionText: $scope.models.question
                }
            ).
            success(function (data) {
                if (data) {
                    alert('Spørsmålet er registrert.');
                    $location.path('/faq');
                    return;
                }
                alert("Erorr");
            }).
            error(function () {
                alert("Erorr");
            });
    };

    //// Send svar
    $scope.subQuestion = {};
    $scope.submitAnswer = function () {
        $http.post(
                '/api/faq/SubmitAnswer', {
                    SubmittedQuestionId: $scope.subQuestion.SubmittedQuestionId,
                    Answer: $scope.subQuestion.Answer
                }
            ).
            success(function (data) {
                if (data) {
                    alert('Svaret er registrert.');
                    $location.path('/faq');
                    return;
                }
                alert("Erorr");
            }).
            error(function () {
                alert("Erorr");
            });
    };

    /// velg fag fra kategori
    $scope.selectByCategory = function (category) {
        var categoryFilter = category;
        var showAll = 0 === categoryFilter.length;
        angular.forEach($scope.subquestions, function (faqItem) {
            if (showAll) {
                faqItem.excludedByFilter = false;
            } else {
                faqItem.excludedByFilter = (faqItem.Category.Name.indexOf(categoryFilter) === -1);
            }
        });
    };

    /// søk med text i spørsmål og svar
    $scope.searchByText = function (searchText) {
        var showAll = 0 === searchText.length;
        angular.forEach($scope.subquestions, function (faqItem) {
            if (showAll) {
                faqItem.excludedByFilter = false;
            } else {
                var findInQText = faqItem.QuestionText.indexOf(searchText);
                var findInAnswer = faqItem.Answer == null ? -1 : faqItem.Answer.indexOf(searchText);
                faqItem.excludedByFilter = findInQText == -1 && findInAnswer == -1;
            }
        });
    }

    ///// regex validators
    $scope.emailPattern =/^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,4}$/;

}

FaqController.$inject = ['$scope', '$http', '$location'];