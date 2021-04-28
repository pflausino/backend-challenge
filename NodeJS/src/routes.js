const express = require("express");
const routes = express.Router();
const { query, validationResult } = require('express-validator');

const BudgetsController = require("../src/controllers/budgets-controller");

routes.get(
    "/cities/:id/budgets",
    [
        query('meters')
            .isNumeric('Must be a number')
            .withMessage()
            .isLength({ min: 10, max: 10000 })
            .withMessage('Must be grater then 10 ane smaller tha 10000')
    ],
    BudgetsController.get)

module.exports = routes;

