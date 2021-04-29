const BudgetModel = class Budget{
    constructor(totalProperties, squareMeterAveragePrice, cityName, totalSquareMetters) {
        this.totalProperties = totalProperties;
        this.squareMeterAveragePrice = squareMeterAveragePrice;
        this.cityName = cityName;
        this.totalSquareMeters = totalSquareMetters;
        var totalprice = totalSquareMetters * squareMeterAveragePrice;
        this.budgetSimulation = "R$ "+totalprice.toFixed(2);
    }
}

module.exports = BudgetModel;