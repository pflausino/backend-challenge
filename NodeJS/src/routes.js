const express = require("express");
const routes = express.Router();
const { query } = require('express-validator');

const app = express();

app.use(express.json());

const BudgetsController = require("../src/controllers/budgets-controller");

/**
 * @swagger
 * /api/v1/cities/{id}/budgets:
 *    get:
 *      description: Simula o preço do Imovel com base na localização e na metragem em metros quadrados 
 *      responses:
 *          '200':
 *              description: Orçamento concluido
 *          '400':
 *              description: BadRequest requisiçao incorreta
 *    parameters:
 *      - name: id
 *        in: path
 *        description: Id da cidade para consulta
 *        required: true
 *        schema:
 *          type: string
 *          format: string
 *      - name: meters
 *        in: query
 *        description: total de metros quadrados
 *        required: true
 *        schema:
 *          type: number
 *          format: number
 */
routes.get(
    "/v1/cities/:id/budgets",
    [
        query('meters')
            .isNumeric()
            .withMessage('Must be a number')
            .isFloat({ min: 10, max: 10000 })
            .withMessage('Must be grater then 10 and smaller tha 10000')
    ],
    BudgetsController.get)

module.exports = routes;

