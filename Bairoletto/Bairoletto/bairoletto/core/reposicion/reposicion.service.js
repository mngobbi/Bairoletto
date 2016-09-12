(function () {
    'use strict';

    angular
        .module('app.core')
        .factory('reposicionService', reposicionService);

    function reposicionService($http, $q) {
        var service = {
            get: getReposiciones,
            getById: getReposicion,
            nuevas: getNuevas,
            aprobadas: getAprobadas,
            canceladas: getCanceladas,
            entransito: getEntransito,
            entregadas: getEntregadas,
            crear: crearReposicion,
            aprobar: aprobarOrden,
            cancelar: cancelarOrden,
            enviar: enviarOrden,
            recepcion: recibirOrden
        };

        return service;

        function getReposiciones(pv_id) {
            if (typeof pv_id !== 'undefined')
                return $http.get('/api/reposiciones?punto_venta_id=' + pv_id).then(dataSuccess).catch(dataError);
            return $http.get('/api/reposiciones').then(dataSuccess).catch(dataError);
        }
        function getReposicion(rep_id) {
            return $http.get('/api/reposiciones/' + rep_id).then(dataSuccess).catch(dataError);
        }
        function getNuevas(pv_id) {
            if (typeof pv_id !== 'undefined')
                return $http.get('/api/reposiciones/nuevas?punto_venta_id=' + pv_id).then(dataSuccess).catch(dataError);
            return $http.get('/api/reposiciones/nuevas').then(dataSuccess).catch(dataError);
        }
        function getAprobadas(pv_id) {
            if (typeof pv_id !== 'undefined')
                return $http.get('/api/reposiciones/aprobadas?punto_venta_id=' + pv_id).then(dataSuccess).catch(dataError);
            return $http.get('/api/reposiciones/aprobadas').then(dataSuccess).catch(dataError);
        }
        function getCanceladas(pv_id) {
            if (typeof pv_id !== 'undefined')
                return $http.get('/api/reposiciones/canceladas?punto_venta_id=' + pv_id).then(dataSuccess).catch(dataError);
            return $http.get('/api/reposiciones/canceladas').then(dataSuccess).catch(dataError);
        }
        function getEntransito(pv_id) {
            if (typeof pv_id !== 'undefined')
                return $http.get('/api/reposiciones/entransito?punto_venta_id=' + pv_id).then(dataSuccess).catch(dataError);
            return $http.get('/api/reposiciones/entransito').then(dataSuccess).catch(dataError);
        }
        function getEntregadas(pv_id) {
            if (typeof pv_id !== 'undefined')
                return $http.get('/api/reposiciones/entregadas?punto_venta_id=' + pv_id).then(dataSuccess).catch(dataError);
            return $http.get('/api/reposiciones/entregadas').then(dataSuccess).catch(dataError);
        }

        function crearReposicion(pv_id, fecha_deseada, productos, comentario) {
            var obj = {
                planta_elaboracion_id: 1,
                punto_venta_id: pv_id,
                fecha_entrega_deseada: fecha_deseada,
                comentario: comentario,
                productos: productos
            }
            return $http.post('/api/reposiciones', obj).then(dataSuccess).catch(dataError);
        }
        function aprobarOrden(rep_id, fecha_estimada, comentario) {
            var obj = {
                reposicion_id: rep_id,
                fecha_entrega_estimada: fecha_estimada,
                comentario: comentario
            }
            return $http.post('/api/reposiciones/'+ rep_id +'/aprobar', obj).then(dataSuccess).catch(dataError);
        }
        function cancelarOrden(rep_id, causa, comentario) {
            var obj = {
                reposicion_id: rep_id,
                causa: causa,
                comentario: comentario
            }
            return $http.post('/api/reposiciones/' + rep_id + '/rechazar', obj).then(dataSuccess).catch(dataError);
        }
        function enviarOrden(rep_id, cam_id, comentario) {
            var obj = {
                reposicion_id: rep_id,
                camion_id: cam_id,
                comentario: comentario
            }
            return $http.post('/api/reposiciones/' + rep_id + '/enviar', obj).then(dataSuccess).catch(dataError);
        }
        function recibirOrden(rep_id, comentario) {
            var obj = {
                reposicion_id: rep_id,
                comentario: comentario
            }
            return $http.post('/api/reposiciones/' + rep_id + '/recepcion', obj).then(dataSuccess).catch(dataError);
        }

        function dataSuccess(result) {
            return result.data;
        }
        function dataError(e) {
            var errorMessage = 'Se ha producido un error'
            if (typeof e.data !== 'undefined')
                errorMessage = e.data.Message;
            console.log(errorMessage);
            return $q.reject(e);
        }
        
    }
})();