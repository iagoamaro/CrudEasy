var myApp = angular.module('myApp', []);
myApp.controller('pessoaCtrl', function ($scope, $http) {

    
    $scope.desabilitaBtnsalvar = false;
    $scope.desabilitaBtnatualizar = true;
    $scope.Pessoas = {};
    $http.get("/pessoa/GetPessoa").then(function (result) {
        $scope.Pessoas = result;
        console.log(result);

    });

    $scope.salvar = function (pessoa) {

        $http.post("/pessoa/SalvarPessoa", { p: pessoa })
        .then(function (result) {
            
            $scope.Pessoas = result;
            delete $scope.pessoa;
        })
        , function (result) {

            console.log(result);
        }
    }

    $scope.pessoa = {};
    $scope.editarPessoa = function (id) {

        $http.post("/pessoa/EditarPessoa", { id: id })
        .then(function (result) {
            
            $scope.pessoa = result.data;
            $scope.desbilitaBtnsalvar= true;
            $scope.desabilitaBtnatualizar = false;
            console.log(result.data);
        }),
        function (result) {

            console.log(result);
        }

    }

    
    $scope.atualizar = function (pessoa) {

            $http.post("/pessoa/AtualizarPessoa", { p: pessoa })
            .then(function (result) {
                $scope.desabilitaBtnatualizar = true;
                $scope.desbilitaBtnsalvar = false;
                $scope.Pessoas = result;
                delete $scope.pessoa;
            })
            , function (result) {
                console.log(result);

            }
        
        
    }

    $scope.deletarPessoa = function (PessoaId) {

        $http.post("/pessoa/DeletarPessoa", { id: PessoaId })
        .then(function (result) {

            $scope.Pessoas = result;
            delete $scope.pessoa;
            
        })
        , function (result) {

            console.log(result);
        }

    }


});