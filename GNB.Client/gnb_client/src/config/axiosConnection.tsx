import axios from "axios";

const axiosConnection = axios.create({
    baseURL: process.env.REACT_APP_API_CONNECTION,
});

export default axiosConnection;