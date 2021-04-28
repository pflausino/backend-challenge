const axios = require('axios');
const path = 'http://localhost:8080'

module.exports = {

    async getCities() {
        
        const response = await axios.get(path + '/api/v1/cities')
        return response.data
    },
    async getStatistics(id) {
        
        const response = await axios.get(path + `/api/v1/city/${id}/statistics`)
        
        return response.data
    }

}