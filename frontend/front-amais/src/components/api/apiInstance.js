const axios = require('axios');

const axiosInstance = axios.create({
    baseURL: 'http://localhost:5285',
});

export default axiosInstance;