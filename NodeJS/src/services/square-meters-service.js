const axios = require('axios');
const path = process.env.MAIN_API // 'http://squaremetersvalueapi:80'

module.exports = {

    async getCities() {
        
        const response = await axios.get(path + '/api/v1/cities')
        return response.data
    },
    async getStatistics(id) {
        console.log("Aim HERE");
        console.log(path + `/api/v1/city/${id}/statistics`);
        
        const response = await axios.get(path + `/api/v1/city/${id}/statistics`)
        
        return response.data
    }

}