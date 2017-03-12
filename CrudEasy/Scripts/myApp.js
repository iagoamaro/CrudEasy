var myApp = angular.module('myApp', []);
myApp.controller('pessoaCtrl', function ($scope, $http) {

    $scope.Pessoa = "";
    $http.get("/pessoa/GetPessoa").then(function (result) {
        $scope.Pessoa = result;
        console.log(result);

    });

    $scope.salvar = function (pessoa) {

        $http.post("/pessoa/SalvarPessoa", { p: pessoa })
        .then(function (result) {

            $scope.Pessoa = result;
        })
        , function (result) {

            console.log(result);
        }
    }

    $scope.pessoa = "";
    $scope.editarPessoa = function (id) {

        $http.post("/pessoa/EditarPessoa", { id: id })
        .then(function (result) {
            $scope.pessoa = result.data;
            console.log(result.data);
        }),
        function (result) {

            console.log(result);
        }

    }

    
    $scope.atualizar = function (pessoa) {

        if (pessoa.PessoaId > 0) {


            $http.post("/pessoa/AtualizarPessoa", { p: pessoa })
            .then(function (result) {
                $scope.Pessoa = result;
            })
            , function (result) {
                console.log(result);

            }
        }
        else {
           
            alert("nao é possivel editar pessoa que nao seja cadastrada");
        }
    }

    $scope.deletarPessoa = function (PessoaId) {

        $http.post("/pessoa/DeletarPessoa", { id: PessoaId })
        .then(function (result) {

            $scope.Pessoa = result;
            
        })
        , function (result) {

            console.log(result);
        }

    }


});