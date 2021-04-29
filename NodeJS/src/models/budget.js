const BudgetModel = class Budget{
    constructor(totalProperties, squareMeterAveragePrice, cityName, totalSquareMetters) {
        this.totalProperties = totalProperties;
        this.squareMeterAveragePrice = squareMeterAveragePrice;
        this.cityName = cityName;
        this.totalSquareMeters = totalSquareMetters;
        this.budgetSimulation = (this.totalSquareMetters * this.squareMeterAveragePrice).toFixed(2)
    }
}

module.exports = BudgetModel;