const { validationResult } = require('express-validator');

const Budget = require("../models/budget");


const SquareMetersService = require("../services/square-meters-service");


module.exports = {
    async get(req, res) {
        const errors = validationResult(req);
        if (!errors.isEmpty()) {
          return res.status(400).json({ errors: errors.array() });
        }
        //var cities = await SquareMetersService.getCities();

            // Access the provided 'page' and 'limt' query parameters
        let cityId = req.params.id
        let meters = req.query.meters;


        var statistics = await SquareMetersService.getStatistics(cityId).catch(
            err => {
                console.log(err);
                res.status(400).send("Bad Request - Invalid cityID");
                return;
            }
        );


        const budget = new Budget(
            statistics.totalProperties, 
            statistics.squareMeterAveragePriceValue, 
            statistics.cityName,
            meters
        )
        res.status(200).send(budget);

    }
}
